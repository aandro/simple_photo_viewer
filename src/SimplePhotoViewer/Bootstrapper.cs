using System.Windows;
using Prism.Unity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using SimplePhotoViewer.Views;
using SimplePhotoViewer.Services;

namespace SimplePhotoViewer
{
    internal class Bootstrapper: UnityBootstrapper
    {

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window) Shell;

            RegisterViews();

            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<INavigationService, NavigationService>();
        }    

        private void RegisterViews()
        {
            var regionManager = Container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(StringConstants.MainRegionName, typeof(MasterView));
            regionManager.RegisterViewWithRegion(StringConstants.MainRegionName, typeof(DetailedView));   
        }
    }
}
