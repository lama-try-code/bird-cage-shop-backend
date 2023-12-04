namespace backend_not_clear.DTO.ProductDTO.UpdateProduct
{
    public class UpdateProduct
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int? DiscountPrice { get; set; }
        public bool status { get; set; }
        public List<ProductStyleDTO>? Styles { get; set; }
        public List<SizeProductsDTO>? Sizes { get; set; }
        public List<ColorProductsDTO>? Colors { get; set; }
        public List<MaterialProductsDTO>? Materials { get; set; }
        public string ImageUrl { get; set; }
    }
}
