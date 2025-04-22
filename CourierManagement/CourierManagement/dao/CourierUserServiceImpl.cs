using CourierManagement.entity;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CourierManagement.exception;

namespace CourierManagement.dao
{
    public class CourierUserServiceImpl : ICourierUserService
    {
        private readonly string connectionString = "Data Source=POORNIMA\\SQLSERVER2022;Initial Catalog=Courier_Management;Integrated Security=True;";

        public long PlaceOrder(Courier courierObj)
        {
            long trackingNumber = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Random random = new Random();
                    trackingNumber = random.Next(100000000, 999999999); 

                    string query = "INSERT INTO Courier (SenderName, SenderAddress, ReceiverName, ReceiverAddress, Weight, Status, Tracking_Number, Delivary_Date, Employee_id) " +
                                   "VALUES (@SenderName, @SenderAddress, @ReceiverName, @ReceiverAddress, @Weight, @Status, @Tracking_Number, @Delivary_Date, @Employee_id)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SenderName", courierObj.SenderName);
                    command.Parameters.AddWithValue("@SenderAddress", courierObj.SenderAddress);
                    command.Parameters.AddWithValue("@ReceiverName", courierObj.ReceiverName);
                    command.Parameters.AddWithValue("@ReceiverAddress", courierObj.ReceiverAddress);
                    command.Parameters.AddWithValue("@Weight", courierObj.Weight);
                    command.Parameters.AddWithValue("@Status", courierObj.Status);
                    command.Parameters.AddWithValue("@Tracking_Number", trackingNumber);
                    command.Parameters.AddWithValue("@Delivary_Date", courierObj.Delivary_Date);
                    command.Parameters.AddWithValue("@Employee_id", courierObj.Employee_id);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("An error occurred while placing the order: " + ex.Message);
            }

