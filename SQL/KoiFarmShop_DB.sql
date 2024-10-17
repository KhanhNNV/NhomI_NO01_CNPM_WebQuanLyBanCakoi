create database KoiFarmShop_DB
go

use KoiFarmShop_DB
go


create table Category
(
	ID int primary key identity(1,1),
	Title nvarchar(10)
);

insert into Category
values
	(N'Trang chủ'),
	(N'Cá Koi'),
	(N'Giới Thiệu'),
	(N'Tin tức'),
	(N'Liên hệ');
insert into Category
values
	(N'Blog');
create table Koi_Category
(
	ID int primary key identity(1,1),
	Title nvarchar(25),
	Description nvarchar(MAX),
	Cate_ID int foreign key references Category(ID)
);
insert into Koi_Category
values
	(N'Koi Kohaku',N'cá Koi kohaku thân đỏ trắng là dòng cá tiêu biểu, khả năng sinh dôi nảy nở cực tốt và cũng là 1 trong những dòng cá có tuổi thọ cao',
	2),
	(N'Koi Karashi',N'Koi Karashi loại cá Koi này có da trơn màu sắc cá từ màu vàng nhạt đến vàng đậm toàn thân, rất đẹp và tươi tắn',
	2);


create table Koi
(
	ID int PRIMARY KEY IDENTITY(1,1),          
    KoiCate_ID int foreign key references Koi_Category(ID),  
    Title nvarchar(255),                    
    Price decimal(9, 2),                  
    Price_sale decimal(9, 2),              
    Description nvarchar(MAX),               
    Birth date,                              
    Size float,                              
    Breed nvarchar(255),                     
    Source nvarchar(255),                    
    Detail nvarchar(MAX),                    
    Image varchar(255),                      
    Quantity int    
);
insert into Koi
values
	(1, 'Ca Koi Nhat', 2000000, 1900000, 'Ca Koi thuan chung','2023-03-25', 30.0, 'Kohaku', 'Nhat Ban', 'Mo ta chi tiet ve loai ca Kohaku', 'cakoinhat.jpg', 10),
	(2, 'Ca Koi Viet', 1500000, 1200000, 'Ca Koi nuoi tai VN', '2024-01-25', 20.0, 'Taisho Sanke', 'Viet Nam', 'Mo ta chi tiet ve loai ca Taisho Sanke','cakoiviet.jpg', 15);

create table Comment_Koi
(
	Comment_ID int PRIMARY KEY IDENTITY(1,1),
	Koi_ID int FOREIGN KEY REFERENCES Koi(ID),
	Fullname nvarchar(255),
	Username nvarchar(255),
	Email nvarchar(255) unique,
	Comment nvarchar(255),
	Creaete_date date,
	Created_by nvarchar(255),
	Modifier_date date,
	Modifier_by nvarchar(255)
);
insert into Comment_Koi
values
	(1, 'Truong Thanh Danh', 'Danh', 'thanhdanh123@gmail.com', 'Ca dep qua !', '2023-04-14', 'Danh', NULL, NULL),
	(2, 'Dang Quoc Khang', 'Khang', 'quockhang123@gmail.com', 'Giong ca nay rat to', '2023-06-19', 'Khang', NULL, NULL);

CREATE TABLE News
(
    ID int PRIMARY KEY IDENTITY(1,1),
	Cate_ID int foreign key references Category(ID),
    Title nvarchar(255),                   
    Content nvarchar(MAX),                 
    Image nvarchar(255),                  
    Created_date date,                    
    Created_by nvarchar(255),              
    Modifier_date date,                    
    Modifier_by nvarchar(255)             
);


INSERT INTO News
VALUES
    (4,'Tin tức về cá Koi', 'Nội dung chi tiết về loài cá Koi', 'news_image.jpg', '2023-05-15', 'Nguyen Van Nam', NULL, NULL),
    (4,'Tin tức về thủy sinh', 'Nội dung chi tiết về các loại thủy sinh', 'news_image2.jpg', '2024-02-20', 'Nguyen Mai Thao Nguyen', NULL, NULL);


