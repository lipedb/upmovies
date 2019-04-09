using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using UpMovies.Enum;
using UpMovies.Interfaces;
using UpMovies.Resources.Languages;
using UpMovies.ViewModels.Alerts;
using Xamarin.Forms;

namespace UpMovies.Services.Local
{
    public class Alert : IAlert
    {
        private string _message = String.Empty;
        private string _secondMessage = String.Empty;
        private DialogType _type;
        event EventHandler _closeDialog;

        //Made the report System ready , if the app needs one in the future 
        //protected ILog Logger { get; set; }

        public event EventHandler CloseDialog
        {
            add
            {
                _closeDialog += value;
            }
            remove
            {
                _closeDialog -= value;
            }
        }

        public Alert()
        {

        }

        public Alert(string message, string secondMessage, DialogType type)
        {
            _message = message;
            _secondMessage = secondMessage;
            _type = type;

            //Logger = DependencyService.Get<ILog>();
        }

        public void SetData(string message, string secondMessage, DialogType type)
        {
            _message = message;
            _secondMessage = secondMessage;
            _type = type;
        }

        public string Message
        {
            get => _message; 
            set => _message = value;
        }

        public string SecondMessage
        {
            get => _secondMessage;
            set => _secondMessage = value;
        }

        public DialogType Type
        {
            get => _type;
            set => _type = value;
        }


        public async Task Dismiss()
        {
            try
            {
                if (PopupNavigation.Instance.PopupStack.Any())
                {
                    await PopupNavigation.Instance.PopAsync();
                }
            }
            catch (Exception e)
            {
                //Logger.Log(LogType.Error, $"Page: {nameof(Alert)}, in method {nameof(Dismiss)}", e);
                if (e.Message.Contains(AppResources.MessagePopupException))
                {
#if DEBUG
                    Debug.WriteLine(AppResources.MessageGenericException + AppResources.StringUtilsSpace + e.Message);
#endif
                }
                else
                {
                    throw;
                }
            }
            finally
            {
                _closeDialog?.Invoke(this, new EventArgs());
            }
        }

        async public Task Show()
        {
            PopupPage modalPage;
            Command closeCommand = new Command(() =>
            {
                this.Dismiss();
            });

            switch (this.Type)
            {
                case DialogType.Error:
                    {
                        modalPage = new Views.Alerts.ErrorView();
                        modalPage.BindingContext = new AlertVM(Message, SecondMessage, true, closeCommand);
                        break;
                    }
                case DialogType.Success:
                    {
                        modalPage = new Views.Alerts.SuccessView();
                        modalPage.BindingContext = new AlertVM(Message, SecondMessage, false, closeCommand);
                        break;
                    }
                case DialogType.Progress:
                    {
                        modalPage = new Views.Alerts.LoadingView();
                        modalPage.BindingContext = new AlertVM(Message, String.Empty, false, closeCommand);
                        break;
                    }
                default:
                    modalPage = new Views.Alerts.LoadingView();
                    modalPage.BindingContext = new AlertVM(Message, String.Empty, false, closeCommand);
                    break;


            }


            await PopupNavigation.Instance.PushAsync(modalPage);
        }

        public IReadOnlyList<PopupPage> GetPopupPages()
        {
            return PopupNavigation.Instance.PopupStack;
        }
    }
}

