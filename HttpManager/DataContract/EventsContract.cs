using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpManager.DataContract
{
    class EventsContract
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
       
        [JsonProperty("datetime")]
        public string Date { get; set; }
       
        [JsonProperty("ticket_url")]
        public string TicketUrl { get; set; }
       
        [JsonProperty("ticket_type")]
        public string TicketType { get; set; }
       
        [JsonProperty("ticket_status")]
        public string TicketStatus { get; set; }
       
        [JsonProperty("on_sale_datetime")]
        public string OnSaleDataTime { get; set; }
       
        [JsonProperty("facebook_rsvp_url")]
        public string FbrsvpUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("artists")]
        public List<Artist> Artists { get; set; }
        
        [JsonProperty("venue")]
        public Venue Venur { get; set; }

        [JsonProperty("formatted_location")]
        public string FormattedLocation { get; set; }

         [JsonProperty("formatted_datetime")]
        public string FormattedDateTime { get; set; }

        public class Artist
        {
            [JsonProperty("website")]
            public string Website { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("image_url")]
            public string ImageUrl { get; set; }

            [JsonProperty("thumb_url")]
            public string ThumbNailUrl { get; set; }

            [JsonProperty("facebook_tour_dates_url")]
            public string FbTourDates { get; set; }

            [JsonProperty("mbid")]
            public string Mbid { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("tracker_count")]
            public string TrackerCount { get; set; }


        }

        public class Venue
        {
            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("latitude")]
            public double Latitude { get; set; }

            [JsonProperty("region")]
            public string Region { get; set; }

            [JsonProperty("longitude")]
            public double Longitude { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }
        }
    }
}
