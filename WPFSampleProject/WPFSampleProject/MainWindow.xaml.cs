using System.Windows;
using WPFSampleProject.Models;
using WPFSampleProject.ViewModel;

namespace WPFSampleProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = new { EmployeeList = EmployeeList } ;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MainViewModel).LoadInitialData();
        }
    }
}
