using System;
using System.Windows.Input;

namespace UpMovies.ViewModels.Alerts
{
    public class AlertVM 
    {
        private string _message = String.Empty;
        private string _secondMessage = String.Empty;
        private bool _isError;
        private ICommand _closeCommand;

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

        public ICommand CloseCommand
        {
            get => _closeCommand;
            set => _closeCommand = value;
        }


        public bool IsSingleLine => !ShowSecondMessage;
        public bool ShowSecondMessage => !string.IsNullOrEmpty(SecondMessage);
        public bool ShowSuccessIcon => !_isError;
        public bool ShowErrorIcon => _isError;

        public AlertVM(string message, string secondMessage, bool isError, ICommand closeCommandAction)
        {
            _message = message;
            _secondMessage = secondMessage;
            _isError = isError;
            _closeCommand = closeCommandAction;
        }
    }
}

