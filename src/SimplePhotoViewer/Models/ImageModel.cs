using System.Windows.Media.Imaging;

namespace SimplePhotoViewer.Models
{
    public class ImageModel
    {
        public ImageModel(int index, BitmapImage content)
        {
            Index = index;
            Content = content;
        }

        public int Index { get; }
        public BitmapImage Content { get; }
    }
}
