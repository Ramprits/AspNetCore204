using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApplication.Model;

namespace AspNetCoreApplication.Repository.Interface {
    public interface IOrganizationRepository {
        Task<IEnumerable<Organization>> OrganizationsAsync ();
    }
}