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
    public class VerciclesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VerciclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Vercicles
        [HttpGet]
        public IEnumerable<Vercicle> GetVercicles()
        {
            return _context.Vercicles;
        }

        // GET: api/Vercicles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVercicle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vercicle = await _context.Vercicles.FindAsync(id);

            if (vercicle == null)
            {
                return NotFound();
            }

            return Ok(vercicle);
        }

        // GET: api/Vercicles/GetBibleUser
        [HttpGet]
        public async Task<IActionResult> GetBibleUser()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // var vercicle = await _context.Vercicles.FindAsync(id);

            return Ok();
        }

        private bool VercicleExists(int id)
        {
            return _context.Vercicles.Any(e => e.Id == id);
        }
    }
}