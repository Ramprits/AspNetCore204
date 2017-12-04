using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApplication.ModelDto;
using AspNetCoreApplication.Repository.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApplication.Controllers {
    [Route ("api/business")]
    public class BusinessController : Controller {
        private readonly IBusinessRepository _repository;
        private readonly IMapper _mapper;
        public BusinessController (IBusinessRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBusiness () {
            var GetBusiness = await _repository.BusinessUnitsAsync ();
            return Ok (_mapper.Map<IEnumerable<BusinessUnitVm>> (GetBusiness));
        }
    }
}