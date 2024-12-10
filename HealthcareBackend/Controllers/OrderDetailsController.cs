using HealthCareTestingLabPortel.Models;
using HealthCareTestingLabPortel.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthCareTestingLabPortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailsController(IOrderDetailService OrderDetailServices)
        {
            this._orderDetailService = OrderDetailServices;
        }
        // GET: api/<HealthCareController>
        [HttpGet("{role}/{userId}")]
        public ActionResult<List<Orderdetails>> Get(string role, int userId)
        {
            try
            {
                return _orderDetailService.Get(role, userId);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);

            }
        }


        // GET api/<HealthCareController>/5
        [HttpGet("{id}")]
        public ActionResult<Orderdetails> Get(int id)
        {
            try
            {
                var order = _orderDetailService.GetById(id);
                if (order == null)
                {
                    return NotFound($"Order with Id = {id} not found");
                }
                return order;

            }
            catch (Exception e)
            {
                return StatusCode(500, e);

            }

        }

        

        


        // POST api/<HealthCareController>
        [HttpPost]
        public ActionResult<Orderdetails> Post([FromBody] Orderdetails order)
        {
            try
            {
                _orderDetailService.Create(order);
                return CreatedAtAction(nameof(Get), new { id = order.RecordId }, order);
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // PUT api/<HealthCareController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Orderdetails order)
        {
            try
            {
                var existingOrder = _orderDetailService.GetById(id);
                if (existingOrder == null)
                {
                    return NotFound($"Order with id = {id} not found");
                }
                _orderDetailService.Update(id, order);
                return NoContent();
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }

        }

        // DELETE api/<HealthCareController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var existingOrder = _orderDetailService.GetById(id);
                if (existingOrder == null)
                {
                    return NotFound($"Order with id = {id} not found");
                }
                _orderDetailService.Delete(id);
                return Ok($"Order with id={id} deleted");
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}

