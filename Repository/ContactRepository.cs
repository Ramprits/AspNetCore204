using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreApplication.Model;
using AspNetCoreApplication.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AspNetCoreApplication.Repository {
    public class ContactRepository : IContactRepository {
        private readonly AspNetCoreApplicationDbContext _context;
        private readonly ILogger _loggerFactory;

        public ContactRepository (AspNetCoreApplicationDbContext context, ILoggerFactory loggerFactory) {
            _context = context;
            _loggerFactory = loggerFactory.CreateLogger (typeof (ContactRepository));
        }
        public async Task<IEnumerable<Contact>> ContactsAsync () {
            return await _context.Contact.ToListAsync ();
        }

        public async Task<Contact> ContactsAsync (Guid contactId) {
            return await _context.Contact.FirstOrDefaultAsync (c => c.ContactId == contactId);
        }

        public async Task<Contact> InsertContactAsync (Contact Contact) {
            Contact.ContactId = Guid.NewGuid ();
            await _context.AddAsync (Contact);
            try {
                await _context.SaveChangesAsync ();
            } catch (Exception ex) {

                _loggerFactory.LogInformation ($"{ex.Message}");
            }
            return Contact;
        }

        public async Task<bool> SaveContactAsync () {
            return await _context.SaveChangesAsync () >= 0;
        }
    }
}