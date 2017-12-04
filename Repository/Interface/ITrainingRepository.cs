using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApplication.Model;

namespace AspNetCoreApplication.Repository.Interface {
    public interface ITrainingRepository {
        Task<IEnumerable<Training>> TrainingsAsync ();
        Task<Training> TrainingAsync (Guid TrainingId);
        Task<Training> InsertTrainingAsync (Training Training);
        Task<bool> UpdateTrainingAsync (Guid TrainingId);
        Task<bool> DeleteTrainingAsync (Guid TrainingId);
        Task<bool> TrainingExistAsync (Guid TrainingId);
        Task<bool> SaveTrainingAsync ();
    }
}