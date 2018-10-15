using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SimplePhotoViewer.Models;
using SimplePhotoViewer.Services;

namespace SimplePhotoViewer.ViewModels
{
    public class MasterViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IImageRepository _imageRepository;

        private ImageModel _selectedContent;

        public MasterViewModel(
            INavigationService navigationService,
            IImageRepository imageRepository)
        {
            _navigationService = navigationService;
            _imageRepository = imageRepository;

            NavigationCommand = new DelegateCommand<object>(NavigateToDetailed);
            ReceiveCommand = new DelegateCommand<object>(ReceiveImage);
        }

        public bool IsContentAvailable => _imageRepository.Images.Count > 0;

        public ObservableCollection<ImageModel> Images => _imageRepository.Images;

        public ICommand NavigationCommand { get; }

        public ICommand ReceiveCommand { get; }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            if (_selectedContent != null)
            {
                navigationContext.Parameters.Add(StringConstants.ContentNavigationParameter, _selectedContent);
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _selectedContent = null;
        }

        private void NavigateToDetailed(object parameter)
        {
            _selectedContent = (ImageModel) parameter;
            _navigationService.NavigateToDetailed();
        }

        private void ReceiveImage(object parameter)
        {
            var filePaths = (IEnumerable<string>)parameter;
            foreach (var file in filePaths)
            {
                _imageRepository.Add(file);
            }

            RaisePropertyChanged(nameof(IsContentAvailable));
        }
    }
}
