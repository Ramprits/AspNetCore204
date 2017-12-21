using System;
using System.Threading.Tasks;
using AspNetCoreApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApplication.Controllers {
    [Route ("api/technologies")]
    public class TechnologiesController : Controller {
        private readonly AspNetCoreApplicationDbContext _context;

        public TechnologiesController (AspNetCoreApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTechnologies () {
            var getTechnologies = await _context.Technologies.ToListAsync ();
            return Ok (getTechnologies);
        }

        [HttpGet ("{Id}", Name = "GetTechnologies")]
        public async Task<IActionResult> GetTechnologies (Guid Id) {
            var getTechnologies = await _context.Technologies.FirstOrDefaultAsync (c => c.Id == Id);
            return Ok (getTechnologies);
        }

        [HttpPost]
        public async Task<IActionResult> AddTechnologies ([FromBody] Technologies entity) {
            await _context.AddAsync (entity);
            await _context.SaveChangesAsync ();
            var newCreatedTech = _context.Technologies.FirstOrDefaultAsync (c => c.Id == entity.Id);
            return Created ("GetTechnologies", new { Id = newCreatedTech.Id });
        }
    }
}