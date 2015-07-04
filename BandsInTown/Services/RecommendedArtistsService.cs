using BandsInTown.Helpers;
using BandsInTown.IServices;
using BandsInTown.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BandsInTown.Services
{
    public class RecommendedArtistsService : IRecommendedArtistsService
    {
        public async Task<List<RecommendedArtists>> GetRecommendedArtists()
        {
            Uri uri = await UriHelper.GetRecommendedArtists();

            HttpResponseMessage response = await HttpManager.BitRequestManager.SendRequest(uri);
            var jsonMessage = await HttpManager.BitResponseManager.ReadResponse(response);

            //Since the json object returned has a root node "data" it is being removed
            var recArtists = JObject.Parse(jsonMessage).SelectToken("data").ToString();

            var Artists = (List<RecommendedArtists>)JsonConvert.DeserializeObject(recArtists, typeof(List<RecommendedArtists>));
            return Artists;
        }
    }
}
