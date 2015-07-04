using BandsInTown.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandsInTown.IServices
{
    public interface IRecommendedArtistsService
    {
        Task<List<RecommendedArtists>> GetRecommendedArtists();
    }
}
