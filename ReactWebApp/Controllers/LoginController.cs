using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace ReactWebApp.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/{controller}")]
    [ApiController]
    public class LoginController : Controller
    {
        public IConfiguration _configuration;
        public LoginController(IConfiguration config)
        {
            _configuration = config;
        }
        [HttpPost, Route("forgotpassword")]
        public IActionResult ForgotPassword([FromBody] string email)
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Ok("Success");
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("GetAccounts")]
        public IActionResult GetAccounts(int smartGroup, int pageNumber)
        {
            int defaultRecords = 9;
            List<int> vs = new List<int>() { 1,2,3,4,5,6,7,8,9,
            10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,
            33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60};
            vs = vs.Skip(defaultRecords * (pageNumber-1)).Take(defaultRecords).ToList();
            return Ok(vs);
        }
    }
}
