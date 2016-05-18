using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace WPFSampleProject.Models
{
    public class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public Employee(string lName, string fName)
        {
            LastName = lName;
            FirstName = fName;
        }
    }

    public class EmployeeList : ObservableCollection<Employee>
    {
        public EmployeeList()
        {
            string json = File.ReadAllText("MOCK_DATA.json");
            List<Employee> obj = JsonConvert.DeserializeObject<List<Employee>>(json);

            foreach(var emp in obj)
            {
                Add(emp);
            }
        }
    }
}
