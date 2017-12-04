using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApplication.Model;
using AspNetCoreApplication.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApplication.Repository {
    public class ModalityRepository : IModalityRepository {
        private readonly AspNetCoreApplicationDbContext _ctx;

        public ModalityRepository (AspNetCoreApplicationDbContext ctx) {
            _ctx = ctx;
        }
        public async Task<IEnumerable<Modality>> ModalitiesAsync () {
            return await _ctx.Modalities.ToListAsync ();
        }
    }
}