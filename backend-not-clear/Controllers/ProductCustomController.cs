using backend_not_clear.DTO.ProductDTO.CreateProductCustom;
using backend_not_clear.DTO.ProductDTO.SearchProductCustom;
using backend_not_clear.DTO.ProductDTO.UpdateCustomProduct;
using backend_not_clear.DTO;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend_not_clear.DTO.ProductDTO.UpdateSizeInProductCustom;
using backend_not_clear.DTO.ProductDTO.UpdateMaterialInProductCustom;
using backend_not_clear.DTO.ProductDTO.UpdateColorInProductCustom;

namespace backend_not_clear.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCustomController : ControllerBase
    {
        private IProductCustom service;
        public ProductCustomController(IProductCustom service)
        {
            this.service = service;
        }
        //product custom

        [AllowAnonymous]
        [Route("get-product-custom-for-user")]
        [HttpPost]
        public async Task<IActionResult> GetCustomProduct(SearchProductCustom product)
        {
            ResponseAPI<ProductCustom> responseAPI = new ResponseAPI<ProductCustom>();
            try
            {
                responseAPI.Data = await this.service.GetCustomProduct(product);
                return Ok(responseAPI);
            } catch(Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            } 
        }


        [AllowAnonymous]
        [Route("create-custom")]
        [HttpPost]
        public async Task<IActionResult> CreateCustomProduct(CreateProductCustom product)
        {
            ResponseAPI<ProductCustom> responseAPI = new ResponseAPI<ProductCustom>();
            try
            {
                responseAPI.Data = await this.service.CreateCustomProduct(product);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        //[AllowAnonymous]
        //[Route("update-custom-product")]
        //[HttpPut]
        //public async Task<IActionResult> UpdateProductCustom(UpdateProductCustom product)
        //{
        //    ResponseAPI<ProductCustom> responseAPI = new ResponseAPI<ProductCustom>();
        //    try
        //    {
        //        responseAPI.Data = await this.service.UpdateProductCustom(product);
        //        return Ok(responseAPI);
        //    }
        //    catch (Exception ex)
        //    {
        //        responseAPI.message = ex.Message;
        //        return BadRequest(responseAPI);
        //    }
        //}

        [AllowAnonymous]
        [Route("update-style-custom-product")]
        [HttpPut]
        public async Task<IActionResult> UpdateStyleInProductCustom(UpdateStyleInProductCustom product)
        {
            ResponseAPI<ProductCustom> responseAPI = new ResponseAPI<ProductCustom>();
            try
            {
                responseAPI.Data = await this.service.UpdateStyleInProductCustom(product);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [AllowAnonymous]
        [Route("update-size-custom-product")]
        [HttpPut]
        public async Task<IActionResult> UpdateSizeInProductCustom(UpdateSizeInProductCustom product)
        {
            ResponseAPI<ProductCustom> responseAPI = new ResponseAPI<ProductCustom>();
            try
            {
                responseAPI.Data = await this.service.UpdateSizeInProductCustom(product);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [AllowAnonymous]
        [Route("update-material-custom-product")]
        [HttpPut]
        public async Task<IActionResult> UpdateMaterialInProductCustom(UpdateMaterialInProductCustom product)
        {
            ResponseAPI<ProductCustom> responseAPI = new ResponseAPI<ProductCustom>();
            try
            {
                responseAPI.Data = await this.service.UpdateMaterialInProductCustom(product);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [AllowAnonymous]
        [Route("update-color-custom-product")]
        [HttpPut]
        public async Task<IActionResult> UpdateColorInProductCustom(UpdateColorInProductCustom product)
        {
            ResponseAPI<ProductCustom> responseAPI = new ResponseAPI<ProductCustom>();
            try
            {
                responseAPI.Data = await this.service.UpdateColorInProductCustom(product);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [AllowAnonymous]
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll(string UserId)
        {
            ResponseAPI<List<ProductCustom>> responseAPI = new ResponseAPI<List<ProductCustom>>();
            try
            {
                responseAPI.Data = await this.service.GetAll(UserId);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("remove")]
        [HttpDelete]
        public async Task<IActionResult> RemoveProduct(string id)
        {
            ResponseAPI<ProductCustom> resposneAPI = new ResponseAPI<ProductCustom>();
            try
            {
                resposneAPI.Data = await this.service.Remove(id);
                return Ok(resposneAPI);
            }
            catch (Exception ex)
            {
                resposneAPI.message = ex.Message;
                return BadRequest(resposneAPI);
            }
        }
    }
}
