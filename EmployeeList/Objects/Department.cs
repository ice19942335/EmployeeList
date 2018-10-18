using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xaml.Schema;
using System.Xml.Serialization;

namespace EmployeeList.Objects
{
    [Serializable]
    public class Department
    {
        private string name;
        private string location;
        private double basicSalary;

        public Department()
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

        public string Location
        {
            get { return location; }
            set
            {
                if (value != String.Empty)
                    location = value;
            }
        }

        public double BasicSalary
        {
            get { return basicSalary; }
            set
            { basicSalary = value; }
        }

        public Department(string _name, string _location, double _basicSalary)
        {
            name = _name;
            location = _location;
            basicSalary = _basicSalary;

        }


    }
}
