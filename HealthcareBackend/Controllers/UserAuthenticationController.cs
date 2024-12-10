using HealthCareTestingLabPortel.Models;
using HealthCareTestingLabPortel.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthCareTestingLabPortel.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IUserAuthenticationService _UserAuthenticationService;
        public UserAuthenticationController(IUserAuthenticationService UserAuthenticationService)
        {
            this._UserAuthenticationService = UserAuthenticationService;
        }

        // GET: api/<UserAuthenticationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserAuthenticationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserAuthenticationController>
        [HttpPost]
        public ActionResult Authenticate([FromBody] UserDetails userdetails)
        {
            try
            {
                var obj = _UserAuthenticationService.GetDetails(userdetails.Emailaddress, userdetails.Role);
                Console.WriteLine(obj);
                Console.WriteLine($"Password in userdetail is {userdetails.Password}");
                if (obj == null)
                {
                    return NotFound($"Username {userdetails.Emailaddress} or Selected Role is invalid");
                }
                else if(obj.Password != userdetails.Password)
                {
                    return NotFound($"The password you have entered is incorrect");
                }
                else
                {
                    return Ok(new
                    {
                        isloggedin = "true",
                 message = "Login Success",
                 userDetails = obj
                    });
                }

            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }

        }

        // PUT api/<UserAuthenticationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
           
        }

        // DELETE api/<UserAuthenticationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
