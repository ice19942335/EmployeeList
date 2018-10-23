using System;
using System.Collections.Generic;
using System.Xaml;
using System.Xml;
using System.Xml.Serialization;

namespace EmployeeRegistration.Objects
{
    [Serializable]
    public class Employee
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        private string surename;

        public string Surename
        {
            get { return surename; }
            set { this.surename = value; }
        }

        private double salary;

        public double Salary
        {
            get { return salary; }
            set { this.salary = value; }
        }

        public Employee()
        {

        }

        private List<Department> departments = new List<Department>();

        public List<Department> Departments
        {
            get { return departments; }
            set { departments = value; }
        }


        public Employee(string name, string surename, double salary)
        {
            this.name = name;
            this.surename = surename;
            this.salary = salary;
        }

        internal void AddDepartment(Department dep)
        {
            departments.Add(dep);
        }
    }
}
