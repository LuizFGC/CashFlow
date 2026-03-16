using CashFlow.Application.UseCases.Despesas.Deletar;
using CashFlow.Application.UseCases.Despesas.GetAll;
using CashFlow.Application.UseCases.Despesas.Registrar;
using CashFlow.Application.UseCases.Despesas.GetById;
using CashFlow.Application.UseCases.Despesas.Update;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Despesas;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class DespesasController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegistrarDespesa),  StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseRegistrarDespesa),  StatusCodes.Status400BadRequest)]
        public async Task< IActionResult> Registrar(
            [FromServices] IRegistrarDespesaUseCase useCase,
            [FromBody] RequestDespesa request)
        {

            var response = await useCase.Execute(request);

            return Created(String.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseDespesas), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll([FromServices] IGetAllDespesasUseCase useCase)
        {
            var response = await useCase.Execute();
            
            if (response.Despesas.Count!= 0)
                return Ok(response);
            
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseDespesaById), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromServices] IGetDespesasByIdUseCase useCase, [FromRoute] long id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            [FromServices] IDeleteDespesaUseCase useCase,
            [FromRoute] long id)
        {
            await useCase.Execute(id);
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
            [FromServices] IUpdateDespesaUseCase useCase,
            [FromRoute] long id,
            [FromBody] RequestDespesa request)
        {
            await useCase.Execute(id, request);
            
            return NoContent();
        }
    }
}
