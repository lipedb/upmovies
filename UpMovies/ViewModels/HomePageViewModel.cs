using System;
using System.Threading.Tasks;
using Prism.Navigation;
using UpMovies.Enum;
using UpMovies.Interfaces;
using UpMovies.Models.Response;
using UpMovies.Services.Remote;
using Xamarin.Forms;

namespace UpMovies.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private int _currentPageIndex = 1;
        public int CurrentPageIndex
        {
            get => _currentPageIndex;
            set => _currentPageIndex = value;
        }

        private void RetriveMovies()
        {
            if(IsInternetConnected)
            {
                Task.Run(async () => { await GetMoviesRoutineAsync(CurrentPageIndex.ToString()); });
            }
            else
            {
                DependencyService.Get<ISnackBarNotification>().SnackbarShow("Offline! Please connect to use this app!", String.Empty);
            }

        }

        async Task GetMoviesRoutineAsync(string page)
        {
            var getMoviesAsyc = await RESTServices.RetriveMoviesToServerAsync(page);
            string response = getMoviesAsyc;
            UpcomingMoviesResponse upcomingMovies = UpcomingMoviesResponse.FromJson(response);
        }

        public HomePageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            RetriveMovies();
        }
    }
}
