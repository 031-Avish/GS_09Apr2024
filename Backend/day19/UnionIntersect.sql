use NorthWind
select * from Categories

select * from Suppliers

select CategoryID,  categoryname from Categories
union
select SupplierId,CompanyName from Suppliers

select * from [Order Details]

select * from Orders where ShipCountry='Spain'
union all
select * from orders where Freight>50
select * from Orders where ShipCountry='Spain'
intersect
select * from orders where Freight>50
select * from Orders where ShipCountry='Spain'
union
select * from orders where Freight>50
select top 5 * from orders order by Freight desc

--get the order id, productname and quantitysold of products that have price
--greater than 15
select OrderID ,Quantity as Quantity_Sold,ProductName  from [Order Details] od
join Products p on p.ProductID = od.ProductID where p.UnitPrice	 > 15;

select * from Categories
--get the order id, productname and quantitysold of products that aare from
-- category diary and within the range of 10 to 20 
--select OrderID ,Quantity as Quantity_Sold,ProductName  from [Order Details] od
--join Products p on p.ProductID = od.ProductID where p.CategoryID=4 and 
--p.UnitPrice between 11 and 19

select OrderID, ProductName, Quantity "Quantity Sold" 
from [Order Details] od join Products p 
on od.ProductID=p.ProductID join Categories c on p.CategoryID=c.CategoryID
where c.CategoryName like '%dairy%' and p.UnitPrice between 10 and 20;

select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%'
order by p.unitprice desc


-- getting top 10 record 
select top 10 * from (
select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%'

)as t  order by t.UnitPrice  desc



--CTE
 with OrderDetails_CTE(OrderID,ProductName,Quantity,Price)
  as
  (select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
  from [Order Details] od join Products p
  on od.ProductId = p.ProductID
  where p.UnitPrice>15
  union
  SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
  JOIN Products p ON p.ProductID = [Order Details].ProductID
  JOIN Categories c ON c.CategoryID = p.CategoryID
  WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')

  select top 10 * from  OrderDetails_CTE order by price desc


  create view vwOrderDetails
  as
  (select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
  from [Order Details] od join Products p
  on od.ProductId = p.ProductID
  where p.UnitPrice>15
  union
  SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
  JOIN Products p ON p.ProductID = [Order Details].ProductID
  JOIN Categories c ON c.CategoryID = p.CategoryID
  WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')


select top 10  * from vwOrderDetails order by UnitPrice


with OrderDetailss_CTE( OrderID , ContactName , ProductName)
as
(
select o.OrderID , c.ContactName , p.ProductName
from [Order Details] od join Products p on od.ProductID = p.ProductID 
join Orders o on od.OrderID = o.OrderID join Customers c on o.CustomerID = c.CustomerID
where c.Country = 'USA'
union
select o.OrderID , c.ContactName , p.ProductName
from [Order Details] od join Products p on od.ProductID = p.ProductID 
join Orders o on od.OrderID = o.OrderID join Customers c on o.CustomerID = c.CustomerID
where c.Country = 'France' and o.Freight < 20 
)
select top 10 * from  OrderDetailss_CTE 

