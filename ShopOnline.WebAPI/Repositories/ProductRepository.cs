using Microsoft.EntityFrameworkCore;
using ShopOnline.WebAPI.Data;
using ShopOnline.WebAPI.Entities;
using ShopOnline.WebAPI.Repositories.Contracts;

namespace ShopOnline.WebAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext shopOnlineDbContext;

        public ProductRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            this.shopOnlineDbContext = shopOnlineDbContext;
        }
        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            return await shopOnlineDbContext.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await shopOnlineDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Product> GetItem(int id)
        {
            return await shopOnlineDbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            return await this.shopOnlineDbContext.Products.ToListAsync();
        }
    }
}
