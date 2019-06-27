using System;
using Rg.Plugins.Popup.Pages;

namespace UpMovies.Views.Alerts
{
    public partial class SuccessView : PopupPage
    {
        //Ready to submit data
        private bool _buttonEnabled = false;

        public EventHandler SuccessPopupClosing;
        public SuccessView()
        {
            InitializeComponent();
            CloseWhenBackgroundIsClicked = false;
            _buttonEnabled = true;
        }

        void CloseAlert(object sender, System.EventArgs e)
        {
            if (_buttonEnabled)
            {
                _buttonEnabled = false;
                ClosePopUp();
            }
        }

        private void ClosePopUp()
        {
            _buttonEnabled = true;
            SuccessPopupClosing?.Invoke(this, null);
        }
    }
}