create database KoiFarmShopDB
go

use KoiFarmShopDB
go

CREATE TABLE [Roles] (
  [RoleId] int PRIMARY KEY IDENTITY(1, 1),
  [RoleName] nvarchar(20)
)
GO

CREATE TABLE [User] (
  [UserId] int PRIMARY KEY IDENTITY(1, 1),
  [RoleID] int,
  [FullName] nvarchar(30) NOT NULL,
  [Phone] varchar(12) UNIQUE,
  [Password] varchar(64) NOT NULL,
  [Email] varchar(30) UNIQUE,
  [UserAddress] nvarchar(50),
  [CreatedDay] date default GETDATE(),
  [UpdateDay] date default GETDATE()
)
GO

CREATE TABLE [Permissions] (
  [PermissionId] int PRIMARY KEY IDENTITY(1, 1),
  [PermissionName] NVARCHAR(255)
)
GO

CREATE TABLE [RolePermissions] (
  [RoleId] int,
  [PermissionId] int,
  PRIMARY KEY ([RoleId], [PermissionId])
)
GO

CREATE TABLE [Category] (
  [CategoryId] int PRIMARY KEY IDENTITY(1, 1),
  [Title] nvarchar(32)
)
GO

CREATE TABLE [KoiCategory] (
  [KoiCateId] int PRIMARY KEY IDENTITY(1, 1),
  [CateID] int,
  [Title] nvarchar(32),
  [Description] nvarchar(MAX)
)
GO

CREATE TABLE [Koi] (
  [KoiId] int PRIMARY KEY IDENTITY(1, 1),
  [KoiCateID] int,
  [Title] nvarchar(32),
  [Description] nvarchar(MAX),
  [Price] float NOT NULL,
  [Age] int,
  [Size] float,
  [Breed] nvarchar(20),
  [Gender] int,
  [Origin] nvarchar(20),
  [Detail] nvarchar(MAX),
  [Image] varchar(50),
  [Stock] int
)
GO

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

CREATE TABLE [Promotion] (
  [ProId] int PRIMARY KEY IDENTITY(1, 1),
  [DayStart] date default GETDATE(),
  [DayEnd] date default GETDATE(),
  [Percent] float
)
GO

CREATE TABLE [Discount] (
  [DiscountID] int PRIMARY KEY IDENTITY(1, 1),
  [ProId] int,
  [KoiId] int
)
GO

CREATE TABLE [Orders] (
  [OrderId] int PRIMARY KEY IDENTITY(1, 1),
  [CustomerID] int,
  [Total] float NOT NULL,
  [Status] int,
  [ShipAddress] nvarchar(64) NOT NULL,
  [PaymentMethod] int NOT NULL,
  [CreatedDay] date default GETDATE(),
  [UpdateDay] date
)
GO

CREATE TABLE [OrderDetail] (
  [OrderDetailID] int PRIMARY KEY IDENTITY(1, 1),
  [OrderId] int,
  [KoiId] int,
  [quantity] int NOT NULL,
  [price] float NOT NULL
)
GO

CREATE TABLE [Booking] (
  [BookingId] int PRIMARY KEY IDENTITY(1, 1),
  [CateID] int,
  [CustomerID] int,
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

CREATE TABLE [News] (
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

ALTER TABLE [KoiCategory] ADD FOREIGN KEY ([CateID]) REFERENCES [Category] ([CategoryId])
GO

ALTER TABLE [Koi] ADD FOREIGN KEY ([KoiCateID]) REFERENCES [KoiCategory] ([KoiCateId])
GO

ALTER TABLE [CommentKoi] ADD FOREIGN KEY ([KoiID]) REFERENCES [Koi] ([KoiId])
GO

ALTER TABLE [User] ADD FOREIGN KEY ([RoleID]) REFERENCES [Roles] ([RoleId])
GO

ALTER TABLE [RolePermissions] ADD FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([RoleId])
GO

ALTER TABLE [RolePermissions] ADD FOREIGN KEY ([PermissionId]) REFERENCES [Permissions] ([PermissionId])
GO

ALTER TABLE [CommentKoi] ADD FOREIGN KEY ([CreatedBy]) REFERENCES [User] ([UserId])
GO

ALTER TABLE [Booking] ADD FOREIGN KEY ([CateID]) REFERENCES [Category] ([CategoryId])
GO

ALTER TABLE [Booking] ADD FOREIGN KEY ([CustomerID]) REFERENCES [User] ([UserId])
GO

ALTER TABLE [Discount] ADD FOREIGN KEY ([ProId]) REFERENCES [Promotion] ([ProId])
GO

ALTER TABLE [Discount] ADD FOREIGN KEY ([KoiId]) REFERENCES [Koi] ([KoiId])
GO

ALTER TABLE [OrderDetail] ADD FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId])
GO

ALTER TABLE [OrderDetail] ADD FOREIGN KEY ([KoiId]) REFERENCES [Koi] ([KoiId])
GO

ALTER TABLE [Orders] ADD FOREIGN KEY ([CustomerID]) REFERENCES [User] ([UserId])
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

ALTER TABLE [Orders] ADD FOREIGN KEY ([CustomerID]) REFERENCES [Orders] ([OrderId])
GO

ALTER TABLE [CommentKoi] ADD FOREIGN KEY ([UpdateBy]) REFERENCES [User] ([UserId])
GO
