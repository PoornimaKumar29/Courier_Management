using System;
using System.Collections.Generic;
using CourierManagement.dao;
using CourierManagement.entity;
using CourierManagement.exception;
using Microsoft.Data.SqlClient;

namespace CourierManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            CourierUserServiceImpl courierUserService = new CourierUserServiceImpl();
            CourierAdminServiceImpl courierAdminService = new CourierAdminServiceImpl();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Courier Management System");
                Console.WriteLine("1. Place an Order");
                Console.WriteLine("2. Get Order Status");
                Console.WriteLine("3. Cancel Order");
                Console.WriteLine("4. Add Courier Staff");
                Console.WriteLine("5. Get Assigned Orders for Courier Staff");
                Console.WriteLine("6. View All Couriers");
                Console.WriteLine("7. View All Employees");
                Console.WriteLine("8. View Delivery History"); 
                Console.WriteLine("9. Generate Report");
                Console.WriteLine("10. Exit");
                Console.Write("Enter your choice: ");
                
                int choice = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                           
                            Courier courierObj = new Courier();
                            Console.Write("Enter Sender Name: ");
                            courierObj.SenderName = Console.ReadLine();
                            Console.Write("Enter Sender Address: ");
                            courierObj.SenderAddress = Console.ReadLine();
                            Console.Write("Enter Receiver Name: ");
                            courierObj.ReceiverName = Console.ReadLine();
                            Console.Write("Enter Receiver Address: ");
                            courierObj.ReceiverAddress = Console.ReadLine();
                            Console.Write("Enter Weight: ");
                            courierObj.Weight = Convert.ToDecimal(Console.ReadLine());
                            Console.Write("Enter Status: ");
                            courierObj.Status = Console.ReadLine();
                            Console.Write("Enter Delivery Date (yyyy-mm-dd): ");
                            courierObj.Delivary_Date = Convert.ToDateTime(Console.ReadLine());
                            Console.Write("Enter Employee ID: ");
                            courierObj.Employee_id = Convert.ToInt32(Console.ReadLine());

                            try
                            {
                                long trackingNumber = courierUserService.PlaceOrder(courierObj);
                                Console.WriteLine($"Order placed successfully. Tracking Number: {trackingNumber}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;

                        case 2:
                            
                            Console.Write("Enter Tracking Number: ");
                            long trackingNumberForStatus = Convert.ToInt64(Console.ReadLine());

                            try
                            {
                                string status = courierUserService.GetOrderStatus(trackingNumberForStatus);
                                Console.WriteLine($"Order Status: {status}");
                            }
                            catch (TrackingNumberNotFoundException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;

                        case 3:
                            // Code for cancelling an order
                            Console.Write("Enter Tracking Number to cancel the order: ");
                            long trackingNumberForCancel = Convert.ToInt64(Console.ReadLine());

                            try
                            {
                                bool isCancelled = courierUserService.CancelOrder(trackingNumberForCancel);
                                if (isCancelled)
                                {
                                    Console.WriteLine("Order cancelled successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Order cancellation failed.");
                                }
                            }
                            catch (TrackingNumberNotFoundException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;

                        case 4:
                           
                            Employee employeeObj = new Employee();
                            Console.Write("Enter Employee Name: ");
                            employeeObj.Employee_Name = Console.ReadLine();
                            Console.Write("Enter Employee Email: ");
                            employeeObj.Employee_Email = Console.ReadLine();
                            Console.Write("Enter Employee Phone: ");

                           
                            if (!long.TryParse(Console.ReadLine(), out long phone))
                            {
                                Console.WriteLine("Invalid phone number input. Please enter a valid numeric phone number.");
                                return; 
                            }
                            employeeObj.Employee_phone = phone;

                            Console.Write("Enter Employee Role: ");
                            employeeObj.Employee_Role = Console.ReadLine();

                            Console.Write("Enter Employee Salary: ");
                            if (!decimal.TryParse(Console.ReadLine(), out decimal salary))
                            {
                                Console.WriteLine("Invalid salary input. Please enter a valid decimal value.");
                                return; 
                            }
                           
                            employeeObj.Salary = (int)salary;

                            try
                            {
                                int employeeId = courierAdminService.AddCourierStaff(employeeObj);
                                Console.WriteLine($"Courier staff added successfully with Employee ID: {employeeId}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;


                        case 5:
                            
                            Console.Write("Enter courier staff ID to get assigned orders: ");
                            int courierStaffId = Convert.ToInt32(Console.ReadLine());

                            try
                            {
                                List<Courier> assignedOrders = courierUserService.GetAssignedOrder(courierStaffId);

                                if (assignedOrders.Count == 0)
                                {
                                    Console.WriteLine("No assigned orders found for this courier staff.");
                                }
                                else
                                {
                                    Console.WriteLine($"Assigned Orders for Courier Staff ID {courierStaffId}:");
                                    foreach (var order in assignedOrders)
                                    {
                                        Console.WriteLine($"Tracking Number: {order.Tracking_Number}, Sender: {order.SenderName}, Receiver: {order.ReceiverName}, Status: {order.Status}");
                                    }
                                }
                            }
                            catch (InvalidEmployeeIdException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine($"Database error: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                            }
                            break;
                        case 6:
                            
                            try
                            {
                                List<Courier> allCouriers = courierUserService.GetAllCouriers();

                                if (allCouriers.Count == 0)
                                {
                                    Console.WriteLine("No couriers found.");
                                }
                                else
                                {
                                    Console.WriteLine("List of All Couriers:");
                                    foreach (var courier in allCouriers)
                                    {
                                        Console.WriteLine($"Tracking Number: {courier.Tracking_Number}, Sender: {courier.SenderName}, Receiver: {courier.ReceiverName}, Status: {courier.Status}");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;

                        case 7:
                            
                            try
                            {
                                List<Employee> allEmployees = courierUserService.GetAllEmployees();

                                if (allEmployees.Count == 0)
                                {
                                    Console.WriteLine("No employees found.");
                                }
                                else
                                {
                                    Console.WriteLine("List of All Employees:");
                                    foreach (var emp in allEmployees)
                                    {
                                        Console.WriteLine($"ID: {emp.Employee_id}, Name: {emp.Employee_Name}, Role: {emp.Employee_Role}, Phone: {emp.Employee_phone}, Email: {emp.Employee_Email}");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;

                        case 8:
                            // View delivery history
                            try
                            {
                                List<Courier> deliveryHistory = courierUserService.ViewDeliveryHistory();

                                if (deliveryHistory.Count == 0)
                                {
                                    Console.WriteLine("No delivery history found.");
                                }
                                else
                                {
                                    Console.WriteLine("Delivery History:");
                                    foreach (var delivery in deliveryHistory)
                                    {
                                        Console.WriteLine($"Tracking Number: {delivery.Tracking_Number}, Sender: {delivery.SenderName}, Receiver: {delivery.ReceiverName}, Delivered On: {delivery.Delivary_Date}");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        case 9:
                           
                            try
                            {
                                var report = courierUserService.GenerateReport();

                                if (report.Count == 0)
                                {
                                    Console.WriteLine("No data for report.");
                                }
                                else
                                {
                                    Console.WriteLine("Courier Status Report:");
                                    foreach (var status in report)
                                    {
                                        Console.WriteLine($"{status.Key}: {status.Value}");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        case 10:
                            Console.WriteLine("Exiting the application...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
