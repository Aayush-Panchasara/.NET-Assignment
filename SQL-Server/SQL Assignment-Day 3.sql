-- Query 1

create function CalculateExperience(@DateOfJoining Date)
returns decimal(3,1)
as
begin
	return datediff(MONTH,@DateofJoining,getdate())/12.0
end;



select FirstName, LastName, dbo.CalculateExperience(DateOfJoining) as Experience_In_Years  from Employee


-- Query 2

create function GetEmployeeByDept(@DeptId int)
returns table
as
return (
	select FirstName, LastName,
		case 
			when dbo.CalculateExperience(DateOfJoining) > 5 then 'Yes'
			else 'No'
		end as IsSenior
	from Employee
	where DeptId = @DeptId
)


select * from dbo.GetEmployeeByDept(3);


-- Query 3

create procedure InsertNewData
	@EmpId int,
	@FirstName varchar(50),
	@LastName varchar(50),
	@Email varchar(100),
	@Salary decimal(10,2),
	@JoiningDate Date,
	@DeptId int
as
begin
	if exists (select 1 from Employee where Email = @Email)
	begin
	 ;throw 50001,'Email already exist',1;
	end

	insert into Employee
	values (@EmpId,@FirstName,@LastName,@Email,@Salary,@JoiningDate,@DeptId)

end



select * from Employee

exec dbo.InsertNewData 16,'Mann','Badresiya','mann@company.com',50000,'2022-02-13',3

begin try
	exec dbo.InsertNewData 17,'Aayush','Prajapati','aayush.p@company.com',60000,'2021-02-13',2
end try
begin catch
		select ERROR_NUMBER() as ErrorCode, ERROR_MESSAGE() as ErrorMessage		
end catch



-- Query 4

create procedure CalculateSalary
	@StartDate date,
	@EndDate date
as
begin
	select DeptId, 
			sum(
				case 
				when DateOfJoining <= @StartDate then (datediff(DAY,@StartDate,@EndDate)+1)*Salary/30.0
				when @StartDate < DateOfJoining and DateOfJoining <= @EndDate  then (datediff(DAY,DateOfJoining,@EndDate)+1)*Salary/30.0
				else 0
				end
			) as TotalSalary
		from Employee
		group by DeptId		
end


create table #TotalSalaryByDepartment
(
	DeptId int not null,
	TotalSalary decimal(10,2)
)

insert into #TotalSalaryByDepartment exec dbo.CalculateSalary @StartDate='2022-01-01', @EndDate= '2024-01-01'

select * from #TotalSalaryByDepartment



--Query 5

create table Product
(
	PId int not null,
	PName varchar(50)
)

insert into Product
values
(201,'Pen'),
(202,'Book'),
(203,'Laptop'),
(204,'Mouse'),
(205,'Shirt'),
(206,'Shoes'),
(207,'Charger'),
(208,'Bag'),
(209,'keyboard'),
(210,'Earphone')


select * from Product

create table Orders
(
	OId int not null,
	PId int not null,
	Amount decimal(10,2),
	OrderDate Date
)


create table OrderAudit
(
	AId int identity(1,1),
	OId int not null,
	InsertedDate datetime,
	InsertedBy varchar(50)
)


create trigger AuditingTrigger
on Orders
after insert
as
begin
	insert into OrderAudit(OId,InsertedDate,InsertedBy)
	select 
		i.OId,
		GETDATE(),
		SYSTEM_USER
	from inserted as i;
end;

insert into Orders
values
(100,201,5000,'2024-01-15'),
(101,206,2500,'2024-02-02'),
(102,205,1000,'2023-12-25'),
(103,202,1500,'2025-09-30'),
(104,201,3500,'2026-01-31'),
(105,203,25000,'2023-08-15'),
(106,204,4000,'2022-11-21'),
(107,203,30000,'2024-10-14')

select * from Orders

select * from OrderAudit

-- Query 6

create trigger PreventDeletion
on Product
after delete
as
begin
	if exists (select 1 from Orders as o
				join deleted as d on o.PId = d.PId)
	begin
		;throw 50003,'Deletion failed, Product are exist in Orders',5

		rollback transaction
	end
end

select * from Orders

select * from Product

delete from Product where PId = 209

begin try
	delete from Product where PId = 201
end try
begin catch
	select ERROR_NUMBER() as ErrorCode, ERROR_MESSAGE() as ErrorMessage
end catch