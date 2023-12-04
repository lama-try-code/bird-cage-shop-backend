using backend_not_clear.DTO.BlogDTO;
using backend_not_clear.DTO.UserDTO;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_not_clear.Service
{
    public class BlogServices : IBlog
    {
        private readonly BCS_ShopContext _context;

        public BlogServices(BCS_ShopContext context)
        {
            _context = context;
        }

        public async Task<Blog> CreateBlog(CreateBlogDTO request)
        {
            try
            {
                if (request == null)
                    throw new Exception("fail to create");
                Blog blog = new Blog();
                blog.BlogId = "BO" + Guid.NewGuid().ToString().Substring(0,6);
                blog.BlogTitle = request.title;
                blog.BlogContent = request.content;
                blog.BlogSummary = blog.BlogContent.Substring(0, 40) + "...";
                blog.CreateAt = DateTime.UtcNow;
                blog.Status = true;
                blog.BlogType = request.type;
                blog.UserId = request.userID;
                await this._context.AddAsync(blog);
                await this._context.SaveChangesAsync();
                if(request.ImageUrl != null)
                {
                    var img = new Image();
                    img.ImageId = "I" + Guid.NewGuid().ToString().Substring(0, 8);
                    img.BlogId = blog.BlogId;
                    img.ImageUrl = request.ImageUrl;
                    await this._context.Image.AddAsync(img);
                    await this._context.SaveChangesAsync();
                }
                return blog;
            }catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<Blog>> GetAll()
        {
            try
            {
                List<Blog> blog = new List<Blog>();
                var list = await this._context.Blog.Where(x => x.Status)
                                                   .Include(x => x.User)
                                                   .ToListAsync();
                if (list != null)
                    return list;
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Blog> GetById(GetBlogByID request)
        {
            try
            {
                if (request == null) throw new Exception("NOT FOUND");
                var blog = await this._context.Blog.Where(x => x.BlogId.Equals(request.BlogID) && x.Status)
                                                   .Include(x => x.User)
                                                   .Include(x => x.Image)
                                                   .FirstOrDefaultAsync();
                if (blog == null || !blog.Status) throw new Exception("fail");
                return blog;
            }catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<Blog>> GetForCustomer()
        {
            try
            {
                List<Blog> blog = new List<Blog>();
                var list = await this._context.Blog
                                              .Where(x => x.Status)
                                              .Include(x => x.User)
                                              .Include(x => x.Image)
                                              .ToListAsync();
                if (list != null)
                    return list;
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Blog> RemoveBlog(RemoveBlog request)
        {
            try
            {
                if (request == null) 
                    throw new Exception("FAIL TO REMOVE / FAIL To FOUND");
                var blog = await this._context.Blog.Where(x => x.BlogId.Equals(request.BlogID) && x.Status)
                                                   .FirstOrDefaultAsync();
                if (blog == null) return null;
                blog.Status = false;
                this._context.Blog.Update(blog);
                await this._context.SaveChangesAsync();
                return blog;
            }catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<Blog>> SearchBlogByTitle(SearchBlogByTitle request)
        {
            try
            {
                var blog = await this._context.Blog.Where(x => x.BlogTitle.Contains(request.Title) && x.Status)
                                                   .Include(x => x.User)
                                                   .ToListAsync();
                if (blog != null)
                {
                    return blog;
                }
                throw new Exception("NOT FOUND");
            }catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<Blog>> SearchBlogByType(SearchBlogByType request)
        {
            try
            {
                var blog = await this._context.Blog.Where(x => x.BlogType.Equals(request.Type) && x.Status)
                                                   .Include(x => x.User)
                                                   .ToListAsync();
                if (blog == null) throw new Exception("NOT FOUND");
                return blog;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Blog> UpdateBlog(UpdateBlogDTO request)
        {
            try
            {
                var blog = await this._context.Blog.Where(x => x.BlogId.Equals(request.BlogID) && x.Status)
                                                   .Include(x => x.User)
                                                   .FirstOrDefaultAsync();
                if (request == null)
                    throw new Exception("FAIL TO UPDATE");
                else if ( blog == null) 
                    throw new Exception("NOT FOUND");
                blog.BlogTitle = request.title ?? blog.BlogTitle;
                blog.BlogContent = request.content ?? blog.BlogContent;
                blog.BlogType = request.type ?? blog.BlogType;
                this._context.Blog.Update(blog);
                await this._context.SaveChangesAsync();
                return blog;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public async Task<List<Blog>> suggestBlog(string type)//take 4 blogs in the same type in database 
        {
            try
            {
                int i = 0;
                List<Blog> blog = new List<Blog> ();
                var blogs = await this._context.Blog.Where(x => x.BlogType.Equals(type) && x.Status).Include(x => x.Image).ToListAsync();
                foreach (var item in blogs)
                {
                    blog.Add(item);
                    i++;
                    if(i == 4) break;
                }
                return blog;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public async Task<List<Blog>> getEachBlogType()//Take 4 first Blogs in the database
        {
            try
            {
                int i = 0;
                List<Blog> blog = new List<Blog>();
                var blogs = await this._context.Blog
                                     .Where(x => x.Status )
                                     .Include(x => x.Image)
                                     .Include(x => x.User)
                                     .ToListAsync();
                foreach (var item in blogs)
                {
                    blog.Add(item);
                    i++;
                    if (i == 4) break;
                }
                return blog;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
