﻿create database KoiFarmShopDB
go

use KoiFarmShopDB
go


CREATE TABLE [Roles] (
  [RoleId] int PRIMARY KEY,
  [RoleName] nvarchar(20)
)
GO

insert into Roles
values
	(1,'Guest'),
	(2,'Customer'),
	(3,'Staff'),
	(4,'Admin');


CREATE TABLE [User] (
  [UserId] int PRIMARY KEY IDENTITY(1, 1),
  [RoleID] int FOREIGN KEY ([RoleID]) REFERENCES [Roles] ([RoleId]),
  [FullName] nvarchar(30) NOT NULL,
  [Phone] varchar(20) UNIQUE,
  [Password] varchar(64) NOT NULL,
  [Email] varchar(30) UNIQUE,
  [UserAddress] nvarchar(50),
  [CreatedDay] date default GETDATE(),
  [UpdateDay] date default GETDATE()
)
GO

insert into [User]
values
	(2, N'Nguyễn Chí Toàn', '0852592890', 'Toan1111@', 'toannc3900@ut.edu.vn', N'1050 Đường Phạm Văn Đồng, Hồ Chí Minh', GETDATE(), GETDATE()),
	(2, N'Nguyễn Văn A', '0987654321', '1928374655', 'Avannguyen@gmail.com', N'4 Đường số 9, Hồ Chí Minh', GETDATE(), GETDATE()),
	(3, N'Nguyễn Khánh','0399329361','Khanh001', 'Khanh1010@gamil.com', N'25 đường 18, quận Bình Thạnh, tp HCM', GETDATE(), GETDATE()),
	(2, N'Nguyễn Văn Hoa', '099999992', '19678700', 'nguyen@gmail.com', N'45 Đường số 19, Hồ Chí Minh', GETDATE(), GETDATE()),
	(4, N'Nguyễn Văn Thanh', '0956765792', '19245450000', 'Thanh@gmail.com', N'44 Đường số 180, Hồ Chí Minh', GETDATE(), GETDATE()),
	(2, N'Nguyễn Hòa', '09678756792', '19267860', 'nguyennn@gmail.com', N'24 Đường số 189, Hồ Chí Minh', GETDATE(), GETDATE()),
	(2, N'Nguyễn Văn Hiếu', '0453543592', '170000', 'Hieu@gmail.com', N'34 Đường số 10, Hồ Chí Minh', GETDATE(), GETDATE()),
	(2, N'Nguyễn Văn Hậu', '09687978989', '190000', 'Hau@gmail.com', N'14 Đường số 11, Hồ Chí Minh', GETDATE(), GETDATE());

CREATE TABLE [Permissions] 
(
  [PermissionId] int PRIMARY KEY,
  [PermissionName] NVARCHAR(255)
)
GO

CREATE TABLE [RolePermissions] (
  [RoleId] int FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([RoleId]),
  [PermissionId] int FOREIGN KEY ([PermissionId]) REFERENCES [Permissions] ([PermissionId]),
  PRIMARY KEY ([RoleId], [PermissionId])
)
GO

CREATE TABLE [Category] 
(
  [CategoryId] int PRIMARY KEY,
  [Title] nvarchar(32)
)
GO
insert into Category
values
	(1,'cá Koi'),
	(2,'Ký gửi'),
	(3,'Tin tức'),
	(4,'Blog'),
	(5,'Liên hệ');
GO

CREATE TABLE [KoiCategory] 
(
  [KoiCateId] int PRIMARY KEY,
  [CateID] int FOREIGN KEY ([CateID]) REFERENCES [Category] ([CategoryId]),
  [Title] nvarchar(32),
  [Description] nvarchar(MAX)
)
GO 

INSERT INTO [KoiCategory] VALUES 
	(1,1, 'Koi Kohaku', N'cá Koi Kohaku thân đỏ trắng là dòng cá tiêu biểu, khả năng sinh dôi nảy nở cực tốt và cũng là 1 trong những dòng cá có tuổi thọ cao'),
	(2,1, 'Koi Ogon',N'cá Koi Ogon là dòng koi dẫn đàn với bản tính dũng cảm, mạnh dạn, nhanh quen người và quen môi trường sống mới.'),
    (3,1, 'Koi Showa', N'cá Koi Showa là dòng Gosanke tiêu chuẩn, thuộc dòng cá Koi nhóm AAA của Nhật Koi Showa hấp dẫn người chơi bởi 3 màu đỏ-đen-trắng.'),
    (4,1, 'Koi Ginrin',N'Ginrin (Geenleen) dùng để chỉ nhóm giống cá Koi có vảy kim cương trên toàn bộ cơ thể.'),
	(5,1, 'Koi Tancho',N'cá Koi Tancho luôn có giá cao nhất, vẻ đẹp của Koi Tancho thanh lịch, sang trọng với dấu ấn đậm đà 1 chấm tròn đỏ lớn nằm trên đầu.'),
	(6,1, 'Koi Goshiki',N'cá Koi Goshiki được mệnh danh là “kẻ cắp ánh đèn sân khấu” tại bất kỳ hồ Koi nào em ấy xuất hiện.'),
    (7,1, 'Koi Asagi', N'cá Koi Asagi là tổ tiên của Nishikigoi. Nguồn gốc từ cá chép đen suối. Được tiến hóa theo hướng chọn lọc những em Koi có màu trắng, đỏ và xanh dương để nuôi trong hồ.');
