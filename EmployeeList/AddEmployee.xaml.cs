using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EmployeeList.Objects;

namespace EmployeeList
{
    /// <summary>
    /// Логика взаимодействия для AddDirectDebitDialog.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee(Dictionary<string, Department> dict)
        {
            InitializeComponent();

            if (dict.Count > 0)
                foreach (KeyValuePair<string, Department> pair in dict)
                    cbDepartmentAddEmployee.Items.Add(pair.Key);

            cbDepartmentAddEmployee.Items.Add("Other");
        }

        /// <summary>
        /// AddEmployee button event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        /// <summary>
        /// Making Data Array to send it to main window
        /// </summary>
        public string[] GetData
        {
            get
            {
                string[] data = new string[6];

                data[0] = tbNameAddEmployee.Text;
                data[1] = tbSurenameAddEmployee.Text;
                data[2] = tbAgeAddEmployee.Text;
                data[3] = tbPositionAddEmployee.Text;
                data[4] = tbDaysWithUsAddEmployee.Text;
                data[5] = cbDepartmentAddEmployee.SelectedItem.ToString();

                return data;
            }
        }

        /// <summary>
        /// Cancel button event handler, Closing window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}