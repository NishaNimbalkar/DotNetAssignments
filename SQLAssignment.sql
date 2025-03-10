Create database BookStoreDB;

 drop table Authors;
create table Authors(AuthorID int identity primary key , Name varchar(133), Country varchar(123));
insert into Authors(Name,Country)values
    ('Vishwas Patil','India'),
   ( 'George Orwell', 'United Kingdom'),
    ( 'Harper Lee', 'United States'),
    ( 'Mark Twain', 'United States'),
    ( 'Gabriel García Márquez', 'Colombia');
	select * from Authors;

	create table Books(BookId int primary key, Title text,AuthorId int,Price int,PublishedYear int,foreign key(AuthorId)references Authors(AuthorId));
	INSERT INTO Books (BookId, Title, Price, PublishedYear) 
VALUES(7,'Raya',800,2006),
    (1, 'The Guide', 1, 500, 1958),    -- Vishwas Patil
    (2, 'world Of war', 2, 600, 1949),         -- George Orwell
    (3, 'To Kill a Mockingbird', 3, 400, 1960), -- Harper Lee
    (4, 'The Adventures of Tom Sawyer', 1, 350, 1876), -- Mark Twain
    (5, 'One Hundred Years of Solitude', 5, 700, 1967),
	(6,'The angle',3,300,2001); 

	   select * from Books;

	   Create table Customers( CustomerId int primary key not null, Name text,Email varchar(123)unique,PhoneNUmber varchar(12),)


	   INSERT INTO Customers (CustomerId, Name, Email, PhoneNumber) 
VALUES(6,'Sanj Bhosale','sanj@example.com','9087569087'),
    (1, 'Ruhi johnson', 'ruhi.johnson@example.com', '7890121212'),
    (2, 'Bob Smith', 'bob.smith@example.com', '9876543210'),
    (3, 'Nisha Nimbalkar', 'nisha.nimbalkar@example.com', '8459700234'),
    (4, 'Shiv Thakare', 'shiv.Thakare@example.com', '9870123432'),
    (5, 'Bhumi Chavan', 'Bhumi@example.com', '9087095467');



	create table Orders(OrderId int primary key,CustomerId int, OrderDate date,
	TotalAmount DECIMAL,
	foreign key(CustomerId)references Customers(CustomerId) )
	INSERT INTO Orders (OrderId, CustomerId, OrderDate, TotalAmount) 
VALUES
    (1, 1, '2025-03-06', 150.75),  
    (2, 2, '2025-03-07', 250.50), 
	(3,3,'2025-03-14',1120.90),
    (4, 1, '2025-03-09', 320.80),  
    (5, 3, '2025-03-10', 210.00); 
	
	select * from orders;

	create table OrderItems(OrderItemId int primary key,OrderId int,BookId int , Quantity int,SubTotal decimal,foreign key(OrderId)references Orders(OrderId),foreign key(BookId)references Books(BookId))
     
	 INSERT INTO OrderItems (OrderItemId, OrderId, BookId, Quantity, SubTotal) 
VALUES
    (1, 1, 1, 2, 300.50),  -- Alice Johnson's order, BookId 1, Quantity 2, SubTotal $300.50
    (2, 2, 2, 1, 600.00),  -- Bob Smith's order, BookId 2, Quantity 1, SubTotal $600.00
    (3, 5, 1, 3, 300.75),  -- Charlie Brown's order, BookId 3, Quantity 3, SubTotal $300.75
    (4, 4, 4, 2, 700.00), 
    (5, 5, 5, 1, 700.00);  

	select * from OrderItems;
	select *  from Customers;
	select * from Orders;

	--Update the price of a book titled "The angel" by increasing it by 10%.  
	update Books set Price=Price*10 where Title = 'The angle';

