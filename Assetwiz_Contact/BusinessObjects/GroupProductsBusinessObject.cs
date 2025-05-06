//using Assetwiz_Contact.Data;
//using Assetwiz_Contact.ViewModels;
//using Microsoft.EntityFrameworkCore;

//namespace Assetwiz_Contact.BusinessObjects
//{
//    public class GroupProductsBusinessObject
//    {
//        private readonly AppDbContext _context;

//        public GroupProductsBusinessObject(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<GroupProductsViewModel>> GetAllGroupProductsAsync()
//        {
//            return await _context.GroupProducts.ToListAsync();
//        }

//        public async Task<GroupProductsViewModel?> GetGroupProductByIdAsync(long id)
//        {
//            return await _context.GroupProducts.FindAsync(id);
//        }

//        public async Task<GroupProductsViewModel> AddGroupProductAsync(GroupProductsViewModel groupProduct)
//        {
//            _context.GroupProducts.Add(groupProduct);
//            await _context.SaveChangesAsync();
//            return groupProduct;
//        }

//        public async Task<GroupProductsViewModel?> UpdateGroupProductAsync(long id, GroupProductsViewModel updatedProduct)
//        {
//            var existing = await _context.GroupProducts.FindAsync(id);
//            if (existing == null) return null;

//            existing.ProductID = updatedProduct.ProductID;
//            existing.WorkFlowItemID = updatedProduct.WorkFlowItemID;
//            existing.LocationID = updatedProduct.LocationID;
//            existing.LocationName = updatedProduct.LocationName;
//            existing.IsEnabled = updatedProduct.IsEnabled;
//            existing.CreatedOn = updatedProduct.CreatedOn;
//            existing.CreatedBy = updatedProduct.CreatedBy;
//            existing.CreatedByName = updatedProduct.CreatedByName;

//            await _context.SaveChangesAsync();
//            return updatedProduct;
//        }

//        public async Task<bool> DeleteGroupProductAsync(long id)
//        {
//            var product = await _context.GroupProducts.FindAsync(id);
//            if (product == null) return false;
//            _context.GroupProducts.Remove(product);
//            await _context.SaveChangesAsync();
//            return true;
//        }
//    }
//}
