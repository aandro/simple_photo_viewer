using SimplePhotoViewer.Models;
using System.Collections.ObjectModel;

namespace SimplePhotoViewer.Services
{
    public interface IImageRepository: IImageEnumeration
    {
        ObservableCollection<ImageModel> Images { get; }
        void Add(string filePath);
        void SetCurrent(ImageModel current);
    }
}
