using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApplication.Model;
using AspNetCoreApplication.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApplication.Repository {
    public class CategoryRepository : ICategoryRepository {
        private readonly AspNetCoreApplicationDbContext _ctx;

        public CategoryRepository (AspNetCoreApplicationDbContext ctx) {
            _ctx = ctx;
        }
        public Task<Category> CategoryAsync (Guid CategoryId) {
            throw new NotImplementedException ();
        }

        public Task<bool> CategoryExistAsync (Guid CategoryId) {
            throw new NotImplementedException ();
        }

        public async Task<IEnumerable<Category>> CategorysAsync () {
            return await _ctx.Category.ToListAsync ();
        }

        public Task<bool> DeleteCategoryAsync (Guid CategoryId) {
            throw new NotImplementedException ();
        }

        public Task<Category> InsertCategoryAsync (Category Category) {
            throw new NotImplementedException ();
        }

        public Task<bool> SaveCategoryAsync () {
            throw new NotImplementedException ();
        }

        public Task<bool> UpdateCategoryAsync (Guid CategoryId) {
            throw new NotImplementedException ();
        }
    }
}