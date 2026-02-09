create database TrainingDB;

use TrainingDB

--creating table
create table Employee
(
	EmployeeId int,
	FirstName varchar(50),
	LastName varchar(50),
	Email varchar(100),
	DeptName varchar(50),
	Salary decimal(10,2),
	DateOfJoining DATE	
)

--insert data into the created table
INSERT INTO Employee 
(EmployeeID, FirstName, LastName, Email, DeptName, Salary, DateOfJoining)
VALUES
(1, 'Aayush', 'Panchasara', 'aayush.p@company.com', 'IT', 55000.00, '2022-01-15'),
(2, 'Rahul', 'Sharma', 'rahul.sharma@company.com', 'HR', 42000.00, '2021-06-10'),
(3, 'Priya', 'Mehta', 'priya.mehta@company.com', 'Finance', 60000.00, '2020-03-20'),
(4, 'Amit', 'Patel', 'amit.patel@company.com', 'IT', 70000.00, '2019-11-05'),
(5, 'Neha', 'Singh', 'neha.singh@company.com', 'Marketing', 48000.00, '2022-08-01'),
(6, 'Kunal', 'Verma', 'kunal.verma@company.com', 'Sales', 45000.00, '2021-02-18'),
(7, 'Pooja', 'Joshi', 'pooja.joshi@company.com', 'HR', 50000.00, '2020-07-12'),
(8, 'Rohit', 'Kumar', 'rohit.kumar@company.com', 'IT', 65000.00, '2018-09-25'),
(9, 'Sneha', 'Iyer', 'sneha.iyer@company.com', 'Finance', 72000.00, '2019-04-30'),
(10, 'Vikas', 'Malhotra', 'vikas.m@company.com', 'Operations', 58000.00, '2021-12-06'),
(11, 'Anjali', 'Desai', 'anjali.desai@company.com', 'Marketing', 53000.00, '2020-10-14'),
(12, 'Suresh', 'Nair', 'suresh.nair@company.com', 'Sales', 47000.00, '2022-05-22'),
(13, 'Kiran', 'Reddy', 'kiran.reddy@company.com', 'IT', 80000.00, '2017-01-09'),
(14, 'Bhavna', 'Kapoor', 'bhavna.k@company.com', 'HR', 46000.00, '2023-03-01'),
(15, 'Arjun', 'Chauhan', 'arjun.chauhan@company.com', 'Finance', 68000.00, '2018-06-17');

select * from Employee

-- Query 1 
select top 5 * from Employee
order by Salary desc;


-- Query 2
select distinct DeptName from Employee
where DeptName like 's%';


-- Query 3
select * from Employee
where DeptName in ('Finance','HR','IT') and Salary > 50000


-- Query 4 : Here we filter the data based on DeptName and Salary, our intention is to find the employee whoes department is sales
--           or whoes salary is greater than 75000. We don't want both to be true at the same time. we check for any of the
--			 two conditions, if any one or both is true then we will include those rows in our result set.

select * from Employee
where DeptName = 'Sales' or Salary > 75000


-- Query 5
select * from Employee
where Email like '%'+FirstName+'%'


-- Query 6
select * from Employee
order by DateOfJoining
offset 5 rows
fetch next 5 rows only


-- Query 7
select * from Employee
where (DeptName = 'IT' and Salary > 60000) or (DeptName = 'HR' and DateOfJoining > '2020-01-01')

