using backend_not_clear.DTO.SizeDTO.CreateForCustom;
using backend_not_clear.DTO.SizeDTO.CreateSize;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_not_clear.Service
{
    public class SizeServices : ISize
    {
        private readonly BCS_ShopContext _context;
        public SizeServices(BCS_ShopContext context)
        {
            _context = context;
        }
        //new for sort
        public async Task<Size> CreateSize(CreateSize size)
        {
            try
            {
                var add = new Size();
                add.SizeId = "Si" + Guid.NewGuid().ToString().Substring(0, 7);
                add.Size1 = size.Size;
                add.SizeDescription = size.SizeDescription;
                add.Price = size.Price;
                add.IsCustom = size.IsCustom;
                add.StyleId = size.StyleID;
                await this._context.Size.AddAsync(add);
                await this._context.SaveChangesAsync();
                return add;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //using for custom product, when select size
        //=> add new size
        //then used add custom product api to add into custom product
        public async Task<Size> CreateSizeForStoreCustom(CreateForSizeCustom size)
        {
            try
            {
                var SizeCustom = new Size();
                SizeCustom = await this.GetById(size.sizeId);
                if (SizeCustom != null)
                {
                    var add = new Size();
                    add.SizeId = SizeCustom.SizeId;
                    add.Size1 = SizeCustom.Size1;
                    add.SizeDescription = SizeCustom.SizeDescription;
                    add.Price = SizeCustom.Price;
                    add.IsCustom = true;
                    add.StyleId = size.styleId;
                    await this._context.Size.AddAsync(add);
                    await this._context.SaveChangesAsync();
                    return add;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //To get Size Value
        public async Task<Size> GetById(string sizeId)
        {
            try
            {
                var found = await this._context.Size.Where(x => x.SizeId.Equals(sizeId))
                                                    .FirstOrDefaultAsync();
                if (found != null)
                    return found;
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<List<Size>> GetAll()
        {
            try
            {
                var list = await this._context.Size
                    .Where(x => !x.IsCustom)
                    .ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Size>> GetForSort()
        {
            try
            {
                var list = await this._context.Size
                    .Where(x => !x.IsCustom)
                    .ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Size>> GetByStyle(string styleId)
        {
            try
            {
                var list = await this._context.Size.Where(x => x.StyleId.Equals(styleId) && x.IsCustom)
                                                   .ToListAsync();
                if (list != null)
                    return list;
                return null;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<string>> GetUniqueSizeNames(string styleId)
        {
            var uniqueNames = await _context.Size
                .Where(x => x.IsCustom && x.StyleId.Equals(styleId))
                .Select(x => x.Size1)
                .Distinct()
                .ToListAsync();
            return uniqueNames;
        }

        public async Task<List<Size>> GetByName(string SizeName)
        {
            try
            {
                var list = await this._context.Size.Where(x => x.Size1.Equals(SizeName))
                                                   .Include(x => x.Image)
                                                   .ToListAsync();
                if (list != null) return list;
                return null;
            } catch( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
