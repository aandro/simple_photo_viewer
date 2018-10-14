using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using SimplePhotoViewer.Services;

namespace SimplePhotoViewer.ViewModels
{
    public class MasterViewModel: BindableBase
    {
        private readonly INavigationService _navigationService;

        public MasterViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigationCommand = new DelegateCommand(NavigateToDetailed);
        }

        public ICommand NavigationCommand { get; }

        private void NavigateToDetailed()
        {
            _navigationService.NavigateToDetailed();
        }

    }
}
