using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using BandsInTown.IServices;
using BandsInTown.Models;
using Caliburn.Micro;

namespace BandsInTown.ViewModels
{
    public class LandingPageViewModel
    {
        private readonly ISearchArtistService _searchArtistService;

        public LandingPageViewModel(ISearchArtistService searchArtistService)
        {
            _searchArtistService = searchArtistService;
        }

        public async void SearchArtist()
        {
            var artist = await _searchArtistService.SearchArtist("Slayer");
            MessageDialog md = new MessageDialog(artist.upcoming_event_count);
            md.ShowAsync();
        }

        
    }
}
