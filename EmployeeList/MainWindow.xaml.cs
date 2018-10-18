using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using EmployeeList.Objects;

namespace EmployeeList
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Init

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region ClassFields

        private Dictionary<string, Department> dictDepartments = new Dictionary<string, Department>();
        private Dictionary<Employee, string> dictEmployee = new Dictionary<Employee, string>(); 
        #endregion

        //Department
        #region DepartmentEventHandlers

        /// <summary>
        /// Add Department btn event handler. Opening new window to add department.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BntAddDepartament_Click(object sender, RoutedEventArgs e)
        {
            AddDepartment();
        }

        /// <summary>
        /// Remove Department btn Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveDepartament_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedDepartment();
        }

        /// <summary>
        /// Edit Department Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BntEditDepartament_Click(object sender, RoutedEventArgs e)
        {
            EditDepartment();
        }

        /// <summary>
        /// Change selecting department list event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowInfoInLabels();
        }

        #endregion

        #region DepartmentLogic

        /// <summary>
        /// Printing data in labels
        /// </summary>
        private void ShowInfoInLabels()
        {
            if (lbDepartment.SelectedItem != null)
            {
                string[] data = lbDepartment.SelectedItem.ToString().Split(',');
                var department = dictDepartments.First(e => e.Key == data[0]);
                lblNameDepartment.Content = $"Name: {department.Value.Name}";
                lblLocationDepartment.Content = $"Location: {department.Value.Location}";
                lblBasicSalaryDepartment.Content = $"Basic salary: {department.Value.BasicSalary}";
            }
        }

        /// <summary>
        /// Edite Department
        /// </summary>
        private void EditDepartment()
        {
            if (lbDepartment.SelectedItem != null)
            {
                string[] data = lbDepartment.SelectedItem.ToString().Split(',');
                var department = dictDepartments.First(e => e.Key == data[0]);
                EditDepartment editDepartment = new EditDepartment(department.Value.Name, department.Value.Location, department.Value.BasicSalary);

                if (editDepartment.ShowDialog() == true)
                {
                    string[] d = editDepartment.GetData;
                    dictDepartments.Remove(d[3]);
                    dictDepartments.Add(d[0], new Department(d[0], d[1], Convert.ToDouble(d[2])));
                    lblNameDepartment.Content = $"Name: {d[0]}";
                    lblLocationDepartment.Content = $"Location: {d[1]}";
                    lblBasicSalaryDepartment.Content = $"Basic salary: {d[2]}";
                    UpdateDepartmentListBox();
                }
            }
            else
            {
                MessageBox.Show("Please select Department");
            }
        }

        /// <summary>
        /// Deleting selected item from Department listBox
        /// </summary>
        private void DeleteSelectedDepartment()
        {
            if (lbDepartment.SelectedItem != null)
            {
                string[] data = lbDepartment.SelectedItem.ToString().Split(',');
                dictDepartments.Remove(data[0]);
                lbDepartment.Items.RemoveAt(lbDepartment.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please select Department");
            }
        }

        /// <summary>
        /// Adding Department
        /// </summary>
        private void AddDepartment()
        {
            AddDepartment addDepartment = new AddDepartment();
            if (addDepartment.ShowDialog() == true)
            {
                string[] d = addDepartment.GetData;
                dictDepartments.Add(d[0], new Department(d[0], d[1], Convert.ToDouble(d[2])));
            }

            UpdateDepartmentListBox();
        }

        /// <summary>
        /// Updating Employee list
        /// </summary>
        private void UpdateDepartmentListBox()
        {
            lbDepartment.Items.Clear();

            foreach (KeyValuePair<string, Department> pair in dictDepartments)
                lbDepartment.Items.Add($"{pair.Value.Name}, {pair.Value.Location}, £{pair.Value.BasicSalary}");
        }

        #endregion

        //Employee
        #region EmployeeEventHandlers

        /// <summary>
        /// Add employee btn event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BntAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee();
        }


        #endregion

        #region EmployeeLogic

        private void AddEmployee()
        {
            AddEmployee addEmployee = new AddEmployee(dictDepartments);
            if (addEmployee.ShowDialog() == true)
            {
                string[] d = addEmployee.GetData;
            }
        }

        #endregion

    }
}
