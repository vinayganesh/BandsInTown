using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpManager.DataContract
{
    class ArtistContract
    {
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

        [JsonProperty("upcoming_Events_count")]
        public string UpcomingEventsCount { get; set; }

        [JsonProperty("tracker_count")]
        public string TrackerCount { get; set; }
    }
}
