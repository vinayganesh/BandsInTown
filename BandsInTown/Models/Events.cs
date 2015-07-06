using HttpManager.DataContract;
using System.Collections.Generic;

namespace BandsInTown.Models
{
    public class Events
    {
        public string id { get; set; }
        public string title { get; set; }
        public string datetime { get; set; }
        public string ticket_url { get; set; }
        public string ticket_type { get; set; }
        public string ticket_status { get; set; }
        public string on_sale_datetime { get; set; }
        public string facebook_rsvp_url { get; set; }
        public string description { get; set; }
        public List<Artists> artists { get; set; }
        public Venue venue { get; set; }
        public string formatted_location { get; set; }
        public string formatted_datetime { get; set; }
    } 
}
