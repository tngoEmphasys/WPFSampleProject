using System.Windows;
using WPFSampleProject.Models;

namespace WPFSampleProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeList _empList;
        public EmployeeList EmployeeList
        {
            get { return _empList; }
            set { _empList = value; }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new EmployeeList();
        }
    }
}
