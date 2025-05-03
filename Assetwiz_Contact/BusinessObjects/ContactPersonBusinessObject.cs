using Assetwiz_Contact.Data;
using Assetwiz_Contact.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assetwiz_Contact.BusinessObjects
{
    public class ContactPersonBusinessObject
    {
        private readonly AppDbContext _context;
        public ContactPersonBusinessObject(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<List<ContactPersonViewModel>> GetAllContactPersonsAsync()
        {
            return await _context.ContactPerson.ToListAsync();
        }

        public async Task<ContactPersonViewModel?> GetContactPersonByIdAsync(long id)
        {
            return await _context.ContactPerson.FindAsync(id);
        }

        public async Task<ContactPersonViewModel> AddContactPersonAsync(ContactPersonViewModel contactPerson)
        {
            _context.ContactPerson.Add(contactPerson);
            await _context.SaveChangesAsync();
            return contactPerson;
        }

        public async Task<ContactPersonViewModel> UpdateContactPersonAsync(long id, ContactPersonViewModel updatedContactPerson)
        {
            var existing = await _context.ContactPerson.FindAsync(id);
            if (existing == null) return null;

            existing.PersonName = updatedContactPerson.PersonName;
            existing.Email = updatedContactPerson.Email;
            existing.Mobile = updatedContactPerson.Mobile;
            existing.Designation = updatedContactPerson.Designation;
            existing.Department = updatedContactPerson.Department;
            existing.IsEnabled = updatedContactPerson.IsEnabled;
            existing.Address = updatedContactPerson.Address;
            existing.City = updatedContactPerson.City;
            existing.State = updatedContactPerson.State;
            existing.ZipCode = updatedContactPerson.ZipCode;
            existing.Country = updatedContactPerson.Country;
            existing.LocationID = updatedContactPerson.LocationID;
            existing.LocationName = updatedContactPerson.LocationName;
            existing.ModifiedOn = updatedContactPerson.ModifiedOn;
            existing.ModifiedBy = updatedContactPerson.ModifiedBy;
            existing.ModifiedByName = updatedContactPerson.ModifiedByName;

            await _context.SaveChangesAsync();

            return existing;

        }

        public async Task<bool> DeleteContactPersonAsync(long id)
        {
            var contactPerson = await _context.ContactPerson.FindAsync(id);
            if (contactPerson == null) return false;
            _context.ContactPerson.Remove(contactPerson);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
