using Assetwiz_Contact.Data;
using Assetwiz_Contact.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assetwiz_Contact.BusinessObjects
{
    public class ProductTransactionBusinessObject
    {
        public readonly AppDbContext _context;

        public ProductTransactionBusinessObject(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductTransactionViewModel>> GetAllProductTransactionsAsync()
        {
            return await _context.ProductTransaction.ToListAsync();
        }

        public async Task<ProductTransactionViewModel?> GetProductTransactionByIdAsync(long id)
        {
            return await _context.ProductTransaction.FindAsync(id);
        }

        public async Task<ProductTransactionViewModel> AddProductTransactionAsync(ProductTransactionViewModel productTransaction)
        {
            _context.ProductTransaction.Add(productTransaction);
            await _context.SaveChangesAsync();
            return productTransaction;
        }

        public async Task<ProductTransactionViewModel?> UpdateProductTransactionAsync(long id, ProductTransactionViewModel updatedProductTransaction)
        {
            var existing = await _context.ProductTransaction.FindAsync(id);
            if (existing == null) return null;

            existing.ProductID = updatedProductTransaction.ProductID;
            existing.ProductName = updatedProductTransaction.ProductName;
            existing.WorkFlowItemID = updatedProductTransaction.WorkFlowItemID;
            existing.LocationID = updatedProductTransaction.LocationID;
            existing.LocationName = updatedProductTransaction.LocationName;
            existing.WorkFlowItemName = updatedProductTransaction.WorkFlowItemName;
            existing.PreviousClosingStock = updatedProductTransaction.PreviousClosingStock;
            existing.PreviousClosingRate = updatedProductTransaction.PreviousClosingRate;
            existing.PreviousClosingValue = updatedProductTransaction.PreviousClosingValue;
            existing.Quantity = updatedProductTransaction.Quantity;
            existing.Rate = updatedProductTransaction.Rate;
            existing.Amount = updatedProductTransaction.Amount;
            existing.CurrentClosingStock = updatedProductTransaction.CurrentClosingStock;
            existing.CurrentClosingRate = updatedProductTransaction.CurrentClosingRate;
            existing.CurrentClosingValue = updatedProductTransaction.CurrentClosingValue;
            existing.OrderedPrice = updatedProductTransaction.OrderedPrice;
            existing.OrderItemPrice = updatedProductTransaction.OrderItemPrice;
            existing.ContactID = updatedProductTransaction.ContactID;
            existing.ContactName = updatedProductTransaction.ContactName;
            existing.ContactPersonID = updatedProductTransaction.ContactPersonID;
            existing.ContactPersonName = updatedProductTransaction.ContactPersonName;
            existing.WorkFlowStatusCode = updatedProductTransaction.WorkFlowStatusCode;
            existing.WorkFlowStatusID = updatedProductTransaction.WorkFlowStatusID;
            existing.ProductCategoryGroupID = updatedProductTransaction.ProductCategoryGroupID;
            existing.ProductSubCategoryGroupID = updatedProductTransaction.ProductSubCategoryGroupID;
            existing.OrderDate = DateTime.UtcNow;
            existing.InvoiceDate = DateTime.UtcNow;
            existing.DCNumber = updatedProductTransaction.DCNumber;
            existing.InvoiceNumber = updatedProductTransaction.InvoiceNumber;
            existing.ExpireDate = DateTime.UtcNow;
            existing.Tax1IsEnabled = updatedProductTransaction.Tax1IsEnabled;
            existing.Tax1Name = updatedProductTransaction.Tax1Name;
            existing.Tax1Rate = updatedProductTransaction.Tax1Rate;
            existing.Tax1Amount = updatedProductTransaction.Tax1Amount;
            existing.Tax2IsEnabled = updatedProductTransaction.Tax2IsEnabled;
            existing.Tax2Name = updatedProductTransaction.Tax2Name;
            existing.Tax2Rate = updatedProductTransaction.Tax2Rate;
            existing.Tax2Amount = updatedProductTransaction.Tax2Amount;
            existing.Tax3IsEnabled = updatedProductTransaction.Tax3IsEnabled;
            existing.Tax3Name = updatedProductTransaction.Tax3Name;
            existing.Tax3Rate = updatedProductTransaction.Tax3Rate;
            existing.Tax3Amount = updatedProductTransaction.Tax3Amount;
            existing.OrderItemRemark = updatedProductTransaction.OrderItemRemark;
            existing.OrderItemGrossAmount = updatedProductTransaction.OrderItemGrossAmount;
            existing.OrderItemDiscountAmount = updatedProductTransaction.OrderItemDiscountAmount;
            existing.OrderItemChargeAmount = updatedProductTransaction.OrderItemChargeAmount;
            existing.OrderItemSubTotalAmount = updatedProductTransaction.OrderItemSubTotalAmount;
            existing.OrderItemTaxAmount = updatedProductTransaction.OrderItemTaxAmount;
            existing.OrderItemNetTotalAmount = updatedProductTransaction.OrderItemNetTotalAmount;
            existing.ModifiedBy = updatedProductTransaction.ModifiedBy;
            existing.ModifiedByName = updatedProductTransaction.ModifiedByName;
            existing.ModifiedOn = DateTime.UtcNow;
            existing.OrderType = updatedProductTransaction.OrderType;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteProductTransactionAsync(long id)
        {
            var existing = await _context.ProductTransaction.FindAsync(id);
            if (existing == null) return false;
            _context.ProductTransaction.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
