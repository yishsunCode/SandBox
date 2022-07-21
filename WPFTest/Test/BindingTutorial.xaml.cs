using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTest.Test
{
    /// <summary>
    /// Interaction logic for BindingTutorial.xaml
    /// </summary>
    public partial class BindingTutorial : UserControl
    {
        public BindingTutorial()
        {
            InitializeComponent();

            this.DataContext = new ViewModel();
        }
    }
    interface IViewModel
    {
        string Name { get; set; }
        int Money { get; set; }
        bool IsMale { get; set; }
        IList<IRow> Rows { get; }
        ICommand AddCommand { get; }
    }
    interface IRow
    {
        string Name { get; }
        int Money { get; }
        bool IsMale { get; }

    }
    class ViewModel : ObservableObject, IViewModel
    {
        #region - Member -

        string _name = "";
        int _money = 1;
        bool _male = false;
        IList<IRow> _rows = new IRow[] { };

        #endregion

        #region - Property -

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public int Money
        {
            get { return _money; }
            set { SetProperty(ref _money, value); }
        }

        public bool IsMale
        {
            get { return _male; }
            set { SetProperty(ref _male, value); }
        }

        public ICommand AddCommand { get; private set; }

        public IList<IRow> Rows
        {
            get { return _rows; }
            set { SetProperty(ref _rows, value); }
        }

        #endregion

        public ViewModel() 
        {
            AddCommand = new RelayCommand(() =>
            {
                var newRow = new Row
                {
                    Name = Name,
                    Money = Money,
                    IsMale = IsMale
                };

                var newList = new List<IRow>(Rows);
                newList.Add(newRow);
                Rows = newList;
            });
        }

        class Row : IRow
        {
            public string Name { get; set; }
            public int Money { get; set; }
            public bool IsMale { get; set; }
        }
    }
}
