using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandsInTown.Models;

namespace BandsInTown.IServices
{
    public interface ISearchEventsService
    {
        Task<List<Events>> GetArtistsEvents(string artist);
    }
}
