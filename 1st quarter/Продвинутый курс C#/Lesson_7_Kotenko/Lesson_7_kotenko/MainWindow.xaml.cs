using System;
using System.Collections.Generic;
using System.Data;
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

namespace Lesson_7_kotenko
{
    /// <summary>
    /// Логика взоимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = @"Data Source=(localdb)\MSSQLLocalDB;
                            Initial Catalog = Lesson7;
                            Integrated Security = True;
                            Pooling = False";
        public MainWindow()
        {
            InitializeComponent();
            #region Создание таблиц и загрузка в них данных


            // Саздание таблицы сотрудников

            // CREATE TABLE [dbo].[Employees]
            //(            
            //  [Id] INT IDENTITY(1, 1) NOT NULL,           
            //  [Name] NVARCHAR(MAX) NOT NULL,
            //  [Department] NVARCHAR(MAX) NULL, 
            //  [Age] INT NULL,
            //  [Selary] INT NULL
            //  CONSTRAINT[PK_dbo.Employees] PRIMARY KEY CLUSTERED([Id] ASC)
            // )

            //Создание таблицы департаментов

            //CREATE TABLE[dbo].[Departments]
            //(
            //[Id] INT IDENTITY(1, 1) NOT NULL,
            //[Name] NVARCHAR(MAX) NULL
            //CONSTRAINT[PK_dbo.Departments] PRIMARY KEY CLUSTERED([Id] ASC)
            //)


            //загрузка данных в таблицы

            

            //DataCreater.CreateData(50, path, "Employees", "Departments");
            #endregion
            DepList.ItemsSource = DataManager.GetDeps(path).DefaultView; //DataTable
        }

        private void DepList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            EmpList.ItemsSource = DataManager.GetEmps(path, (DepList.SelectedValue as DataRowView).Row[0].ToString()).DefaultView;
        }

        private void EmpList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmpParamPannel.DataContext = EmpList.SelectedItem as DataRowView;
        }

        private void NameTxt_TextChanged(object sender, TextChangedEventArgs e)
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

        private void DeleteDepBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DepName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DepComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
