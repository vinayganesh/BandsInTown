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
    public class LandingPageViewModel : Screen, IHandle<PropertyChangedBase>
    {
        private readonly IRecommendedArtistsService _recommendedArtistsService;
        private readonly IPopularEventsService _popularEventsService;
        private readonly ISearchEventsService _eventSearchService;

        private bool _showProgressBar;
        private int _selectedPivotIndex;

        private List<Event> _popularEvents;
        private List<RecommendedArtists> _recommendedArtists;

        public LandingPageViewModel(IRecommendedArtistsService recommendedArtistsService,
                                    IPopularEventsService popularEventsService,
            ISearchEventsService searchEventService)
        {
            _recommendedArtistsService = recommendedArtistsService;
            _popularEventsService = popularEventsService;
            _eventSearchService = searchEventService;
        }

        #region Properties

        public bool ShowProgressBar
        {
            get { return _showProgressBar; }
            set
            {
                _showProgressBar = value;
                NotifyOfPropertyChange(() => ShowProgressBar);
            }
        }

        public int SelectedPivotIndex
        {
            get { return _selectedPivotIndex; }
            set
            {
                _selectedPivotIndex = value;
                NotifyOfPropertyChange(() => SelectedPivotIndex);
            }
        }

        public List<RecommendedArtists> RecommendedArtists
        {
            get { return _recommendedArtists; }
            set
            {
                _recommendedArtists = value;
                NotifyOfPropertyChange(() => RecommendedArtists);
            }
        }

        public List<Event> PopularEvents
        {
            get { return _popularEvents; }
            set
            {
                _popularEvents = value;
                NotifyOfPropertyChange(() => PopularEvents);
            }
        }

        #endregion

        protected async override void OnInitialize()
        {
            Debug.WriteLine(SelectedPivotIndex);
            try
            {
                ShowProgressBar = true;
                var x = await _recommendedArtistsService.GetRecommendedArtists();
                RecommendedArtists = x;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                ShowProgressBar = false;
            }
        }

        protected async void PivotSelectionChanged(int i)
        {
            SelectedPivotIndex = i;

            if(SelectedPivotIndex==0)
            {
                if(RecommendedArtists==null)
                {
                    ShowProgressBar = true;
                    var x = await _recommendedArtistsService.GetRecommendedArtists();
                    RecommendedArtists = x;
                }
            }
            else if (SelectedPivotIndex == 1)
            {
                if(PopularEvents==null)
                {
                    ShowProgressBar = true;
                    PopularEvents = await _popularEventsService.GetPopularEvents();
                    ShowProgressBar = false;
                }
            }
        }

        public void Handle(PropertyChangedBase message)
        {
            throw new NotImplementedException();
        }
    }
}
