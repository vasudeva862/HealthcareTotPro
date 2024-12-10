using HealthCareTestingLabPortel.Models;
using HealthCareTestingLabPortel.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthCareTestingLabPortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabdetailsController : ControllerBase
    {
        private readonly ILabDetailService _LabDetailsServices;
        // GET: api/<labdetails>
        public LabdetailsController(ILabDetailService LabDetailsServices)
        {
            this._LabDetailsServices = LabDetailsServices;
        }
        [HttpGet]
        public ActionResult<List<LabDetails>> Get()
        {
            try
            {
                return _LabDetailsServices.Get();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);

            }
        }

        // GET api/<labdetails>/5
        [HttpGet("{id}")]
        public ActionResult<LabDetails> Get(int id)
        {
            try
            {
                var lab = _LabDetailsServices.GetById(id);
                if (lab == null)
                {
                    return NotFound($"lab with Id = {id} not found");
                }
                return lab;
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // POST api/<labdetails>
        [HttpPost]
        public ActionResult<LabDetails> Post([FromBody] LabDetails lab)

        {
            try
            {
                _LabDetailsServices.Create(lab);
                return CreatedAtAction(nameof(Get), new { id = lab.RecordId }, lab);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);

            }
        }
        // PUT api/<labdetails>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] LabDetails lab)
        {
            try
            {
                var existinglab = _LabDetailsServices.GetById(id);
                if (existinglab == null)
                {
                    return NotFound($"lab with Id = {id} not found");
                }
                _LabDetailsServices.Update(id, lab);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var existingLab = _LabDetailsServices.GetById(id);
                if (existingLab == null)
                {
                    return NotFound($"lab with Id={id} not found");
                }
                _LabDetailsServices.Delete(id);
                return Ok($"lab with id={id} deleted");


            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
