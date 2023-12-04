
namespace backend_not_clear.DTO.ProductDTO.CreateProduct
{
    public class CreateProduct
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? DiscountPrice { get; set; }
        public List<ProductStyleDTO>? Styles { get; set; }
        public List<BirdProductsDTO>? Birds { get; set; }
        public CategoryProductsDTO Category { get; set; }
        public List<SizeProductsDTO>? Sizes { get; set; }
        public List<ColorProductsDTO>? Colors { get; set; }
        public List<MaterialProductsDTO>? Materials { get; set; }
        public string ImageUrl { get; set; }
    }
}
