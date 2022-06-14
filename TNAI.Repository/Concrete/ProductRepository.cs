using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNAI.Model.Entitites;
using TNAI.Repository.Abstract;

namespace TNAI.Repository.Concrete
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await GetProductAsync(id);
            if (product == null) return true;

            Context.Products.Remove(product);
            try
            {
                await Context.SaveChangesAsync();

            }catch(Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await Context.Products.ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
           return await Context.Products.SingleOrDefaultAsync(p => p.Id == id); 
        }

        public async Task<bool> SaveProductAsync(Product product)
        {
            if (product == null) return false;
            try
            {
                Context.Entry(product).State =product.Id==default(int)?EntityState.Added:EntityState.Modified;
                await Context.SaveChangesAsync();
                await Context.Entry(product).Reference(x => x.Category).LoadAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
