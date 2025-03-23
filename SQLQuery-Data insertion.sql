
------------ Insert sample data into User_tb
INSERT INTO User_tb (User_Name, User_Email, User_Password, User_Phone, User_Address) VALUES
('John Doe', 'john@example.com', 'pass123', 9876543210, '123 Main St'),
('Alice Smith', 'alice@example.com', 'alicepass', 9876543211, '456 Oak St'),
('Bob Johnson', 'bob@example.com', 'bobpass', 9876543212, '789 Pine St'),
('Charlie Brown', 'charlie@example.com', 'charliepass', 9876543213, '101 Elm St'),
('David White', 'david@example.com', 'davidpass', 9876543214, '202 Maple St'),
('Eva Green', 'eva@example.com', 'evapass', 9876543215, '303 Cedar St'),
('Frank Black', 'frank@example.com', 'frankpass', 9876543216, '404 Birch St'),
('Grace Blue', 'grace@example.com', 'gracepass', 9876543217, '505 Willow St'),
('Henry Red', 'henry@example.com', 'henrypass', 9876543218, '606 Spruce St'),
('Ivy Yellow', 'ivy@example.com', 'ivypass', 9876543219, '707 Chestnut St');
------------------- Insert sample data into Courier
INSERT INTO Courier (SenderName, SenderAddress, ReceiverName, ReceiverAddress, Weight, Status, Tracking_Number, Delivary_Date) VALUES
('John Doe', '123 Main St', 'Alice Smith', '456 Oak St', 2.5, 'delivered', 100001, '2024-03-01'),
('Alice Smith', '456 Oak St', 'Bob Johnson', '789 Pine St', 5.0, 'Dispatched', 100002, '2024-03-02'),
('Bob Johnson', '789 Pine St', 'Charlie Brown', '101 Elm St', 3.8, 'delivered', 100003, '2024-03-03'),
('Charlie Brown', '101 Elm St', 'David White', '202 Maple St', 4.5, 'delivered', 100004, '2024-03-04'),
('David White', '202 Maple St', 'Eva Green', '303 Cedar St', 6.2, 'Dispatched', 100005, '2024-03-05'),
('Eva Green', '303 Cedar St', 'Frank Black', '404 Birch St', 7.0, 'delivered', 100006, '2024-03-06'),
('Frank Black', '404 Birch St', 'Grace Blue', '505 Willow St', 3.3, 'Dispatched', 100007, '2024-03-07'),
('Grace Blue', '505 Willow St', 'Henry Red', '606 Spruce St', 4.8, 'delivered', 100008, '2024-03-08'),
('Henry Red', '606 Spruce St', 'Ivy Yellow', '707 Chestnut St', 2.9, 'delivered', 100009, '2024-03-09'),
('Ivy Yellow', '707 Chestnut St', 'John Doe', '123 Main St', 5.1, 'Dispatched', 100010, '2024-03-10');

--------------------- Insert sample data into CourierService
INSERT INTO CourierService (ServiceName, Cost) VALUES
('Standard Delivery', 50.00),
('Express Delivery', 100.00),
('Same-Day Delivery', 150.00),
('Overnight Delivery', 200.00),
('International Shipping', 500.00),
('Eco-Friendly Delivery', 70.00),
('Bulk Shipping', 250.00),
('Fragile Item Delivery', 120.00),
('Premium Service', 300.00),
('Drone Delivery', 400.00);

----------------------- Insert sample data into Employee
INSERT INTO Employee (Employee_Name, Employee_Email, Employee_Phone, Employee_Role, Salary) VALUES
('Michael Scott', 'michael@example.com', 9876543220, 'Manager', 50000),
('Dwight Schrute', 'dwight@example.com', 9876543221, 'Sales', 30000),
('Jim Halpert', 'jim@example.com', 9876543222, 'Sales', 30000),
('Pam Beesly', 'pam@example.com', 9876543223, 'Receptionist', 20000),
('Stanley Hudson', 'stanley@example.com', 9876543224, 'Sales', 30000),
('Kevin Malone', 'kevin@example.com', 9876543225, 'Accounting', 35000),
('Angela Martin', 'angela@example.com', 9876543226, 'Accounting', 35000),
('Oscar Martinez', 'oscar@example.com', 9876543227, 'Accounting', 35000),
('Ryan Howard', 'ryan@example.com', 9876543228, 'Temp', 15000),
('Toby Flenderson', 'toby@example.com', 9876543229, 'HR', 40000);

---------------------- Insert sample data into Location
INSERT INTO Location (Location_Name, Address) VALUES
('New York', 'NY, USA'),
('Los Angeles', 'CA, USA'),
('Chicago', 'IL, USA'),
('Houston', 'TX, USA'),
('Phoenix', 'AZ, USA'),
('Philadelphia', 'PA, USA'),
('San Antonio', 'TX, USA'),
('San Diego', 'CA, USA'),
('Dallas', 'TX, USA'),
('San Jose', 'CA, USA');

---------------------- Insert sample data into Payment
INSERT INTO Payment (Courier_id, Location_id, Amount, PaymentDate) VALUES
(101, 201, 100, '2024-03-01'),
(102, 202, 200, '2024-03-02'),
(103, 203, 150, '2024-03-03'),
(104, 204, 250, '2024-03-04'),
(105, 205, 180, '2024-03-05'),
(106, 206, 220, '2024-03-06'),
(107, 207, 300, '2024-03-07'),
(108, 208, 400, '2024-03-08'),
(109, 209, 500, '2024-03-09'),
(110, 210, 600, '2024-03-10');