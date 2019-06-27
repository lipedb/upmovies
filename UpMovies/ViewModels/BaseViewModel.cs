using System;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using UpMovies.Enum;
using UpMovies.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UpMovies.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        private bool _isInternetConnected = true;
        public bool IsInternetConnected
        {
            get { return _isInternetConnected; }
            set
            {
                SetProperty(ref _isInternetConnected, value);
                RaisePropertyChanged(nameof(IsInternetConnected));
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }


        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            Connectivity.ConnectivityChanged -= ConnectivityConnectivityChanged;
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
            Connectivity.ConnectivityChanged += ConnectivityConnectivityChanged;
            IsInternetConnected = Connectivity.NetworkAccess == NetworkAccess.Internet;
        }

        private void ConnectivityConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsInternetConnected = e.NetworkAccess == NetworkAccess.Internet;
            if (IsInternetConnected)
            {
                DismissAlert();
            }
            else
            {
                ShowOfflineAlert();
                OnInternetAvailable();
            }

        }

        protected void ShowOfflineAlert()
        {
            DependencyService.Get<ISnackBarNotification>().SnackbarShow("Offline!", String.Empty);
        }

        protected void DismissAlert()
        {
            DependencyService.Get<ISnackBarNotification>().SnackbarDismiss();
        }

        public virtual void OnInternetAvailable()
        {

        }

        public virtual void Destroy()
        {

        }

        protected Busy SetIsBusy(string message = "")
        {
            return new Busy(this, message);
        }

        protected bool CanExecuteSubmit()
        {
            return !IsBusy;
        }

        protected class Busy : IDisposable
        {
            private readonly object sync = new object();
            private readonly BaseViewModel viewModel;

            public Busy(BaseViewModel viewModel, string message)
            {
                this.viewModel = viewModel;
                lock (sync)
                {
                    viewModel.IsBusy = true;
                }
            }

            public void Dispose()
            {
                lock (sync)
                {
                    viewModel.IsBusy = false;
                }
            }
        }
    }
}

