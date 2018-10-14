using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace SimplePhotoViewer.Services
{
    public class ImageRepository : IImageRepository
    {
       
        public ImageRepository()
        {
            Images = new ObservableCollection<BitmapImage>();
        }

        public ObservableCollection<BitmapImage> Images { get; }

        public void Add(string filePath)
        {
            var bitmap = new BitmapImage(new Uri(filePath));
            Images.Add(bitmap);
        }
    }
}
