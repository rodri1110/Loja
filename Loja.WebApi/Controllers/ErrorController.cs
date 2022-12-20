using Microsoft.AspNetCore.Mvc;
using Loja.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;

namespace Loja.WebApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public ErrorResponseModelView Error()
        {
            var contexto = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = contexto?.Error;

            Response.StatusCode = 500;

            var idErro = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            return new ErrorResponseModelView(idErro);
        }
    }
}
