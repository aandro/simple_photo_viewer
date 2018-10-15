using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SimplePhotoViewer.Models;
using SimplePhotoViewer.Services;

namespace SimplePhotoViewer.ViewModels
{
    public class DetailedViewModel: BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IImageEnumeration _imageEnumeration;

        public DetailedViewModel(
            INavigationService navigationService, 
            IImageEnumeration imageEnumeration)
        {
            _navigationService = navigationService;
            _imageEnumeration = imageEnumeration;

            NavigationCommand = new DelegateCommand(NavigateToMaster);

            GetNextCommand = new DelegateCommand(GetNext);           
            GetPreviousCommand = new DelegateCommand(GetPrevious);
        }

        public ICommand NavigationCommand { get; }

        public ICommand GetNextCommand { get; }
        public ICommand GetPreviousCommand { get; }

        public bool IsNextActive => CurrentContent != null
                    && _imageEnumeration.IsNextAvailable(CurrentContent.Index);

        public bool IsPreviousActive => CurrentContent != null 
                    && _imageEnumeration.IsPreviousAvailable(CurrentContent.Index);

        private ImageModel _currentContent;
        public ImageModel CurrentContent
        {
            get { return _currentContent; }
            private set
            {
                SetProperty(ref _currentContent, value);
                RaisePropertyChanged(string.Empty);
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var content = navigationContext?.Parameters[StringConstants.ContentNavigationParameter];
            if (content == null)
            {
                return;
            }

            CurrentContent = (ImageModel) content;
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

        private void GetNext()
        {
            if (CurrentContent == null)
            {
                return;
            }

            var nextElement = _imageEnumeration.GetNext(CurrentContent.Index);
            CurrentContent = nextElement;
        }

        private void GetPrevious()
        {
            if (CurrentContent == null)
            {
                return;
            }

            var nextElement = _imageEnumeration.GetPrevious(CurrentContent.Index);
            CurrentContent = nextElement;
        }
    }
}