ALTER TABLE Books Alter column  Title VARCHAR(164);
	--delete DML
	delete  from Customers where CustomerId NOT IN(select CustomerId from Orders)
	select *from Books;
	select * from Customers;

	--Retrive all books with a price greater than 400
	 
	 select * from books where Price>400;

	 --find the number of books available

	 select count(BookId)from Books;

	 --find the book published between 300 and 600

	 select * from books where Price between 300 and 600;  --inclusive
     
	    --find all customers who have orderd atleast one order

		select * from Customers where customerId  In(select CustomerId from Orders);

		--retrives the books where the title contains the word "SQL"
		
		  select * from Books where Title like'%The%' 

		  -- Find the most expensive book in the store. 
		  select max(price)from books;
		  
		 -- Retrieve customers whose name starts with "A" or "J". 

		 select * from Customers where Name like 'n%' or name like'r%'; 

		 -- Calculate the total revenue from all orders. 
		 select sum(TotalAmount)from Orders;


		 --JOINS 
		 -- Retrieve all book titles along with their respective author names. 

   select b.Title as b ,a.Name as a from books b inner join Authors a on b.AuthorId=a.AuthorID; 

   -- List all customers and their orders (if any). 

       select c.Name as CustomerName , 
	   o.OrderId  as OrderId from Customers c 
	   left join Orders o on c.CustomerId=o.CustomerId;
       
	   -- Find all books that have never been ordered. 
	   select * from OrderItems;
	   select b.BookId,b.Title,b.AuthorId,b.Price,b.PublishedYear  from Books b
	   LEFT JOIN OrderItems oi ON b.BookID = oi.BookID
WHERE oi.OrderItemID IS NULL;

	   --Retrieve the total number of orders placed by each customer. 

	   select * from Customers;
	   select CustomerId, count(OrderId)from Orders group by CustomerId ;

	   -- Find the books ordered along with the quantity for each order.
	   
SELECT b.BookId AS bookId,b.Title, o.OrderId AS OrderId, om.Quantity AS Quantity
from Books b join OrderItems as om on om.OrderItemId=b.BookId join Orders as o on o.OrderId =om.OrderItemId;


--Display all customers, even those who haven’t placed any orders. 

select c.CustomerId,c.Name,c.Email,c.PhoneNumber ,o.OrderId from Customers c left join Orders o on c.CustomerId=o.OrderId;

-- Find authors who have not written any books 
	select *  from Authors where  AuthorId NOT IN(select AuthorId from Books)

select * from Orders;

--Assignment 10

--1. Find the customer(s) who placed the first order (earliest OrderDate). 
  
 select * from Customers where CustomerId in ( select CustomerId from Orders where OrderDate =(select min(orderDate)from Orders ));

 --2. Find the customer(s) who placed the most orders. 

SELECT * 
FROM Customers 
WHERE CustomerID IN (
    SELECT CustomerID
    FROM Orders
    GROUP BY CustomerID
    HAVING COUNT(OrderID) = (
        SELECT MAX(OrderCount)
        FROM (
            SELECT COUNT(OrderID) AS OrderCount
            FROM Orders
            GROUP BY CustomerID
        ) AS subquery
    )
);


--3. Find customers who have not placed any orders 

  select * from  Customers where CustomerId not in( select CustomerId from  Orders  );

  --4. Retrieve all books cheaper than the most expensive book written by( any  author based on your data) 
     
	select * from Books where Price<( select max(Price)from Books);

---- List all customers whose total spending is greater than the average spending of all customers
    
select * from Customers where CustomerId in(select  CustomerId  from Orders group by CustomerId having sum(TotalAmount) >( select  avg(TotalAmount)from Orders));


 --Write a stored procedure that accepts a CustomerID and returns all orders placed by that customer 

 create Procedure GetOrdersByCustomerId
 @CustomerId int
 as begin
 select * from Orders where customerId=@CustomerId;
 end;

 exec  GetOrdersByCustomerId @CustomerId=1;



 CREATE PROCEDURE GetBooksByPriceRange
    @MinPrice DECIMAL(10, 2),  -- Minimum price
    @MaxPrice DECIMAL(10, 2)   -- Maximum price
AS
BEGIN
    -- Select all books within the specified price range
    SELECT * 
    FROM Books
    WHERE Price BETWEEN @MinPrice AND @MaxPrice;
END;

EXEC GetBooksByPriceRange @MinPrice = 100.00, @MaxPrice = 600.00;

CREATE VIEW AvailableBooks AS
SELECT b.BookID, b.Title, b.AuthorID, b.Price, b.PublishedYear
FROM Books b
JOIN OrderItems oi ON b.BookID = oi.BookID;


  select * from AvailableBooks;
  drop view AvailableBooks;
