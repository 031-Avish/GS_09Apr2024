-- date 03-05-2024
use NorthWind;
select * from Categories
-- problem will get only one result
select CategoryId from Categories where CategoryName = 'Confections'
--All the products from 'Confections' 
select * from products where CategoryID = 
(select CategoryId from Categories where CategoryName = 'Confections')
-- select product name from supplier of tokYO trade
select * from Suppliers;
select * from Products where SupplierID=
(select SupplierID from Suppliers where CompanyName='Tokyo Traders' );

--get all the products that are supplied by suppliers from usa
select * from Products where SupplierID in 
(select SupplierID from Suppliers where Country='USA')

-- get all the product from the category that has ea in desc
select * from Products where CategoryID in 
(select CategoryID from Categories where Description like '%ea%')

--get all the products that are supplied by suppliers from usa
select * from Products where SupplierID not in 
(select SupplierID from Suppliers where Country='USA')

select * from products where CategoryID in
(select CategoryID from Categories where Description like '%ea%')
and SupplierID = 
(select SupplierID from Suppliers where CompanyName = 'Tokyo Traders')

select * from Customers 
select * from Products
select * from Orders
select * from Employees
-- select the product id and the quantity ordered by customer from france
select ProductID,Quantity from [Order Details] where OrderID in 
(select OrderID from Orders where CustomerID in
(select CustomerID from Customers where Country='France' ))

--Get the products that are priced above the average price of all the products
select * from products  where UnitPrice > 
(select avg(UnitPrice) from Products );
-- correlated subqueries
-- select the latest order by every employee
--select  EmployeeID , MAX(orderDate) from orders group by EmployeeID

select * from orders o1 where OrderDate =
(select max(OrderDate) from Orders o2 where o2.EmployeeID = o1.EmployeeID)

select * from products p1 where UnitPrice =
(select max(UnitPrice) from Products p2 where p1.CategoryID = p2.CategoryID)

-- select the order number for the maximum fright paid by the every customer
select EmployeeID, OrderID from orders o1 where Freight = 
(select max(Freight) from orders o2 where o2.EmployeeID=o1.EmployeeID);

-- cross join 
select * from Categories, customers;
--Inner join
select * from categories where CategoryID 
not in (select distinct categoryid from products)
select * from Suppliers where SupplierID 
not in (select distinct SupplierID from products)

--Get teh categoryId and teh productname
select CategoryId,ProductName from products

--Get teh categoryname and the productname
select categoryName,ProductName from Categories 
join Products on Categories.CategoryID = Products.CategoryID 
-- or 
select categoryName,ProductName from Categories,Products
where Categories.CategoryID = Products.CategoryID
--Get the Supplier company name, contact person name,
--Product name and the stock ordered
select * from products
select CompanyName,ContactName,productname,unitsonorder from Suppliers
join Products on suppliers.SupplierID = Products.SupplierID

 --Print the order id, customername and the fright cost for all teh orders
 select OrderID ,ContactName, Freight from 
 orders o join Customers c
 on o.CustomerID = c.CustomerID

--product name, quantity sold, Discount Price, Order Id, Fright for all orders
 select o.OrderID "Order ID", p.Productname, od.Quantity "Quantity Sold",
 (p.UnitPrice*od.Quantity) "Base Price", 
 ((p.UnitPrice*od.Quantity)-((p.UnitPrice*od.Quantity)* od.Discount/100)) "Discounted price",
 Freight "Freight Charge"
 from Orders o join [Order Details] od
 on o.OrderID = od.OrderID
 join Products p on p.ProductID = od.ProductID
 order by o.OrderID

--select customer name, product name, quantity sold and the frieght, 
--total price(unitpice*quantity+freight)
select c.ContactName "Customer name" ,
p.ProductName , od.Quantity , o.Freight , 
(p.UnitPrice * od.Quantity + o.Freight) "Total Price" from 
Orders o join [Order Details] od
on o.OrderID=od.OrderID
join Products p on p.ProductID = od.ProductID
join customers c on c.customerID = o.CustomerID
order by o.OrderID

-- print the product name and the total quantity sold 
select productname , sum(quantity) "TOTAL QUANTITY" from products p 
join [Order Details] od on p.ProductID= od.ProductID
group by ProductName

-- customer name and the # of product bought for every order
select * from [Order Details]
select o.OrderID ,c.ContactName, count(ProductID) from [Order Details] od join Orders o on 
o.OrderID=od.OrderID join Customers c on o.CustomerID=c.CustomerID
group by o.OrderID,c.ContactName

select * from [Order Details]
-- select the employee name , customer name , product name 
--and the total price of the product

select e.FirstName , c.ContactName , p.ProductName, sum(od.UnitPrice* od.Quantity) as totalPrict from 
Employees e join Orders o on o.EmployeeID=e.EmployeeID 
join Customers c on c.CustomerID= o.CustomerID join 
[Order Details] od on o.OrderID=od.OrderID join 
Products p on p.ProductID=od.ProductID group by p.ProductName, c.ContactName,e.FirstName;