  use pubs
  select * from authors
  select * from publishers 
--1) Create a stored procedure that will take the author firstname and 
--print all the books polished by him with the publisher's name
    create proc BookWithAuthorId(@aFirstName varchar(50))
	as
	begin 
	   select t.title Book_Title , p.pub_name Publisher_Name
	   from titleauthor ta join titles t
	   on ta.title_id = t.title_id 
	   join authors a on a.au_id = ta.au_id
	   join publishers p on t.pub_id=p.pub_id
	   where a.au_fname = @aFirstName
	end;

	exec BookWithAuthorId 'Michel'

--2) Create a sp that will take the employee's firtname and print 
--all the titles sold by him/her, price, quantity and the cost.

select * from employee
select * from titles
select * from sales
create proc EmployeeDetails(@eFname varchar(50))
as
begin
    select e.fname , t.title ,sum(t.price) , sum(s.qty) , sum(s.qty*t.price) as Cost from 
	employee e join titles t  on e.pub_id = t.pub_id
	join sales s on  t.title_id=s.title_id 
	where e.fname=@eFname group by t.title, e.fname;
end;
    
exec EmployeeDetails 'Paolo';
exec EmployeeDetails 'Aria';
exec EmployeeDetails 'Ann';


--3) Create a query that will print all names from authors and employees

    select au_fname Names from authors
	union
	select fname Names from employee;

--4) Create a  query that will float the data from sales,titles, publisher 
--and authors table to print title name, Publisher's name, author's full
--name with quantity ordered and price for the order for all orders,
--print first 5 orders after sorting them based on the price of order

    select top 5 t.title , p.pub_name Publisher_Name ,
	concat(a.au_fname,' ', a.au_lname ) Author_Name , sum(s.qty) Quantity, sum(t.price* s.qty) Cost
	from sales s join titles t on s.title_id = t.title_id
	join publishers p on t.pub_id = p.pub_id 
	join titleauthor ta on t.title_id = ta.title_id
	join authors a on ta.au_id = a.au_id
	group by t.title , p.pub_name , concat(a.au_fname,' ', a.au_lname )
	order by Cost   ;