CREATE TABLE Comment_News
(
    ID int PRIMARY KEY IDENTITY(1,1),
    NewsID int FOREIGN KEY REFERENCES News(ID),
    Fullname nvarchar(255),
    Username nvarchar(255),
    Email nvarchar(255) UNIQUE,
    Comment nvarchar(255),
    Create_date date,
    Created_by nvarchar(255),
    Modifier_date date,
    Modifier_by nvarchar(255)
);
INSERT INTO Comment_News
VALUES
    (1, 'Tran Van Nam', 'Nam123', 'namtran@gmail.com', 'Bài viết rất hay!', '2023-06-01', 'Nam', NULL, NULL),
    (2, 'Le Thi Hoa', 'HoaLe', 'hoale@gmail.com', 'Thông tin hữu ích về các loại cá!', '2023-07-15', 'Hoa', NULL, NULL);



CREATE TABLE Blog
(
	Blog_ID int PRIMARY KEY IDENTITY(1,1),       
	Cate_ID int foreign key references Category(ID),
	Title nvarchar(255),                          
	Content nvarchar(MAX),                        
	Image nvarchar(255),                          
	Fullname nvarchar(255),                       
	Username nvarchar(255),                       
	Email varchar(255),                           
	Create_date date,                             
	Created_by nvarchar(255),                     
	Modifier_date date,                           
	Modifier_by nvarchar(255)                     
);
INSERT INTO Blog
VALUES
	(6,N'Kinh nghiệm nuôi cá Koi', N'Bài viết chia sẻ kinh nghiệm nuôi cá Koi cho người mới bắt đầu.', 'koi_experience.jpg', N'Nguyễn Văn A', 'nguyenvana', 'nguyenvana@gmail.com', '2024-10-17', N'Nguyễn Văn A', NULL, NULL),
	(6,N'Chăm sóc cá Koi vào mùa đông', N'Bí quyết giữ ấm cho cá Koi trong mùa đông để đảm bảo sức khỏe của cá.', 'winter_koi_care.jpg', N'Trần Bảo B', 'tranbaob', 'tranbaob@gmail.com', '2024-10-18', N'Trần Bảo B', NULL, NULL);



CREATE TABLE Comment_Blog
(
	Comment_ID int PRIMARY KEY IDENTITY(1,1),      
	Blog_ID int FOREIGN KEY REFERENCES Blog(Blog_ID), 
	Fullname nvarchar(255),                        
	Username nvarchar(255),                        
	Email varchar(255) UNIQUE,                    
	Comment nvarchar(255),                         
	Create_date date,                              
	Created_by nvarchar(255),                      
	Modifier_date date,                            
	Modifier_by nvarchar(255)                      
);

INSERT INTO Comment_Blog
VALUES
	(1, 'Đặng Trung Thiện', 'Thiện', 'thiendang123@gmail.com', N'Bài viết rất hữu ích, cảm ơn tác giả!', '2024-10-18', N'Thiện', NULL, NULL),
	(2, 'Phạm Thanh Hùng', 'Hùng', 'hungpham456@gmail.com', N'Cảm ơn đã chia sẻ, mình sẽ thử áp dụng!', '2024-10-19', N'Hùng', NULL, NULL);

create table Orders
(
	ID int primary key identity(1,1),
	fullname nvarchar(20),
	phone varchar (12),
	Customer_address nvarchar(50),
	total decimal(9,2),
	quantity int,
	status int,
	Creaete_date date,
	Created_by nvarchar(50),
	Modifier_date date,
	Modifier_by nvarchar(50)
);

insert into Orders
values
	(N'Nguyễn Khánh','0399329361',N'25 đường 18, quận Bình Thạnh, tp HCM',
	300000,1,2,'2024-10-17',N'Khánh',NULL,NULL),
	(N'Nguyễn Ngọc','0255145632',N'102 đường Võ Oanh, quận Bình Thạnh, tp HCM',
	300000,1,1,'2024-10-17',N'Ngọc',NULL,NULL);

create table Detail_Orders
(
	ID int primary key identity(1,1),
	Koi_ID int foreign key references Koi(ID),
	Order_ID int foreign key references Orders(ID),
	price decimal (9,2),
	total decimal(9,2),
	quantity int
);


insert into Detail_Orders
values
	(1,1,300000,2,600000),
	(2,2,300000,1,300000);







