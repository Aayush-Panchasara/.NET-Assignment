create database BasicsDB

use BasicsDB

-- 1)Create Tables

-- Query 1
create table Departments
(
	DepartmentId int primary key,
	DepartmentName varchar(50) unique not null
)


insert into Departments
values
(1,'IT'),
(2,'HR'),
(3,'Finance'),
(4,'Marketing'),
(5,'Sales')

select * from Departments

-- Query 2
create table Employee
(
	EmployeeId int primary key,
	EmpName varchar(50) not null,
	Salary decimal(10,2) check (Salary > 15000),
	HireDate Date,
	DepartmentId int foreign key references Departments(DepartmentId)
)

-- 2)Alter Table & Comstraint

-- Query 1
alter table Employee
add Email varchar(50) unique


-- Query 2
alter table Employee
add IsActive int default 1

insert into Employee(EmployeeId,EmpName,Salary,HireDate,DepartmentId,Email)
values (100,'Aayush Panchasara',55000,'2025-01-05',1,'aayush.p@company.com')

insert into Employee
values (101,'Divyanshu Panchasara',55000,'2026-01-05',1,'ayush.p@company.com',0)

select * from Employee

-- Query 3

alter table Employee
alter column Salary decimal(8,2)

-- Query 4
alter table Employee
add constraint chk_Hiredate check (HireDate <= getdate())

insert into Employee(EmployeeId,EmpName,Salary,HireDate,DepartmentId,Email)
values (101,'Aayush Prajapati',50000,'2026-04-05',2,'ayush.p@company.com')

-- 3) DML

-- Query 1
insert into Employee(EmployeeId,EmpName,Salary,HireDate,DepartmentId,Email)
values
(102,'Niken Patel',50000,'2026-01-04',2,'niken.p@company.com'),
(103,'Mann Patel',40000,'2025-02-04',1,'mann.p@company.com'),
(104,'Devam Satasiya',59000,'2026-01-06',4,'devam.s@company.com'),
(105,'Raj Rana',60000,'2022-10-14',3,'raj.r@company.com'),
(106,'Ashish Pateliya',45000,'2025-09-04',1,'ashish.p@company.com'),
(107,'Krunal khairnar',55000,'2025-11-24',1,'krunal.k@company.com'),
(108,'Het',40000,'2024-03-15',5,'het@company.com'),
(109,'Ayush Dumasiya',60000,'2024-12-04',5,'ayush.d@company.com')

select * from Employee


-- Query 2
update Employee
set Salary = Salary*1.05
where DepartmentId = 1

select * from Employee

-- Query 3
update Employee
set IsActive = 0
where HireDate > '2025-12-31'

select * from  Employee

-- Query 4
delete from Employee
where IsActive = 0

select * from  Employee


-- Query 5
update Employee
set DepartmentId = 2
where EmployeeId in (100,103)

select * from Employee

-- 4) Joins

-- Query 1
select e.EmpName, d.DepartmentName from Employee e
inner join Departments d
on e.DepartmentId = d.DepartmentId


-- Query 2
select d.DepartmentName from Departments d
left join Employee e
on d.DepartmentId = e.DepartmentId
group by d.DepartmentName
having count(e.EmployeeId) = 0

-- Query 3
select d.DepartmentName, Max(e.Salary) from Departments d
inner join Employee e
on d.DepartmentId = e.DepartmentId
group by d.DepartmentName
