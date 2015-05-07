using System;
using System.Net.Http;
using System.Threading.Tasks;
using BandsInTown.Helpers;
using BandsInTown.IServices;
using BandsInTown.Models;
using Newtonsoft.Json;

namespace BandsInTown.Services
{
    public class SearchArtistService : ISearchArtistService
    {
        public async Task<Artists> SearchArtist(string artist)
        {
            Uri uri = UriHelper.GetArtistUri(artist);
            HttpResponseMessage response = await HttpManager.BitRequestManager.SendRequest(uri);

            var jsonMessage = await HttpManager.BitResponseManager.ReadResponse(response);

            var artists = (Artists)JsonConvert.DeserializeObject(jsonMessage, typeof(Artists));

            return artists;
        }
    }
}
