using CartService.Models;
using DataService.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IO.Pipes;
using System.Net;

namespace CartService.Data
{
    public class CartClient
    {
        APIClient client;
        public CartClient()
        {
            client = new APIClient("https://localhost:7197/");
        }
        public HttpStatusCode DeleteCart(int UserID)
        {
            var DeleteCartURL = $"api/Cart/DisableCart/{UserID}";
            return client.MakeDeleteCall(DeleteCartURL);    
        }
        public HttpStatusCode DeleteFromCart(int UserID, int TrackID)
        {
            var DeleteTrackFromCartURL = $"api/cart/User/{UserID}/RemoveFromCart/{TrackID}";
            var response = client.MakeDeleteCall(DeleteTrackFromCartURL);
            return response;
        }
        public string AddToCart(int UserID, int TrackID)
        {
            string AddToCartURL = $"api/Cart/User/{UserID}/AddToCart/{TrackID}";
            var responseStr = client.MakePostCall(AddToCartURL);
            return responseStr;
        }
        public decimal GetCartPrice(int UserID)
        {
            var GetCartPriceURL = $"api/Cart/{UserID}/GetTotalPrice";
            var responsestring = client.MakeGetAPICall(GetCartPriceURL);
            return Convert.ToDecimal(responsestring);
        }
        public IEnumerable<CartItem> GetCartItems(int UserID)
        {
            string GetCartItemsAPI = $"api/Cart/User/{UserID}/GetTracks";
            var responseStr = client.MakeGetAPICall(GetCartItemsAPI);
            JArray arr = JArray.Parse(responseStr);
            List<CartItem> items = new List<CartItem>();
            foreach (var item in arr)
            {
                var crrTrack = DataClient.ConvertToTrack(item);
                CartItem cartItem = new CartItem()
                {
                    Id = crrTrack.TrackId,
                    Name = crrTrack.Name,
                    Price = crrTrack.Price,
                    Discount = 0

                };
                items.Add(cartItem);    
            }
            return items;

        }
    }
}
