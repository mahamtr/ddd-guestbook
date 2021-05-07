using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
