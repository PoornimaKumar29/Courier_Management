using CourierManagement.entity;
using System;
using Microsoft.Data.SqlClient;

namespace CourierManagement.dao
{
    public class CourierAdminServiceImpl : ICourierAdminService
    {
        private readonly string connectionString = "Data Source=POORNIMA\\SQLSERVER2022;Initial Catalog=Courier_Management;Integrated Security=True;";

        
        public int AddCourierStaff(Employee employeeObj)
        {
            int employeeId = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                   
                    string query = "INSERT INTO Employee (Employee_Name, Employee_Email, Employee_phone, Employee_Role, Salary) " +
                                   "VALUES (@Employee_Name, @Employee_Email, @Employee_phone, @Employee_Role, @Salary);" +
                                   "SELECT SCOPE_IDENTITY();"; // To get the generated Employee_id

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Employee_Name", employeeObj.Employee_Name);
                    command.Parameters.AddWithValue("@Employee_Email", employeeObj.Employee_Email);
                    command.Parameters.AddWithValue("@Employee_phone", employeeObj.Employee_phone);
                    command.Parameters.AddWithValue("@Employee_Role", employeeObj.Employee_Role);
                    command.Parameters.AddWithValue("@Salary", employeeObj.Salary);

                    
                    employeeId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while adding courier staff: " + ex.Message);
            }
            catch (Exception ex)
            {
                
                throw new Exception("An unexpected error occurred: " + ex.Message);
            }

            return employeeId;
        }
    }
}
