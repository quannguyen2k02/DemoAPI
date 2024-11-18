using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly QuanLySanPhamDBContext _context;
        private readonly IProductRepository _repo;

        public ProductController(QuanLySanPhamDBContext context, IProductRepository repo) {
            _context = context;
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _repo.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _repo.GetProductById(id);
            if (product == null)
            {
                return NoContent();
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewProduct(SanPham sanpham)
        {
            var product =await _repo.AddNewProduct(sanpham);
            if (product != null)
            {
                return StatusCode(201, product);
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _repo.DeleteProduct(id);
            if (result)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
