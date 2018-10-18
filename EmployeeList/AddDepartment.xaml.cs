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

namespace EmployeeList
{
    /// <summary>
    /// Логика взаимодействия для AddDepartment.xaml
    /// </summary>
    public partial class AddDepartment : Window
    {
        public AddDepartment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Making Data Array to send it to main window
        /// </summary>
        public string[] GetData
        {
            get
            {
                string[] data = new string[3];

                data[0] = tbNameAddDepartment.Text;
                data[1] = tbLocationAddDepartment.Text;
                data[2] = tbBasicSalaryAddDepartment.Text;

                return data;
            }
        }

        /// <summary>
        /// Sending data to main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDepartment_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        
        /// <summary>
        /// Closing dialog window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
