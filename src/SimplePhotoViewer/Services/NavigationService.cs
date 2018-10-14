using Prism.Regions;
using SimplePhotoViewer.Views;
using System;

namespace SimplePhotoViewer.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IRegionManager _regionManager;

        public NavigationService(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void NavigateToDetailed()
        {
            _regionManager.RequestNavigate(
                StringConstants.MainRegionName, new Uri(nameof(DetailedView), UriKind.Relative));
        }

        public void NavigateToMaster()
        {
            _regionManager.RequestNavigate(
                StringConstants.MainRegionName, new Uri(nameof(MasterView), UriKind.Relative));
        }
    }
}
