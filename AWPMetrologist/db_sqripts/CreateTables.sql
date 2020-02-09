CREATE TABLE dbo.Users
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Login] VARCHAR(10) NOT NULL,
	[Full_name] VARCHAR(100) NOT NULL,

	CONSTRAINT AK_Login UNIQUE(Login)
);
GO

CREATE TABLE dbo.Kinds
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Kind] VARCHAR NOT NULL,

	CONSTRAINT AK_Kind UNIQUE(Kind)
);
GO

CREATE TABLE dbo.Categories
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Category] VARCHAR NOT NULL,

	CONSTRAINT AK_Category UNIQUE(Category)
);
GO

CREATE TABLE dbo.VerificationPlaces
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Place] VARCHAR NOT NULL,

	CONSTRAINT AK_Place UNIQUE(Place)
);
GO

CREATE TABLE dbo.DeviceTypes
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Device] VARCHAR NOT NULL,

	CONSTRAINT AK_Device UNIQUE(Device)
);
GO

 /*TODO: допольнить данные об устройстве*/
CREATE TABLE dbo.MeasuringInstruments
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Type] VARCHAR NOT NULL,
	[DeviceId] INT FOREIGN KEY REFERENCES DeviceTypes(Id),
	[Cost] INT,
	[Period] INT NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id),
	[KindId] INT FOREIGN KEY REFERENCES Kinds(Id),
	[PlaceId] INT FOREIGN KEY REFERENCES VerificationPlaces(Id),
	[Gold] INT,
	[Silver] INT,
	[Platinum] INT,
	[Paladium] INT,
	[Mercury] INT

);
GO