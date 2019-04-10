using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UpMovies.Models;
using UpMovies.Models.Response;
using UpMovies.Services.Remote;
using Xamarin.Forms;

namespace UpMovies
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            RetriveMovies();
        }

        private void RetriveMovies()
        {
            Task.Run(async () => { await OnLogginSucceedRoutineAsync("1"); });
        }

        async Task OnLogginSucceedRoutineAsync(string page)
        {
            var getMoviesAsyc = await RESTServices.RetriveMoviesToServerAsync(page);
            string response  = getMoviesAsyc;
            UpcomingMoviesResponse upcomingMovies = UpcomingMoviesResponse.FromJson(response);
        }
    }
}
