using backend_not_clear.DTO.StyleDTO.CreateStyle;
using backend_not_clear.DTO.StyleDTO.SearchStyle;
using backend_not_clear.DTO.StyleDTO.UpdateStyle;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_not_clear.Service
{
    public class StyleServices : IStyle
    {
        private readonly BCS_ShopContext _context;
        public StyleServices(BCS_ShopContext context)
        {
            _context = context;
        }

        public async Task<Style> CreateStyle(CreateStyle style)
        {
            try
            {
                var add = new Style();
                add.StyleId = "S" + Guid.NewGuid().ToString().Substring(0, 8);
                add.StyleName = style.StyleName;
                add.StyleDescription = style.StyleDescription;
                add.Price = style.Price;
                add.IsCustom = style.IsCustom;
                add.Status = true;
                await this._context.Style.AddAsync(add);
                await this._context.SaveChangesAsync();
                return add;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Style> DeleteStyle(string StyleID)
        {
            try
            {
                var delete = await this._context.Style.Where(x => x.StyleId.Equals(StyleID))
                    .FirstOrDefaultAsync();
                if (delete != null)
                {
                    delete.Status = false;
                    this._context.Style.Update(delete);
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

        public async Task<List<Style>> GetAll()
        {
            try
            {
                var list = await this._context.Style
                                              .Where(x => !x.IsCustom && x.Status)
                                               .ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Style>> GetByCustom()
        {
            try
            {
                var list = await this._context.Style.Where(x => x.Status && x.IsCustom)
                    .Include(x => x.Image)
                    .ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //use for get by style for custom
        public async Task<Style> GetById(string id)
        {
            try
            {
                var found = await this._context.Style.Where(x => x.StyleId.Equals(id))
                                                     .FirstOrDefaultAsync();
                if (found != null) return found;
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Style>> GetForSort()
        {
            try
            {
                var list = await this._context.Style.Where(x => x.Status && !x.IsCustom)
                    .ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
