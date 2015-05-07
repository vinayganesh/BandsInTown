using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using BandsInTown.IServices;
using BandsInTown.Services;
using BandsInTown.ViewModels;
using BandsInTown.Views;
using Caliburn.Micro;

namespace BandsInTown
{
   
    public sealed partial class App 
    {
        private TransitionCollection transitions;

        private WinRTContainer _container;

        
        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }

        #region Caliburn Micro Methods

        protected override void Configure()
        {
            MessageBinder.SpecialValues.Add("$clickeditem", c => ((ItemClickEventArgs)c.EventArgs).ClickedItem);

            _container = new WinRTContainer();

            _container.RegisterWinRTServices();

            RegisterViewModels();
            RegisterServices();
        }

        protected override void OnWindowCreated(WindowCreatedEventArgs args)
        {
            args.Window.VisibilityChanged += Window_VisibilityChanged;
        }

        private void Window_VisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (!e.Visible)
            {
                OnExitAppNotification();
            }
        }

        private void OnExitAppNotification()
        {

        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            _container.RegisterNavigationService(rootFrame);
        }

        private void RegisterServices()
        {
            _container.Singleton<ISearchArtistService, SearchArtistService>();
            _container.Singleton<ISearchEventsService, SearchEventsService>();
        }

        private void RegisterViewModels()
        {
            _container.PerRequest<LandingPageViewModel>();
        }

        private void DisplayRootView()
        {
            DisplayRootView<LandingPageView>();
        }

        private static void PreInitialization()
        {
            var statusBar = StatusBar.GetForCurrentView();
            if (statusBar != null)
            {
                statusBar.BackgroundColor = Colors.Gray;
                statusBar.BackgroundOpacity = 1;
                statusBar.HideAsync();
            }
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        #endregion

        
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            PreInitialization();
            DisplayRootView();
        }

       
        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            rootFrame.Navigated -= this.RootFrame_FirstNavigated;
        }

        
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        protected async override void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.Exception != null)
            {
                //
            }
#if DEBUG
            e.Handled = true;
            var md = new MessageDialog(e.ToString());
            await md.ShowAsync();
#else
             base.OnUnhandledException(sender, e);
#endif
        }
    }
}