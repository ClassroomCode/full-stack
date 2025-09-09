using Microsoft.AspNetCore.Mvc;

namespace EComm.Controllers
{
    [ApiController]
    public class ErrorController(ILogger logger) : ControllerBase
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError()
        {
            logger.LogCritical("BAD THINGS!!!");

            return Problem();
        }
    }
}
