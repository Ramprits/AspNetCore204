using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApplication.Model;
using AspNetCoreApplication.ModelDto;
using AspNetCoreApplication.Repository.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApplication.Controllers {
    [Route ("api/Categories")]
    public class CategoriesController : Controller {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoriesController (ICategoryRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories () {
            var getCategories = await _repository.CategorysAsync ();
            return Ok (_mapper.Map<IEnumerable<CategoriesVm>> (getCategories));
        }
    }
}