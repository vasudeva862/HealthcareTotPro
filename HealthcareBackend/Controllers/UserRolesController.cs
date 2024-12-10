using Microsoft.AspNetCore.Mvc;
using HealthCareTestingLabPortel.Models;
using HealthCareTestingLabPortel.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthCareTestingLabPortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleService _UserRoleservice;

        public UserRolesController(IUserRoleService healthCareService)
        {
            this._UserRoleservice = healthCareService;

        }

        // GET: api/<HealthCareController>
        [HttpGet]
        public ActionResult<List<UserRoles>> Get()
        {
            try
            {
                return _UserRoleservice.Get();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        // GET api/<HealthCareController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}




