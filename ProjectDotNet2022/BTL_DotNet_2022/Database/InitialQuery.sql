/*Select Top 3 BookId ,Sum(Amount) From tblOrders_Detail
Where Exists(
	Select * From tblOrders
	Where tblOrders.OrdersId = tblOrders_Detail.OrdersId
	And tblOrders.OrdersStatus = 'done'
)
Group by BookId
Order By Sum(Amount) DESC*/

/* Comand use to delete all table, proc
Drop Table tblProcessing_Orders
Drop Table tblOrders_Detail
Drop Table tblOrders
Drop Table tblBook
Drop Table tblUser
Drop Proc DeleteUser
Drop Proc EditBook
Drop Proc InsertBook
Drop Proc InsertOrders
Drop Proc InsertOrders_Detail
Drop Proc InsertProcessing_Orders
Drop Proc InsertUser
Drop Proc UpdateUser
*/

--Select * From tblOrders Where Cast(OrdersDate as date) = '10/24/2022'



Use [C:\USERS\ADMIN\SOURCE\REPOS\PROJECTDOTNET2022\BTL_DOTNET_2022\DATABASE\QUANLYCUAHANGSACH.MDF]
Go

Create Table tblUser
(
	Username varchar(50),
	Password varchar(50),
	FullName Nvarchar(100),
	CCCD varchar(15),
	Address Nvarchar(100),
	Phone varchar(20),
	Role varchar(10),
	RegisterDate DateTime Default(GETDATE()),
	-- Set primary key
	Primary Key(Username)
)
Go

Create Table tblBook
(
	BookId int identity( 1, 1),
	BookName Nvarchar(100),
	BookGenre Nvarchar(100),
	BookAuthor Nvarchar(100),
	BookPrice decimal,
	ReleaseDate date,
	BookImage varchar(400) Default('No image'),
	InventoryQuantity int,
	Primary key(BookId)
)
Go

Create Table tblOrders
(
	OrdersId int identity(1,1),
	Username varchar(50),
	OrdersDate DateTime Default(GETDATE()), -- Gan mac dinh ngay h hien tai
	OrdersStatus Nvarchar(100) Default('waiting'),

	Primary Key(OrdersId),
	Foreign key(Username) References tblUser(Username)
)
Go

Create Table tblOrders_Detail
(
	OrdersId int,
	BookId int,
	Amount int,
	Primary key(OrdersId, BookId),
	Foreign key(BookId) References tblBook(BookId),
	Foreign key(OrdersId) References tblOrders(OrdersId)
)
Go

Create Table tblProcessing_Orders
(
	OrdersId int,
	ProcessingDate DateTime Default(GETDATE()),  -- gan mac dinh date hien tai
	Username varchar(50),

	Primary key(OrdersId),
	Foreign key(OrdersId) references tblOrders(OrdersId),
	Foreign key(Username) references tblUser(Username)
)
Go

-- Insert data for tblUser
Insert Into tblUser(Username, Password, FullName, CCCD, Address, Phone, Role) Values
('admin', 'admin', 'admin', 'admin', 'admin', 'admin', 'master'),
('ThuanHieu','2002',N'Đàm Thuận Hiếu', '107872593399', N'Từ Sơn - Bắc Ninh', '0964837511', 'master'), -- add 2 master
('ThuanThinh','2005', N'Đàm Thuận Thịnh', '20052005', N'Tiền Hải - Thái Bình', '045896435', 'customer'), -- 2 user 
('ThuanPhuong','1994', N'Đàm Thuận Phương', '19941994', N'Hương Mạc - Từ Sơn', '019941995', 'customer'),
('StaffA', '12345', N'Nguyễn Thị Linh', '999988884321', N'Hưng Yên', '03837247474', 'staff'), 
('StaffB', '23456', N'Hoàng Văn Hải', '43287432', N'Mê Linh - Hà Nội', '0432984234', 'staff') -- add two user with role = staff

