using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using UpMovies.Enum;

namespace UpMovies.Interfaces
{
    public interface IAlert
    {

        string Message { get; set; }

        string SecondMessage { get; set; }

        DialogType Type { get; set; }

        Task Show();

        event EventHandler CloseDialog;

        Task Dismiss();

        IReadOnlyList<PopupPage> GetPopupPages();

        void SetData(string message, string secondMessage, DialogType type);

    }
}

