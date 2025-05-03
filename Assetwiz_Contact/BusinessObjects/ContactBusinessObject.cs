using Assetwiz_Contact.Data;
using Assetwiz_Contact.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assetwiz_Contact.BusinessObjects
{
    public class ContactBusinessObject
    {
        private readonly AppDbContext _context;

        public ContactBusinessObject(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContactViewModel>> GetAllContactsAsync()
        {
            return await _context.Contact.ToListAsync();
        }

        public async Task<ContactViewModel?> GetContactByIdAsync(long id)
        {
            return await _context.Contact.FindAsync(id);
        }

        public async Task<ContactViewModel> AddContactAsync(ContactViewModel contact)
        {
            _context.Contact.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<ContactViewModel?> UpdateContactAsync(long id, ContactViewModel updatedContact)
        {
            var existing = await _context.Contact.FindAsync(id);
            if (existing == null) return null;
            existing.ContactTypeID = updatedContact.ContactTypeID;
            existing.ContactTypeName = updatedContact.ContactTypeName;
            existing.LocationID = updatedContact.LocationID;
            existing.LocationName = updatedContact.LocationName;
            existing.CompanyName = updatedContact.CompanyName;
            existing.Email = updatedContact.Email;
            existing.Mobile = updatedContact.Mobile;
            existing.Address = updatedContact.Address;
            existing.City = updatedContact.City;
            existing.State = updatedContact.State;
            existing.ZipCode = updatedContact.ZipCode;
            existing.StateCode = updatedContact.StateCode;
            existing.Country = updatedContact.Country;
            existing.Description = updatedContact.Description;
            existing.IsEnabled = updatedContact.IsEnabled;
            existing.PanNo = updatedContact.PanNo;
            existing.GSTIN = updatedContact.GSTIN;
            existing.CIN = updatedContact.CIN;
            existing.PaymentTerms = updatedContact.PaymentTerms;
            existing.RoundingPrecision = updatedContact.RoundingPrecision;
            existing.ExternalReferenceID = updatedContact.ExternalReferenceID;
            existing.OtherInformation = updatedContact.OtherInformation;
            existing.ModifiedOn = DateTime.UtcNow;
            existing.ModifiedBy = updatedContact.ModifiedBy;
            existing.ModifiedByName = updatedContact.ModifiedByName;

            await _context.SaveChangesAsync();
            return updatedContact;
        }


        public async Task<bool> DeleteContactAsync(long id)
        {
            var contact = await _context.Contact.FindAsync(id);
            if (contact == null) return false;
            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
