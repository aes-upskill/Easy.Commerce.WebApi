using Microsoft.AspNetCore.Mvc;

namespace Easy.Commerce.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Welcome to Easy Commerce Api";
        }
    }
}