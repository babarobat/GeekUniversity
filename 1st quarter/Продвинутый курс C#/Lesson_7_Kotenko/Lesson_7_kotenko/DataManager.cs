using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Lesson_7_kotenko
{
    public static class DataManager
    {
        
        public static void SaveEmployee(string path, string table,Employee emp)   
        {   
            try
            {
                var sql = $@"INSERT INTO {table} (Name, Department, Age, Selary) 
                       VALUES ('{emp.Name}', '{emp.Dep}','{emp.Age.ToString()}', '{emp.Sel.ToString()}')";
                using (SqlConnection connection = new SqlConnection(path))
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
                using (SqlConnection connection = new SqlConnection(path))
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
    }
}
