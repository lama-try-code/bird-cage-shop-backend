using backend_not_clear.DTO.ProductDTO.CreateProductCustom;
using backend_not_clear.DTO.ProductDTO.SearchProductCustom;
using backend_not_clear.DTO.ProductDTO.UpdateColorInProductCustom;
using backend_not_clear.DTO.ProductDTO.UpdateCustomProduct;
using backend_not_clear.DTO.ProductDTO.UpdateMaterialInProductCustom;
using backend_not_clear.DTO.ProductDTO.UpdateSizeInProductCustom;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_not_clear.Service
{
    public class ProductCustomService : IProductCustom
    {
        private readonly BCS_ShopContext _context;
        public ProductCustomService(BCS_ShopContext context)
        {
            _context = context;
        }

        //public async Task<ProductCustom> GetCustomProduct(SearchProductCustom product)
        //{
        //    try
        //    {
        //        var ProductCustom = await this._context.ProductCustom.Where(x => x.UserId.Equals(product.UserId) && x.ProductName.Equals(product.ProductCustomName)).FirstOrDefaultAsync();
        //        if (ProductCustom != null)
        //        {
        //            var found = await this._context.Product.Where(x => x.ProductId.Equals(ProductCustom.ProductCustomId) && x.ProductName.Equals(product.ProductCustomName) && !x.Status).FirstOrDefaultAsync();
        //            var result = await this._context.ProductCustom.Where(x => x.ProductCustomId.Equals(found.ProductId)).FirstOrDefaultAsync();
        //            return result;
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public async Task<ProductCustom> CreateCustomProduct(CreateProductCustom product)
        {
            try
            {
                var addCustom = new ProductCustom();
                addCustom.ProductCustomId = "PDTC" + Guid.NewGuid().ToString().Substring(0, 5);
                addCustom.ProductName = product.ProductName;
                addCustom.UserId = product.UserId;
                addCustom.Price = 0;
                await this._context.ProductCustom.AddAsync(addCustom);
                if (await this._context.SaveChangesAsync() > 0)
                {
                    var addProduct = new Product();
                    addProduct.ProductId = addCustom.ProductCustomId;
                    addProduct.ProductName = addCustom.ProductName;
                    addProduct.Quantity = 1;
                    addProduct.Description = "Custom Product";
                    addProduct.Price = 0;
                    addProduct.Discount = null;
                    addProduct.Status = false;
                    await this._context.Product.AddAsync(addProduct);
                    await this._context.SaveChangesAsync();
                }
                return addCustom;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductCustom> UpdateSizeInProductCustom(UpdateSizeInProductCustom product)
        {
            try
            {
                var updateCustom = await this._context.ProductCustom.Where(x => x.ProductCustomId.Equals(product.ProductId) && x.UserId.Equals(product.UserId)).FirstOrDefaultAsync();
                var size = await this._context.Size.Where(x => x.SizeId.Equals(product.SizeId)).FirstOrDefaultAsync();
                updateCustom.ProductSize = product.SizeId;
                updateCustom.Price += size.Price;
                this._context.ProductCustom.Update(updateCustom);
                await this._context.SaveChangesAsync();
                return updateCustom;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductCustom> UpdateStyleInProductCustom(UpdateStyleInProductCustom product)
        {
            try
            {
                var updateCustom = await this._context.ProductCustom.Where(x => x.ProductCustomId.Equals(product.ProductId) && x.UserId.Equals(product.UserId)).FirstOrDefaultAsync();
                var style = await this._context.Style.Where(x => x.StyleId.Equals(product.StyleId)).FirstOrDefaultAsync();
                updateCustom.ProductStyle = product.StyleId;
                updateCustom.Price += style.Price;
                this._context.ProductCustom.Update(updateCustom);
                await this._context.SaveChangesAsync();
                return updateCustom;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductCustom> UpdateMaterialInProductCustom(UpdateMaterialInProductCustom product)
        {
            try
            {
                var updateCustom = await this._context.ProductCustom.Where(x => x.ProductCustomId.Equals(product.ProductId) && x.UserId.Equals(product.UserId)).FirstOrDefaultAsync();
                var material = await this._context.Material.Where(x => x.MaterialId.Equals(product.MaterialId)).FirstOrDefaultAsync();
                updateCustom.ProductMaterial = product.MaterialId;
                updateCustom.Price += material.Price;
                this._context.ProductCustom.Update(updateCustom);
                await this._context.SaveChangesAsync();
                return updateCustom;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductCustom> UpdateColorInProductCustom(UpdateColorInProductCustom product)
        {
            try
            {
                var updateCustom = await this._context.ProductCustom.Where(x => x.ProductCustomId.Equals(product.ProductId) && x.UserId.Equals(product.UserId)).FirstOrDefaultAsync();
                var color = await this._context.Color.Where(x => x.ColorId.Equals(product.ColorId)).FirstOrDefaultAsync();
                updateCustom.ProductColor = product.ColorId;
                updateCustom.Price += color.Price;
                this._context.ProductCustom.Update(updateCustom);
                await this._context.SaveChangesAsync();
                return updateCustom;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductCustom> GetCustomProduct(SearchProductCustom product)
        {
            try
            {
                var lastResult = await this._context.ProductCustom
                    .Join(_context.User, p => p.UserId, u => u.UserId, (p, u) => new { p, u })
                    .Join(_context.Product, p0 => p0.p.ProductCustomId, p => p.ProductId, (p0, p) => new { p0.p, p0.u, p.Status })
                    .Where(p => p.p.ProductCustomId.Equals(product.ProductId) && p.p.UserId.Equals(product.UserId) && !p.Status)
                    .Select(x => x.p)
                    .Include(x => x.User)
                    .FirstOrDefaultAsync();
                if (lastResult == null)
                    return null;
                return lastResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<ProductCustom>> GetAll(string UserId)
        {
            try
            {
                var result = await _context.ProductCustom
                    .Join(_context.User, p => p.UserId, u => u.UserId, (p, u) => new { p, u })
                    .Join(_context.Product, p0 => p0.p.ProductCustomId, p => p.ProductId, (p0, p) => new { p0.p, p0.u, p.Status })
                    .Where(p => p.p.UserId.Equals(UserId))
                    .Select(x => x.p)
                    .Include(x => x.User)
                    .ToListAsync();
                if (result == null)
                    return null;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public async Task<ProductCustom> Remove(string ProductId)
        {
            try
            {
                var delete = await this._context.ProductCustom.Where(x => x.ProductCustomId.Equals(ProductId)).FirstOrDefaultAsync();
                if (delete == null) return null;
                this._context.ProductCustom.Remove(delete);
                await this._context.SaveChangesAsync();
                var product = await this._context.Product.Where(x => x.ProductId.Equals(ProductId)).FirstOrDefaultAsync();
                if (product == null) return null;
                this._context.Product.Remove(product);
                await this._context.SaveChangesAsync();
                return delete;
            } 
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
