using backend_not_clear.DTO.ProductDTO.CreateProduct;
using backend_not_clear.DTO.ProductDTO.CreateProductCustom;
using backend_not_clear.DTO.ProductDTO.SearchProductCustom;
using backend_not_clear.DTO.ProductDTO.UpdateCustomProduct;
using backend_not_clear.DTO.ProductDTO.UpdateProduct;
using backend_not_clear.Models;

namespace backend_not_clear.Interface
{
    public interface IProduct
    {
        //for product
        Task<List<Product>> GetAll();
        Task<List<Product>> GetForCustomer();
        Task<List<Product>> GetByName(string name);
        Task<Product> GetById(string id);
        Task<List<Product>> GetByCategory(string categoryId);
        Task<Product> UpdateProduct(UpdateProduct product);
        Task<Product> DecreaseProductQuantity(DecreaseProductQuantity product);
        Task<Product> CreateNewProduct(CreateProduct product);
        Task<Product> DeleteProduct(string id);
        Task<Int32> countProducts();
    }
}
