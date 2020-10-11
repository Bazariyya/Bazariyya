using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Product.API.Application.Commands;
using Product.API.Application.Commands.ProductCommands;
using Product.API.Application.Models;
using Product.API.Application.Queryes.ProductQueryes;
using ProductApi.Data;

namespace ProductApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IOptionsSnapshot<ProductSettings> _settings;
        private readonly Product.Infrastructure.ProductContext _productDbContext;
        private readonly IMediator _mediator;
        private readonly IProductQuery _productQuery;

        public ProductController(Product.Infrastructure.ProductContext productContext, 
            IOptionsSnapshot<ProductSettings> settings,
             IMediator mediator,
             IProductQuery productQuery)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _productQuery = productQuery ?? throw new ArgumentNullException(nameof(productQuery));
            _settings = settings;
            _productDbContext = productContext;
            ((DbContext)_productDbContext).ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        [HttpGet]
        [Route("getall")]
        public List<ProductDto> GetAll()
        {
            return _productQuery.GetAllProductsAsync();
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult> AddProduct([FromBody]CreateProductCommand request)
        {
            var result = await _mediator.Send(request);

            return new JsonResult(result);
        }
        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<ActionResult> UpdateProduct([FromBody]UpdateProductCommand request)
        {
            var result = await _mediator.Send(request);

            return new JsonResult(result);
        }
        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult> Get([FromBody]UpdateProductCommand request)
        {
            var result = await _mediator.Send(request);

            return new JsonResult(result);
        }
    }
}