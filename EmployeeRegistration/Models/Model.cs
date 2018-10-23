using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using EmployeeRegistration.Objects;



namespace EmployeeRegistration.Models
{
    public class Model
    {
        //Model Fields
        private const string DB_DEPARTMENT = "DB_DEPARTMENT.xml";
        private const string DB_EMPLOYEE = "DB_EMPLOYEE.xml";

        private ObservableCollection<Department> DB_DEP = new ObservableCollection<Department>();
        private ObservableCollection<Employee> DB_EMP = new ObservableCollection<Employee>();

        public ObservableCollection<Department> DbDepartment
        {
            get { return DB_DEP; }
        }
        public ObservableCollection<Employee> DbEmployee
        {
            get { return DB_EMP; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Model()
        {
            DB_DEP = GetDataDep();
            DB_EMP = GetDataEmp();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Employee Model

        public void EmployeeDeleteDepartmentModel(int empSelIndex, int depSelIndex)
        {
            DB_EMP.ElementAt(empSelIndex).Departments.RemoveAt(depSelIndex);
        }

        /// <summary>
        /// Returning list of departments that is on employee
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<Department> GetDepListEMP(int index)
        {
            return DB_EMP.ElementAt(index).Departments;
        }

        /// <summary>
        /// Adding department to employee
        /// </summary>
        /// <param name="empSelIndex"></param>
        /// <param name="depSelIndex"></param>
        public void EmployeeAddDepartmentModel(int empSelIndex, int depSelIndex)
        {
               DB_EMP.ElementAt(empSelIndex).Departments.Add(DB_DEP.ElementAt(depSelIndex));
        }

        /// <summary>
        /// Deleting employee
        /// </summary>
        /// <param name="index"></param>
        public void DeleteEmployeeModel(int index)
        {
            DB_EMP.RemoveAt(index);
        }

        /// <summary>
        /// Adding employee
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sureName"></param>
        /// <param name="salary"></param>
        public void AddEmployeeModel(string name, string sureName, double salary)
        {
            DB_EMP.Add(new Employee(name, sureName, salary));
        }

        #endregion

        //===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///
        #region Department Model

        /// <summary>
        /// Deleting department
        /// </summary>
        /// <param name="index"></param>
        public void DeleteDepartment(int index)
        {
            DB_DEP.RemoveAt(index);
        }

        /// <summary>
        /// Adding department
        /// </summary>
        /// <param name="nameDep"></param>
        /// <param name="locationDep"></param>
        /// <param name="basicSalaryDep"></param>
        public void AddDepartmentModel(string nameDep, string locationDep, double basicSalaryDep)
        {
            DB_DEP.Add(new Department(nameDep, locationDep, basicSalaryDep));
        }

        /// <summary>
        /// Saving all data
        /// </summary>
        public void SaveAllData()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<Department>));
            Stream fStream = new FileStream(
                DB_DEPARTMENT,
                FileMode.Create,
                FileAccess.Write
            );
            xmlFormat.Serialize(fStream, DB_DEP);
            fStream.Close();

            XmlSerializer xmlFormat1 = new XmlSerializer(typeof(ObservableCollection<Employee>));
            Stream fStream1 = new FileStream(
                DB_EMPLOYEE,
                FileMode.Create,
                FileAccess.Write
            );
            xmlFormat1.Serialize(fStream1, DB_EMP);
            fStream1.Close();
        }

        #endregion



        //Loading data from files ------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Returning departments list
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Department> GetDataDep()
        {
            try
            {
                XmlSerializer xmlFormatIncomes = new XmlSerializer(typeof(ObservableCollection<Department>));
                Stream fStreamIncomes = new FileStream(
                    DB_DEPARTMENT,
                    FileMode.Open,
                    FileAccess.Read
                );
                DB_DEP = (ObservableCollection<Department>)xmlFormatIncomes.Deserialize(fStreamIncomes);
                fStreamIncomes.Close();
            }
            catch (Exception)
            {
            }

            return DB_DEP;
        }

        /// <summary>
        /// Returning employee list
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<Employee> GetDataEmp()
        {
            try
            {
                XmlSerializer xmlFormatIncomes = new XmlSerializer(typeof(ObservableCollection<Employee>));
                Stream fStreamIncomes = new FileStream(
                    DB_EMPLOYEE,
                    FileMode.Open,
                    FileAccess.Read
                );
                DB_EMP = (ObservableCollection<Employee>)xmlFormatIncomes.Deserialize(fStreamIncomes);
                fStreamIncomes.Close();
            }
            catch (Exception)
            {
            }

            return DB_EMP;
        }
    }
}
