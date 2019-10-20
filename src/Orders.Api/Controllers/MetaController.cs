using Microsoft.AspNetCore.Mvc;

namespace Orders.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MetaController : ControllerBase
    {
        [HttpGet]
        [Route("ready")]
        public ActionResult IsReady()
        {
            return Ok();
        }

        [HttpGet]
        [Route("healthy")]
        public ActionResult IsHealthy()
        {
            return Ok();
        }
    }
}