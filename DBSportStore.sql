use master
go
if exists(select * from sysdatabases where name='DBSportStore')
	drop database DBSportStore

CREATE DATABASE DBSportStore
GO 

USE DBSportStore
GO

CREATE TABLE [dbo].[AdminUser] (
    [ID]           INT            NOT NULL,
    [NameUser]     NVARCHAR (MAX) NULL,
    [RoleUser]     NVARCHAR (MAX) NULL,
    [PasswordUser] NCHAR (50)     NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
)
GO

--Bang Category
CREATE TABLE [dbo].[Category] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [IDCate]   NCHAR (20)     NOT NULL,
    [NameCate] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([IDCate] ASC)
)
GO

--Bang Customer
CREATE TABLE [dbo].[Customer] (
    [IDCus]    INT            IDENTITY (1, 1) NOT NULL,
    [NameCus]  NVARCHAR (MAX) NULL,
    [PhoneCus] NVARCHAR (15)  NULL,
    [EmailCus] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([IDCus] ASC)
)
go
--Bang Products
CREATE TABLE [dbo].[Products] (
    [ProductID]     INT             IDENTITY (1, 1) NOT NULL,
    [NamePro]       NVARCHAR (MAX)  NULL,
    [DecriptionPro] NVARCHAR (MAX)  NULL,
    [Category]      NCHAR (20)      NULL,
    [Price]         DECIMAL (18, 2) NULL,
    [ImagePro]      NVARCHAR (MAX)  NULL,
	[Quantity]    int  NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC),
    CONSTRAINT [FK_Pro_Category] FOREIGN KEY ([Category]) REFERENCES [dbo].[Category] ([IDCate]))
--Bang OrderPro
GO  

ALTER TABLE  [dbo].[Products] 


CREATE TABLE [dbo].[OrderPro] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [DateOrder]        DATE           NULL,
    [IDCus]            INT            NULL,
    [AddressDeliverry] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([IDCus]) REFERENCES [dbo].[Customer] ([IDCus])
) 
GO 

--Bang OrderDetail
CREATE TABLE [dbo].[OrderDetail] (
    [ID]        INT        IDENTITY (1, 1) NOT NULL,
    [IDProduct] INT        NULL,
    [IDOrder]   INT        NULL,
    [Quantity]  INT        NULL,
    [UnitPrice] FLOAT (53) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([IDProduct]) REFERENCES [dbo].[Products] ([ProductID]),
    FOREIGN KEY ([IDOrder]) REFERENCES [dbo].[OrderPro] ([ID])
)
GO 

SELECT * FROM dbo.Category

delete from dbo.Category

INSERT INTO dbo.Category
(
    IDCate,
    NameCate
)
VALUES
(   N'7', -- IDCate - nchar(20)
    N'Sport 10'  -- NameCate - nvarchar(max)
    ),
(   N'6', -- IDCate - nchar(20)
    N'Soccer'  -- NameCate - nvarchar(max)
    ),
(   N'5', -- IDCate - nchar(20)
    N'Sport Cate 10'  -- NameCate - nvarchar(max)
    ),
(   N'4', -- IDCate - nchar(20)
    N'Watersport'  -- NameCate - nvarchar(max)
    ),
(   N'3', -- IDCate - nchar(20)
    N'He'  -- NameCate - nvarchar(max)
    ),
(   N'2', -- IDCate - nchar(20)
    N'Thu Dong'  -- NameCate - nvarchar(max)
    ),
(   N'1', -- IDCate - nchar(20)
    N'The Thao'  -- NameCate - nvarchar(max)
    )
	
SELECT *FROM dbo.Products

DELETE FROM dbo.Products
WHERE ProductID='18'

 INSERT INTO dbo.Products
(
    NamePro,
    DecriptionPro,
    Category,
    Price,
    ImagePro,
	Quantity
)
VALUES
(   N'Water 2',  -- NamePro - nvarchar(max)
    N'hello water ball',  -- DecriptionPro - nvarchar(max)
    N'4',  -- Category - nchar(20)
    19.50, -- Price - decimal(18, 2)
    N'user.png',   -- ImagePro - nvarchar(max)
	23
    ),
(   N'Water 1',  -- NamePro - nvarchar(max)
    N'hello water ball',  -- DecriptionPro - nvarchar(max)
    N'4',  -- Category - nchar(20)
    23.50, -- Price - decimal(18, 2)
    N'user.png',   -- ImagePro - nvarchar(max)
    13
	),
(   N'Soccer 10',  -- NamePro - nvarchar(max)
    N'hello soccer ball',  -- DecriptionPro - nvarchar(max)
    N'5',  -- Category - nchar(20)
    17.50, -- Price - decimal(18, 2)
    N'user.png',   -- ImagePro - nvarchar(max)
    10
  ),
(   N'Sport vip',  -- NamePro - nvarchar(max)
    N'hello soccer ball',  -- DecriptionPro - nvarchar(max)
    N'7',  -- Category - nchar(20)
    52.00, -- Price - decimal(18, 2)
    N'user.png',  -- ImagePro - nvarchar(max)
    1
	),
(   N'Soccer 1',  -- NamePro - nvarchar(max)
    N'hello soccer ball',  -- DecriptionPro - nvarchar(max)
    N'6',  -- Category - nchar(20)
    29.50, -- Price - decimal(18, 2)
    N'user.png',   -- ImagePro - nvarchar(max)
    5
	),
	(   N'Soccer Ball',  -- NamePro - nvarchar(max)
    N'hello soccer ball',  -- DecriptionPro - nvarchar(max)
    N'3',  -- Category - nchar(20)
    19.50, -- Price - decimal(18, 2)
    N'user.png',   -- ImagePro - nvarchar(max)
    30
	),
	(   N'Statium',  -- NamePro - nvarchar(max)
    N'hello Statium',  -- DecriptionPro - nvarchar(max)
    N'2',  -- Category - nchar(20)
    275.00, -- Price - decimal(18, 2)
    N'user.png',   -- ImagePro - nvarchar(max)
    24
	),
	(   N'Thinking Cap',  -- NamePro - nvarchar(max)
    N'hello Thinking Cap',  -- DecriptionPro - nvarchar(max)
    N'1',  -- Category - nchar(20)
    75.00, -- Price - decimal(18, 2)
    N'user.png',   -- ImagePro - nvarchar(max)
    1
	),
	(   N'Unsteady Chair',  -- NamePro - nvarchar(max)
    N'hello Unsteady Chair',  -- DecriptionPro - nvarchar(max)
    N'3',  -- Category - nchar(20)
    275.00, -- Price - decimal(18, 2)
    N'user.png',   -- ImagePro - nvarchar(max)
    3
	)
,
(   N'Likejacket',  -- NamePro - nvarchar(max)
    N'hello likejacket',  -- DecriptionPro - nvarchar(max)
    N'2',  -- Category - nchar(20)
    49.95, -- Price - decimal(18, 2)
    N'user.png',   -- ImagePro - nvarchar(max)
    45
	),
(   N'Kayak',  -- NamePro - nvarchar(max)
    N'hello kayak',  -- DecriptionPro - nvarchar(max)
    N'1',  -- Category - nchar(20)
    275.00, -- Price - decimal(18, 2)
    N'user.png',   -- ImagePro - nvarchar(max)
    13
	)
