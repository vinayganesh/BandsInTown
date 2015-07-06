using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandsInTown.IServices;
using BandsInTown.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BandsInTown.Services
{
    public class SearchEventsService : ISearchEventsService
    {
        public async Task<List<Events>>  GetArtistsEvents(string artist)
        {
            Uri uri = Helpers.UriHelper.GetEvents(artist);
            HttpResponseMessage response = await HttpManager.BitRequestManager.SendRequest(uri);

            var jsonMessage = await HttpManager.BitResponseManager.ReadResponse(response);

            var artistEvents = (List<Events>)JsonConvert.DeserializeObject(jsonMessage, typeof(List<Events>));

            return artistEvents;

        }
    }
}
