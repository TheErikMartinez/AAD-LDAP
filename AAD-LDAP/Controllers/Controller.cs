using Microsoft.AspNetCore.Mvc;
using AAD_LDAP.Context;

namespace AAD_LDAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AdContext _context;
        public UserController(AdContext context) {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok( _context.GetAllUsers );
        }
    }
    
}
    

