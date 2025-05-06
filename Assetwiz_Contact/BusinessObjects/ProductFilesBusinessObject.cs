using Assetwiz_Contact.Data;
using Assetwiz_Contact.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assetwiz_Contact.BusinessObjects
{
	public class ProductFilesBusinessObject
	{
		private readonly AppDbContext _context;

		public ProductFilesBusinessObject(AppDbContext context)
		{
			_context = context;
		}

		public async Task<List<ProductFilesViewModel>> GetAllProductFilesAsync()
		{
			return await _context.ProductFiles.ToListAsync();
		}

		public async Task<ProductFilesViewModel?> GetProductFileByIdAsync(long id)
		{
			return await _context.ProductFiles.FindAsync(id);
		}

		public async Task<ProductFilesViewModel> AddProductFileAsync(ProductFilesViewModel productFile)
		{
			_context.ProductFiles.Add(productFile);
			await _context.SaveChangesAsync();
			return productFile;
		}

		public async Task<ProductFilesViewModel?> UpdateProductFileAsync(long id, ProductFilesViewModel updatedFile)
		{
			var existing = await _context.ProductFiles.FindAsync(id);
			if (existing == null) return null;

			existing.ProductID = updatedFile.ProductID;
			existing.ProductName = updatedFile.ProductName;
			existing.ProductFileName = updatedFile.ProductFileName;
			existing.ProductFileExtention = updatedFile.ProductFileExtention;
			existing.Description = updatedFile.Description;
			existing.StorageProviderName = updatedFile.StorageProviderName;
			existing.ContactID = updatedFile.ContactID;
			existing.LocationID = updatedFile.LocationID;
			existing.LocationName = updatedFile.LocationName;
			existing.AssignedUserTo = updatedFile.AssignedUserTo;
			existing.AssignedUserName = updatedFile.AssignedUserName;
			existing.AssignedUserEmail = updatedFile.AssignedUserEmail;
			existing.IsDeleted = updatedFile.IsDeleted;
			existing.ModifiedOn = DateTime.UtcNow;
			existing.ModifiedBy = updatedFile.ModifiedBy;
			existing.ModifiedByName = updatedFile.ModifiedByName;
			

			await _context.SaveChangesAsync();
			return updatedFile;
		}

		public async Task<bool> DeleteProductFileAsync(long id)
		{
			var file = await _context.ProductFiles.FindAsync(id);
			if (file == null) return false;
			_context.ProductFiles.Remove(file);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