GO

CREATE TABLE [Koi]
(
  [KoiId] int PRIMARY KEY IDENTITY(1, 1),
  [KoiCateID] int FOREIGN KEY ([KoiCateID]) REFERENCES [KoiCategory] ([KoiCateId]),
  [Title] nvarchar(255),
  [Description] nvarchar(MAX),
  [Price] float NOT NULL,
  [Age] int,
  [Size] float,
  [Breed] nvarchar(64),
  [Gender] int, --0:đực,1:cái
  [Origin] nvarchar(64),
  [Detail] nvarchar(MAX),
  [Image] varchar(64),
  [Stock] int
)
GO

INSERT INTO [Koi] 
VALUES 
	(1,'Tancho Kohaku 84 cm 4 tuổi ', N'là dòng cá tiêu biểu, khả năng sinh sôi nảy nở cực tốt và cũng là một trong những dòng cá có tuổi thọ cao', 300000, 4, 84, 'Koi Kohaku lai Koi Tancho',1, 'KOI FARM SHOP', N'Màu sắc tươi tắn, khỏe mạnh.', 'Tancho_kuhaku.jpg', 10),
	(2,'Yamabuki Ogon 3 tuổi 75 cm', N'là dòng koi dẫn đàn với bản tính dũng cảm, mạnh dạn, nhanh quen người và quen môi trường sống mới.', 500000, 3, 75, 'Koi Ogon', 0, 'KOI FARM SHOP', N'Một màu vàng óng lấp lánh như vàng thật.', 'Yamabuki_Ogon.jpg',16 ),
	(3,'Onkoi showa 97 cm 5 tuổi', N'là dòng Gosanke tiêu chuẩn, thuộc dòng cá Koi nhóm AAA của Nhật Koi Showa hấp dẫn người chơi bởi 3 màu đỏ-đen-trắng.', 450000, 5, 97, 'Koi Showa', 1, 'KOI FARM SHOP', N'màu sắc, hoa văn, hình thể của em ấy đạt đến chuẩn mực cao.', 'Onkoi_showa.jpg', 9 );

CREATE TABLE [CommentKoi] (
  [CmtKoiId] int PRIMARY KEY IDENTITY(1, 1),
  [KoiID] int,
  [Content] nvarchar(MAX),
  [CreatedBy] int,
  [CreatedDay] date default GETDATE(),
  [UpdateDay] date default GETDATE(),
  [UpdateBy] int
)
GO
ALTER TABLE [CommentKoi] ADD FOREIGN KEY ([CreatedBy]) REFERENCES [User] ([UserId])
GO


CREATE TABLE [Promotion] 
(
  [ProId] int PRIMARY KEY IDENTITY(1, 1),
  [DayStart] date default GETDATE(),
  [DayEnd] date default GETDATE(),
  [Percent] float
)
GO
INSERT INTO Promotion
VALUES
('1-1-2024', '1-2-2024', 15.0), -- 15% discount for one month
('1-6-2024', '1-7-2024', 10.0), -- 10% discount for one month
('1-12-2024', '1-1-2025', 20.0); -- 20% discount for holiday season
GO
CREATE TABLE [Discount] (
  [DiscountID] int PRIMARY KEY IDENTITY(1, 1),
  [ProId] int,
  [KoiId] int
)
GO
ALTER TABLE [Discount] ADD FOREIGN KEY ([ProId]) REFERENCES [Promotion] ([ProId])
GO

ALTER TABLE [Discount] ADD FOREIGN KEY ([KoiId]) REFERENCES [Koi] ([KoiId])
GO

CREATE TABLE [Orders]
(
  [OrderId] int PRIMARY KEY IDENTITY(1, 1),
  [CustomerID] int FOREIGN KEY ([CustomerID]) REFERENCES [User] ([UserId]),
  [Total] float NOT NULL,
  [Status] int,
  [ShipAddress] nvarchar(64) NOT NULL,
  [PaymentMethod] int NOT NULL,
  [CreatedDay] date default GETDATE(),
  [UpdateDay] date
)
GO


CREATE TABLE [OrderDetail] 
(
  [OrderDetailID] int PRIMARY KEY IDENTITY(1, 1),
  [OrderId] int FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId]),
  [KoiId] int  FOREIGN KEY ([KoiId]) REFERENCES [Koi] ([KoiId]),
  [quantity] int NOT NULL,
  [price] float NOT NULL
)
GO


