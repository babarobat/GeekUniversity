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

        
        public ObservableCollection<Department> Company
        {
            get => DepList.ItemsSource as ObservableCollection<Department>;
            set => DepList.ItemsSource = value;
        }
        public ObservableCollection<Employee> Department
        {
            get => EmpList.ItemsSource as ObservableCollection<Employee>;
            set => EmpList.ItemsSource = value;
        }
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
        }

        #region Обработчики событий
        /// <summary>
        /// Вызывается при изменении выбранного элемента в списке департаментов.
        /// Передает информацию в список сотрудников.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (DepList.SelectedItem != null)
            //{
            //    EmpList.ItemsSource = (DepList.SelectedItem as Department).Employees;
            //}
        }
        ///// <summary>
        ///// Вызывается при изменении выбранного элемента в списке сотрудников.
        ///// Передает информацию в форму с данными о сотруднике.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void EmpList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //EmpParamPannel.DataContext = (EmpList.SelectedItem as Employee);
            //DepComboBox.ItemsSource = company.Departments;
            //DepComboBox.SelectedItem = DepList.SelectedItem as Department;
        }
        ///// <summary>
        ///// Вызывается при нажатии на кнопку удаления сотрудника.
        ///// Удаляет выбранного сотрудника из выбранного департамента
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void DeleteEmpBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (DepList.SelectedItem != null && EmpList.SelectedItem != null)
            //{
            //    (DepList.SelectedItem as Department).Employees.Remove((EmpList.SelectedItem as Employee));
            //}

        }
        ///// <summary>
        ///// Вызывается при нажатии на кнопку добавления сотрудника.
        ///// Добавляет сотрудника в выбранный  департамент.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void AddEmpBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (DepList.SelectedItem != null)
            //{
            //    (DepList.SelectedItem as Department).Employees.Add(new Employee() { Name = "New Employee" });
            //}
        }
        ///// <summary>
        ///// Вызывается при нажатии на кнопку добавления департамента.
        ///// Добавляет новый департамент в компанию
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void AddDepBtn_Click(object sender, RoutedEventArgs e)
        {
            //company.Departments.Add(new Department() { Name = "New Department" });
        }
        ///// <summary>
        ///// Вызывается при изменении выбранного элемента в спсике департаментов сотрудника и перемещает его в выбранный департамент.
        ///// Затем удаляет его из текущего департамента
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void DepComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (DepList.SelectedItem != null && EmpList.SelectedItem != null)
            //{
            //    (DepComboBox.SelectedItem as Department).Employees.Add(EmpList.SelectedItem as Employee);
            //    (DepList.SelectedItem as Department).Employees.Remove(EmpList.SelectedItem as Employee);
            //}
        }
        ///// <summary>
        ///// Вызывается при нажатии на кнопку удаления департамента.
        ///// Удаляет департамент из компании, если он может быть удален.
        ///// Если в департаменте есть сотрудники, они будут перемещены в специальный департамент под название "Сотрудники без департамента"
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void DeleteDepBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (DepList.SelectedItem != null && (DepList.SelectedItem as Department).Deletable)
            //{
            //    foreach (var employee in (DepList.SelectedItem as Department).Employees)
            //    {
            //        company.NoDepEmployees.Employees.Add(employee);
            //    }
            //    company.Departments.Remove(DepList.SelectedItem as Department);
            //    EmpList.ItemsSource = null;
            //}
        }
        #endregion

    }
}
