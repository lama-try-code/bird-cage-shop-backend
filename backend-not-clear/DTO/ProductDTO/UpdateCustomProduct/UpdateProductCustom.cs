namespace backend_not_clear.DTO.ProductDTO.UpdateCustomProduct
{
    public class UpdateProductCustom
    {
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public ProductStyleDTO? Style { get; set; }
        public SizeProductsDTO? Size { get; set; }
        public ColorProductsDTO? Color { get; set; }
        public MaterialProductsDTO? Material { get; set; }
    }
}