-- Insert date for tblBook
Insert Into tblBook(BookName, BookGenre, BookAuthor, BookPrice, ReleaseDate, BookImage, InventoryQuantity) Values
(N'Thủ lĩnh bộ lạc', N'Kỹ năng lãnh đạo', 'Dave Logan , John King', 20, '12-1-2019', 'C:\Users\Admin\source\repos\ProjectDotNet2022\BTL_DotNet_2022\Public\Images\Book\image01.jpg', 1000),
(N'Nhà giả kim', N'Phiêu lưu, Tưởng tượng, Thần bí', 'Paulo Coelho', 15, '1-1-1988', 'C:\Users\Admin\source\repos\ProjectDotNet2022\BTL_DotNet_2022\Public\Images\Book\image02.jpg', 1100),
(N'Khéo ăn nói sẽ có được thiên hạ', N'Tâm lý, Kỹ năng sống', N'Trác Nhã', 25, '5-5-2018', 'C:\Users\Admin\source\repos\ProjectDotNet2022\BTL_DotNet_2022\Public\Images\Book\image03.jpg', 1200),
(N'Cảm xúc là kẻ thù số 1 của thành công', N'Kỹ năng sống, Self-help',N'TS.Lê Thẩm Dương', 80, '9-15-2016', 'C:\Users\Admin\source\repos\ProjectDotNet2022\BTL_DotNet_2022\Public\Images\Book\image04.jpg', 1300),
(N'Đắc Nhân Tâm', N'Kỹ năng sống, Self-help', 'Dale Carnergie', 50, '1-1-1936', 'C:\Users\Admin\source\repos\ProjectDotNet2022\BTL_DotNet_2022\Public\Images\Book\image05.jpg', 1400),
(N'Tuổi trẻ đáng giá bao nhiêu?', N'Tâm lý học',N'Rosie Nguyễn', 100, '1-1-2017', 'C:\Users\Admin\source\repos\ProjectDotNet2022\BTL_DotNet_2022\Public\Images\Book\image06.jpg', 1500)
Go



/*=====  Demo data use to check fearure: (revenue statistic, orders - ordres detaild)  ======
Insert into tblOrders(Username, OrdersDate, OrdersStatus)
Values('ThuanThinh', '1-1-2023', 'accept'),
('ThuanPhuong', '1-1-2023', 'accept'),
('ThuanThinh', '2-1-2023', 'accept'),
('ThuanPhuong', '3-1-2023', 'accept'),
('ThuanThinh', '4-1-2023', 'accept'),
('ThuanPhuong', '5-1-2023', 'accept'),
('ThuanThinh', '6-1-2023', 'accept'),
('ThuanPhuong', '7-1-2023', 'accept'),
('ThuanThinh', '8-1-2023', 'accept'),
('ThuanPhuong', '9-1-2023', 'accept'),
('ThuanPhuong', '10-1-2023', 'accept'),
('ThuanPhuong', '11-1-2023', 'accept')
Go

Insert Into tblOrders_Detail(OrdersId, BookId, Amount) Values
(1, 1, 10),
(1, 2, 5),
(1, 3, 10),
(1, 4, 5),
(1, 5, 10),
(1, 6, 5),
(2, 1, 3),
(2, 2, 1),
(2, 3, 1),
(2, 4, 2),
(2, 5, 1),
(2, 6, 1),
(3, 1, 10),
(3, 2, 4),
(3, 3, 10),
(3, 4, 6),
(3, 5, 2),
(3, 6, 5),
(4, 1, 1),
(4, 2, 5),
(4, 3, 1),
(4, 4, 8),
(4, 5, 2),
(4, 6, 3),
(5, 6, 3),
(6, 1, 3),
(7, 2, 4),
(8, 3, 5),
(9, 4, 6),
(10, 5, 7),
(11, 6, 8),
(12, 1, 10)

Go
Insert into tblProcessing_Orders(OrdersId, ProcessingDate, Username)
VALUES
	(1, '1-2-2023', 'thuanhieu' ),
	(2, '1-2-2023', 'thuanhieu'),
	(3, '2-2-2023','thuanhieu'),
	(4, '3-2-2023','thuanhieu'),
	(5, '4-2-2023','thuanhieu'),
	(6, '5-2-2023','thuanhieu'),
	(7, '6-2-2023','thuanhieu'),
	(8, '7-2-2023','thuanhieu'),
	(9, '8-2-2023','thuanhieu'),
	(10, '9-2-2023','thuanhieu'),
	(11, '10-2-2023','thuanhieu'),
	(12, '11-2-2023','thuanhieu')

===== END =====*/

-- in ra nhung cuon sach ma nguoi 1 mua
--Select tblBook.*, tblOrders_Detail.Amount as N'Số lượng' From tblBook
	--inner join tblOrders_Detail on tblOrders_Detail.BookId = tblBook.BookId
	--Where tblOrders_Detail.OrdersId = 1

