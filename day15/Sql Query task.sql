create table Department
(
deptname varchar(25) constraint pk_deptname primary key,
floor int,
phone varchar(12),
empno int not null
);


create table emp(
empno int constraint pk_empno primary key,
empname varchar(24) , 
salary decimal(10,2),
deptname varchar(25) constraint fk_department_emp foreign key 
references department(deptname),
bossno int constraint fk_bossno_emp foreign key references emp(empno)
);

alter table department
add constraint fk_empno_dept foreign key (empno) references emp(empno);

create table item (
itemname varchar(50) constraint pk_item primary key,
itemtype varchar(25),
itemcolor varchar(25),
)

create table sales(
salesno int constraint pk_Sales primary key,
saleqty int,
itemname varchar(50)  constraint fk_itemname_sales foreign key
references item(itemname) ,
deptname varchar(25)  constraint fk_deptname_sales foreign key 
references department(deptname),
);



-- Add data to the EMP table with deptname as NULL
INSERT INTO EMP (Empno, Empname, salary, deptname, Bossno) VALUES
(1, 'Alice', 75000, NULL, NULL),
(2, 'Ned', 45000, NULL, 1),
(3, 'Andrew', 25000, NULL, 2),
(4, 'Clare', 22000, NULL, 2),
(5, 'Todd', 38000, NULL, 1),
(6, 'Nancy', 22000, NULL, 5),
(7, 'Brier', 43000, NULL, 1),
(8, 'Sarah', 56000, NULL, 7),
(9, 'Sophile', 35000, NULL, 1),
(10, 'Sanjay', 15000, NULL, 3),
(11, 'Rita', 15000, NULL, 4),
(12, 'Gigi', 16000, NULL, 4),
(13, 'Maggie', 11000, NULL, 4),
(14, 'Paul', 15000, NULL, 3),
(15, 'James', 15000, NULL, 3),
(16, 'Pat', 15000, NULL, 3),
(17, 'Mark', 15000, NULL, 3);

select * from emp;

INSERT INTO DEPARTMENT (Deptname, floor, phone, empno) VALUES
('Management', 5, '34', 1),
('Books', 1, '81', 4),
('Clothes', 2, '24', 4),
('Equipment', 3, '57', 3),
('Furniture', 4, '14', 3),
('Navigation', 1, '41', 3),
('Recreation', 2, '29', 4),
('Accounting', 5, '35', 5),
('Purchasing', 5, '36', 7),
('Personnel', 5, '37', 9),
('Marketing', 5, '38', 2);

select * from department;

UPDATE EMP SET Deptname = 'Management' WHERE Empno = 1;
UPDATE EMP SET Deptname = 'Marketing' WHERE Empno IN (2, 3, 4);
UPDATE EMP SET Deptname = 'Accounting' WHERE Empno IN (5, 6);
UPDATE EMP SET Deptname = 'Purchasing' WHERE Empno IN (7, 8);
UPDATE EMP SET Deptname = 'Personnel' WHERE Empno = 9;
UPDATE EMP SET Deptname = 'Navigation' WHERE Empno = 10;
UPDATE EMP SET Deptname = 'Books' WHERE Empno IN (11, 12, 13);
UPDATE EMP SET Deptname = 'Equipment' WHERE Empno IN (14, 15);
UPDATE EMP SET Deptname = 'Furniture' WHERE Empno = 16;
UPDATE EMP SET Deptname = 'Recreation' WHERE Empno = 17;

-- Add data to the ITEM table
INSERT INTO ITEM (Itemname, itemtype, itemcolor) VALUES
('Pocket Knife-Nile', 'E', 'Brown'),
('Pocket Knife-Avon', 'E', 'Brown'),
('Compass', 'N', NULL),
('Geo positioning system', 'N', NULL),
('Elephant Polo stick', 'R', 'Bamboo'),
('Camel Saddle', 'R', 'Brown'),
('Sextant', 'N', NULL),
('Map Measure', 'N', NULL),
('Boots-snake proof', 'C', 'Green'),
('Pith Helmet', 'C', 'Khaki'),
('Hat-polar Explorer', 'C', 'White'),
('10 Easy Lessons', 'B', NULL),
('Hammock', 'F', 'Khaki'),
('How to win  Friends', 'B', NULL),
('Map case', 'E', 'Brown'),
('Safari Chair', 'F', 'Khaki'),
('Safari cooking kit', 'F', 'Khaki'),
('Stetson', 'C', 'Black'),
('Tent - 2 person', 'F', 'Khaki'),
('Tent -8 person', 'F', 'Khaki');


-- Add data to the SALES table
INSERT INTO SALES (Salesno, Saleqty, itemname, Deptname) VALUES
(101, 2, 'Boots-snake proof', 'Clothes'),
(102, 1, 'Pith Helmet', 'Clothes'),
(103, 1, 'Sextant', 'Navigation'),
(104, 3, 'Hat-polar Explorer', 'Clothes'),
(105, 5, 'Pith Helmet', 'Equipment'),
(106, 2, 'Pocket Knife-Nile', 'Clothes'),
(107, 3, 'Pocket Knife-Nile', 'Recreation'),
(108, 1, 'Compass', 'Navigation'),
(109, 2, 'Geo positioning system', 'Navigation'),
(110, 5, 'Map Measure', 'Navigation'),
(111, 1, 'Geo positioning system', 'Books'),
(112, 1, 'Sextant', 'Books'),
(113, 3, 'Pocket Knife-Nile', 'Books'),
(114, 1, 'Pocket Knife-Nile', 'Navigation'),
(115, 1, 'Pocket Knife-Nile', 'Equipment'),
(116, 1, 'Sextant', 'Clothes'),
(117, 1, null, 'Equipment'),
(118, 1, null, 'Recreation'),
(119, 1, null, 'Furniture'),
(120, 1, 'Pocket Knife-Nile', null),
(121, 1, '10 Easy Lessons', 'Books'),
(122, 1, 'How to win  Friends', null),
(123, 1, 'Compass', null),
(124, 1, 'Pith Helmet', null),
(125, 1, 'Elephant Polo stick', 'Recreation'),
(126, 1, 'Camel Saddle', 'Recreation');

select * from sales
select * from item