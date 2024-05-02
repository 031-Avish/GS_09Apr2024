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
