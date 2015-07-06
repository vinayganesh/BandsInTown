using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpManager.DataContract
{
    class PopularEventsContract
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("artist_event_id")]
        public string ArtistEventId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("datetime")]
        public string Datetime { get; set; }
        [JsonProperty("formatted_datetime")]
        public string FormattedDatetime { get; set; }
        [JsonProperty("formatted_location")]
        public string FormattedLocation { get; set; }
        [JsonProperty("ticket_url")]
        public string TicketUrl { get; set; }
        [JsonProperty("ticket_type")]
        public string TicketType { get; set; }
        [JsonProperty("ticket_status")]
        public string TicketStatus { get; set; }
        [JsonProperty("on_sale_datetime")]
        public string OnSaleDatetime { get; set; }
        [JsonProperty("facebook_rsvp_url")]
        public string FacebookRsvpUrl { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("artists")]
        public List<Artist> Artists { get; set; }
        [JsonProperty("venue")]
        public Venue venue { get; set; }
        [JsonProperty("facebook_event_id")]
        public string FacebookEventId { get; set; }
        [JsonProperty("rsvp_count")]
        public int RsvpCount { get; set; }
        [JsonProperty("media_id")]
        public int? MediaId { get; set; }
    }

    public class Artist
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }
        [JsonProperty("large_image_url")]
        public string LargeImageUrl { get; set; }
        [JsonProperty("on_tour")]
        public bool OnTour { get; set; }
        [JsonProperty("events_url")]
        public string EventsUrl { get; set; }
        [JsonProperty("sony_id")]
        public string SonyId { get; set; }
        [JsonProperty("tracker_count")]
        public int TrackerCount { get; set; }
        [JsonProperty("verified")]
        public bool Verified { get; set; }
        [JsonProperty("media_id")]
        public int MediaId { get; set; }
    }

    public class Venue
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }

    public class Pages
    {
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
        [JsonProperty("results_per_page")]
        public int ResultsPerPage { get; set; }
        [JsonProperty("next_page_url")]
        public string NextPageUrl { get; set; }
        [JsonProperty("previous_page_url")]
        public object PreviousPageUrl { get; set; }
    }
}
