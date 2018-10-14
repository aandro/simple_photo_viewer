using Prism.Mvvm;
using SimplePhotoViewer.Services;

namespace SimplePhotoViewer.ViewModels
{
    public class MainViewModel: BindableBase
    {
        public MainViewModel(INavigationService navigationService)
        {
            navigationService.NavigateToMaster();
        }
    }
}
