using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Input;
using BandsInTown.IServices;
using BandsInTown.Models;
using Caliburn.Micro;

namespace BandsInTown.ViewModels
{
    public class LandingPageViewModel:PropertyChangedBase
    {
        private readonly ISearchArtistService _searchArtistService;

        private string _artistName;

        //Dependency Injection
        public LandingPageViewModel(ISearchArtistService searchArtistService)
        {
            _searchArtistService = searchArtistService;
        }

        //this is used for binding data
        public string ArtistName
        {
            get { return _artistName; }
            set
            {
                _artistName = value;
                NotifyOfPropertyChange(() => ArtistName);
            }
        }

        //Search for artists
        public async void SearchArtist(ActionExecutionContext context)
        {
            try
            {
                var eventArgs = context.EventArgs as KeyRoutedEventArgs;
                if (eventArgs != null && eventArgs.Key == VirtualKey.Enter)
                {
                    var artist = await _searchArtistService.SearchArtist(ArtistName);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
        }

    }
}
