using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandsInTown.Models
{
    public class Events
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string TicketUrl { get; set; }
        public string TicketType { get; set; }
        public string TicketStatus { get; set; }
        public string OnSaleDataTime { get; set; }
        public string FbrsvpUrl { get; set; }
        public string Description { get; set; }
        public List<Artist> Artists { get; set; }
        public Venue Venur { get; set; }
        public string FormattedLocation { get; set; }
        public string FormattedDateTime { get; set; }

        public class Artist
        {
            public string Website { get; set; }
            public string Name { get; set; }
            public string ImageUrl { get; set; }
            public string ThumbNailUrl { get; set; }
            public string FbTourDates { get; set; }
            public string Mbid { get; set; }
            public string Url { get; set; }
            public string TrackerCount { get; set; }
        }

        public class Venue
        {
            public string Country { get; set; }
            public string Name { get; set; }
            public double Latitude { get; set; }
            public string Region { get; set; }
            public double Longitude { get; set; }
            public string City { get; set; }
        }
    }
}
