using Azure.Core;
using FashionStock.Data;
using FashionStock.Entities;
using FashionStock.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionStock.WebApi.Models;
using System.Collections;
using Microsoft.AspNetCore.Http.HttpResults;


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
            var stockRecords = await _businessContext.StockRecords.Include(sr => sr.Product).Include(sr => sr.RecordType).Where(sr => sr.IsDeleted == false).ToListAsync();

            if (!stockRecords.Any())
                return NotFound();

            return Ok(stockRecords);
        }

        [HttpPost("/savestockrecord")]
        public async Task<IActionResult> SaveStockRecord([FromBody] StockRecordModel model)
        {
            var record = await _businessContext.StockRecords.FirstOrDefaultAsync(r => r.Id.Equals(model.Id));



            if (record is not null)
                return BadRequest();


            var newRecord = new StockRecord();
            newRecord.ProductId = model.ProductId;
            newRecord.UserId = model.UserId;
            newRecord.RecordTypeId = model.RecordTypeId;
            newRecord.Quantity = model.Quantity;
            newRecord.CreatedAt = DateTime.Now;
            newRecord.UpdatedAt = DateTime.Now;

            _businessContext.StockRecords.Add(newRecord);

            var result = await _businessContext.SaveChangesAsync();

            if (result.Equals(1))
                return Ok();

            return BadRequest();
        }

        [HttpGet("/getrecordtypes")]
        public async Task<IActionResult> GetRecordTypes()
        {
            var recordTypeTable = await _businessContext.RecordTypes.Where(rt => rt.IsDeleted == false).ToListAsync();

            if (!recordTypeTable.Any())

                return NotFound();
            else

                return Ok(recordTypeTable);
        }

        [HttpDelete("/deleterecord")]
        public async Task<IActionResult> DeleteRecord(long id)
        {
            var record = await _businessContext.StockRecords.FirstOrDefaultAsync(r => r.Id.Equals(id));

            if (record is null)
                return BadRequest();

            record.IsDeleted = true;

            var result = await _businessContext.SaveChangesAsync();
            if (result.Equals(1))
                return Ok();

            return BadRequest();
        }

        [HttpPut("/updaterecord")]
        public async Task<IActionResult> UpdateRecord(StockRecordModel recordModel)
        {
            var record = await _businessContext.StockRecords.FirstOrDefaultAsync(p => p.Id.Equals(recordModel.Id));

            if (record is null)

                return BadRequest();

            record.ProductId = recordModel.ProductId;
            record.UserId = recordModel.UserId;
            record.RecordTypeId = recordModel.RecordTypeId;
            record.Quantity = recordModel.Quantity;
            record.CreatedAt = DateTime.Now;
            record.UpdatedAt = DateTime.Now;


            try
            {
                var result = await _businessContext.SaveChangesAsync();
                if (result.Equals(1))
                    return Ok();

            }
            catch (Exception)
            {

                throw;
            }

            return BadRequest();
        }

    }
}


