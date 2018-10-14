using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace SimplePhotoViewer.Services
{
    public interface IImageRepository
    {
        ObservableCollection<BitmapImage> Images { get; }
        void Add(string filePath);
    }
}
