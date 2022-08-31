using Microsoft.AspNetCore.Mvc;

namespace Common.Api.Graphql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DefaultController : ControllerBase
    {
        public DefaultController()
        {

        }

        [HttpGet]
        public string Get()
        {
            return "Running Graphql Api..";
        }
    }
}