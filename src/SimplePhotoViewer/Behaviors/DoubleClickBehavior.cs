using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace SimplePhotoViewer.Behaviors
{
    public class DoubleClickBehavior : Behavior<Image>
    {

        public ICommand ExecuteCommand
        {
            get { return (ICommand)GetValue(ExecuteCommandProperty); }
            set { SetValue(ExecuteCommandProperty, value); }
        }

        public static readonly DependencyProperty ExecuteCommandProperty =
            DependencyProperty.Register(nameof(ExecuteCommand), typeof(ICommand), typeof(DoubleClickBehavior), new PropertyMetadata(null));

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;           
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown; ;
            base.OnDetaching();
        }

        private void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount < 2)
            {
                return;
            }

            ExecuteCommand?.Execute(AssociatedObject.Source); 
        }

    }
}
