# Product CRUD

## Installation and Project Documentation

### Overview
This document provides step by step instructions for intallation, configuring and running the Product CRUD app using .NET with MSSQL Server database.

### Project Functions
* Product List (Paging, Searching, Sorting)
* Create Product (Validation, Duplication)
* Update Product (Validation, Duplication)
* Delete Product (Validation)
* Route Handlers (404 Page)
* Exception Handler (Error Page, Text Logging)


### Used Technologies
* .NET 8 MVC
* MSSQL Server
* Dapper
* Admin Lte Template
* Server Side Datatable
* Serilog

### Prerequisites
Ensure you have the following installed before proceeding:
* .NET SDK (8.0)
* SQL Server (2019 or later)
* Visual Studio (latest version recommended)


### Project Structure
<img src="https://github.com/htetpyie/QHRM-assignment/blob/master/project-structure.png"></img>

### Installation Steps
1. Clone the Repository
```
git clone https://github.com/htetpyie/QHRM-assignment.git
```

2. Create a new Database named 'ProductMS' and run the [ProductMS.script](https://github.com/htetpyie/QHRM-assignment/blob/master/ProductMS.sql) in SQL Server
```
CREATE DATABASE [ProductMS]
```
<i>ProductMS.script</i>
```
USE [ProductMS]
GO
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [DF_Product_IsDelete]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/9/2025 7:12:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
DROP TABLE [dbo].[Product]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/9/2025 7:12:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Price], [Description], [IsDelete], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (1, N'Apple iPhone 15', CAST(999.99 AS Decimal(10, 2)), N'Latest Apple iPhone with A16 Bionic chip', 0, CAST(N'2025-03-09T19:10:43.090' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Description], [IsDelete], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (2, N'Samsung Galaxy S23', CAST(799.99 AS Decimal(10, 2)), N'Flagship Samsung smartphone with AMOLED display', 0, CAST(N'2025-03-09T19:10:43.090' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Description], [IsDelete], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (3, N'Sony WH-1000XM5', CAST(399.99 AS Decimal(10, 2)), N'Wireless noise-canceling headphones', 0, CAST(N'2025-03-09T19:10:43.090' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Description], [IsDelete], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (4, N'Dell XPS 15', CAST(1499.99 AS Decimal(10, 2)), N'High-performance laptop with Intel Core i7', 0, CAST(N'2025-03-09T19:10:43.090' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Description], [IsDelete], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (5, N'Logitech MX Master 3S', CAST(99.99 AS Decimal(10, 2)), N'Ergonomic wireless mouse for productivity', 0, CAST(N'2025-03-09T19:10:43.090' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Description], [IsDelete], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (6, N'Apple MacBook Air M2', CAST(1199.99 AS Decimal(10, 2)), N'Lightweight laptop with M2 chip', 0, CAST(N'2025-03-09T19:10:43.090' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Description], [IsDelete], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (7, N'Bose SoundLink Revolve', CAST(179.99 AS Decimal(10, 2)), N'Portable Bluetooth speaker with 360° sound', 0, CAST(N'2025-03-09T19:10:43.090' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Description], [IsDelete], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (8, N'Samsung 65" 4K Smart TV', CAST(1299.99 AS Decimal(10, 2)), N'Ultra HD Smart TV with QLED technology', 0, CAST(N'2025-03-09T19:10:43.090' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Description], [IsDelete], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (9, N'PlayStation 5', CAST(499.99 AS Decimal(10, 2)), N'Next-gen gaming console by Sony', 0, CAST(N'2025-03-09T19:10:43.090' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Description], [IsDelete], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (10, N'Nike Air Jordan 1', CAST(180.00 AS Decimal(10, 2)), N'Iconic basketball sneakers', 0, CAST(N'2025-03-09T19:10:43.090' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Description], [IsDelete], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (11, N'Garmin Fenix 7', CAST(699.99 AS Decimal(10, 2)), N'Premium multisport GPS smartwatch', 0, CAST(N'2025-03-09T19:10:43.090' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Description], [IsDelete], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (12, N'GoPro HERO12 Black', CAST(399.99 AS Decimal(10, 2)), N'Action camera with 5.3K video recording', 0, CAST(N'2025-03-09T19:10:43.090' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO

```

3.  Configure Database with your connection in appsettings.json
```
"DbConnection": {
        "SQLServerConnection": "Server=.;Database =ProductMS;Trusted_Connection=True;TrustServerCertificate=true"
    }
```

4. Run The App from IDE or Terminal
```
dotnet run
```

5. Use The App
<img src="https://github.com/htetpyie/QHRM-assignment/blob/master/project-sample.png"></img>







