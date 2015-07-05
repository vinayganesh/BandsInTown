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

        private bool _showProgressBar;
        private int _selectedPivotIndex;
        private List<RecommendedArtists> _recommendedArtists;

        public LandingPageViewModel(IRecommendedArtistsService recommendedArtistsService)
        {
            _recommendedArtistsService = recommendedArtistsService;
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

        protected void PivotSelectionChanged(int i)
        {
            SelectedPivotIndex = i;

            if(SelectedPivotIndex==0)
            {
                //get recommended artsits
            }
            else if(SelectedPivotIndex==1)
            {
                //get popular events
            }

        }

        public void Handle(PropertyChangedBase message)
        {
            throw new NotImplementedException();
        }
    }
}
