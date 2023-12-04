using backend_not_clear.DTO.ProductDTO.CreateProductCustom;
using backend_not_clear.DTO.ProductDTO.SearchProductCustom;
using backend_not_clear.DTO.ProductDTO.UpdateCustomProduct;
using backend_not_clear.DTO.ProductDTO.UpdateMaterialInProductCustom;
using backend_not_clear.DTO.ProductDTO.UpdateSizeInProductCustom;
using backend_not_clear.DTO.ProductDTO.UpdateColorInProductCustom;
using backend_not_clear.Models;

namespace backend_not_clear.Interface
{
    public interface IProductCustom
    {
        Task<ProductCustom> CreateCustomProduct(CreateProductCustom product);

        //Task<ProductCustom> UpdateProductCustom(UpdateProductCustom product);
        
        Task<ProductCustom> UpdateStyleInProductCustom(UpdateStyleInProductCustom product);
        Task<ProductCustom> UpdateSizeInProductCustom(UpdateSizeInProductCustom product);
        Task<ProductCustom> UpdateMaterialInProductCustom(UpdateMaterialInProductCustom product);
        Task<ProductCustom> UpdateColorInProductCustom(UpdateColorInProductCustom product);
        Task<ProductCustom> GetCustomProduct(SearchProductCustom product);
        Task<List<ProductCustom>> GetAll(string UserId);
        Task<ProductCustom> Remove(string ProductId);
    }
}
