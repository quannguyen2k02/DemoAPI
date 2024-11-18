using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly QuanLySanPhamDBContext _context;

        public ProductRepository(QuanLySanPhamDBContext context) {
            _context =  context;
        }
        public async Task<SanPham> AddNewProduct(SanPham product)
        {
            _context.SanPhams.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.SanPhams.FindAsync(id);
            if (product != null)
            {
                _context.SanPhams.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<SanPham>> GetAllProducts()
        {
            var products = await _context.SanPhams.ToListAsync();
            return products;
        }

        public async Task<SanPham> GetProductById(int id)
        {
            var product = await _context.SanPhams.FindAsync(id);
            return product;
        }

        public async Task<SanPham> UpdateProduct(SanPham product)
        {
            throw new NotImplementedException();
        }
    }
}
