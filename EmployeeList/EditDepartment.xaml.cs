using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace EmployeeList
{
    /// <summary>
    /// Логика взаимодействия для EditDepartment.xaml
    /// </summary>
    public partial class EditDepartment : Window
    {
        private string oldName;

        public EditDepartment(string name, string location, double basicSalary)
        {
            InitializeComponent();

            tbNameEditDepartment.Text = name;
            oldName = name;
            tbLocationEditDepartment.Text = location;
            tbBasicSalaryEditDepartment.Text = basicSalary.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
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
                string[] data = new string[4];
                data[0] = tbNameEditDepartment.Text;
                data[1] = tbLocationEditDepartment.Text;
                data[2] = tbBasicSalaryEditDepartment.Text;
                data[3] = oldName;

                return data;
            }
        }
    }
}
