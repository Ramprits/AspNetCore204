using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApplication.ModelDto;
using AspNetCoreApplication.Repository.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApplication.Controllers {
    [Route ("api/modalities")]
    public class ModalityController : Controller {
        private readonly IModalityRepository _repository;
        private readonly IMapper _mapper;
        public ModalityController (IModalityRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetModality () {
            var GetModalities = await _repository.ModalitiesAsync ();
            return Ok (_mapper.Map<IEnumerable<ModalityVm>> (GetModalities));
        }
    }

}