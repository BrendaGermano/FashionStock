using FashionStock.Data;
using FashionStock.Entities;
using FashionStock.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionStock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly BusinessContext _businessContext;

        public DashboardController(BusinessContext businessContext) 
        { 
            _businessContext = businessContext;
        }

        [HttpGet("/getlowstock")]
        // Mostra os produtos que estão com baixo estoque 
        public async Task<IActionResult> GetLowStock([FromQuery] int threshold = 5)
        {
            var products = await _businessContext.Products.Where(p => p.Quantity < threshold).Select( p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Quantity = p.Quantity
            }).ToListAsync();

            return Ok(products);
        }

        [HttpGet("/gettopsellingproducts")]
        // Consulta os produtos com mais venda no estoque 
        public async Task<IActionResult> GetTopSellingProducts([FromQuery] int top = 5)
        {
            var products = await _businessContext.StockRecords
                .Include(r => r.RecordType)
                .Include(r => r.Product)
                .Where(r => r.RecordTypeId == 3)
                .GroupBy(r => r.ProductId)
                .Select(g => new ProductDto
                {
                    ProductId = g.Key,
                    Name = g.First().Product.Name,
                    TotalSold = g.Sum(r => r.Quantity)
                })
                .OrderByDescending(p => p.TotalSold)
                .Take(top) 
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("/gettopsellingcategories")]
        // Mostra as categorias com mais produtos vendidos 
        public async Task<IActionResult> GetTopSellingCategories()
        {
            var categories = await _businessContext.StockRecords
                .Where(r => r.RecordTypeId == 3)  
                .GroupBy(r => r.Product.CategoryId)
                .Select(g => new CategoryDto
                {
                    CategoryId = g.Key,
                    Name = g.First().Product.Category.Name,
                    TotalSold = g.Sum(r => r.Quantity)
                })
                .OrderByDescending(c => c.TotalSold)
                .ToListAsync();

            return Ok(categories);
        }
    }
}
