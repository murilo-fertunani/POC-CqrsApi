using CqrsApi.Domain.Commands.Requests;
using CqrsApi.Domain.Commands.Responses;
using CqrsApi.Domain.Handlers.Interfaces;
using CqrsApi.Domain.Queries.Requests;
using CqrsApi.Domain.Queries.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CqrsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProductByIdResponse>>> GetAllAsync(
            [FromServices] IGetAllProductsHandler handler,
            [FromQuery] GetAllProductsRequest command)
        {
            var response = await handler.HandleAsync(command);

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetProductByIdResponse>> GetByIdAsync(
            [FromServices] IGetProductByIdHandler handler,
            [FromRoute] Guid id)
        {
            var command = new GetProductByIdRequest { Id = id };
            var response = await handler.HandleAsync(command);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CreateProductResponse>> CreateAsync(
            [FromServices] ICreateProductHandler handler,
            [FromBody] CreateProductRequest command)
        {
            var response = await handler.HandleAsync(command);
            var location = Url.Action(nameof(GetByIdAsync), new { id = response.Id }) ?? $"/{response.Id}";

            return Created(location, response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<UpdateProductResponse>> UpdateAsync(
            [FromServices] IUpdateProductHandler handler,
            [FromBody] UpdateProductRequest command)
        {
            var response = await handler.HandleAsync(command);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPatch]
        [Route("disable")]
        public async Task<ActionResult<DisableProductResponse>> DisableAsync(
            [FromServices] IDisableProductHandler handler,
            [FromBody] DisableProductRequest command)
        {
            var response = await handler.HandleAsync(command);
            if (response == null)
                return NotFound();

            return Ok(response);
        }


        [HttpPatch]
        [Route("enable")]
        public async Task<ActionResult<EnableProductResponse>> EnableAsync(
            [FromServices] IEnableProductHandler handler,
            [FromBody] EnableProductRequest command)
        {
            var response = await handler.HandleAsync(command);
            if (response == null)
                return NotFound();

            return Ok(response);
        }
    }
}