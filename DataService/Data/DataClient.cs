using DataService.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Data
{
    public class DataClient
    {
        APIClient client;
        private string DataApiURL = "https://localhost:7197/Data/";

        public DataClient()
        {
            client = new APIClient(DataApiURL);
        }

        public HttpStatusCode AddTrack(Track track)
        {
            string AddTrackURL = "AddTrack";
            return client.MakePostCall(AddTrackURL, track);
        }
        public IEnumerable<Track> GetTracks()
        {
            string GetTracksURL = $"Tracks/GetAllTracks";
            List<Track> tracks = null;
            try
            {
                tracks = new List<Track>();
                var responseStr = client.MakeGetAPICall(GetTracksURL);
                JArray arr = JArray.Parse(responseStr);
                foreach (var track in arr)
                {
                    tracks.Add(ConvertToTrack(track));
                }
                return tracks;

            }
            catch (Exception ex)
            {
                // print custom error message in future
                Console.WriteLine(ex.Message);
            }
            return tracks;

        }

        public HttpStatusCode DeleteTrack(int TrackID)
        {
            string DeleteTrackURL = $"Tracks/{TrackID}";
            return client.MakeDeleteCall(DeleteTrackURL);
        }
        public HttpStatusCode UpdateTrack(Track track)
        {
            string UpdateTrackURL = "UpdateTrack";
            return client.MakePutCall(UpdateTrackURL, track);
        }
        public Track GetTrack(int TrackID)
        {
            string GetTrackURL = $"Tracks/{TrackID}";
            string track = null;

            try
            {
                var responseString = client.MakeGetAPICall(GetTrackURL);

                return ConvertToTrack(responseString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to convert response to Model[track]");
                Console.WriteLine(ex.Message);
            }
            return null;

        }
        public static Track ConvertToTrack(string str)
        {
            var obj = JObject.Parse(str);
            return ConvertToTrack(obj);

        }
        public static Track ConvertToTrack(JToken obj)
        {
            Track track = new Track();
            track.Name = (string)obj["name"];
            track.TrackId = int.Parse((string)obj["trackId"]);
            track.Price = decimal.Parse((string)obj["price"]);
            track.AlbumId = int.Parse(obj["albumID"].ToString());
            return track;
        }

        public static Album ConvertToAlbum(string str)
        {
            var obj = JObject.Parse(str);
            return ConvertToAlbum(obj);
        }
        public static Album ConvertToAlbum(JToken obj)
        {
            Album Album = new Album();
            Album.AlbumID = int.Parse((string)obj["albumID"]);
            Album.Name = obj["name"].ToString();
            Album.RealeasedOn = DateOnly.Parse(obj["realeasedOn"].ToString());

            Album.ProviderID = int.Parse(obj["providerID"].ToString());
            return Album;
        }
        public static Artist ConvertToArtist(string str)
        {
            var obj = JObject.Parse(str);
            return ConvertToArtist(obj);
        }

        public static Genre ConverToGenre(string str)
        {
            JToken obj = JToken.Parse(str);
            return ConvertToGenre(obj);
        }
        public static Genre ConvertToGenre(JToken Obj)
        {
            return new Genre()
            {
                Id = int.Parse((string)Obj["id"]),
                Name = Obj["name"].ToString()
            };
        }
        public static Artist ConvertToArtist(JToken Obj)
        {
            return new Artist()
            {
                ArtistId = int.Parse(Obj["artistId"].ToString()),
                ArtistName = Obj["artistName"].ToString(),
                DOB = DateOnly.Parse(Obj["dob"].ToString())
            };
        }

        public static Payment ConverToPayment(string str)
        {
            JToken obj = JToken.Parse(str);
            return ConverToPayment(obj);
        }
        public static Payment ConverToPayment(JToken Obj)
        {
            Payment payment = new Payment();
            payment.PaymentId = int.Parse(Obj["paymentId"].ToString());
            
            payment.PurchaseType = Obj["purchaseType"].ToString();
            payment.PurchaseStatus = (PaymentStatus)(int.Parse(Obj["purchaseStatus"].ToString()));
            payment.CartID = int.Parse(Obj["cartID"].ToString());
            return payment;

        }
    }
}
