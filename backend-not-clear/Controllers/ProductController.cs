using backend_not_clear.DTO;
using backend_not_clear.DTO.ProductDTO.CreateProduct;
using backend_not_clear.DTO.ProductDTO.CreateProductCustom;
using backend_not_clear.DTO.ProductDTO.SearchProductCustom;
using backend_not_clear.DTO.ProductDTO.UpdateCustomProduct;
using backend_not_clear.DTO.ProductDTO.UpdateProduct;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_not_clear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct service;
        public ProductController(IProduct service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get for manager to see and decide what to do
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2, 3")]
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResponseAPI<List<Product>> responseAPI = new ResponseAPI<List<Product>>();
            try
            {
                responseAPI.Data = await this.service.GetAll();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// get for customer to see our product
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("get-for-customer")]
        [HttpGet]
        public async Task<IActionResult> GetForCustomer()
        {
            ResponseAPI<List<Product>> responseAPI = new ResponseAPI<List<Product>>();
            try
            {
                responseAPI.Data = await this.service.GetForCustomer();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// Let customer/manager search their needs
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("search-by-name")]
        [HttpGet]
        public async Task<IActionResult> SearchByName(string name)
        {
            ResponseAPI<List<Product>> responseAPI = new ResponseAPI<List<Product>>();
            try
            {
                responseAPI.Data = await this.service.GetByName(name);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// Let customer see product information
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            ResponseAPI<Product> responseAPI = new ResponseAPI<Product>();
            try
            {
                responseAPI.Data = await this.service.GetById(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// Get by category for user when chose category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("get-by-category")]
        [HttpGet]
        public async Task<IActionResult> GetByCategory(string categoryId)
        {
            ResponseAPI<List<Product>> responseAPI = new ResponseAPI<List<Product>>();
            try
            {
                responseAPI.Data = await this.service.GetByCategory(categoryId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// Allow manager create new one
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateNewProduct(CreateProduct product)
        {
            ResponseAPI<Product> responseAPI = new ResponseAPI<Product>();
            try
            {
                responseAPI.Data = await this.service.CreateNewProduct(product);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// Allow manager update one
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProduct product)
        {
            ResponseAPI<Product> responseAPI = new ResponseAPI<Product>();
            try
            {
                responseAPI.Data = await this.service.UpdateProduct(product);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// After buy this api run to decrease product's quantity in system
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("decrease-quantity")]
        [HttpPut]
        public async Task<IActionResult> DecreaseProductQuantity(DecreaseProductQuantity product)
        {
            ResponseAPI<Product> responseAPI = new ResponseAPI<Product>();
            try
            {
                responseAPI.Data = await this.service.DecreaseProductQuantity(product);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        /// <summary>
        /// Allow manager delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [Route("delete-product")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            ResponseAPI<Product> responseAPI = new ResponseAPI<Product>();
            try
            {
                responseAPI.Data = await this.service.DeleteProduct(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [AllowAnonymous]
        [Route("Count-all-products")]
        [HttpGet]
        public async Task<IActionResult> countProducts()
        {
            ResponseAPI<Product> responseAPI = new ResponseAPI<Product>();
            try
            {
                responseAPI.Data = await this.service.countProducts();
                return Ok(responseAPI);
            }catch(Exception ex)
            {
                responseAPI.message = ex.Message;   
                return BadRequest(responseAPI);
            }
        }
    }
}
