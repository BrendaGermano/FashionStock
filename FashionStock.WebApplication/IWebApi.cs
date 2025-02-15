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

        [Post("/savestockrecord")]
        Task<HttpResponseMessage> SaveStockRecord([FromBody] StockRecordModel model);

        [Get("/getrecordtypes")]
        Task<List<RecordTypeModel>> GetRecordTypes();

        [Get("/getcategories")]
        Task<List<WebApi.Models.CategoryModel>> GetCategories();

        [Get("/getcategory")]
        Task<WebApi.Models.CategoryModel> GetCategory(int id);

        [Post("/addimage")]
        Task<HttpResponseMessage> AddImage([FromBody] ImageModel imageModel);
        [Get("/getimages")]
        Task<List<ImageModel>> GetImages();
        [Delete("/deleteimage")]
        Task<HttpResponseMessage> DeleteImage(long id);
    }
}
