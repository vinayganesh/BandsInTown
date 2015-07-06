using BandsInTown.Helpers;
using BandsInTown.IServices;
using BandsInTown.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BandsInTown.Services
{
    public class PopularEventsService : IPopularEventsService
    {
        public async Task<List<Event>> GetPopularEvents()
        {
            Uri uri = await UriHelper.GetPopularEventsNearby();

            HttpResponseMessage response = await HttpManager.BitRequestManager.SendRequest(uri);
            var jsonMessage = await HttpManager.BitResponseManager.ReadResponse(response);

            //var popEvents = JObject.Parse(jsonMessage).SelectToken("data").SelectToken("events").ToString();

            var events = (List<Event>)JsonConvert.DeserializeObject(jsonMessage, typeof(List<Event>));
            return events;
        }
    }
}
