using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApplication.Model;
using AspNetCoreApplication.ModelDto;
using AspNetCoreApplication.Repository.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApplication.Controllers {
    [Route ("api/trainings")]
    public class TrainingController : Controller {
        private readonly ITrainingRepository _repository;
        private readonly IMapper _mapper;

        public TrainingController (ITrainingRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrainings () {
            var getTrainins = await _repository.TrainingsAsync ();
            return Ok (_mapper.Map<IEnumerable<TrainingVm>> (getTrainins));
        }

        [HttpGet ("{trainingId}", Name = "GetTraining")]
        public async Task<IActionResult> GetTrainings (Guid trainingId) {
            var getTrainins = await _repository.TrainingAsync (trainingId);
            return Ok (_mapper.Map<TrainingVm> (getTrainins));
        }

        [HttpGet ("trainingbyCategory/{categoryId}")]
        public IActionResult Get (Guid categoryId) {
            var getTrainingByCategory = _repository.TrainingByCategoryAsync (categoryId);
            if (getTrainingByCategory == null) {
                return NotFound ($"category with {categoryId} not found?");
            }
            return Ok (getTrainingByCategory);
        }

        [HttpPost]
        public async Task<IActionResult> PostTraining ([FromBody] CreateTraining AddTraining) {
            var training = _mapper.Map<Training> (AddTraining);
            await _repository.InsertTrainingAsync (training);
            if (!await _repository.SaveTrainingAsync ()) {
                return BadRequest ($"Unable to create new Traing");
            }
            return Created ("GetTraining", null);
        }
        protected override void Dispose (bool disposing) {
            _repository.Dispose ();
            base.Dispose (disposing);
        }
    }
}