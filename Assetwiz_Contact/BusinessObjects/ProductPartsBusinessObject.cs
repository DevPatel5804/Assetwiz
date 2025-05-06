using Assetwiz_Contact.Data;
using Assetwiz_Contact.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assetwiz_Contact.BusinessObjects
{
    public class ProductPartsBusinessObject
    {
        private readonly AppDbContext _context;

        public ProductPartsBusinessObject(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductPartsViewModel>> GetAllProductPartsAsync()
        {
            return await _context.ProductParts.ToListAsync();
        }

        public async Task<ProductPartsViewModel?> GetProductPartByIdAsync(long id)
        {
            return await _context.ProductParts.FindAsync(id);
        }

        public async Task<ProductPartsViewModel> AddProductPartAsync(ProductPartsViewModel part)
        {
            _context.ProductParts.Add(part);
            await _context.SaveChangesAsync();
            return part;
        }

        public async Task<ProductPartsViewModel?> UpdateProductPartAsync(long id, ProductPartsViewModel updatedPart)
        {
            var existing = await _context.ProductParts.FindAsync(id);
            if (existing == null) return null;

            existing.ProductPartsID = updatedPart.ProductPartsID;
            existing.ProductID = updatedPart.ProductID;
            existing.PartID = updatedPart.PartID;
            existing.WorkFlowItemID = updatedPart.WorkFlowItemID;
            existing.WorkFlowItemName = updatedPart.WorkFlowItemName;
            existing.LocationID = updatedPart.LocationID;
            existing.LocationName = updatedPart.LocationName;
            existing.PartsQuantity = updatedPart.PartsQuantity;
            existing.PartsPrice = updatedPart.PartsPrice;
            existing.IsEnabled = updatedPart.IsEnabled;
            existing.CreatedOn = updatedPart.CreatedOn;
            existing.CreatedBy = updatedPart.CreatedBy;
            existing.CreatedByName = updatedPart.CreatedByName;

            await _context.SaveChangesAsync();
            return updatedPart;
        }

        public async Task<bool> DeleteProductPartAsync(long id)
        {
            var part = await _context.ProductParts.FindAsync(id);
            if (part == null) return false;
            _context.ProductParts.Remove(part);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
