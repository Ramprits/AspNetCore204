using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApplication.Model;
using AspNetCoreApplication.ModelDto;
using AspNetCoreApplication.Repository.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApplication.Controllers {

    [Route ("api/Categories")]
    public class CategoriesController : Controller {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly AspNetCoreApplicationDbContext _ctx;

        public CategoriesController (ICategoryRepository repository, IMapper mapper, AspNetCoreApplicationDbContext ctx) {
            _repository = repository;
            _mapper = mapper;
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories () {
            var getCategories = await _ctx.Category.Include (t => t.Trainings).ToListAsync ();
            return Ok (getCategories);
        }

        [HttpGet ("{CategoryId}")]
        public async Task<IActionResult> GetCategoryWithTraining (Guid CategoryId) {
            if (CategoryId == null) {
                return NotFound ($"Category with {CategoryId} not found !");
            }
            var getCategoryWithTraining = await _repository.GetCategoryWithTrainingAsync (CategoryId);
            return Ok (getCategoryWithTraining);
        }
    }
}