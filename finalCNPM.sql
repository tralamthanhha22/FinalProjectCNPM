--create database finalCNPM
--go
use finalCNPM
go
create table Accountants
(
	AccountantID varchar(20) primary key,
	name nvarchar(255),
	password varchar(200),
)
go
create table Agents
(
	AgentID varchar(20) primary key,
	name nvarchar(255),
	password varchar(200),
	adds nvarchar(255),
	email varchar(255),
	phone varchar(255),
	username varchar(200),
)
go
create table Products(
	ProductsID varchar(20) primary key,
	name nvarchar(255),
	origin nvarchar(255),
	quantity int,
	soldOut bit,--đã bán rồi là 1 chưa bán là 0
	kind nvarchar(255),
	brand nvarchar(255),
	description nvarchar(400),
	expireDate date,
	mfg date,--ngày sản xuất
	image varchar(400),
	price int,
)
go
create table Orders
(
	OrderID varchar(20) primary key,
	dateOrder datetime,
	AgentID varchar(20),
	OrderStatus bit,
	PaymentStatus bit,
	PaymentMethod nvarchar(100),
)
go
create table OrderDetails
(
	DetailID varchar(20) primary key,
	OrderID varchar(20),
	ProductID varchar(20),
	quantity int,
)
go
create table DeliveryNotes
(
	DeliveryNotesID varchar(20) primary key,
	OrderID varchar(20),
	AgentID varchar(20),
	OrderStatus bit,
	PaymentStatus bit,
	DeliveryID int,--so sánh từ cột Delivey
)
go
create table Delivery
(
	DeliveryID varchar(20) primary key,
	name nvarchar(200),
	fee_noiThanh int,--phí nội thành
	fee_ngoaiThanh int,-- phí ngoại thành
)
go
create table ImportNotes
(
	ImportID varchar(20) primary key,
	AccountID varchar(20),
)
go
create table ImportNoteDetails--chi tiết phiếu nhập
(
	ImportDetailsID varchar(20) primary key,
	ProductID varchar(20),
	quantity int,
	price int,--giá sỉ
	ImportID varchar(20),
)
insert into Delivery(DeliveryID,name,fee_noiThanh,fee_ngoaiThanh)values('De01','Grab',20000,40000),
('De02','Gojek',10000,20000),
('De03','Be',5000,10000)

/*insert into DeliveryNotes(DeliveryNotesID,OrderID,AgentID,OrderStatus,PaymentStatus,DeliveryID)
values('DN01','O001'),
('DN02'),
('DN03')*/

insert into ImportNotes(ImportID,AccountID)values
('I001','A003'),
('I002','A003'),
('I003','A002')
--select * from ImportNotes
insert into ImportNoteDetails(ImportDetailsID,ProductID,quantity,price,ImportID)values
('IDetail002','P001',14,25000,'I002'),
('IDetail001','P002',20,80000,'I001'),
('IDetail003','P003',10,10000,'I003')
--select * from ImportNoteDetails
insert into Products
(ProductsID,price,name,origin,quantity,soldOut,kind,brand,description,expireDate,mfg,image)
values
('P002',100000,N'kẹo vitamin',N'Mỹ',20,0,N'kẹo',N'Bear',N'kẹo hỗ trợ vitamin cho trẻ em','2023-03-03','2020-01-02','/images/keo-vitamin.png'),
('P001',500000,N'hoạt huyết nhất nhất',N'Việt Nam',14,0,N'thuốc',N'Vina',N'thuốc giúp tăng cường máu não','2023-03-03','2020-01-02','/images/hoat-huyet-nhat-nhat.png'),
('P003',20000,N'sữa ensure',N'Mỹ',10,0,N'sữa cho người già',N'Ensure',N'sữa béo ngon bổ rẻ','2023-03-03','2020-01-02','/images/sua-ensure.png')
--select * from Products
insert into Accountants(AccountantID,name,password)values
('A000',N'Nguyễn Văn A','123'),
('A001',N'Trần Thị B','123'),
('A002',N'Lâm Thị C','123')
--select * from Accountants
insert into Agents(AgentID,name,password,email,phone,adds,username)
values('Agent001',N'Trà Lâm Thanh Hà','123','tralam@gmail.com','0123456789',N'1 Nguyễn Thị Minh Khai TP.HCM','tralamthanhha'),
('Agent002',N'Bùi Phương S','123','buiphuongs@gmail.com','0987654321',N'2 Trần Hưng Đạo TP.HCM','buiphuongs'),
('Agent003',N'Trần Văn A','123','nguyenvana@gmail.com','0911767452',N'5 Út Tịch TP.HCM','tranvana')
--select *from Agents

/*insert into Orders(OrderID,dateOrder,AgentID,OrderStatus,PaymentStatus,PaymentMethod)
values('O001',GETDATE(),'',0,0,N''),
('O002',GETDATE(),'',0,0,N''),
('O003',GETDATE(),'',0,0,N'')

insert into OrderDetails(DetailID,OrderID,ProductID,quantity) 
values
('OD01','','',0),
('OD02','','',0),
('OD03','','',0)*/