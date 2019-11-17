using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Redmond.API.Helpers;
using Redmond.Domain.Commands;
using Redmond.Domain.Queries.GetAllProducts;
using Redmond.Domain.Queries.GetProduct;
using Redmond.SharedKernel.Interfaces;

namespace Redmond.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDispatcher dispatcher;

        public ProductController(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string name)
        {
            var products = await this.dispatcher.GetAsync<IEnumerable<GetAllProductsResult>>(new GetAllProductsFilter(name));

            return Ok(products);
        }

        [HttpGet, Route("{productId}")]
        public async Task<IActionResult> GetAsync(Guid productId)
        {
            var product = await this.dispatcher.GetAsync<GetProductResult>(new GetProductFilter(productId));

            return this.SwitchResult(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductCommand command)
        {
            var operationResult = await this.dispatcher.DoAsync(command);

            return this.SwitchResult(operationResult);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateProductCommand command)
        {
            var operationResult = await this.dispatcher.DoAsync(command);

            return this.SwitchResult(operationResult);
        }

        [HttpDelete, Route("{productId}")]
        public async Task<IActionResult> DeleteAsync(Guid productId)
        {
            var operationResult = await this.dispatcher.DoAsync(new DeleteProductCommand(productId));

            return this.SwitchResult(operationResult);
        }
    }
}
