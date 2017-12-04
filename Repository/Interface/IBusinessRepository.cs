using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApplication.Model;

namespace AspNetCoreApplication.Repository.Interface {
    public interface IBusinessRepository {
        Task<IEnumerable<BusinessUnit>> BusinessUnitsAsync ();
    }
}