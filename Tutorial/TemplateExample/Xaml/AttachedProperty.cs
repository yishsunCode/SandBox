using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tutorial.TemplateExample.Xaml
{
    static class AttachedProperty
    {



        public static int GetCheckBoxSize(DependencyObject obj)
        {
            return (int)obj.GetValue(CheckBoxSizeProperty);
        }

        public static void SetCheckBoxSize(DependencyObject obj, int value)
        {
            obj.SetValue(CheckBoxSizeProperty, value);
        }

        // Using a DependencyProperty as the backing store for CheckBoxSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckBoxSizeProperty =
            DependencyProperty.RegisterAttached("CheckBoxSize", typeof(int), typeof(AttachedProperty), new PropertyMetadata(100));



    }
}
