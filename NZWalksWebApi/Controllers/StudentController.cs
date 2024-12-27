using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalksWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        [HttpGet]
        public IActionResult Students()
        {
            string[] studntName = new string[] { "Nithushan" , "Janson"};
            return Ok(studntName);
        }
    }
}
