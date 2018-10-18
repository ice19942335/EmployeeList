using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Automation.Peers;
using System.Xml.Serialization;

namespace EmployeeList.Objects
{
    [Serializable]
    public class Employee
    {
        private string name;
        private string sureName;
        private int age;
        private string position;
        private int daysWthUs;
        private double salary;
        private List<Department> departmentList;

        public Employee()
        {

        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value != String.Empty)
                    name = value;
            }
        }

        public string SureName
        {
            get { return sureName; }
            set
            {
                if (value != String.Empty)
                    sureName = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 15)
                    age = value;
            }
        }

        public string Position
        {
            get { return position; }
            set
            {
                if (value != String.Empty)
                    position = value;
            }
        }

        public int DaysWU
        {
            get { return daysWthUs; }
            set { daysWthUs = value; }
        }

        public Employee(string _name, string _surename, int _age, string _position, double _salary, KeyValuePair<string, Department> _department, int _daysWthUs = 0)
        {
            name = _name;
            sureName = _surename;
            age = _age;
            position = _position;
            salary = _salary;
            departmentList.Add(_department.Value);
            daysWthUs = _daysWthUs;
        }
    }
}
