using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UpMovies.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailNavigationBarControl : ContentView
    {
        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
                                                         propertyName: "TitleText",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(DetailNavigationBarControl),
                                                         defaultValue: "",
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: TitleTextPropertyChanged);

        public string TitleText
        {
            get { return base.GetValue(TitleTextProperty).ToString(); }
            set { base.SetValue(TitleTextProperty, value); }
        }

        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (DetailNavigationBarControl)bindable;
            control.title.Text = newValue.ToString();
        }

        public DetailNavigationBarControl()
        {
            InitializeComponent();
        }


    }
}
