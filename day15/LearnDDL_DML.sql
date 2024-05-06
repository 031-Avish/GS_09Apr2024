--to create the database
create database dbEmployeeTracker

-- select the database you want to work on
use dbEmployeeTracker;

-- delete database 
use master;
go 
drop database dbEmployeeTracker; --cannot directly drop while using it


-- create table 

create Table Areas
( Area varchar(20),
  Zipcode char(5)
  );

 -- see the table 
select * from Areas;

-- see table description 
sp_help Areas;

-- edit the area column to primary key

alter table Areas
alter column Area varchar(20) not null;

alter table Areas 
add constraint pk_Area primary key (Area);


-- second way by deleting table 
drop table Areas;

create Table Areas
( Area varchar(20) constraint pk_Area primary key,
Zipcode char(5)
);

-- Alter and add column 

alter table Areas
add AreaDesc varchar(1000);

select * from Areas
-- alter and remove the column 

alter table Areas
drop column AreaDesc;


--create table Skills
--(
--Skill varchar(20) constraint pk_Skill primary key ,
--Desciption varchar(20)
--);
drop table Skills ;
create table Skills(
Skill_id int identity(1,1) constraint pk_skill primary key,
Skill varchar(20),
SkillDescription varchar(100))

select * from Skills;

create table Employees
(
id int identity(101,1) constraint pk_employees primary key,
Name varchar(100) not null,
DateOfBirth datetime constraint chk_DOB check(DateOfBirth<Getdate()),
EmployeeArea varchar(20) constraint fk_Area references Areas(Area), -- the value you provide here should already be present in the area table 
Phone varchar(20),
email varchar(100) not null
);
sp_help Employees;

create table EmployeeSkill
( Employee_id int constraint fk_skill_eid foreign key references Employees(id),
Skill int constraint fk_skill_EmplSkill foreign key references Skills(skill_id),
Skilllevel float constraint chk_skilllevel check(Skilllevel > 0),
constraint pk_employee_skill primary key (Employee_id, skill)
);



--DML--
Insert into Areas(Area,Zipcode) values('DDDD','12345')
Insert into Areas(Zipcode,Area) values('12333','FFFF')
insert into Areas values('HHHH','12222')
insert into Areas values('IIII','12223'),('KKKK','12121')

--Insert Failures
Insert into Areas(Area,Zipcode) values('DDDD','12345')--Primary key duplication
Insert into Areas(Area,Zipcode) values('OOOO','12345334')--Size violation
Insert into Areas(Zipcode) values('12345')--Primary key null

select * from Areas

--Foreign Key insert
insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
Values('Ramu','2000-12-12','DDDD','9876543210','ramu@gmail.com')
insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
Values('Somu','2001-05-01','FFFF','9988776655','somu@gmail.com')

-- error because Area is not present in Areas table
insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
Values('Somu','2001-05-01','FFsF','9988776655','somu@gmail.com')
select * from Employees

insert into skills(Skill,SkillDescription) values('C','PLT')
insert into skills(Skill,SkillDescription) values('C++','OOPS'),('Java','Web'),('C#','Web'),('SQL','RDBMS')
select * from skills
--Employee Skill- Composite key

Insert into EmployeeSkill values(101,3,8)


--Update 
update Employees set phone = '9876543210'
where id = 101
update Employees set phone = '9988776655'
where id = 102


Insert into EmployeeSkill values(102,2,7)
Insert into EmployeeSkill values(102,3,7)

select * from EmployeeSkill;
update EmployeeSkill set skillLevel = 8
where skill = 2 and Employee_id = 101

-- Update the skill level to 5 if it is 7 and to 9 if it is 8 otherwise leave it as it is
update EmployeeSkill set skillLevel = 
				case 
				when skillLevel= 7 then 5
				when skillLevel = 8 then 9
				else skillLevel
				end
where Employee_id = 101



Delete from EmployeeSkill --where Employee_id = 105


select * from areas

delete from Areas where area ='KKKK'
-- cannot delete 
delete from Areas where area = 'DDDD'