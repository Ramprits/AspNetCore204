using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApplication.Model;

namespace AspNetCoreApplication.Repository.Interface {
    public interface IContactRepository {
        Task<IEnumerable<Contact>> ContactsAsync ();
        Task<Contact> InsertContactAsync (Category Contact);
    }
}