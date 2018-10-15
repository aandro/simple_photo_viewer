using System.Windows.Input;
using System.Windows.Media.Imaging;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SimplePhotoViewer.Services;

namespace SimplePhotoViewer.ViewModels
{
    public class DetailedViewModel: BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        public DetailedViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigationCommand = new DelegateCommand(NavigateToMaster);
        }

        public ICommand NavigationCommand { get; }

        private BitmapImage _currentContent;
        public BitmapImage CurrentContent
        {
            get { return _currentContent; }
            private set { SetProperty(ref _currentContent, value); }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var content = navigationContext?.Parameters[StringConstants.ContentNavigationParameter];
            if (content == null)
            {
                return;
            }

            CurrentContent = (BitmapImage) content;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        private void NavigateToMaster()
        {
            _navigationService.NavigateToMaster();
        }
    }
}
