  use pubs;
  select * from stores;
  select * from sales;
  select * from titles;
  select * from publishers;
  select * from authors;
  select * from titleauthor;
  select * from employee
  --1) Print the storeid and number of orders for the store
     select stor_id , count(ord_num) from sales group by stor_id;
  --2) print the numebr of orders for every title
     select title "title name" , count(ord_num) from titles 
	 join sales on titles.title_id=sales.title_id group by title;
  --3) print the publisher name and book name
      select pub_name, title  from publishers p
	  join titles t on p.pub_id=t.pub_id;
  --4) Print the author full name for al the authors
       select CONCAT(au_fname,' ',au_lname) FullName from authors;
  --5) Print the price or every book with tax (price+price*12.36/100)
       select title , (price+price*12.36/100) "Price with tax" from titles;
  --6) Print the author name, title name
       select Concat(a.au_fname,' ',a.au_lname) as author_name ,t.title title_name  from titleauthor ta join
	   titles t on t.title_id=ta.title_id
	   join authors a on ta.au_id=a.au_id
  --7) print the author name, title name and the publisher name
       select Concat(a.au_fname,' ',a.au_lname) as author_name ,t.title title_name,
	   p.pub_name from titleauthor ta join
	   titles t on t.title_id=ta.title_id
	   join authors a on ta.au_id=a.au_id 
	   join publishers p on t.pub_id=p.pub_id;
  --8) Print the average price of books pulished by every publicher
       select pub_name , avg(price) from publishers p
	   left join titles t on p.pub_id=t.pub_id 
	   group by pub_name  
  --9) print the books published by 'Marjorie'
       select title from titles where title_id in (select title_id from titleauthor where au_id=
       (select au_id from authors where au_fname='Marjorie'))
     
  --10) Print the order numbers of books published by 'New Moon Books'
       select s.ord_num as orderNumber,s.title_id from sales s where s.title_id=(
       select  t.title_id from titles t 
	   join publishers p on p.pub_id=t.pub_id and pub_name='New Moon Books' where 
	   t.title_id = s.title_id)
 
  --11) Print the number of orders for every publisher
       select p.pub_name , count(*) as Number_Of_Orders
	   from sales s join titles t on s.title_id=t.title_id
	   join publishers p on t.pub_id=p.pub_id 
	   group by p.pub_name;
 
  --12) print the order number , book name, quantity, price and the total price for all orders
        select ord_num as Order_Number , title as Book_Name , 
		qty as Quantity , Price , (price*qty ) as Total_Price 
		from sales s join titles t on s.title_id = t.title_id

  --13) print he total order quantity fro every book
        select title as Book_Name , 
		sum(qty) as Order_Quantity  
		from sales s join titles t on s.title_id = t.title_id 
		group by title
  --14) print the total ordervalue for every book
        select title as Book_Name , 
		sum(qty*price) as Order_Value
		from sales s join titles t on s.title_id = t.title_id 
		group by title
 --15) print the orders that are for the books published by the publisher for which 'Paolo' works for
       select * from sales where title_id in ( select title_id from titles where pub_id = (
       (select pub_id from employee where fname='Paolo')))