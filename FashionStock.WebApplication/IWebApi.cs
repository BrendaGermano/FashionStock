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

        [Get("/getstockrecord")]
        Task<StockRecordModel> GetRecord(int id);

        [Post("/savestockrecord")]
        Task<HttpResponseMessage> SaveStockRecord([FromBody] StockRecordModel model);

        [Get("/getrecordtypes")]
        Task<List<RecordTypeModel>> GetRecordTypes();

        [Get("/getcategory")]
        Task<WebApi.Models.CategoryModel> GetCategory(int id);

        [Post("/addimage")]
        Task<HttpResponseMessage> AddImage([FromBody] ImageModel imageModel);
        [Get("/getimages")]
        Task<List<ImageModel>> GetImages();
        [Delete("/deleteimage")]
        Task<HttpResponseMessage> DeleteImage(long id);
        [Get("/getcategories")]
        Task<List<CategoryModel>> GetCategories();
        [Put("/updaterecord")]
        Task<HttpResponseMessage> UpdateRecord([FromBody] WebApi.Models.StockRecordModel recordModel);
        [Delete("/deleterecord")]
        Task<HttpResponseMessage> DeleteRecord(long id);
        [Post("/addcategories")]
        Task<HttpResponseMessage> AddCategory([FromBody] CategoryModel categoryModel);

        [Get("/getlowstock")]
        Task<List<ProductDto>> GetLowStock([Query] int threshold = 5);

        [Get("/gettopsellingproducts")]
        Task<List<ProductDto>> GetTopSellingProducts([Query] int top = 5);

        [Get("/gettopsellingcategories")]
        Task<List<CategoryDto>> GetTopSellingCategories();
    }
}
