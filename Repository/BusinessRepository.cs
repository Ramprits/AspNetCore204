using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApplication.Model;
using AspNetCoreApplication.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApplication.Repository {
    public class BusinessRepository : IBusinessRepository {
        private readonly AspNetCoreApplicationDbContext _ctx;

        public BusinessRepository (AspNetCoreApplicationDbContext ctx) {
            _ctx = ctx;
        }
        public async Task<IEnumerable<BusinessUnit>> BusinessUnitsAsync () {
            return await _ctx.BusinessUnit.ToListAsync ();
        }
    }
}