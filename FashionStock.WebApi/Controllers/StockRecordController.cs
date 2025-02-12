using Azure.Core;
using FashionStock.Data;
using FashionStock.Entities;
using FashionStock.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionStock.WebApi.Models;
using System.Collections;


namespace FashionStock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockRecordController : ControllerBase
    {
        private readonly BusinessContext _businessContext;

        public StockRecordController(BusinessContext businessContext)
        {
            _businessContext = businessContext;
        }

        [HttpGet("/getstockrecords")]
        public async Task<IActionResult> GetStockRecords()
        {
            var stockRecords = await _businessContext.StockRecords.Include(sr => sr.Product).Include(sr => sr.RecordType).ToListAsync();

            if (!stockRecords.Any())
                return NotFound();

            return Ok(stockRecords);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddStockRecord([FromBody] StockRecordModel model)
        {
            if (model == null)
                return BadRequest("Dados inválidos");

            var product = await _businessContext.Products.FindAsync(model.ProductId);
            if (product == null)
                return NotFound("Produto não encontrado");

            var stockRecord = new StockRecord
            {
                ProductId = model.ProductId,
                UserId = model.UserId,
                RecordTypeId = model.RecordTypeId,
                Quantity = model.Quantity,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _businessContext.StockRecords.Add(stockRecord);

            await _businessContext.SaveChangesAsync();

            return Ok(stockRecord);
        }
        

    }
}


