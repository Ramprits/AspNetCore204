using System;
using System.Threading.Tasks;
using AspNetCoreApplication.Helper;
using AspNetCoreApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApplication.Controllers {
    [Route ("api/newTrainings"), NoCache]
    public class NewTrainingController : Controller {
        private readonly AspNetCoreApplicationDbContext _context;

        public NewTrainingController (AspNetCoreApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetNewTrainings () {
            var getNewTrainings = await _context.NewTrainings.ToListAsync ();
            return Ok (getNewTrainings);
        }

        [HttpGet ("{Id}", Name = "GetNewTrainings")]
        public async Task<IActionResult> GetNewTrainings (Guid Id) {
            var getNewTraining = await _context.NewTrainings.FirstOrDefaultAsync (x => x.Id == Id);
            return Ok (getNewTraining);
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] NewTraining entity) {
            // if (entity.TechnologyId) {

            // }
            await _context.AddAsync (entity);
            await _context.SaveChangesAsync ();
            var newTraining = _context.NewTrainings.FirstOrDefaultAsync (x => x.Id == entity.Id);
            return Created ("GetNewTrainings", new { Id = newTraining.Id });
        }
    }
}