create table Brand(
Id uniqueidentifier primary key,
Name nvarchar(50) not null,
LogoFileName nvarchar (50) 
);

create table Client(
Id uniqueidentifier primary key,
FirstName nvarchar(50),
LastName nvarchar(50),
Email nvarchar(50),
Phone nvarchar(12),
);

create table Category(
Id uniqueidentifier primary key,
Name nvarchar(30) not null,
);

create table CategoryBrand(
CategoryId uniqueidentifier ,
BrandId uniqueidentifier ,
primary key(CategoryId,BrandId)
);

create table Product(
Id uniqueidentifier primary key,
Name nvarchar(30) not null,
Color nvarchar(20),
Dimentions nvarchar(30),
Weight float(53),
Os nvarchar(20),
Discount float(53),
ImageFileName nvarchar (50), 
Price int,
BrandId uniqueidentifier,
constraint FK_Category  foreign key (BrandId) references Category(Id)
);

create table Stock(
ProductId uniqueidentifier primary key constraint FK_Product  foreign key (ProductId) references Product(Id),
Quantity int not null default(0)
);

create table CartRow(
CartId uniqueidentifier, 
ProductId uniqueidentifier,
Quantity int not null default 0,
primary key (CartId, ProductId),
constraint FK_Product2  foreign key (ProductId) references Product(Id),
constraint FK_Cart  foreign key (CartId) references Category(Id)
);


create table Cart(
Id uniqueidentifier primary key,
Total int default 0
);

create table Orders(
Id uniqueidentifier primary key,
CartId uniqueidentifier,
ClientId uniqueidentifier,
Discount int default 0,
Total money,
Date datetime,
constraint FK_Order_Cart foreign key (CartId) references Cart(Id),
constraint FK_Order_Client foreign key (ClientId) references Client(Id)
);