using System;
using Rg.Plugins.Popup.Pages;


namespace UpMovies.Views.Alerts
{
    public partial class LoadingView : PopupPage
    {
        public LoadingView()
        {
            InitializeComponent();
            CloseWhenBackgroundIsClicked = false;
        }
    }
}