-- Tong tien ma nguoi 1 mua
--Select Sum(tblBook.BookPrice * tblOrders_Detail.Amount) From tblBook
	--Inner join tblOrders_Detail on tblOrders_Detail.BookId = tblBook.BookId
	--Where tblOrders_Detail.OrdersId = 4


-- =====================================================================
-- Create Procedure
Go
CREATE PROCEDURE InsertUser
	@Username varchar(50),
	@Password varchar(50),
	@FullName Nvarchar(100),
	@CCCD varchar(15),
	@Address Nvarchar(100),
	@Phone varchar(20),
	@Role varchar(10)
AS
	Insert Into tblUser(Username, Password, FullName, CCCD, Address, Phone, Role)
	Values(@Username, @Password, @FullName, @CCCD, @Address, @Phone, @Role)

Go
CREATE PROCEDURE DeleteUser
	@Username varchar(50)
As
	Delete From tblUser 
	Where Username = @Username

Go
CREATE PROCEDURE UpdateUser
	@Username varchar(50),
	@Password varchar(50),
	@FullName Nvarchar(100),
	@CCCD varchar(15),
	@Address Nvarchar(100),
	@Phone varchar(20)
As
	Update tblUser 
	Set Password = @Password,
		FullName = @FullName,
		CCCD = @CCCD,
		Address = @Address,
		Phone = @Phone
	Where Username = @Username

-- Book ------------------------------------
Go
CREATE PROCEDURE InsertBook
	@BookName Nvarchar(100),
	@BookGenre Nvarchar(100),
	@BookAuthor Nvarchar(100),
	@BookPrice decimal,
	@ReleaseDate date,
	@BookImage varchar(400),
	@InventoryQuantity int
AS
	Insert into tblBook 
	Values(@BookName,
		   @BookGenre,
		   @BookAuthor,
		   @BookPrice,
		   @ReleaseDate,
		   @BookImage,
		   @InventoryQuantity)

Go
CREATE PROCEDURE EditBook
	@BookId int,
	@BookName Nvarchar(100),
	@BookGenre Nvarchar(100),
	@BookAuthor Nvarchar(100),
	@BookPrice decimal,
	@ReleaseDate date,
	@BookImage varchar(400),
	@InventoryQuantity int
AS
	Update tblBook
	Set BookName = @BookName,
		BookGenre = @BookGenre,
		BookAuthor = @BookAuthor,
		BookPrice = @BookPrice,
		ReleaseDate = @ReleaseDate,
		BookImage = @BookImage,
		InventoryQuantity = @InventoryQuantity 
	Where BookId = @BookId

-- Orders ------------------------------------------------
Go
Create Procedure InsertOrders
	@Username varchar(50)
As 
	Insert into tblOrders(Username) Values(@Username)


-- Because when you insert orders, you will don't know ordersId = ? because ordersId is indentity(1,1)
--Select Top 1 OrdersId From tblOrders
--Where Username = 'ThuanThinh'
--Order by OrdersId DESC

-- Orders detail -------------------------------------------------
Go
Create Procedure InsertOrders_Detail
	@OrdersId int,
	@BookId int,
	@Amount int
As 
	Insert into tblOrders_Detail(OrdersId, BookId, Amount)
		   Values(@OrdersId, @BookId, @Amount)



-- Processing_Orders
Go
Create Procedure InsertProcessing_Orders
	@OrdersId int,
	@Username varchar(50)
As 
	Insert into tblProcessing_Orders(OrdersId, Username)
	Values( @OrdersId, @Username)







Go
--Select OrdersId From tblOrders 
--Where Datepart(hour,OrdersDate) = '7'
--And Datepart(month,OrdersDate) = '11'
--And Datepart(year,OrdersDate) = '2022'
--And OrdersStatus = 'accept'






-- Top book
--Select Top 3 BookId,Sum(Amount) From tblOrders_Detail
--Group by BookId
--Order by Sum(Amount) DESC
	
-- Sum price of orders id
--Select Sum(tblOrders_Detail.Amount * tblBook.BookPrice) From tblOrders_Detail
	--Inner join tblBook on tblBook.BookId = tblOrders_Detail.BookId
--Where tblOrders_Detail.OrdersId = 1

--Delete From tblOrders_Detail
--Where Exists(
	--Select * From tblOrders Where tblOrders.OrdersId = tblOrders_Detail.OrdersId
	--And tblOrders.Username = 'ThuanPhuong'
--)


