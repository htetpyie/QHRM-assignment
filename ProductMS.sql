DROP DATABASE IF EXISTS [ProductMS];

CREATE DATABASE [ProductMS];

USE [ProductMS]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/9/2025 4:09:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DROP TABLE IF EXISTS [dbo].[Product]

CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [char](36) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [char](36) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
INSERT INTO Product (Name, Price, Description, CreatedDate)  
VALUES 
('Apple iPhone 15', 999.99, 'Latest Apple iPhone with A16 Bionic chip', GETDATE()),
('Samsung Galaxy S23', 799.99, 'Flagship Samsung smartphone with AMOLED display', GETDATE()),
('Sony WH-1000XM5', 399.99, 'Wireless noise-canceling headphones', GETDATE()),
('Dell XPS 15', 1499.99, 'High-performance laptop with Intel Core i7', GETDATE()),
('Logitech MX Master 3S', 99.99, 'Ergonomic wireless mouse for productivity', GETDATE()),
('Apple MacBook Air M2', 1199.99, 'Lightweight laptop with M2 chip', GETDATE()),
('Bose SoundLink Revolve', 179.99, 'Portable Bluetooth speaker with 360° sound', GETDATE()),
('Samsung 65" 4K Smart TV', 1299.99, 'Ultra HD Smart TV with QLED technology', GETDATE()),
('PlayStation 5', 499.99, 'Next-gen gaming console by Sony', GETDATE()),
('Nike Air Jordan 1', 180.00, 'Iconic basketball sneakers', GETDATE()),
('Garmin Fenix 7', 699.99, 'Premium multisport GPS smartwatch', GETDATE()),
('GoPro HERO12 Black', 399.99, 'Action camera with 5.3K video recording', GETDATE());
