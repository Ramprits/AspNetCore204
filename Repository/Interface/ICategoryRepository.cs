using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApplication.Model;

namespace AspNetCoreApplication.Repository.Interface {
    public interface ICategoryRepository {
        Task<IEnumerable<Category>> CategorysAsync ();
        Task<Category> CategoryAsync (Guid CategoryId);
        Task<Category> InsertCategoryAsync (Category Category);
        Task<bool> UpdateCategoryAsync (Guid CategoryId);
        Task<bool> DeleteCategoryAsync (Guid CategoryId);
        Task<bool> CategoryExistAsync (Guid CategoryId);
        Task<bool> SaveCategoryAsync ();
    }
}