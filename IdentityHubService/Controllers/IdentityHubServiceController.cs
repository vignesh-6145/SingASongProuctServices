using DataService.Models;
using IdentityHubService.Client;
using Microsoft.AspNetCore.Mvc;

namespace IdentityHubService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityHubServiceController : Controller
    {
        UserClient client;
        public IdentityHubServiceController() {
            client = new UserClient();
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult RegisterUser([FromBody] User User)
        {
            var response = client.Register(User);
            var responseMsg = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                return Ok(responseMsg);
            }
            return BadRequest(responseMsg);
        }
    }
}
