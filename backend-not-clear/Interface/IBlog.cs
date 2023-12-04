using backend_not_clear.DTO.BlogDTO;
using backend_not_clear.DTO.UserDTO;
using backend_not_clear.Models;

namespace backend_not_clear.Interface
{
    public interface IBlog
    {
        public Task<Blog> CreateBlog(CreateBlogDTO request);
        public Task<Blog> UpdateBlog(UpdateBlogDTO request);
        public Task<Blog> RemoveBlog(RemoveBlog request);
        public Task<List<Blog>> GetAll();
        public Task<List<Blog>> GetForCustomer();
        public Task<Blog> GetById(GetBlogByID request);
        public Task<List<Blog>> SearchBlogByTitle(SearchBlogByTitle request);
        public Task<List<Blog>> SearchBlogByType(SearchBlogByType request);
        public Task<List<Blog>> suggestBlog(string type);
        public Task<List<Blog>> getEachBlogType( );
    }
}
