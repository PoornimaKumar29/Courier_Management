use Courier_Management
----------------------------------------------------------------------create usertable-----------------------------------------
create table User_tb(
User_id int identity(1,1) 
constraint pk_userid primary key(User_id),
User_Name varchar(100) not null,
User_Email varchar(100) unique not null,
User_Password varchar(100) unique not null,
User_Phone bigint unique not null,
User_Address varchar(100)
)
drop table User_tb

-------------------------------------------------------------------------create Courier table---------------------------------------------
create table Courier(
Courier_id int identity(101,1) primary key,
SenderName varchar(100) not null,
SenderAddress varchar(100)not null,
ReceiverName varchar(100) not null,
ReceiverAddress varchar(100) not null,
Weight decimal(5,2) check(weight>0),
Status varchar(50) check(Status in ('delivered','Dispatched')),
Tracking_Number bigint unique not null,
Delivary_Date date not null
)
alter table courier add Employee_id int;
alter table courier add constraint fk_employee foreign key(Employee_id) references Employee(Employee_id);

drop table Courier
---------------------------------------------------------------------create Courierservice table--------------------------------------------
create table Courierservice(
Service_id int identity(1,1) primary key,
ServiceName varchar(100),
Cost decimal(5,2)
)
----------------------------------------------------------------------create employee table---------------------------------------------------------
create table Employee(
Employee_id int identity(1,1) primary key ,
Employee_Name varchar(100) not null,
Employee_Email varchar(100) unique not null ,
Employee_phone bigint unique not null,
Employee_Role varchar(100) not null,
Salary int not null default 10000
)

---------------------------------------------------------------------create Location table--------------------------------------------

create table Location(
Location_id int identity(201,1) primary key,
Location_Name varchar(100) not null,
Address varchar(100) not null,
)
--------------------------------------------------------------------create Courierservice table--------------------------------------------

create table Payment(
Payment_id int identity(1,1) primary key,
Courier_id int not null
constraint fk_courierid foreign key(Courier_id) references Courier(Courier_id),
Location_id int not null
constraint fk_locationid foreign key(Location_id) references Location(Location_id),
Amount int not null check(Amount>0),
PaymentDate date not null
)

drop table Payment









