Create database EasyMaintainDb;
GO

Use EasyMaintainDb;
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Categories' AND xtype='U')
    CREATE TABLE Categories (
		CategoryID	int	IDENTITY(1,1) PRIMARY KEY,
		CategoryName	varchar(1000),	
		AdditionalData	nvarchar	
    )
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='SpareParts' AND xtype='U')
    CREATE TABLE SpareParts (
		SparePartID	int IDENTITY(1,1) PRIMARY KEY,
		CategoryID	int FOREIGN KEY REFERENCES Categories(CategoryID),
		SparePartName	nvarchar NOT NULL,
		Description	nvarchar,
		ImagePath	VARCHAR(1000),
		AdditionalData	nvarchar,
		Name VARCHAR(64) 
    )
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Manufacturers' AND xtype='U')
    CREATE TABLE Manufacturers (
		ManufacturerID	Int	IDENTITY(1,1) PRIMARY KEY,
		ManufacturerName	varchar(1000)	Not Null,
		Description	nvarchar,
		AdditionalData	nvarchar
    )
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='EngineTypes' AND xtype='U')
    CREATE TABLE EngineTypes (
		EngineTypeID	int	IDENTITY(1,1) PRIMARY KEY,
		EngineTypeName	varchar(1000)	Not Null,
		ManufacturerID	int	FOREIGN KEY REFERENCES Manufacturers(ManufacturerID),
		AdditionalData	nvarchar	
    )
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='AircraftModels' AND xtype='U')
    CREATE TABLE AircraftModels (
		AircraftModelID	int	IDENTITY(1,1) PRIMARY KEY,
		CategoryID	int FOREIGN KEY REFERENCES Categories(CategoryID),
		ModelName varchar(1000)	Not Null,
		ManufacturerID	int	FOREIGN KEY REFERENCES Manufacturers(ManufacturerID),
		EngineTypeID	int	FOREIGN KEY REFERENCES EngineTypes(EngineTypeID),
		Description	nvarchar,
		ImagePath varchar(1000),
		AdditionalData	nvarchar	
    )
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Suppliers' AND xtype='U')
    CREATE TABLE Suppliers (
		SupplierID	int	IDENTITY(1,1) PRIMARY KEY,
		SupplierName	varchar(1000)	Not Null,
		Description	nvarchar,
		Address	nvarchar,
		ContactDetails	nvarchar,		
		EmailAddress	varchar(1000),	
		AdditionalData	nvarchar	
    )
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Inventory' AND xtype='U')
    CREATE TABLE Inventory (
		InventoryID	int	IDENTITY(1,1) PRIMARY KEY,
		SparePartID	int	FOREIGN KEY REFERENCES SpareParts(SparePartID),
		UnitToMeasure	varchar(100),
		ItemsInStock	decimal,
		LastPurchasedDate	DateTime,	
		RefillTriggerQty	int,
		StoreLocation	nvarchar,	
		AdditionalData	nvarchar	
    )
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='SparePart_AircraftModel' AND xtype='U')
    CREATE TABLE SparePart_AircraftModel (
		SparePart_AircraftModelID	int	IDENTITY(1,1) PRIMARY KEY,
		SparePartID	int	FOREIGN KEY REFERENCES SpareParts(SparePartID),
		AircraftModelID	int	FOREIGN KEY REFERENCES AircraftModels(AircraftModelID)
    )
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='SparePart_Supplier' AND xtype='U')
    CREATE TABLE SparePart_Supplier (
		SparePart_SupplierID int IDENTITY(1,1)	PRIMARY KEY,
		SparePartID	int	FOREIGN KEY REFERENCES SpareParts(SparePartID),
		SupplierID	int	FOREIGN KEY REFERENCES Suppliers(SupplierID)
    )
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='SparePart_Manufacturer' AND xtype='U')
    CREATE TABLE SparePart_Manufacturer (
		SparePart_ManufacturerID	int IDENTITY(1,1)	PRIMARY KEY,
		SparePartID	int	FOREIGN KEY REFERENCES SpareParts(SparePartID),
		ManufacturerID	Int	FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
    )
GO