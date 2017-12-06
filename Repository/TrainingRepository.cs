using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreApplication.Model;
using AspNetCoreApplication.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApplication.Repository {
    public class TrainingRepository : ITrainingRepository {
        private readonly AspNetCoreApplicationDbContext _ctx;

        public TrainingRepository (AspNetCoreApplicationDbContext ctx) {
            _ctx = ctx;
        }
        public async Task<bool> DeleteTrainingAsync (Guid TrainingId) {
            var deleteCampaign = await _ctx.Trainings.FirstOrDefaultAsync (c => c.TrainingId == TrainingId);
            _ctx.Remove (deleteCampaign);
            try {
                return await _ctx.SaveChangesAsync () > 0 ? true : false;
            } catch (System.Exception ex) {

                throw new Exception ($"{ex.Message}");
            }
        }

        public async Task<Training> InsertTrainingAsync (Training Training) {
            Training.TrainingId = Guid.NewGuid ();
            await _ctx.AddAsync (Training);
            try {
                await _ctx.SaveChangesAsync ();
            } catch (Exception ex) {

                throw new Exception ($"{ex.Message}");
            }
            return Training;
        }

        public async Task<bool> SaveTrainingAsync () {
            return await _ctx.SaveChangesAsync () >= 0;
        }

        public async Task<Training> TrainingAsync (Guid TrainingId) {
            return await _ctx.Trainings.FirstOrDefaultAsync (t => t.TrainingId == TrainingId);
        }

        public IQueryable<Training> TrainingByCategoryAsync (Guid CategoryId) {
            var get = _ctx.Trainings.Where (x => x.CategoryId == CategoryId);
            return get;
        }

        public async Task<bool> TrainingExistAsync (Guid TrainingId) {
            return await _ctx.Trainings.AnyAsync (t => t.TrainingId == TrainingId);
        }

        public async Task<IEnumerable<Training>> TrainingsAsync () {
            return await _ctx.Trainings.Include (c => c.Category)
                .Include (b => b.BusinessUnit).Include (m => m.Modality).ToListAsync ();
        }

        public Task<bool> UpdateTrainingAsync (Guid TrainingId) {
            throw new NotImplementedException ();
        }
    }
}