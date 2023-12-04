using backend_not_clear.DTO.ProductDTO.CreateProduct;
using backend_not_clear.DTO.ProductDTO.CreateProductCustom;
using backend_not_clear.DTO.ProductDTO.UpdateProduct;
using backend_not_clear.Service;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.EntityFrameworkCore;
using backend_not_clear.DTO.ProductDTO.UpdateCustomProduct;
using backend_not_clear.DTO.ProductDTO.SearchProductCustom;
using System.Text.RegularExpressions;

namespace backend_not_clear.Service
{
    public class ProductServices : IProduct
    {
        private readonly BCS_ShopContext _context;
        public ProductServices(BCS_ShopContext context)
        {
            _context = context;
        }

        const string pattern = @"PDT(?!C)\w*(\d+)";

        public async Task<Product> CreateNewProduct(CreateProduct product)
        {
            try
            {
                var add = new Product();
                add.ProductId = "PDT" + Guid.NewGuid().ToString().Substring(0, 7);
                add.ProductName = product.ProductName;
                add.Description = product.ProductDescription;
                add.Quantity = product.Quantity;
                add.Price = product.Price;
                add.Discount = product.DiscountPrice;
                add.Status = true;
                await this._context.Product.AddAsync(add);
                //style
                if (await this._context.SaveChangesAsync() > 0)
                {
                    if (product.Styles != null && product.Styles.Count > 0)
                    {
                        foreach (var style in product.Styles)
                        {
                            var st = new StyleProduct();
                            st.ProductId = add.ProductId;
                            st.StyleId = style.StyleID;
                            st.Status = true;
                            await this._context.StyleProduct.AddAsync(st);
                            await this._context.SaveChangesAsync();
                        }
                    }
                    //birds
                    if (product.Birds != null && product.Birds.Count > 0)
                    {
                        foreach (var bird in product.Birds)
                        {
                            var b = new BirdProduct();
                            b.ProductId = add.ProductId;
                            b.BirdId = bird.BirdID;
                            b.Status = true;
                            await this._context.BirdProduct.AddAsync(b);
                            await this._context.SaveChangesAsync();
                        }
                    }
                    //Category
                    if (product.Category != null)
                    {
                        var cate = new CategoryProduct();
                        cate.ProductId = add.ProductId;
                        cate.CategoryId = product.Category.CategoryID;
                        cate.Status = true;
                        await this._context.CategoryProduct.AddAsync(cate);
                        await this._context.SaveChangesAsync();
                    }
                    //Color
                    if (product.Colors != null && product.Colors.Count > 0)
                    {
                        foreach (var color in product.Colors)
                        {
                            var co = new ColorProduct();
                            co.ProductId = add.ProductId;
                            co.ColorId = color.ColorID;
                            co.Status = true;
                            await this._context.ColorProduct.AddAsync(co);
                            await this._context.SaveChangesAsync();

                        }
                    }
                    //Size
                    if (product.Sizes != null && product.Sizes.Count > 0)
                    {
                        foreach (var sizes in product.Sizes)
                        {
                            var si = new SizeProduct();
                            si.ProductId = add.ProductId;
                            si.SizeId = sizes.SizeID;
                            si.Status = true;
                            await this._context.SizeProduct.AddAsync(si);
                            await this._context.SaveChangesAsync();

                        }
                    }
                    //Material
                    if (product.Materials != null && product.Materials.Count > 0)
                    {
                        foreach (var material in product.Materials)
                        {
                            var mate = new MaterialProduct();
                            mate.ProductId = add.ProductId;
                            mate.MaterialId = material.MaterialID;
                            mate.Status = true;
                            await this._context.MaterialProduct.AddAsync(mate);
                            await this._context.SaveChangesAsync();
                        }
                    }
                    if (product.ImageUrl != null)
                    {
                        var img = new Image();
                        img.ImageId = "I" + Guid.NewGuid().ToString().Substring(0, 8);
                        img.ProductId = add.ProductId;
                        img.ImageUrl = product.ImageUrl;
                        await this._context.Image.AddAsync(img);
                        await this._context.SaveChangesAsync();
                    }
                    return add;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> DecreaseProductQuantity(DecreaseProductQuantity product)
        {
            try
            {
                var found = await this._context.Product
                            .Where(x => x.ProductId.Equals(product.ProductID))
                            .FirstOrDefaultAsync();
                if (found != null)
                {
                    found.Quantity -= 1;
                    this._context.Product.Update(found);
                    await this._context.SaveChangesAsync();
                    return found;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> DeleteProduct(string id)
        {
            try
            {
                var delete = await this._context.Product
                            .Where(x => x.ProductId.Equals(id))
                            .FirstOrDefaultAsync();
                if (delete != null)
                {
                    delete.Status = false;
                    this._context.Product.Update(delete);
                    await this._context.SaveChangesAsync();
                    return delete;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Product>> GetAll()
        {
            try
            {
                var list = await this._context.Product.Where(x => x.Status)
                    .Include(x => x.Image)
                    .Include(x => x.CategoryProduct)
                        .ThenInclude(x => x.Category)
                    .ToListAsync();
                var products = new List<Product>();
                foreach (var item in list)
                {
                    if (Regex.IsMatch(item.ProductId, pattern))
                        products.Add(item);
                }
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetById(string id)
        {
            try
            {
                var found = await this._context.Product
                            .Where(x => x.ProductId.Equals(id))
                            .Include(x => x.StyleProduct.Where(x => x.Status))
                                .ThenInclude(x => x.Style)
                            .Include(x => x.BirdProduct)
                                .ThenInclude(x => x.Bird)
                            .Include(x => x.CategoryProduct)
                                .ThenInclude(x => x.Category)
                            .Include(x => x.SizeProduct)
                                .ThenInclude(x => x.Size)
                            .Include(x => x.ColorProduct)
                                .ThenInclude(x => x.Color)
                            .Include(x => x.MaterialProduct)
                                .ThenInclude(x => x.Material)
                            .Include(x => x.Image)
                            .FirstOrDefaultAsync();
                return found;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Product>> GetByName(string name)
        {
            try
            {
                var list = await this._context.Product
                            .Where(x => x.ProductName.Contains(name))
                            .Include(x => x.Image)
                           .ToListAsync();
                var products = new List<Product>();
                foreach (var item in list)
                {
                    if (Regex.IsMatch(item.ProductId, pattern))
                        products.Add(item);
                }
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Product>> GetForCustomer()
        {
            try
            {
                var list = await this._context.Product
                            .Where(x => x.Status)
                            .Include(x => x.StyleProduct.Where(x => x.Status))
                                .ThenInclude(x => x.Style)
                            .Include(x => x.BirdProduct)
                                .ThenInclude(x => x.Bird)
                            .Include(x => x.CategoryProduct)
                                .ThenInclude(x => x.Category)
                            .Include(x => x.SizeProduct)
                                .ThenInclude(x => x.Size)
                            .Include(x => x.ColorProduct)
                                .ThenInclude(x => x.Color)
                            .Include(x => x.MaterialProduct)
                                .ThenInclude(x => x.Material)
                            .Include(x => x.Image)
                            .ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Product>> GetByCategory(string categoryId)
        {
            try
            {
                var GetAll = await this._context.Product
                            .Where(x => x.Status)
                            .Include(x => x.CategoryProduct.Where(x => x.CategoryId.Equals(categoryId)))
                                .ThenInclude(x => x.Category)
                            .Include(x => x.Image)
                            .ToListAsync();
                var list = GetAll.Where(product => product.CategoryProduct.Any(category => category.CategoryId.Equals(categoryId))).ToList();
                var products = new List<Product>();
                foreach (var item in list)
                {
                    if (Regex.IsMatch(item.ProductId, pattern))
                        products.Add(item);
                }
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> UpdateProduct(UpdateProduct product)
        {
            try
            {
                var FoundUpdate = await this._context.Product
                                    .Where(x => x.ProductId.Equals(product.ProductID))
                                    .FirstOrDefaultAsync();
                if (FoundUpdate == null) return null;

                if (product.ProductName != "")
                    FoundUpdate.ProductName = product.ProductName;
                
                if (product.ProductDescription != "")
                    FoundUpdate.Description = product.ProductDescription;
                
                if (product.Quantity != 0)
                    FoundUpdate.Quantity = product.Quantity;
                
                if (product.Price != 0)
                    FoundUpdate.Price = product.Price;
                
                if (product.DiscountPrice != 0)
                    FoundUpdate.Discount = product.DiscountPrice;
                FoundUpdate.Status = product.status;
                this._context.Product.Update(FoundUpdate);
                //style
                if (await this._context.SaveChangesAsync() > 0)
                {
                    if (product.Styles != null && product.Styles.Count > 0 && product.Styles[0].StyleID != "")
                    {
                        var st = new StyleProduct();
                        foreach (var style in product.Styles)
                        {
                            st.ProductId = FoundUpdate.ProductId;
                            st.StyleId = style.StyleID;
                            st.Status = true;
                        }
                        this._context.Update(st);
                    }
                    //Color
                    if (product.Colors != null && product.Colors.Count > 0 && product.Colors[0].ColorID != "")
                    {
                        var co = new ColorProduct();
                        foreach (var color in product.Colors)
                        {
                            co.ProductId = FoundUpdate.ProductId;
                            co.ColorId = color.ColorID;
                            co.Status = true;
                        }
                        this._context.Update(co);
                    }
                    //Size
                    if (product.Sizes != null && product.Sizes.Count > 0 && product.Sizes[0].SizeID != "")
                    {
                        var si = new SizeProduct();
                        foreach (var sizes in product.Sizes)
                        {
                            si.ProductId = FoundUpdate.ProductId;
                            si.SizeId = sizes.SizeID;
                            si.Status = true;
                        }
                        this._context.Update(si);
                    }
                    //Material
                    if (product.Materials != null && product.Materials.Count > 0 && product.Materials[0].MaterialID != "")
                    {
                        var mate = new MaterialProduct();
                        foreach (var material in product.Materials)
                        {
                            mate.ProductId = FoundUpdate.ProductId;
                            mate.MaterialId = material.MaterialID;
                            mate.Status = true;
                        }
                        this._context.Update(mate);
                    }
                    //image url 
                    if (product.ImageUrl != null && product.ImageUrl != "")
                    {
                        var img = await this._context.Image.Where(x => x.ProductId.Equals(FoundUpdate.ProductId)).FirstOrDefaultAsync();
                        if (img == null)
                        {
                            img = new Image();
                            img.ImageId = "I" + Guid.NewGuid().ToString().Substring(0, 8);
                            img.ProductId = FoundUpdate.ProductId;
                            img.ImageUrl = product.ImageUrl;
                            await this._context.Image.AddAsync(img);
                            await this._context.SaveChangesAsync();
                        }
                        else
                        {
                            img.ImageUrl = product.ImageUrl;
                            this._context.Image.Update(img);
                            await this._context.SaveChangesAsync();
                        }
                    }
                    await this._context.SaveChangesAsync();
                    return FoundUpdate;
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Int32> countProducts()
        {
            try
            {
                var list = await this._context.Product.ToListAsync();
                return list.Count();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
