CREATE DATABASE BANK;
USE BANK;

	CREATE TABLE products (
	productCode INT PRIMARY KEY,
	productName VARCHAR(50),
	productLine VARCHAR(20),
	productScale VARCHAR(20),
	productVendor VARCHAR(50),
	productDescription VARCHAR(255),
	quantityInStock INT,
	buyPrice FLOAT,
	MSRP FLOAT
	);

	CREATE TABLE productlines (
	productLine VARCHAR(20) PRIMARY KEY,
	textDescription VARCHAR(50),
	htmlDescription VARCHAR(20),
	image VARCHAR(20)
	);

	CREATE TABLE orderdetais (
	orderNumber INT PRIMARY KEY,
	productCode INT,
	quantityOrdered INT,
	priceEach FLOAT,
	orderLineNumber INT
	);

	CREATE TABLE employees (
	employeeNumber INT PRIMARY KEY,
	lastName VARCHAR(40),
	firstName VARCHAR(40) ,
	extension VARCHAR(50) ,
	email VARCHAR(50) ,
	officeCode NCHAR(10) ,
	reportsTo VARCHAR(20) ,
	jobTitle varchar(40) 
);

	CREATE TABLE offices(
	officeCode NCHAR(10) PRIMARY KEY ,
	city VARCHAR(50) ,
	phone VARCHAR(15) ,
	addressLine1 VARCHAR(75) ,
	addressLine2 VARCHAR(75) ,
	state VARCHAR(25) ,
	country VARCHAR(50) ,
	postalCode INT ,
	territory VARCHAR(50) 
);

	CREATE TABLE orders(
	orderNumber INT PRIMARY KEY ,
	orderDate DATE ,
	requiredDate DATE ,
	shippedDate DATE ,
	[status] CHAR(1) ,
	comments VARCHAR(50) ,
	customerNumber INT 
);

	CREATE TABLE payments(
	customerNumber INT ,
	checkNumber INT PRIMARY KEY ,
	paymentDate DATE ,
	amount INT 
);

	CREATE TABLE customers(
	customersNumber INT PRIMARY KEY ,
	customerName VARCHAR(50) ,
	contactLastName VARCHAR(50) ,
	contactFirstName VARCHAR(50) ,
	phone VARCHAR(15) ,
	addressLine1 VARCHAR(50) ,
	addressLine2 VARCHAR(50) ,
	city VARCHAR(50) ,
	state VARCHAR(50) ,
	postalCode INT ,
	country VARCHAR(50) ,
	salesRepEmployeeNumber INT ,
	creditLimit INT 
);

	ALTER TABLE customers ADD CONSTRAINT FK_customers_employees FOREIGN KEY(salesRepEmployeeNumber)
	REFERENCES employees (employeeNumber);

	ALTER TABLE orderdetails ADD CONSTRAINT FK_orderdetails_orders FOREIGN KEY(orderNumber)
	REFERENCES orders (orderNumber);

	ALTER TABLE orderdetails ADD CONSTRAINT FK_orderdetails_products FOREIGN KEY(productCode)
	REFERENCES products (productCode);

	ALTER TABLE orders ADD CONSTRAINT FK_orders_customers FOREIGN KEY(customerNumber)
	REFERENCES customers (customersNumber);

	ALTER TABLE payments ADD CONSTRAINT FK_payments_customers FOREIGN KEY(customerNumber)
	REFERENCES customers (customersNumber);

	ALTER TABLE products ADD CONSTRAINT FK_products_productlines FOREIGN KEY(productLine)
	REFERENCES productlines (productLine);

	INSERT products VALUES 
	('001','Marimas Jeruk', 1, 5,'Marimas','Minuman Sachet', 4, 500, 1000),
	('002','Marimas Mangga', 1, 5,'KMarimas','Minuman Sachet', 5, 500, 1000),
	('003','Marimas Anggur', 1, 5,'Marimas','Minuman Sachet', 6, 500, 1000),
	('004','Pop Ice Jeruk', 2, 6,'Pop Ice','Minuman Sachet', 2, 1000, 2000),
	('005','Pop Ice Mangga', 2, 2,'Pop Ice','Minuman Sachet', 3, 1000, 2000),
	('006','Pop Ice Anggur', 2, 8,'Pop Ice','Minuman Sachet', 8, 1000, 2000),
	('007','Pop Ice Jambu', 2, 9,'Pop Ice','Minuman Sachet', 5, 1000, 2000),
	('008','Jasjus Jeruk', 3, 5,'Jasjus','Minuman Sachet', 9, 500, 1000),
	('009','Jasjus Mangga', 3, 3,'Jasjus','Minuman Sachet', 3, 500, 1000),
	('010','Jasjus Anggur', 3, 5,'Jasjus ','Minuman Sachet', 1, 500, 1000);

	INSERT productlines VALUES 
	(1, 'Produk Marimas', 'Line1.html','image1.jpg'),
	(2, 'Produk Pop Ice', 'Line2.html','image2.jpg'),
	(3, 'Produk Jasjus', 'Line3.html', 'image3.jpg'),
	(4, 'Produk Aqua','Line4.html','image4.jpg'),
	(5, 'Produk ABC','Line5.html','image5.jpg'),
	(6, 'Produk Luak','Line6.html','image6.jpg'),
	(7, 'Produk Mizone','Line7.html','image7.jpg'),
	(8, 'Produk Sasa','Line8.html','image8.jpg'),
	(9, 'Produk Hit','Line9.html','image9.jpg'),
	(10,'Produk Miss','Line10.html','image10.jpg');

	INSERT payments VALUES 
	(1, 1, '2019-09-09' , 1000),
	(2, 2, '2018-09-10' , 2000),
	(3, 3, '2020-09-11' , 3000),
	(4, 4, '2020-09-12' , 4000),
	(5, 5, '2020-09-10' , 5000),
	(6, 6, '2020-09-14' , 6000),
	(7, 7, '2020-03-15' , 7000),
	(8, 8, '2020-01-16' , 8000),
	(9, 9, '2020-02-17' , 9000),
	(10, 10, '2020-07-18' , 10000);

	INSERT orders VALUES 
	(1, '2000-01-01' , '2000-01-02' , '2000-01-03' ,'1','Alright', 1),
	(2, '2000-01-01' , '2000-01-01' , '2000-01-03' ,'1','Alright', 2),
	(3, '2000-01-01' , '2000-01-01' , '2000-01-03' ,'1','Alright', 3),
	(4, '2000-01-01' , '2000-01-01' , '2000-01-03' ,'1','Alright', 4),
	(5, '2000-01-01' , '2000-01-01' , '2000-01-03' ,'1','Alright', 5),
	(6, '2000-01-01' , '2000-01-01' , '2000-01-03' ,'1','Alright', 6),
	(7, '2000-01-01' , '2000-01-01' , '2000-01-03' ,'1','Alright', 7),
	(8, '2000-01-01' , '2000-01-01' , '2000-01-03' ,'1','Alright', 8),
	(9, '2000-01-01' , '2000-01-01' , '2000-01-03' ,'1','Alright', 9),
	(10, '2000-01-01' , '2000-01-01' , '2000-01-03' ,'1','Alright', 10);

	INSERT orderdetails VALUES 
	(6,'006', 2, 2300, 10),
	(2,'002', 30, 1500, 3),
	(3,'003', 10, 1700, 4),
	(4,'004', 5, 1900, 5),
	(5,'005', 3, 2100, 6),
	(7,'007', 1, 2500, 12),
	(8,'008', 8, 2700, 11),
	(9,'009', 7, 2900, 7),
	(10,'010', 5, 3100, 8),
	(1,'001', 3, 1300, 2);

	INSERT offices VALUES 
	('OF01','Mojokerto','329149','Jl. Diponegoro', NULL,'Jawa Barat','Indonesia', 60113,'Mandeu'),
	('OF02','Mojokerto','329148','Jl. Mawar','Jl. Sudirman','Jawa Barat','Indonesia', 60110, NULL),
	('OF03','Mojokerto','329147','Jl. Diponegoro','Jl.Bojong','Jawa Barat','Indonesia', 60107,'Owned'),
	('OF04','Mojokerto','329146','Jl. Melati','Jl.Cendrawasih','Jawa Barat','Indonesia', 60104, NULL),
	('OF05','Mojokerto','329145','Jl. Diponegoro','Jl. Maca','Jawa Barat','Indonesia', 60101,'Owned'),
	('OF06','Mojokerto','329144','Jl. Pari','Jl.Wayang','Jawa Barat','Indonesia', 60098, NULL),
	('OF07','Mojokerto','329143','Jl. Diponegoro', NULL,'Jawa Barat','Indonesia', 60095,'Owned'),
	('OF08','Mojokerto','329142','Jl. Opak','Jl.Waru','Jawa Barat','Indonesia', 60092, NULL),
	('OF09','Mojokerto','329141','Jl. Kamboja', NULL,'Jawa Barat','Indonesia', 60089,'Owned'),
	('OF00','Mojokerto','329140','Jl. Sepatu', NULL,'Jawa Barat','Indonesia', 60086,'Owned');

	INSERT employees VALUES 
	(1,'William','Boy', NULL,'Boy@gmail.com','A05', 1,'Marketing'),
	(2,'Besos','Jeff', NULL,'jeff@gmail.com','A01', 1,'Manager'),
	(3,'Marie','Rene', NULL,'Rene@gmail.com','A02', 10,'Staff'),
	(4,'Sanjaya','Kevi', NULL,'Kevin@gmail.com','A03', 1,'Branch Manager'),
	(5,'Susilo','Anji', NULL,'Anji@gmail.com','A04', 4,'HRD'),
	(6,'Hawk','Stephe', NULL,'Stephen@gmail.com','A06', 1,'IT Head'),
	(7,'Anderso','Shau', NULL,'Shaun@gmail.com','A07', 6,'IT Support'),
	(8,'Bobby','Cloud', NULL,'Cloud@gmail.com','A08', 5,'Sales'),
	(9,'Margaret','Stevie', NULL,'Stevie@gmail.com','A09', 1,'Head Sales'),
	(10,'Kinasi','Putri', NULL,'Putri@gmail.com','A10', 1,'Head Staff');

	INSERT customers VALUES 
	(1,'Betul Iya','Iya','Betul','081232132137','Jl. cempaka no.3','Jl. kuningan no.1','Bandung','Jawa Barat', 60111,'Indonesia', 1, 3),
	(2,'Gungslinger Bro','Bro','Gunslinger','08213123224','Jl. bubutan no.4','Jl. kembang no.2','Bandung','Jawa Barat', 60112,'Indonesia', 2, 4),
	(3,'Yeah Yo','Yo','Yeah','089253523622','Jl. durian no.5','Jl. Bina no.3','Bandung','Jawa Barat', 60113,'Indonesia', 3, 6),
	(4,'Joko Susanto','Susanto','Joko','081525362362','Jl. apel no.6','Jl. bangsa no.4','Bandung','Jawa Barat', 60114,'Indonesia', 4, 2),
	(5,'Nina Nino','Nino','Nina','08253636373','Jl. bekam no.7','Jl. lembah no.5','Bandung','Jawa Barat', 60115,'Indonesia', 5, 1),
	(6,'Pandu Ann','Ann','Pandu','089635435463','Jl. lembayung no.8','Jl. dukuh no.6','Bandung','Jawa Barat', 60114,'Indonesia', 6, 4),
	(7,'Jiwo Supanji','Jiwo','Supanji','085232732737','Jl. indragiri no.9','Jl. kuningan no.7','Bandung','Jawa Barat', 60114,'Indonesia', 7, 6),
	(8,'Haja Radika','Radika','Haja','081734343628','Jl. kepanjen no.10','Jl. kembali no.8','Bandung','Jawa Barat', 60113,'Indonesia', 8, 3),
	(9,'Moto Sukaben','Sukaben','Moto','081229936372','Jl. darmo no.11','Jl. kuningan no.9','Bandung','Jawa Barat', 60113,'Indonesia', 9, 5),
	(10,'Seman Dioni','Dioni','Seman','081666373838','Jl. husada no.12','Jl. asiwan no.10','Bandung','Jawa Barat', 60111,'Indonesia', 10, 4);