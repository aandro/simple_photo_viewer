using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using SimplePhotoViewer.Services;

namespace SimplePhotoViewer.ViewModels
{
    public class DetailedViewModel: BindableBase
    {
        private readonly INavigationService _navigationService;

        public DetailedViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigationCommand = new DelegateCommand(NavigateToMaster);
        }

        public ICommand NavigationCommand { get; }

        private void NavigateToMaster()
        {
            _navigationService.NavigateToMaster();
        }
    }
}
