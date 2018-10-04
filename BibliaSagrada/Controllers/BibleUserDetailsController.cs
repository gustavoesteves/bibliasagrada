using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliaSagrada.Models;
using BibliaSagrada.Models.BibliaModels;

namespace BibliaSagrada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibleUserDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BibleUserDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BibleUserDetails
        [HttpGet]
        public IEnumerable<BibleUserDetail> GetBibleUsers()
        {
            return _context.BibleUsers;
        }

        // GET: api/BibleUserDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBibleUserDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bibleUserDetail = await _context.BibleUsers.FindAsync(id);

            if (bibleUserDetail == null)
            {
                return NotFound();
            }

            return Ok(bibleUserDetail);
        }

        // PUT: api/BibleUserDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBibleUserDetail([FromRoute] int id, [FromBody] BibleUserDetail bibleUserDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bibleUserDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(bibleUserDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BibleUserDetailExists(id))
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

        // POST: api/BibleUserDetails
        [HttpPost]
        public async Task<IActionResult> PostBibleUserDetail([FromBody] BibleUserDetail bibleUserDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BibleUsers.Add(bibleUserDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBibleUserDetail", new { id = bibleUserDetail.Id }, bibleUserDetail);
        }

        // DELETE: api/BibleUserDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBibleUserDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bibleUserDetail = await _context.BibleUsers.FindAsync(id);
            if (bibleUserDetail == null)
            {
                return NotFound();
            }

            _context.BibleUsers.Remove(bibleUserDetail);
            await _context.SaveChangesAsync();

            return Ok(bibleUserDetail);
        }

        private bool BibleUserDetailExists(int id)
        {
            return _context.BibleUsers.Any(e => e.Id == id);
        }
    }
}