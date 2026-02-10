-- SQL Assignment – Day 2

use TrainingDB

select * from Employee

truncate table Employee;

alter table Employee
drop column DeptName

alter table Employee
add DeptId int 


create table Department(
	Id int,
	DName varchar(50)
)

insert into Department
values
(1,'IT'),
(2,'HR'),
(3,'Sales'),
(4,'Finance'),
(5,'Marketing')

select * from Department

create table Skill(
	Id int not null,
	SName varchar(50) unique
)
alter table Skill
add constraint PK_SId primary key (Id);

insert into Skill
values
(100,'DOTNET'),
(101,'Angular'),
(102,'NodeJS'),
(103,'AI/ML'),
(104,'Java')

select * from Skill


INSERT INTO Employee 
VALUES
(1, 'Aayush', 'Panchasara', 'aayush.p@company.com', 55000.00, '2022-01-15',1),
(2, 'Rahul', 'Sharma', 'rahul.sharma@company.com', 42000.00, '2021-06-10',2),
(3, 'Priya', 'Mehta', 'priya.mehta@company.com',  60000.00, '2020-03-20',4),
(4, 'Amit', 'Patel', 'amit.patel@company.com', 70000.00, '2019-11-05',1),
(5, 'Neha', 'Singh', 'neha.singh@company.com', 48000.00, '2022-08-01',5),
(6, 'Kunal', 'Verma', 'kunal.verma@company.com', 45000.00, '2021-02-18',3),
(7, 'Pooja', 'Joshi', 'pooja.joshi@company.com', 50000.00, '2020-07-12',2),
(8, 'Rohit', 'Kumar', 'rohit.kumar@company.com', 65000.00, '2018-09-25',1),
(9, 'Sneha', 'Iyer', 'sneha.iyer@company.com', 72000.00, '2019-04-30',4),
(10, 'Vikas', 'Malhotra', 'vikas.m@company.com',  58000.00, '2021-12-06',1),
(11, 'Anjali', 'Desai', 'anjali.desai@company.com',  53000.00, '2020-10-14',5),
(12, 'Suresh', 'Nair', 'suresh.nair@company.com' , 47000.00, '2022-05-22',3),
(13, 'Kiran', 'Reddy', 'kiran.reddy@company.com',  80000.00, '2017-01-09',1),
(14, 'Bhavna', 'Kapoor', 'bhavna.k@company.com',  46000.00, '2023-03-01',2),
(15, 'Arjun', 'Chauhan', 'arjun.chauhan@company.com', 68000.00, '2018-06-17',4);


-- Query 1

create view vw_EmployeeBasicInfo as 
select EmployeeId, FirstName, DeptId from Employee

select * from vw_EmployeeBasicInfo

-- Query 2
with FinanceEmployeeCTE as (
	select * from Employee
	where DeptId = 4
)

select * from FinanceEmployeeCTE




-- Query 3
select * into #TempHREmployees from Employee where DeptId = 2

select * from #TempHREmployees

-- Query 4

create table EmployeeSkill(
	EmpId int foreign key references Employee(EmployeeId),
	SkId int foreign key references Skill(Id)
)

insert into EmployeeSkill
values
(1,100),
(1,101),
(2,100),
(3,102),
(3,104),
(5,103),
(6,100),
(7,103)

select * from EmployeeSkill

 

with InterMediateCTE as (
select EmpId from EmployeeSkill
group by EmpId 
having count(SkId) > 1
)
select FirstName,LastName from Employee
where EmployeeId in (select EmpId from InterMediateCTE)




-- Query 5

alter table Employee
alter column EmployeeID int not null

alter table Department
alter column Id int not null


--Add primary key constraint
alter table Employee
add constraint PK_EmpId primary key (EmployeeId)

alter table Department
add constraint PK_Id primary key (Id)

--Add foreign key
alter table Employee
add constraint FK_DeptId foreign key (DeptId) references Department(Id)

--Add unique key
alter table Employee
add constraint UQ_Email unique (Email)
