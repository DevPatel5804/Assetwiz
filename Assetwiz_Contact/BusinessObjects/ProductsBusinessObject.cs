using Assetwiz_Contact.Data;
using Assetwiz_Contact.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assetwiz_Contact.BusinessObjects
{
    public class ProductsBusinessObject
    {
        private readonly AppDbContext _context;

        public ProductsBusinessObject(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductsViewModel>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductsViewModel?> GetProductByIdAsync(long id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<ProductsViewModel> AddProductAsync(ProductsViewModel product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<ProductsViewModel?> UpdateProductAsync(long id, ProductsViewModel updatedProduct)
        {
            var existing = await _context.Products.FindAsync(id);
            if (existing == null) return null;

            existing.OrganisationID = updatedProduct.OrganisationID;
            existing.ProductName = updatedProduct.ProductName;
            existing.ProductType = updatedProduct.ProductType;
            existing.Description = updatedProduct.Description;
            existing.Unit = updatedProduct.Unit;
            existing.UnitType = updatedProduct.UnitType;
            existing.HSN_SAC = updatedProduct.HSN_SAC;
            existing.IsEnabled = updatedProduct.IsEnabled;
            existing.SellingPrice = updatedProduct.SellingPrice;
            existing.PurchasePrice = updatedProduct.PurchasePrice;
            existing.IsStockMaintainEnabled = updatedProduct.IsStockMaintainEnabled;
            existing.MinOrderQuantity = updatedProduct.MinOrderQuantity;
            existing.MaximumStock = updatedProduct.MaximumStock;
            existing.ReorderStock = updatedProduct.ReorderStock;
            existing.LocationID = updatedProduct.LocationID;
            existing.LocationName = updatedProduct.LocationName;
            existing.ModifiedOn = DateTime.UtcNow;
            existing.ModifiedBy = updatedProduct.ModifiedBy;
            existing.ModifiedByName = updatedProduct.ModifiedByName;
            existing.OtherInformation = updatedProduct.OtherInformation;
            existing.EndOfLife = updatedProduct.EndOfLife;
            existing.EndOfWarranty = updatedProduct.EndOfWarranty;
            existing.ProductImage = updatedProduct.ProductImage;
            existing.CurrentStock = updatedProduct.CurrentStock;
            existing.Capacity = updatedProduct.Capacity;
            existing.MakeModel = updatedProduct.MakeModel;
            existing.MinimumStock = updatedProduct.MinimumStock;
            existing.SerialNo = updatedProduct.SerialNo;
            existing.Zone = updatedProduct.Zone;
            existing.GroupID = updatedProduct.GroupID;
            existing.GroupName = updatedProduct.GroupName;
            existing.SubGroupID = updatedProduct.SubGroupID;
            existing.SubGroupName = updatedProduct.SubGroupName;
            existing.WorkFlowID = updatedProduct.WorkFlowID;

            await _context.SaveChangesAsync();
            return updatedProduct;
        }

        public async Task<bool> DeleteProductAsync(long id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
