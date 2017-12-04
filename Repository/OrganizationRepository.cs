using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApplication.Model;
using AspNetCoreApplication.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApplication.Repository {
    public class OrganizationRepository : IOrganizationRepository {

        private readonly AspNetCoreApplicationDbContext _ctx;

        public OrganizationRepository (AspNetCoreApplicationDbContext ctx) {
            _ctx = ctx;
        }
        public async Task<IEnumerable<Organization>> OrganizationsAsync () {
            return await _ctx.Organizations.ToListAsync ();
        }
    }
}