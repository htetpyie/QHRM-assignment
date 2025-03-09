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

2. Run the [ProductMS.script](https://github.com/htetpyie/QHRM-assignment/blob/master/ProductMS.sql) in SQL Server


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
<img src="https://github.com/htetpyie/QHRM-assignment/blob/master/project%20sample.png"></img>







