using DataService.Data;
using DataService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SingASongProuctServices.Controllers
{
    public class SingASongProductController : Controller
    {

        DataClient Client;

        public SingASongProductController()
        {
            Client = new DataClient();
        }

        [HttpGet]
        [Route("Product/GetAllTracks")]
        public IEnumerable<Track> GetTracks()
        {
            return Client.GetTracks();
        }

        [HttpGet]
        [Route("Product/GetTrack/{TrackID}")]
        public Track GetTrack(int TrackID)
        {
            return Client.GetTrack(TrackID);

        }

        [HttpPost]
        [Route("Product/AddTrack")]
        public HttpStatusCode AddTrack(Track track)
        {
            return Client.AddTrack(track);
        }

        [HttpPut]
        [Route("Product/UpdateTrack")]
        public HttpStatusCode UpdateTrack(Track track)
        {
            return Client.UpdateTrack(track);
        }

        [HttpDelete]
        [Route("Product/DeleteTrack")]
        public HttpStatusCode DeleteTrack(int TrackId)
        {
            return Client.DeleteTrack(TrackId);

        }
    }
}
