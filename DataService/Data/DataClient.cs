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

            }catch (Exception ex)
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
        public  Track GetTrack(int TrackID)
        {
            string GetTrackURL = $"Tracks/{TrackID}";
            string track = null;

            try {
                var responseString = client.MakeGetAPICall(GetTrackURL);
                
                return ConvertToTrack(responseString);
            }
            catch (Exception ex) {
                Console.WriteLine("Failed to convert response to Model[track]");
                Console.WriteLine(ex.Message);  
            }
            return null;
            
        }
        private Track ConvertToTrack(string str)
        {
            var obj = JObject.Parse(str);
            return ConvertToTrack(obj);

        }
        private Track ConvertToTrack(JToken obj)
        {
            Track track = new Track();
            track.Name = (string)obj["name"];
            track.TrackId = int.Parse((string)obj["trackId"]);
            track.Album = (string)obj["album"];
            track.Artists = new List<string>();
            track.Artists.Add((string)obj["artists"][0]);

            track.Genres = new List<string>();
            track.Genres.Add((string)obj["genres"][0]);
            return track;
        }
    }
}
