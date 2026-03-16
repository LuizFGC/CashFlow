using CashFlow.Communication.Responses;
using CashFlow.Exeception;
using CashFlow.Exeception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CashFlowException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        
        var cashFlowException = (CashFlowException)context.Exception;
        var errorResponse = new ResponseError(cashFlowException.GetErrors());
        
        context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
        
    }
    
    private void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ResponseError(ResourceErrorMessages.Erro_Desconhecido);
        
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}