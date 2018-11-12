using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lesson_8_kotenko.Models
{
    public class DataPeople
    {
        private SqlConnection sqlConnection;
        public DataPeople()
        {
            string connectionstring = @"Data Source = (localdb)\MSSQLLocalDB;
                                        Initial Catalog = Lesson7;
                                        Integrated Security = True; Pooling = False";
            sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
        }
        public List<Employee> GetList()
        {
            List<Employee> list = new List<Employee>();

            string sql = @"SELECT * FROM Employees";

            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(
                            new Employee()
                            {
                                Name = reader["Name"].ToString(),
                                Department = reader["Department"].ToString(),
                                Age = Convert.ToInt32(reader["Age"]),
                                Selary = Convert.ToInt32(reader["Selary"])
                            });
                    }
                }

            }

            return list;
        }

        public Employee GetPeopleId(int Id)
        {
            string sql = $@"SELECT * FROM Employees WHERE Id={Id}";
            Employee temp = new Employee();
            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        temp = new Employee()
                        {
                            Name = reader["Name"].ToString(),
                            Department = reader["Department"].ToString(),
                            Age = Convert.ToInt32(reader["Age"]),
                            Selary = Convert.ToInt32(reader["Selary"])
                        };
                    }
                }

            }
            return temp;
        }

        public bool AddPeople(Employee Worker)
        {
            try
            {
                string sqlAdd = $@" INSERT INTO Employees(Name, Department, Age, Selary)
                               VALUES(N'{Worker.Name}',
                                      N'{Worker.Department}',
                                      N'{Worker.Age}',
                                      N'{Worker.Selary}' ) ";

                

                using (var com = new SqlCommand(sqlAdd, sqlConnection))
                {
                    com.ExecuteNonQuery();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
