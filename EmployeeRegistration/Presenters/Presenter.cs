using System.Collections.Generic;
using System.Collections.ObjectModel;
using EmployeeRegistration.Views;
using EmployeeRegistration.Models;
using EmployeeRegistration.Objects;
using System.Windows;

namespace EmployeeRegistration.Presenters
{
    public class Presenter
    {
        private readonly IView view;
        private readonly Model model;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view"></param>
        public Presenter(IView view)
        {
            model = new Model();
            this.view = view;
            view.ListViewDep.ItemsSource = model.DbDepartment;
            view.ListViewEmp.ItemsSource = model.DbEmployee;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region EMP

        /// <summary>
        /// Deleting Selected employee from list
        /// </summary>
        public void DeleteEmployee()
        {
            if (view.ListViewEmp.SelectedIndex != -1)
                model.DeleteEmployeeModel(view.ListViewEmp.SelectedIndex);
            else
                MessageBox.Show("Selet item from list");
        }

        /// <summary>
        /// Deleting department from employee
        /// </summary>
        public void DeleteDepartmentFromEMP()
        {
            if (view.ListViewEmp.SelectedIndex != -1 && view.ComboBoxDepartmentListEMP.SelectedIndex != -1)
            {
                model.EmployeeDeleteDepartmentModel(view.ListViewEmp.SelectedIndex, view.ComboBoxDepartmentListEMP.SelectedIndex);
                RefreshDepartmentsList();
            }
            else
            {
                MessageBox.Show("Have to be selected Employee from list and Deparment from combo box at the bottom");
            }
        }

        /// <summary>
        /// Adding department to the employee if selected
        /// </summary>
        public void AddDepartmentToEMP()
        {
            if (view.ListViewEmp.SelectedIndex != -1 && view.ComboBoxDepList.SelectedIndex != -1)
            {
                model.EmployeeAddDepartmentModel(view.ListViewEmp.SelectedIndex, view.ComboBoxDepList.SelectedIndex);
                RefreshDepartmentsList();
            }
            else
            {
                MessageBox.Show("Have to be selected Employee from list and Deparment from combo box at the bottom");
            }
        }

        /// <summary>
        /// Adding new employee
        /// </summary>
        public void AddEmployee()
        {
            model.AddEmployeeModel(view.NameEmp, view.SureName, view.SalaryEmp);
        }

        /// <summary>
        /// Refreshing Combobox - Departmentlist on employee
        /// </summary>
        public void RefreshDepartmentsList()
        {
            List<Department> list = model.GetDepListEMP(view.ListViewEmp.SelectedIndex);
            view.ComboBoxDepartmentListEMP.Items.Clear();
            foreach (var dep in list)
                view.ComboBoxDepartmentListEMP.Items.Add($"{dep.Name}, {dep.Location}, £{dep.BasicSalary}");
        }

        #endregion

        //===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///===///
        #region DEP

        /// <summary>
        /// Adding new department
        /// </summary>
        public void AddDepartment()
        {
            if (view.BasicSalaryDep != 0)
                model.AddDepartmentModel(view.NameDep, view.LocationDep, view.BasicSalaryDep);
            else
                MessageBox.Show("Basic salary field can be a number only");

            RefreshDepListCB();
        }

        /// <summary>
        /// Refreshing ComboBox - Departments list !!!Not on employee list!!!
        /// </summary>
        private void RefreshDepListCB()
        {
            ObservableCollection<Department> depList = GetDepList();
            view.ComboBoxDepList.Items.Clear();
            foreach (var dep in depList)
                view.ComboBoxDepList.Items.Add($"{dep.Name}, {dep.Location}, {dep.BasicSalary}");
        }

        /// <summary>
        /// Saving all changet data to the xml files for now. LAte should be in the Data base.
        /// </summary>
        public void SaveAllData()
        {
            model.SaveAllData();
        }

        /// <summary>
        /// Deleting department
        /// </summary>
        public void DeleteDepartment()
        {
            if (view.ListViewDep.SelectedIndex != -1)
                model.DeleteDepartment(view.ListViewDep.SelectedIndex);
            else
                MessageBox.Show("Selet item from list");

            RefreshDepListCB();
        }

        /// <summary>
        /// Getting departments list for initialization on start of application
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Department> GetDepList()
        {
            return model.DbDepartment;
        }

        #endregion
    }
}
