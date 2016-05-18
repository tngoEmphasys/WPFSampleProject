using System.Windows;
using WPFSampleProject.Models;

namespace WPFSampleProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeList EmployeeList;
        public MainWindow()
        {
            InitializeComponent();
            EmployeeList = new EmployeeList();
            DataContext = EmployeeList;
        }
    }
}
