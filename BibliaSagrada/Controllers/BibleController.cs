using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliaSagrada.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliaSagrada.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BibleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BibleController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Bible/GetUserVercicles
        [HttpGet]
        public async Task<IActionResult> GetUserVercicles()
        {
            var id = (await _userManager.GetUserAsync(HttpContext.User))?.Id;
            var bibleUserDetail = await _context.BibleUsers.FirstOrDefaultAsync(_ => _.ApplicationUserId == id);
            var result =
                from _vercicles in _context.Vercicles
                join _charpters in _context.Charpters on _vercicles.CharpterId equals _charpters.Id
                join _books in _context.Books on _charpters.BookId equals _books.Id
                where _vercicles.Id >= bibleUserDetail.Vercicle &&
                _vercicles.Id < bibleUserDetail.Vercicle + bibleUserDetail.NumbersVercicle
                select new
                {
                    InLine = bibleUserDetail.Inline,
                    BookId = _books.Id,
                    BookName = _books.Name,
                    CharpterId = _charpters.Id,
                    CharpterNumber = _charpters.Number,
                    VercicleId = _vercicles.Id,
                    VercicleNumber = _vercicles.Number,
                    VercicleText = _vercicles.Text
                };
            return Ok(result);
        }

        // GET: api/Bible/GetPickOne
        [HttpGet]
        public async Task<IActionResult> GetPickOne()
        {
            var id = (await _userManager.GetUserAsync(HttpContext.User))?.Id;
            var bibleUserDetail = await _context.BibleUsers.FirstOrDefaultAsync(_ => _.ApplicationUserId == id);

            Random rnd = new Random();
            var _id = rnd.Next(1, 35437);
            var result = from _vercicles in _context.Vercicles
                         join _charpters in _context.Charpters on _vercicles.CharpterId equals _charpters.Id
                         join _books in _context.Books on _charpters.BookId equals _books.Id
                         where _vercicles.Id == _id
                         select new
                         {
                             BookId = _books.Id,
                             BookName = _books.Name,
                             CharpterId = _charpters.Id,
                             CharpterNumber = _charpters.Number,
                             VercicleId = _vercicles.Id,
                             VercicleNumber = _vercicles.Number,
                             VercicleText = _vercicles.Text
                         };
            return Ok(result);
        }

        // GET: api/Bible/GetUserDetail
        [HttpGet]
        public async Task<IActionResult> GetBibleUserDetail()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = (await _userManager.GetUserAsync(HttpContext.User))?.Id;
            var bibleUserDetail = await _context.BibleUsers.FindAsync(id);

            if (bibleUserDetail == null)
            {
                return NotFound();
            }

            return Ok(bibleUserDetail);
        }

        // POST: api/BibleUserDetails/PostChangeNumberVercicles
        [HttpPost("{NumberVercicles}")]
        public async Task<IActionResult> PostChangeNumberVercicles([FromRoute] int NumberVercicles)
        {
            var id = (await _userManager.GetUserAsync(HttpContext.User))?.Id;
            var bibleUserDetail = await _context.BibleUsers.FirstOrDefaultAsync(_ => _.ApplicationUserId == id);

            bibleUserDetail.NumbersVercicle = NumberVercicles;
            _context.Entry(bibleUserDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BibleUserDetailExists(bibleUserDetail.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BibleUserDetails/PostChangeInLine
        [HttpPost]
        public async Task<IActionResult> PostChangeInLine()
        {
            var id = (await _userManager.GetUserAsync(HttpContext.User))?.Id;
            var bibleUserDetail = await _context.BibleUsers.FirstOrDefaultAsync(_ => _.ApplicationUserId == id);

            bibleUserDetail.Inline = ! bibleUserDetail.Inline;
            _context.Entry(bibleUserDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BibleUserDetailExists(bibleUserDetail.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

            private bool BibleUserDetailExists(int id)
        {
            return _context.BibleUsers.Any(e => e.Id == id);
        }
    }
}