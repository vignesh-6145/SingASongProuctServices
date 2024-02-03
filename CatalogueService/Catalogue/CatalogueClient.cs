using CatalogueService.Models;
using DataService.Data;
using DataService.Models;
using Newtonsoft.Json.Linq;

namespace CatalogueService.Catalogue
{
    public class CatalogueClient
    {
        APIClient client;
        public CatalogueClient()
        {
            client = new APIClient("https://localhost:7197/Data/");
        }

        public CatalogueItem buildCatalogueItem(Track track)
        {
            CatalogueItem item = new CatalogueItem();
            item.ID = track.TrackId;
            item.Name = track.Name;
            item.Price = track.Price;
            item.Album = GetAlbum(track.AlbumId).Name;
            item.Artists = GetTrackArtist(track.TrackId).Select(record => record.ArtistName);
            item.Genres = GetTrackGenres(track.TrackId).Select(record => record.Name);
            return item;
        }
        public CatalogueItem GetCatalogueItem(int TrackId)
        {
            Track track = GetTrack(TrackId);
            return buildCatalogueItem(track);
        }
        public IEnumerable<CatalogueItem> GetCatalogueItems()
        {
            IEnumerable<Track> tracks = GetTracks();
            List<CatalogueItem> items = new List<CatalogueItem>();
            foreach (var track in tracks) {
                items.Add(buildCatalogueItem(track));
            }
            return items;
        }
        public Album GetAlbum(int AlbumID)
        {
            string AlbumURL = $"Albums/{AlbumID}";
            return DataClient.ConvertToAlbum(client.MakeGetAPICall(AlbumURL));
        }

        public IEnumerable<Genre> GetTrackGenres(int TrackID)
        {
            string TrackGenres = $"Tracks/{TrackID}/Genres";
            var responseStr = client.MakeGetAPICall(TrackGenres);
            JArray arr = JArray.Parse(responseStr);
            List<Genre> Genres = new List<Genre>();
            foreach (var item in arr)
            {
                Genres.Add(DataClient.ConvertToGenre(item));
            }
            return Genres;
        }
        public IEnumerable<Artist> GetTrackArtist(int TrackID)
        {
            string TrackArtsitURL = $"Tracks/{TrackID}/Artists";
            var responseStr = client.MakeGetAPICall(TrackArtsitURL);
            JArray arr = JArray.Parse(responseStr);
            IList<Artist> Artists = new List<Artist>();
            foreach (var artist in arr)
            {
                Artists.Add(DataClient.ConvertToArtist(artist));
            }
            return Artists;
        }
        public IEnumerable<Track> GetTracks()
        {
            string GetTracksURL = $"Tracks/GetAllTracks";
            var responeStr =  client.MakeGetAPICall(GetTracksURL);
            JArray arr = JArray.Parse(responeStr);
            List<Track> tracks  = new List<Track>();
            foreach (var track in arr)
            {
                tracks.Add(DataClient.ConvertToTrack(track));
            }
            return tracks;

        }
        public Track GetTrack(int TrackID)
        {
            string TrackURL = $"Tracks/{TrackID}";
            var responseStr = client.MakeGetAPICall(TrackURL);
            return DataClient.ConvertToTrack(responseStr);
        }
    }
}
