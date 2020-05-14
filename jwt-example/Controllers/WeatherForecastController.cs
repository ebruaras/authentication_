using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwt_example.Model;
using jwt_example.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace jwt_example.Controllers
{
    //Authorize attribute ile bu sınıfı sadece yetkisi yani tokenı olan kişilerin girmesini söylüyorum.
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IUserService _userService;
        public WeatherForecastController(IUserService userService) => _userService = userService;

        //Burada da AllowAnonymous attribute nü kullanarak bu seferde bu metoda herkesin erişebileceğini söylüyorum.
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody]AuthenticateModel authenticateModel)
        {
            var user = _userService.Authenticate(authenticateModel.Username, authenticateModel.Password);
            if (user == null)
            {
                return BadRequest("Username or password incorrect");
            }
            return Ok(new { Username = user.Value.username, Token = user.Value.token });

        }
        [HttpGet]
        public IActionResult GetSummaries() => Ok(Summaries);



    }
}
