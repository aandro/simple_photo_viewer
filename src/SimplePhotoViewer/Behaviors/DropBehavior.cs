using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace SimplePhotoViewer.Behaviors
{
    public class DropBehavior: Behavior<UIElement>
    {

        public ICommand ExecuteCommand
        {
            get { return (ICommand)GetValue(ExecuteCommandProperty); }
            set { SetValue(ExecuteCommandProperty, value); }
        }

        public static readonly DependencyProperty ExecuteCommandProperty =
            DependencyProperty.Register(nameof(ExecuteCommand), typeof(ICommand), typeof(DropBehavior), new PropertyMetadata(null));

        protected override void OnAttached()
        {
            base.OnAttached();

            if (AssociatedObject.AllowDrop)
            {
                AssociatedObject.Drop += AssociatedObject_Drop; ;
            }
        }

        protected override void OnDetaching()
        {
            if (AssociatedObject.AllowDrop)
            {
                AssociatedObject.Drop -= AssociatedObject_Drop; ;
            }

            base.OnDetaching();
        }

        private void AssociatedObject_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
                ExecuteCommand?.Execute(filePaths);
            }
        }

    }
}
