using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace InventoryManagementApp.Converters
{
    /// <summary>
    /// Converter class to convert the image url to ImageSource
    /// </summary>
    public class EmptyImageToImageSourceConverter : IValueConverter
    {
        // Holds the images which is already loaded.
        readonly Dictionary<string, byte[]> cachedImages;

        public EmptyImageToImageSourceConverter()
        {
            cachedImages = new Dictionary<string, byte[]>();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Loads the default image if the url is empty
            var urlString = (string)value;
            var url = string.IsNullOrEmpty(urlString) ? "https://www.bandg.com/assets/img/default-product-img.png" : urlString;

            byte[] imageData;
            if (cachedImages.ContainsKey(url))
                imageData = cachedImages[url];
            else
            {
                var imgUrl = new Uri(url);
                imageData = new WebClient().DownloadData(imgUrl);
                cachedImages.Add(url, imageData);
            }

            var bitmapImage = new BitmapImage { CacheOption = BitmapCacheOption.OnLoad };
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(imageData);
            bitmapImage.EndInit();

            return bitmapImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Ignoring the convert back
            return value;
        }
    }
}
