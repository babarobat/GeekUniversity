using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;

namespace Lesson_5_Kotenko
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
       
        private Presenter _p;
        #region  IView

        /// <summary>
        /// Список департаментов
        /// </summary>
        public ObservableCollection<Department> Company
        {
            get => DepList.ItemsSource as ObservableCollection<Department>;
            set
            {
                DepList.ItemsSource = value;
                

            }
        }
        /// <summary>
        /// Список сотрудников
        /// </summary>
        public ObservableCollection<Employee> Department
        {
            get => EmpList.ItemsSource as ObservableCollection<Employee>;
            set
            {
                EmpList.ItemsSource = value;
                DepName.DataContext = DepList.SelectedItem as Department;
                
            }
        }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public Employee Employee
        {
            get => EmpParamPannel.DataContext as Employee;
            set
            {
                EmpParamPannel.DataContext = value;
                EmpList.SelectedItem = value;
                if (EmpList.SelectedItem != null)
                {
                    DepComboBox.ItemsSource = Company;
                    DepComboBox.SelectedItem = DepList.SelectedItem as Department;
                }
                else
                {
                    DepComboBox.ItemsSource = null;
                }
            } 
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            _p = new Presenter(this);
            _p.LoadCompany();

            DepList.SelectionChanged += delegate { _p.ShowDep(DepList.SelectedItem as Department); };
            EmpList.SelectionChanged += delegate { _p.ShowEmp(EmpList.SelectedItem as Employee); };
            DepComboBox.SelectionChanged += delegate
            {
                _p.ChangeDep(DepComboBox.SelectedItem as Department,
                            DepList.SelectedItem as Department,
                           EmpList.SelectedItem as Employee);
            };
            DeleteEmpBtn.Click += delegate { _p.RemoveEmployee(); };
            AddEmpBtn.Click+= delegate { _p.AddEmployee(); };
            AddDepBtn.Click += delegate { _p.AddDep(); };
            DeleteDepBtn.Click += delegate { _p.RemoveDep(DepList.SelectedItem as Department); };
            DepName.LostFocus += delegate { _p.ChangeDepName(DepList.SelectedItem as Department, DepName.Text); };
        }

        #region Обработчики событий
        
        private void DepList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        
        private void EmpList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        
        private void DeleteEmpBtn_Click(object sender, RoutedEventArgs e)
        {
           

        }
        
        private void AddEmpBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void AddDepBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void DepComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        
        private void DeleteDepBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
        #endregion

    }
}
