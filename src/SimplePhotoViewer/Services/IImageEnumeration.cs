using SimplePhotoViewer.Models;

namespace SimplePhotoViewer.Services
{
    //todo: improve approach in general
    public interface IImageEnumeration
    {
         ImageModel GetNext(int currentIndex);
         ImageModel GetPrevious(int currentIndex);
         bool IsNextAvailable(int currentIndex);
         bool IsPreviousAvailable(int currentIndex);
    }
}
