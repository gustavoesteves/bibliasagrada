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

        public string GetUserId()
        {
            return _userManager.GetUserId(User);
        }

        public Object ListUserVercicles()
        {
            var bibleUserDetail = _context.BibleUsers.FirstOrDefault(_ => _.ApplicationUserId == GetUserId());

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

            return result;
        }

        // GET: api/Bible/GetUserVercicles
        [HttpGet]
        public IActionResult GetUserVercicles()
        {
            return Ok(ListUserVercicles());
        }

        // POST: api/Bible/Previous
        [HttpGet("{PreviousNext}")]
        public async Task<IActionResult> GetPreviousNext([FromRoute] bool PreviousNext)
        {
            var bibleUserDetail = await _context.BibleUsers.FirstOrDefaultAsync(_ => _.ApplicationUserId == GetUserId());
            bibleUserDetail.Vercicle = PreviousNext ? bibleUserDetail.Vercicle + bibleUserDetail.NumbersVercicle
                : bibleUserDetail.Vercicle - bibleUserDetail.NumbersVercicle;
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
            return Ok(ListUserVercicles());
        }

        // GET: api/Bible/GetPickOne
        [HttpGet]
        public async Task<IActionResult> GetPickOne()
        {
            var bibleUserDetail = await _context.BibleUsers.FirstOrDefaultAsync(_ => _.ApplicationUserId == GetUserId());

            Random rnd = new Random();
            var _idResult = rnd.Next(1, 35437);
            var result = from _vercicles in _context.Vercicles
                         join _charpters in _context.Charpters on _vercicles.CharpterId equals _charpters.Id
                         join _books in _context.Books on _charpters.BookId equals _books.Id
                         where _vercicles.Id == _idResult
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

            var bibleUserDetail = await _context.BibleUsers.FindAsync(GetUserId());

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
            var bibleUserDetail = await _context.BibleUsers.FirstOrDefaultAsync(_ => _.ApplicationUserId == GetUserId());

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
            var bibleUserDetail = await _context.BibleUsers.FirstOrDefaultAsync(_ => _.ApplicationUserId == GetUserId());

            bibleUserDetail.Inline = !bibleUserDetail.Inline;
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