using System;
using System.Globalization;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;

namespace UpMovies.Converters
{
    public class StringToSvgResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sourceString = value as String;
            return SvgImageSource.FromResource(sourceString);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //No need for the Convert Back Method
            throw new NotImplementedException();
        }
    }
}
