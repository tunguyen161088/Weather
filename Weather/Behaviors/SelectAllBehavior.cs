using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

namespace Weather.Behaviors
{
    public class SelectAllBehavior : Behavior<ButtonBase>
    {
        protected override void OnAttached()
        {
            AssociatedObject.GotFocus += OnTextBoxSelectAll;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.GotFocus -= OnTextBoxSelectAll;
        }

        private void OnTextBoxSelectAll(object sender, RoutedEventArgs e)
        {
            ((TextBox)SelectAllElement).SelectAll();
        }

        public Control SelectAllElement
        {
            get { return (Control)GetValue(SelectAllElementProperty); }
            set { SetValue(SelectAllElementProperty, value); }
        }

        public static readonly DependencyProperty SelectAllElementProperty =
            DependencyProperty.Register("SelectAllElement", typeof(TextBox), typeof(SelectAllBehavior), new UIPropertyMetadata());
    }
}
