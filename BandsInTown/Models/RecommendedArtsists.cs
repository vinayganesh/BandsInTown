using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandsInTown.Models
{
    public class RecommendedArtists
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Image_Url { get; set; }
        public string Thumb_Url { get; set; }
        public string Large_Image_Url { get; set; }
        public bool On_Tour { get; set; }
        public string Events_Url { get; set; }
        public string Sony_Id { get; set; }
        public int Tracker_Count { get; set; }
        public bool Verified { get; set; }
        public int Media_Id { get; set; }
    }

    public class Pages
    {
        public int current_page { get; set; }
        public int total_results { get; set; }
        public int results_per_page { get; set; }
        public string next_page_url { get; set; }
        public object previous_page_url { get; set; }
    }

    public class RootObject
    {
        public List<RecommendedArtists> data { get; set; }
        public Pages pages { get; set; }
    }
}

