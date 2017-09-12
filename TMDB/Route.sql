﻿CREATE TABLE [dbo].[Route]
(
	[RouteID] INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[RouteName] NVARCHAR(50) NULL,
	[DriverID] INT NOT NULL,
	[VehicleID] INT NOT NULL,
	CONSTRAINT Fk_Route_Driver FOREIGN KEY([DriverID]) REFERENCES [dbo].[Driver] ([DriverID]) ON DELETE CASCADE,
	CONSTRAINT Fk_Route_Vehicle FOREIGN KEY([VehicleID]) REFERENCES [dbo].[Vehicle] ([VehicleID]) ON DELETE CASCADE
)
