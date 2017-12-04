using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApplication.ModelDto;
using AspNetCoreApplication.Repository.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApplication.Controllers {
    [Route ("api/organizations")]
    public class OrganizationController : Controller {
        private readonly IOrganizationRepository _repository;
        private readonly IMapper _mapper;

        public OrganizationController (IOrganizationRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get () {
            var GetOrganizations = await _repository.OrganizationsAsync ();
            return Ok (_mapper.Map<IEnumerable<OrganizationVm>> (GetOrganizations));
        }
    }
}