            return trackingNumber;
        }

        public string GetOrderStatus(long trackingNumber)
        {
            string status = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Status FROM Courier WHERE Tracking_Number = @Tracking_Number";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Tracking_Number", trackingNumber);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        status = reader["Status"].ToString();
                    }
                    else
                    {
                        throw new TrackingNumberNotFoundException("Tracking number not found.");
                    }
                }
            }
            catch (TrackingNumberNotFoundException ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while retrieving the order status: " + ex.Message);
            }

            return string.IsNullOrEmpty(status) ? "Tracking Number Not Found" : status;
        }

        public bool CancelOrder(long trackingNumber)
        {
            bool isCancelled = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Courier SET Status = 'Cancelled' WHERE Tracking_Number = @Tracking_Number";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Tracking_Number", trackingNumber);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        isCancelled = true;
                    }
                    else
                    {
                        throw new TrackingNumberNotFoundException("Tracking number not found.");
                    }
                }
            }
            catch (TrackingNumberNotFoundException ex)
            {
                throw ex; 
            }
            catch (SqlException ex)
            {
                
                throw new Exception("An error occurred while canceling the order: " + ex.Message);
            }

            return isCancelled;
        }

        public List<Courier> GetAssignedOrder(int courierStaffId)
        {
            List<Courier> assignedOrders = new List<Courier>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Courier WHERE Employee_id = @Employee_id";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Employee_id", courierStaffId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        throw new InvalidEmployeeIdException("Invalid Employee ID.");
                    }

                    while (reader.Read())
                    {
                        Courier courier = new Courier
                        {
                            Courier_id = Convert.ToInt32(reader["Courier_id"]),
                            SenderName = reader["SenderName"].ToString(),
                            SenderAddress = reader["SenderAddress"].ToString(),
                            ReceiverName = reader["ReceiverName"].ToString(),
                            ReceiverAddress = reader["ReceiverAddress"].ToString(),
                            Weight = Convert.ToDecimal(reader["Weight"]),
                            Status = reader["Status"].ToString(),
                            Tracking_Number = Convert.ToInt64(reader["Tracking_Number"]),
                            Delivary_Date = Convert.ToDateTime(reader["Delivary_Date"]),
                            Employee_id = Convert.ToInt32(reader["Employee_id"])
                        };

                        assignedOrders.Add(courier);
                    }
                }
            }
            catch (InvalidEmployeeIdException ex)
            {
                throw ex; 
            }
            catch (SqlException ex)
            {
                
                throw new Exception("An error occurred while retrieving assigned orders: " + ex.Message);
            }

            return assignedOrders;
        }
        public List<Courier> ViewDeliveryHistory()
        {
            List<Courier> deliveryHistory = new List<Courier>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Courier WHERE Status = 'Delivered' ORDER BY Delivary_Date DESC";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Courier courier = new Courier
                        {
                            Courier_id = reader["Courier_id"] != DBNull.Value ? Convert.ToInt32(reader["Courier_id"]) : 0,
                            SenderName = reader["SenderName"] != DBNull.Value ? reader["SenderName"].ToString() : string.Empty,
                            SenderAddress = reader["SenderAddress"] != DBNull.Value ? reader["SenderAddress"].ToString() : string.Empty,
                            ReceiverName = reader["ReceiverName"] != DBNull.Value ? reader["ReceiverName"].ToString() : string.Empty,
                            ReceiverAddress = reader["ReceiverAddress"] != DBNull.Value ? reader["ReceiverAddress"].ToString() : string.Empty,
                            Weight = reader["Weight"] != DBNull.Value ? Convert.ToDecimal(reader["Weight"]) : 0,
                            Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : string.Empty,
                            Tracking_Number = reader["Tracking_Number"] != DBNull.Value ? Convert.ToInt64(reader["Tracking_Number"]) : 0,
                            Delivary_Date = reader["Delivary_Date"] != DBNull.Value ? Convert.ToDateTime(reader["Delivary_Date"]) : DateTime.MinValue,
                            Employee_id = reader["Employee_id"] != DBNull.Value ? Convert.ToInt32(reader["Employee_id"]) : 0
                        };

                        deliveryHistory.Add(courier);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while retrieving delivery history: " + ex.Message);
            }

            return deliveryHistory;
        }


        public Dictionary<string, int> GenerateReport()
        {
            Dictionary<string, int> report = new Dictionary<string, int>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Status, COUNT(*) AS Count FROM Courier GROUP BY Status";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string status = reader["Status"].ToString();
                        int count = Convert.ToInt32(reader["Count"]);
                        report[status] = count;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while generating report: " + ex.Message);
            }

            return report;
        }
        public List<Courier> GetAllCouriers()
        {
            List<Courier> couriers = new List<Courier>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); 
                    string query = "SELECT * FROM Courier"; 
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Courier courier = new Courier
                        {
                            Tracking_Number = reader["Tracking_Number"] != DBNull.Value ? Convert.ToInt64(reader["Tracking_Number"]) : 0,
                            SenderName = reader["SenderName"] != DBNull.Value ? reader["SenderName"].ToString() : string.Empty,
                            SenderAddress = reader["SenderAddress"] != DBNull.Value ? reader["SenderAddress"].ToString() : string.Empty,
                            ReceiverName = reader["ReceiverName"] != DBNull.Value ? reader["ReceiverName"].ToString() : string.Empty,
                            ReceiverAddress = reader["ReceiverAddress"] != DBNull.Value ? reader["ReceiverAddress"].ToString() : string.Empty,
                            Weight = reader["Weight"] != DBNull.Value ? Convert.ToDecimal(reader["Weight"]) : 0,
                            Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : string.Empty,
                            Delivary_Date = reader["Delivary_Date"] != DBNull.Value ? Convert.ToDateTime(reader["Delivary_Date"]) : DateTime.MinValue,
                            Employee_id = reader["Employee_id"] != DBNull.Value ? Convert.ToInt32(reader["Employee_id"]) : 0
                        };
                        couriers.Add(courier);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return couriers;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employee";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee emp = new Employee
                        {
                            Employee_id = Convert.ToInt32(reader["Employee_id"]),
                            Employee_Name = reader["Employee_Name"].ToString(),
                            Employee_Email = reader["Employee_Email"].ToString(),
                            Employee_phone = Convert.ToInt64(reader["Employee_phone"]),
                            Employee_Role = reader["Employee_Role"].ToString(),
                            Salary = Convert.ToInt32(reader["Salary"])
                        };
                        employees.Add(emp);
                    }
                }
            }
            return employees;
        }

    }

}
