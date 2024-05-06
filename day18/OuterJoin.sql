use NorthWind

select * from [Order Details]
select contactName, shipname, shipaddress
from Customers c join Orders o
on c.CustomerID = o.CustomerID

select contactName, shipname, shipaddress
from Customers c left join Orders o
on c.CustomerID = o.CustomerID

-- are there product which are never ordered 

select * from Products p left join 
[Order Details] od on p.ProductID= od.ProductID
where od.OrderID is Null