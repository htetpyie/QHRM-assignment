# Product CRUD

## Installation and Project Documentation

### Overview
This document provides step by step instructions for intalling, configuring and running the Product CRU app using .NET with MSSQL Server database.

### Project Functions
* Product List (Paging, Searching, Sorting)
* Create Product (Validation, Duplicate)
* Update Product (Validation, Duplicate)
* Delete Product (Validation)
* Route Handlers (404 Page)
* Exception Handler (Error Page, Text Logging)


### Used Technologies
* .NET 8 MVC
* MSSQL Server
* Dapper
* Admin Lte Template
* Serilog

### Prerequisites
Ensure you have the following installed before proceeding:
* .NET SDK (8.0)
* SQL Server (2019 or later)
* Visual Studio (latest version recommended)


### Project Structure
<image src=".project-structure.png">

### Installation Steps
1. Clone the Repository
```
git clone https://github.com/htetpyie/QHRM-assignment.git
```

2. Run the ProductMS.script file in SQL Server
```

DROP DATABASE IF EXISTS [ProductMS];

CREATE DATABASE [ProductMS];

USE [ProductMS]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/9/2025 4:09:43 PM ******/
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





