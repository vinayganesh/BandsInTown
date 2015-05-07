using System;

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
    }
}
