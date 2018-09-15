
create table Brand(
Id uniqueidentifier primary key,
Name nvarchar(50) not null,
LogoFileName nvarchar (50) 
);

alter table Brand drop column LogoPath;

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

alter table Product add constraint Default_Discount  default 0 for Discount;
alter table Product add CategoryId uniqueidentifier;
alter table Product drop constraint FK_Category;
alter table Product add constraint FK_Category foreign key (CategoryId,BrandId) references CategoryBrand(CategoryId,BrandId);

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
