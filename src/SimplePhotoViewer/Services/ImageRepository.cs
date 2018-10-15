using SimplePhotoViewer.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace SimplePhotoViewer.Services
{
    public class ImageRepository : IImageRepository
    {
       
        public ImageRepository()
        {
            Images = new ObservableCollection<ImageModel>();
        }

        public ObservableCollection<ImageModel> Images { get; }

        public void Add(string filePath)
        {
            var bitmap = new BitmapImage(new Uri(filePath));
            var model = new ImageModel(Images.Count, bitmap);
            Images.Add(model);
        }

        public ImageModel GetNext(int currentIndex)
        {
            if (!IsNextAvailable(currentIndex))
            {
                return null;
            }

            return Images[currentIndex + 1];
        }

        public ImageModel GetPrevious(int currentIndex)
        {
            if (!IsPreviousAvailable(currentIndex))
            {
                return null;
            }

            return Images[currentIndex - 1];
        }

        public bool IsNextAvailable(int currentIndex)
        {
            var targetIndex = currentIndex + 1;
            return (targetIndex < Images.Count);
        }

        public bool IsPreviousAvailable(int currentIndex)
        {
            var targetIndex = currentIndex - 1;
            return (targetIndex >= 0);
        }
    }
}
