using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Media;
using WPFSampleProject.Models;

namespace WPFSampleProject.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        #region Properties
        private EmployeeList _empList;
        public EmployeeList EmployeeList
        {
            get { return _empList; }
            set { Set(() => EmployeeList, ref _empList, value); }
        }

        private Color _color;
        public Color Color
        {
            get { return _color; }
            set { Set(() => Color, ref _color, value); }
        }


        #endregion
        #region Relay Commands

        public RelayCommand SubmitCommand { get; private set; }

        #endregion
        public MainViewModel()
        {
            _color = Colors.HotPink;
            SubmitCommand = new RelayCommand(SubmitForm);
        }
        public void LoadInitialData()
        {
            EmployeeList = new EmployeeList();
            Color = Colors.Black;
        }

        public void SubmitForm()
        {
            EmployeeList.Add(new Employee("Ngo", "Trung"));
            Color = Colors.BlueViolet;
        }
    }
}