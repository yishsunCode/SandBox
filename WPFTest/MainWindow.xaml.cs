using System.Windows;
using WPFTest.Test.DI;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //GrandContructorSenario.Run();
            new User().Run();
        }
    }
}
