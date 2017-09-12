CREATE TABLE [dbo].[Vehicle]
(
	[VehicleID] INT IDENTITY (1,1)NOT NULL PRIMARY KEY,
	[RegNumber] NVARCHAR(20) NULL,
	[RegDate] DATETIME NULL,
	[Make] NVARCHAR(50) NULL,
	[Model] NVARCHAR(50) NULL,
	[Colour] NVARCHAR(50) NULL,
	[FuelType] NVARCHAR(10) NULL,
	[MOTExpiryDate] DATETIME NULL,
	[InsuranceExpiryDate] DATETIME NULL,
	[LastServicedDate] DATETIME NULL,
	[ServiceDueDate] DATETIME NULL,
	[CurrentMileage] NVARCHAR(10) NULL,
	[FuelCardNumber] NVARCHAR(50) NULL

)
