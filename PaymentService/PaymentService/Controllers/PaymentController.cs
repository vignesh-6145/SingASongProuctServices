using DataService.Models;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Data;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PaymentController : Controller
    {
        PaymentClient client;
        public PaymentController()
        {
            client = new PaymentClient();
        }
        [HttpGet]
        [Route("getRecord/{PaymentID}")]
        public IActionResult GetPaymentRecord(int PaymentID) { 
            var record = client.GetRecord(PaymentID);
            if(record == null) return NotFound($"No Record Found");
            else return Ok(record);
        }
        [HttpPost]
        [Route("getPaymentHistory")]
        public IActionResult GetPaymenthistory()
        {
            var record = client.GetPaymentHistory();
            if (record == null) return NotFound($"No Records Found");
            else return Ok(record);
        }
        [HttpGet]
        [Route("AddRecord")]
        public IActionResult GetPaymenthistory([FromBody] Payment Payment)
        {
            var record = client.AddPaymentRecord(Payment);
            if (record == System.Net.HttpStatusCode.OK) return Ok("Inserted Successfiully");
            else return BadRequest("Something Went Wrong");
        }
    }
}
