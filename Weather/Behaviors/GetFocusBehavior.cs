using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Weather.Behaviors
{
    public class GetFocusBehavior : Behavior<ButtonBase>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Click += ButtonClick;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= ButtonClick;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(FocusElement);            
        }

        public Control FocusElement
        {
            get { return (Control) GetValue(FocusElementProperty); }
            set { SetValue(FocusElementProperty, value);}
        }

        public static  readonly DependencyProperty FocusElementProperty =
            DependencyProperty.Register("FocusElement",typeof(Control),typeof(GetFocusBehavior), new UIPropertyMetadata());

    }
}
