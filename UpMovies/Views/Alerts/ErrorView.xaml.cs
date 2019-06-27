using System;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;


namespace UpMovies.Views.Alerts
{
    public partial class ErrorView : PopupPage
    {
        public ErrorView()
        {
            InitializeComponent();
            CloseWhenBackgroundIsClicked = false;
        }

        async void CloseAlert(object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}
