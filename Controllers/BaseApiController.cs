using Microsoft.AspNetCore.Mvc;

namespace ServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    { }
}