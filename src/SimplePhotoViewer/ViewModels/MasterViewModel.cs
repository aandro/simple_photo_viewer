using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Prism.Commands;
using Prism.Mvvm;
using SimplePhotoViewer.Services;

namespace SimplePhotoViewer.ViewModels
{
    public class MasterViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private readonly IImageRepository _imageRepository;

        public MasterViewModel(
            INavigationService navigationService,
            IImageRepository imageRepository)
        {
            _navigationService = navigationService;
            _imageRepository = imageRepository;

            NavigationCommand = new DelegateCommand(NavigateToDetailed);
            ReceiveCommand = new DelegateCommand<object>(ReceiveImage);
        }

        public ObservableCollection<BitmapImage> Images => _imageRepository.Images;

        public ICommand NavigationCommand { get; }

        public ICommand ReceiveCommand { get; }

        private void NavigateToDetailed()
        {
            _navigationService.NavigateToDetailed();
        }

        private void ReceiveImage(object parameter)
        {
            var filePaths = (IEnumerable<string>)parameter;
            foreach (var file in filePaths)
            {
                _imageRepository.Add(file);
            }
        }
    }
}
