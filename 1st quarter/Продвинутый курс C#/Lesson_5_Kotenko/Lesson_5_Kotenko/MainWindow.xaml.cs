using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson_5_Kotenko
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Company company = Company.GetRandomCompany();
            DepList.ItemsSource = company.Departments;
            
        }
        private void DepList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmpList.ItemsSource = (DepList.SelectedItem as Department).Employees;
        }

        private void EmpList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmpParamPannel.DataContext = (EmpList.SelectedItem as Employee);
        }
    }
}