CREATE TABLE [Booking] 
(
  [BookingId] int PRIMARY KEY IDENTITY(1, 1),
  [CateID] int FOREIGN KEY ([CateID]) REFERENCES [Category] ([CategoryId]),
  [CustomerID] int FOREIGN KEY ([CustomerID]) REFERENCES [User] ([UserId]),
  [Koiname] nvarchar(32),
  [Description] nvarchar(MAX),
  [Age] int,
  [Size] float,
  [Breed] nvarchar(32),
  [Gender] int,
  [Origin] nvarchar(32),
  [Image] varchar(50),
  [Quantity] int,
  [Status] int DEFAULT (0),
  [Type] int NOT NULL,
  [DateSent] date,
  [DateReceived] date,
  [CreatedDay] date default GETDATE(),
  [UpdateDay] date default GETDATE()
)
GO


CREATE TABLE [News] 
(
  [NewID] int PRIMARY KEY IDENTITY(1, 1),
  [Cate_ID] int,
  [Title] nvarchar(255),
  [Content] nvarchar(MAX),
  [Image] nvarchar(64),
  [CreatedBy] int,
  [CreatedDay] date default GETDATE(),
  [UpdateDay] date default GETDATE(),
  [UpdateBy] int
)
GO

CREATE TABLE [CommentNews] (
  [CmtNewsID] int PRIMARY KEY IDENTITY(1, 1),
  [NewsID] int,
  [Content] nvarchar(MAX),
  [CreatedBy] int,
  [CreatedDay] date default GETDATE(),
  [UpdateDay] date default GETDATE(),
  [UpdateBy] int
)
GO

CREATE TABLE [Blog] (
  [BlogID] int PRIMARY KEY IDENTITY(1, 1),
  [CateID] int,
  [Content] nvarchar(MAX),
  [Image] nvarchar(255),
  [Status] int DEFAULT (0),
  [CreatedBy] int,
  [CreatedDay] date default GETDATE(),
  [UpdateDay] date default GETDATE(),
  [UpdateBy] int
)
GO

CREATE TABLE [CommentBlog] (
  [CmtBlogID] int PRIMARY KEY IDENTITY(1, 1),
  [BlogID] int,
  [Content] nvarchar(MAX),
  [CreatedBy] int,
  [CreatedDay] date default GETDATE(),
  [UpdateDay] date default GETDATE(),
  [UpdateBy] int
)
GO

CREATE TABLE [Contact](
	[ContactId] int PRIMARY KEY IDENTITY(1,1),
	[CateId] int FOREIGN KEY ([CateId]) REFERENCES [Category] ([CategoryId]),
	[UserId] int FOREIGN KEY ([UserId]) REFERENCES [User] ([UserId]),
	[Report] nvarchar (max),
	[Status] int default (0), --0: chưa đọc,1:đã đọc
	[CreatedDay] date default GETDATE()
)
GO

ALTER TABLE [CommentKoi] ADD FOREIGN KEY ([KoiID]) REFERENCES [Koi] ([KoiId])
GO

ALTER TABLE [News] ADD FOREIGN KEY ([Cate_ID]) REFERENCES [Category] ([CategoryId])
GO

ALTER TABLE [CommentNews] ADD FOREIGN KEY ([NewsID]) REFERENCES [News] ([NewID])
GO

ALTER TABLE [News] ADD FOREIGN KEY ([CreatedBy]) REFERENCES [User] ([UserId])
GO

ALTER TABLE [News] ADD FOREIGN KEY ([UpdateBy]) REFERENCES [User] ([UserId])
GO

ALTER TABLE [CommentNews] ADD FOREIGN KEY ([CreatedBy]) REFERENCES [User] ([UserId])
GO

ALTER TABLE [CommentNews] ADD FOREIGN KEY ([UpdateBy]) REFERENCES [User] ([UserId])
GO

ALTER TABLE [CommentBlog] ADD FOREIGN KEY ([BlogID]) REFERENCES [Blog] ([BlogID])
GO

ALTER TABLE [Blog] ADD FOREIGN KEY ([CateID]) REFERENCES [Category] ([CategoryId])
GO

ALTER TABLE [Blog] ADD FOREIGN KEY ([CreatedBy]) REFERENCES [User] ([UserId])
GO

ALTER TABLE [Blog] ADD FOREIGN KEY ([UpdateBy]) REFERENCES [User] ([UserId])
GO

ALTER TABLE [CommentBlog] ADD FOREIGN KEY ([CreatedBy]) REFERENCES [User] ([UserId])
GO

ALTER TABLE [CommentBlog] ADD FOREIGN KEY ([UpdateBy]) REFERENCES [User] ([UserId])
GO

ALTER TABLE [CommentKoi] ADD FOREIGN KEY ([UpdateBy]) REFERENCES [User] ([UserId])
GO