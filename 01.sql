Create Database Employee

use employee
Create Table Departments(
DeptID int identity(1,1) primary key,
DeptName varchar(50)
)

Create Table Employees(
ID int identity(1,1) primary key,
Name varchar(50),
Salary int,
Department int references Departments
)
select * from employees
select * from Departments
insert into Departments values('Admin'),('HR'),('Computer')
insert into Employees values('Shahina',10000,3),('Ragini',15000,3),('Priyanka',8000,2),('Ankita',5000,1)
select id,Name,Salary,Emp.department,Dept.DeptName from Employees Emp left join Departments Dept on Dept.deptid=Emp.Department