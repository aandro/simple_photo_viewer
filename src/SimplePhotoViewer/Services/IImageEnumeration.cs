using SimplePhotoViewer.Models;

namespace SimplePhotoViewer.Services
{
    //todo: improve approach in general
    public interface IImageEnumeration
    {
         ImageModel GetNext();
         ImageModel GetPrevious();
         bool IsNextAvailable();
         bool IsPreviousAvailable();
    }
}
