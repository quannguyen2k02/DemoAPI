using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IProductRepository
    {
        public Task<List<SanPham>> GetAllProducts();
        public Task<SanPham> GetProductById(int id);
        public Task<SanPham> AddNewProduct(SanPham product);
        public Task<SanPham> UpdateProduct(SanPham product);
        public Task<bool> DeleteProduct(int id);

    }
}
