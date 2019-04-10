using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UpMovies.Controls
{
    public class AnimatedLabel : Label
    {
        public static readonly BindableProperty IsVisibleAnimatedProperty = BindableProperty.Create(
            "IsVisibleAnimated",
            typeof(bool),
            typeof(AnimatedLabel),
            true,
            BindingMode.OneWay);


        public bool IsVisibleAnimated
        {
            get { return (bool)GetValue(IsVisibleAnimatedProperty); }
            set
            {
                SetValue(IsVisibleAnimatedProperty, value);
            }
        }

        public AnimatedLabel()
        {
        }

        protected override async void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "IsVisibleAnimated")
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    FadeAnimation();
                });
            }

            if (propertyName == "IsVisible")
            {
                FadeAnimation();
            }
        }

        private async Task FadeAnimation()
        {
            if (IsVisible)
            {
                Opacity = 0;
                IsVisible = IsVisibleAnimated;
                await this.FadeTo(1, 400);
            }
            else
            {
                await this.FadeTo(0, 400);
                IsVisible = IsVisibleAnimated;
            }

        }
    }
}
