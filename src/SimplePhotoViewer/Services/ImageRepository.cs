using SimplePhotoViewer.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace SimplePhotoViewer.Services
{
    public class ImageRepository : IImageRepository
    {
        private int _currentIndex;
        public ImageRepository()
        {
            Images = new ObservableCollection<ImageModel>();
        }

        public ObservableCollection<ImageModel> Images { get; }

        public void Add(string filePath)
        {
            var bitmap = new BitmapImage(new Uri(filePath));
            var model = new ImageModel(bitmap);
            Images.Add(model);
        }

        public void SetCurrent(ImageModel current)
        {
            _currentIndex = Images.IndexOf(current);
        }

        public ImageModel GetNext()
        {
            if (!IsNextAvailable())
            {
                return null;
            }

            return Images[++_currentIndex];
        }

        public ImageModel GetPrevious()
        {
            if (!IsPreviousAvailable())
            {
                return null;
            }

            return Images[--_currentIndex];
        }

        public bool IsNextAvailable()
        {
            var targetIndex = _currentIndex + 1;
            return (targetIndex < Images.Count);
        }

        public bool IsPreviousAvailable()
        {
            var targetIndex = _currentIndex - 1;
            return (targetIndex >= 0);
        }
    }
}
