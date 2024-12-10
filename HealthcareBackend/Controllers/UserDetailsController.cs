using Microsoft.AspNetCore.Mvc;
using HealthCareTestingLabPortel.Models;
using HealthCareTestingLabPortel.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthCareTestingLabPortel.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailsService userDetailsService;
        public UserDetailsController(IUserDetailsService UserDetailsService)
        {
            this.userDetailsService = UserDetailsService;
        }
        // GET: api/<HealthCareController>
        [HttpGet]
        public ActionResult<List<UserDetails>> Get()
        {
            try
            {
                return userDetailsService.Get();
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // GET api/<HealthCareController>/5
        [HttpGet("{id}")]
        public ActionResult<UserDetails> Get(int id)
        {
            var user = userDetailsService.GetById(id);
            if (user == null)
            {
                return NotFound($"User withId={id} not found");
            }
            return user;
        }


        // POST api/<HealthCareController>
        [HttpPost]
        public ActionResult<UserDetails> Post([FromBody] UserDetails user)
        {
            var obj = userDetailsService.Get();
            List<String> EmailList = new List<String>();
            for(int i = 0;i < obj.Count;i++)
            {
                EmailList.Add(obj[i].Emailaddress);

            }
            if(EmailList.Contains(user.Emailaddress))
            {
                Console.WriteLine("Not Found");
                return StatusCode(409, $"User '{user.Emailaddress}' already exists");
            }
            else
            {
                userDetailsService.Create(user);
                return CreatedAtAction(nameof(Get), new { id = user.RecordId }, user);
            }
        }

        // PUT api/<HealthCareController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserDetails user)
        {
            var existingUser = userDetailsService.GetById(id);
            if (existingUser == null)
            {
                return NotFound($"User with id={id} not found");
            }
            var obj = userDetailsService.Get();
            List<String> EmailList=new List<String>();
            for(int i=0; i<obj.Count;i++)
            {
                if (obj[i].Emailaddress != existingUser.Emailaddress)
                {
                    EmailList.Add(obj[i].Emailaddress);
                }
            }
            if (EmailList.Contains(user.Emailaddress))
            {
                return StatusCode(409, $"User '{user.Emailaddress}' already exists. ");
            }
            else
            {
                userDetailsService.Update(id, user);
                return NoContent();

            }

        }

        // DELETE api/<HealthCareController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingUser = userDetailsService.GetById(id);
            if (existingUser == null)
            {
                return NotFound($"User with id={id} not found");
            }
            userDetailsService.Delete(id);
            return Ok($"User with id={id} deleted");
        }
    }
}
