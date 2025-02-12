using Azure.Core;
using FashionStock.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;
namespace FashionStock.WebApplication
{
    public interface IWebApi
    {
        [Get("/getproducts")]
        Task<List<ProductModel>> GetProducts();

        [Delete("/deleteproducts")]
        Task<HttpResponseMessage> DeleteProduct(long id);

        [Post("/addproduct")]
        Task<HttpResponseMessage> AddProduct([FromBody] ProductModel productModel);

        [Get("/getproduct")]
        Task<WebApi.Models.ProductModel> GetProduct(int id);
        [Put("/updateproduct")]
        Task<HttpResponseMessage> UpdateProduct([FromBody] WebApi.Models.ProductModel productModel);

        [Get("/getstockrecords")]
        Task<List<StockRecordModel>> GetStockRecords();

        [Post("/addstockrecord")]
        Task<HttpResponseMessage> AddStockRecord([FromBody] StockRecordModel model);

    }
}
