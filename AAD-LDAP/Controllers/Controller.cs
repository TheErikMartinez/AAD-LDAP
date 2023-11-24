using Microsoft.AspNetCore.Mvc;
using AAD_LDAP.Context;
using AAD_LDAP.Interfaces;
using System.Security.Principal;
using Newtonsoft.Json;
using AAD_LDAP.Models;

namespace AAD_LDAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IAdContext _context;

        public UserController(IAdContext context) {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetUsers()
        {
            var res = _context.GetAllUsers();

            return Ok( res );
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetUser([FromRoute] string name)
        {
            var user = _context.GetAUser(name);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("external")]
        public async Task<IActionResult> GetExtUsers()
        {
            
                HttpClientHandler handler = new HttpClientHandler();
                handler.UseDefaultCredentials = true;                 

            HttpClient client = new HttpClient(handler);

            HttpResponseMessage response = await client.GetAsync("https://auth.hungaria.koerber.de/AllUsers/get-all");

            var jsonResponse = await response.Content.ReadAsStringAsync();

            ExternalUsersList extUs = JsonConvert.DeserializeObject<ExternalUsersList>(jsonResponse);

            handler.Dispose();
            client.Dispose();

            return Ok(extUs);
            
        }
    }
    
}
    

