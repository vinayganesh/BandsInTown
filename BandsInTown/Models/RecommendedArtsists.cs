using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandsInTown.Models
{
    public class RecommendedArtists
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string image_url { get; set; }
        public string thumb_url { get; set; }
        public string large_image_url { get; set; }
        public bool on_tour { get; set; }
        public string events_url { get; set; }
        public string sony_id { get; set; }
        public int tracker_count { get; set; }
        public bool verified { get; set; }
        public int media_id { get; set; }

    }
}

