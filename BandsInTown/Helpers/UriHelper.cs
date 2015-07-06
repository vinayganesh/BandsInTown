using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace BandsInTown.Helpers
{
    public static class UriHelper
    {
        public static Uri GetArtistUri(string artistName)
        {
            var urlRequest = "http://api.bandsintown.com/artists/" + artistName + ".json?" + Constants.APIVersion + "&app_id=" + Constants.BandsInTownKey;
            var uri = new Uri(urlRequest);

            return uri;
        }

        public static Uri GetEvents(string artistName)
        {
            var urlRequest = "http://api.bandsintown.com/artists/" + artistName + "/" + "events.json?" + Constants.APIVersion + "&app_id=" + Constants.BandsInTownKey;
            var uri = new Uri(urlRequest);

            return uri;

        }

        public static async Task<Uri> GetAristEventBasedOnDistanceFromLocation(string artistName, int radius)
        {
            string location = await GeoCodeHelper.GetLocationFromLatLong();

            var urlRequest = "http://api.bandsintown.com/artists/" + artistName + "/" + "events/search.json?" + Constants.APIVersion + "&app_id=" + Constants.BandsInTownKey + "&location=" + location + "&radius=" + radius;
            var uri = new Uri(urlRequest);

            return uri;
          
        }

        public static Uri GetArtistUpcomingEventsBasedOnDates(string artistName, string location, string artistId, string startDate, string endDate)
        {
            var urlRequest = "http://api.bandsintown.com/artists/" + artistName + "/" + "events/search?format=json" + "&artist_id=" + artistId + "&" + Constants.APIVersion + "&app_id=" + Constants.BandsInTownKey + "&date=" + startDate + "," + endDate + "&location=" + location;
            var uri = new Uri(urlRequest);
            
            return uri;
           
        }

        public static async Task<Uri> GetRecommendedEvents(string artistName)
        {
            string location = await GeoCodeHelper.GetLocationFromLatLong();

            var urlRequest = "http://api.bandsintown.com/artists/" + artistName + "/events/recommended?location=" +
                             location + "&radius=100" + "&app_id=" + Constants.BandsInTownKey + "&" + Constants.APIVersion + "&fomat=json";
            var uri = new Uri(urlRequest);

            return uri;
        }

        public static async Task<Uri> GetPopularEventsNearby()
        {
            string location = await GeoCodeHelper.GetLocationFromLatLong();
         
            //Url encoding skips special characters
            location = Helpers.UrlEncodeHelper.UrlEncode(location);
            //Url encode skips space
            location = location.Replace(' ', '+');
         
            //https://app.bandsintown.com/events/popular?location=San+Francisco%2C+CA&radius=75&per_page=27&date=2015-07-02&authenticate=false
            var urlRequest = "http://app.bandsintown.com/events/popular?location=" + location + "&radius=" + Constants.DefaultRadius + "&per_page=27&date=" + DateTime.Today.ToString("yyyy-MM-dd") + "&authenticate=false";
            
            var uri = new Uri(urlRequest);
            return uri;
        }

        public static async Task<Uri> GetJustAnnounedEventsNearby()
        {
            string location = await GeoCodeHelper.GetLocationFromLatLong();

            //https://app.bandsintown.com/events/just_announced?location=San+Francisco%2C+CA&radius=75&per_page=15&authenticate=false
            var urlRequest = "http://app.bandsintown.com/events/just_announced?location=" + location + "&radius=" + Constants.DefaultRadius + "&per_page=27&authenticate=false";
            var uri = new Uri(urlRequest);
            return uri;
        }

        public static async Task<Uri> GetRecommendedArtists()
        {
            string location = await GeoCodeHelper.GetLocationFromLatLong();

            var urlRequest = "http://app.bandsintown.com/artists/recommended?popular=true" + "&per_page=50&authenticate=false";
            var uri = new Uri(urlRequest);
            return uri;
        }
    }
}
