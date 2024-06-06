use NorthWind


-- select all 
select * from Products
-- select any specific column 
select ProductName, QuantityPerUnit from Products
-- select any specific column with alias
select ProductName Name_Of_Product, QuantityPerUnit as Quantity_Per_Unit from Products
select ProductName 'Name Of Product', QuantityPerUnit as Quantity_Per_Unit from Products
-- use where and select
select * from Products where UnitPrice > 10 ;
-- select all the products that are out of stock 
select * from products where UnitsInStock= 0;
--select the products that will no more be stocked
select * from products where discontinued =1
-- select Products that will be in clearance  (product that are in stock and are discontinued)
select * from products where Discontinued=1 and UnitsInStock>0;
-- select products that are in the range of 10 to 30
select * from Products where UnitPrice>10 and UnitPrice<30;
select * from products where UnitPrice between 11 and 29  --(include 11 and 29)

select ProductName , UnitPrice price , unitsInStock, (unitPrice*UnitsInStock) "Amount worth"
from Products where CategoryID=3;
-- like in select %for any char  , _ only one char
select * from products where QuantityPerUnit like '%boxes%'
select * from products where QuantityPerUnit like '__ Boxes'
--Stock of products in category 3
select sum(UnitsInStock) "Stock of products in category 3"
from Products where CategoryID =3
-- average price of prodcuts supplied by supplier 2
select avg(UnitPrice) "Average Price Of product by Supplier 2"
from products where SupplierID=2;
--Worth of Product in order
select sum(UnitsInStock*ReorderLevel) "Worth of product in order"
from Products;
--Aggr by grouping
--Get the sum of products in stock for every category
select categoryId,sum(UnitsInStock) 'Stock Available' from products
group by CategoryId

--Get the Average price of products supplied by every supplier
select supplierID,avg(unitprice) "Average Price of Products" from products
group by supplierID


select supplierID,
count(ProductName) NO_Of_Products,
sum(unitsinstock) 'Items in stock',
avg(unitprice) 'Average PRice'
from products
group by supplierID

select supplierID,
count(ProductName) Number_Of_Products,
sum(unitsinstock) 'Items in stock',
avg(unitprice) 'Average PRice'
from products
group by supplierID

--select sum(UnitPrice),ProductName from products--Non-Sense query

--get teh average price for every supplier for evry category of product
select SupplierId, CategoryId, Avg(UnitPrice) Average_Price
from Products
group by CategoryId,SupplierId


select SupplierId, CategoryId, Avg(UnitPrice) Average_Price
from Products
group by CategoryId,SupplierId
having avg(UnitPrice)>15

--Select category ID and Sum of products avaible if the total number of products is 
--greater than 10

SELECT CategoryID,COUNT(ProductName) as 'Count of Products' FROM Products
GROUP BY CategoryID
HAVING COUNT(ProductName)>10;
--(or)
select categoryID, sum(unitsInStock) 'Sum of Available Products' 
from Products
group by CategoryID
having sum(unitsInStock)>10

select * from Products order by CategoryID,SupplierID,ProductName

select * from products order by ProductName


select productName,UnitPrice from products
where UnitPrice>15
order by CategoryId

--Get the products sorted by the price. Fetch only those products that will be discontiued
SELECT * FROM Products 
WHERE Discontinued = 1
ORDER BY UnitPrice

--sort by category id and fetch the sum of unit price of products that will not be discontinued
select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId
order by categoryId

--sort by category id and fetch the sum of unit price of products that will not be discontinued
--select only if the category is having products total price greater than 200
select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId
Having sum(UnitPrice)>200
order by categoryId desc
--(or)
select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId
Having sum(UnitPrice)>200
order by 1 desc

--Select the products order by the price in descending order

select * from products order by 6 desc
--(or)
select * from products order by UnitPrice desc


select * from Products order by unitprice	

select ProductName,
Rank() over( order by UnitPrice desc) "Price Rank"
from Products


Select * from Customers
