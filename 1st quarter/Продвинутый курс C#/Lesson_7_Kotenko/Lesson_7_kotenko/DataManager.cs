using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace Lesson_7_kotenko
{
    public static class DataManager
    {
        
        static SqlConnection connection;
        
        

        public static void SaveEmployee(string path, string table,Employee emp)   
        {   
            try
            {
                var sql = $@"INSERT INTO {table} (Name, Department, Age, Selary) 
                       VALUES ('{emp.Name}', '{emp.Dep}','{emp.Age.ToString()}', '{emp.Sel.ToString()}')";
                using (connection = new SqlConnection(path))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }           
        }
        public static void SaveDep(string path, string table, Department dep)
        {
            try
            {
                var sql = $@"INSERT INTO {table} (Name) 
                       VALUES ('{dep.Name}')";
                using (connection = new SqlConnection(path))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public static DataTable GetDeps(string path)
        {
            try
            {
                using (connection = new SqlConnection(path))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand("Select Distinct Department from Employees", connection);
                    adapter.SelectCommand = command;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }          
        }
        public static DataTable GetEmps(string path, string selectedDep)
        {
            try
            {
                using (connection = new SqlConnection(path))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand($"SELECT Name, Age, Department, Selary FROM Employees WHERE Department = @Department", connection);
                    command.Parameters.AddWithValue("Department", selectedDep);
                    adapter.SelectCommand = command;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static DataTable UpdateEmp(string path)
        {
            try
            {
                using (connection = new SqlConnection(path))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand($"Update Employees SET Name = @Name, Age = @Age, Department = @Department, Selary = @Selary WHERE ID = @ID", connection);
                    command.Parameters.AddWithValue("@Name",sql)
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}
