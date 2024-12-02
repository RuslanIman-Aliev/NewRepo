using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_app.Models;
using Shop_app.Services;

namespace Shop_app.Controllers.API
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class APIProductsController : ControllerBase
    {
        private readonly IServiceProduct _serviceProduct;
       public APIProductsController(IServiceProduct serviceProduct)
        {
            _serviceProduct = serviceProduct;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _serviceProduct.ReadAsync();
            return Ok(products);
        }
    }
}
