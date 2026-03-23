using CashFlow.Application.UseCases.Users.Criar;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateUser),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(
            [FromServices] ICreateUserUseCase useCase,
            [FromBody] RequestCreateUser request)
        {
            var response = await useCase.Execute(request);
            
            return Created(String.Empty, response);
        }
        
    }
}
