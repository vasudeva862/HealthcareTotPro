using HealthCareTestingLabPortel.Models;
using HealthCareTestingLabPortel.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthCareTestingLabPortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisCategoryController : ControllerBase
    {
        private readonly IDiagnosisService _DiagnosisServices;

        public DiagnosisCategoryController(IDiagnosisService DiagnosisServices)
        {
            this._DiagnosisServices = DiagnosisServices;
        }
        // GET: api/<HealthCare>
        [HttpGet]
        public ActionResult<List<Diagnosis>> Get()
        {

            try
            {
                return Ok( _DiagnosisServices.Get());

            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Value";
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

