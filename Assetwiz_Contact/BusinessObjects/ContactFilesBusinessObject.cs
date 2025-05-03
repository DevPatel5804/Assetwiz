using Assetwiz_Contact.Data;
using Assetwiz_Contact.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assetwiz_Contact.BusinessObjects
{
    public class ContactFilesBusinessObject
    {
        private readonly AppDbContext _context;
        public ContactFilesBusinessObject(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContactFilesViewModel>> GetAllContactFilesAsync()
        {
            return await _context.ContactFiles.ToListAsync();
        }

        public async Task<ContactFilesViewModel?> GetContactFileByIdAsync(long id)
        {
            return await _context.ContactFiles.FindAsync(id);
        }

        public async Task<ContactFilesViewModel> AddContactFileAsync(ContactFilesViewModel contactFile)
        {
            _context.ContactFiles.Add(contactFile);
            await _context.SaveChangesAsync();
            return contactFile;
        }

        public async Task<ContactFilesViewModel?> UpdateContactFileAsync(long id, ContactFilesViewModel updatedContactFile)
        {
            var existing = await _context.ContactFiles.FindAsync(id);
            if (existing == null) return null;
            existing.ContactPersonID = updatedContactFile.ContactPersonID;
            existing.ContactFileName = updatedContactFile.ContactFileName;
            existing.ContactFilePath = updatedContactFile.ContactFilePath;
            existing.ContactFileExtention = updatedContactFile.ContactFileExtention;
            existing.Description = updatedContactFile.Description;
            existing.StorageProviderName = updatedContactFile.StorageProviderName;
            existing.LocationID = updatedContactFile.LocationID;
            existing.LocationName = updatedContactFile.LocationName;
            existing.AssignedUserTo = updatedContactFile.AssignedUserTo;
            existing.AssignedUserName = updatedContactFile.AssignedUserName;
            existing.AssignedUserEmail = updatedContactFile.AssignedUserEmail;
            existing.IsDeleted = updatedContactFile.IsDeleted;
            existing.ModifiedOn = DateTime.UtcNow;
            existing.ModifiedBy = updatedContactFile.ModifiedBy;
            existing.ModifiedByName = updatedContactFile.ModifiedByName;

            await _context.SaveChangesAsync();
            return existing;
        }
        
        public async Task<bool> DeleteContactFileAsync(long id)
        {
            var contactFile = await _context.ContactFiles.FindAsync(id);
            if (contactFile == null) return false;
            _context.ContactFiles.Remove(contactFile);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
