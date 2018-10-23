using System;
using System.Xml;
using System.Xml.Serialization;

namespace EmployeeRegistration.Objects
{
    [Serializable]
    public class Department
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        private string location;

        public string Location
        {
            get { return location; }
            set { this.location = value; }
        }

        private double basicSalary;

        public double BasicSalary
        {
            get { return basicSalary; }
            set { this.basicSalary = value; }
        }

        public Department()
        {

        }

        public Department(string name, string location, double basicSalary)
        {
            this.name = name;
            this.location = location;
            this.basicSalary = basicSalary;
        }

        public override string ToString()
        {
            return $"{this.Name} \t {this.Location} \t {this.BasicSalary}";
        }
    }
}
