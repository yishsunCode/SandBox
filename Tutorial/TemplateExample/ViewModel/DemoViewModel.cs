using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Tutorial.TemplateExample.ViewModel
{
    class DemoViewModel
    {
        public ICommand Command { get; }
        public DemoViewModel() 
        {
            Command = new RelayCommand(() =>
            {
                MessageBox.Show("Click");
            });
        }
    }
}
