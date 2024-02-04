using CartService.Data;
using Microsoft.AspNetCore.Mvc;

namespace CartService.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class CartController : Controller
    {
        CartClient client;
        public CartController()
        {
            client = new CartClient();
        }
        [HttpGet]
        [Route("User/{UserID}/GetCartItems")]
        public IActionResult GetCartItem(int UserID)
        {
            var items = client.GetCartItems(UserID);
            if (items == null)
            {
                return BadRequest("Sorry Something Went Wrong");
            }
            return Ok(items);
        }

        [HttpDelete]
        [Route("User/{UserID}/AddTrack/{TrackID}")]
        public IActionResult DeleteTrackFromCart(int UserID, int TrackID)
        {
            var resp = client.DeleteFromCart(UserID, TrackID);
            if(resp == System.Net.HttpStatusCode.OK)
            {
                return Ok($"Track Removed From your Cart");
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("User/{UserID}/AddTrack/{TrackID}")]
        public IActionResult AddTrackToCart(int UserID, int TrackID)
        {
            var rsp = client.AddToCart(UserID, TrackID);
            if (rsp.Equals("Item Added to the Cart"))
            {
                return Ok(rsp);
            }
            return BadRequest("Failed to Fetch Info");
        }
        [HttpGet]
        [Route("GetCartPrice")]
        public IActionResult GetCartPrice(int UserID)
        {
            try
            {
                return Ok(client.GetCartPrice(UserID));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Wrong HAppend");
                Console.WriteLine(ex.Message );
                return BadRequest("Something Wrong Happend");
            }
        }
        [HttpDelete]
        [Route("DeleteCart/{UserID}")]
        public IActionResult DeleteCart(int UserID)
        {
            var response = client.DeleteCart(UserID);
            if(response == System.Net.HttpStatusCode.OK) { return Ok("Cart Removed"); }
            return BadRequest();
        }
    }
}
