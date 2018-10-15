using System.Windows.Media.Imaging;

namespace SimplePhotoViewer.Models
{
    public class ImageModel
    {
        public ImageModel(BitmapImage content)
        {
            Content = content;
        }

        public BitmapImage Content { get; }
    }
}
