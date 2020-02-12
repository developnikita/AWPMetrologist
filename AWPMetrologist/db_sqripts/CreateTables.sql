CREATE TABLE dbo.Users
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Login] VARCHAR(20) NOT NULL,
	[Full_name] VARCHAR(100) NOT NULL,

	CONSTRAINT AK_Login UNIQUE(Login)
);
GO

CREATE TABLE dbo.Kinds
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Kind] VARCHAR(50) NOT NULL,

	CONSTRAINT AK_Kind UNIQUE(Kind)
);
GO

INSERT INTO dbo.Kinds (Kind) VALUES ('Измерение давления');
INSERT INTO dbo.Kinds (Kind) VALUES ('Электрические измерения');
INSERT INTO dbo.Kinds (Kind) VALUES ('Температура');

CREATE TABLE dbo.Categories
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Category] VARCHAR(50) NOT NULL,

	CONSTRAINT AK_Category UNIQUE(Category)
);
GO

INSERT INTO dbo.Categories (Category) VALUES ('СИ подлежащие поверке');
INSERT INTO dbo.Categories (Category) VALUES ('СИ не подлежащие поверке');

CREATE TABLE dbo.VerificationPlaces
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Place] VARCHAR(50) NOT NULL,

	CONSTRAINT AK_Place UNIQUE(Place)
);
GO

INSERT INTO dbo.VerificationPlaces (Place) VALUES ('Бобруйск ЦСМ');
INSERT INTO dbo.VerificationPlaces (Place) VALUES ('Нефтеюганск ЦСМ');
INSERT INTO dbo.VerificationPlaces (Place) VALUES ('Крым ЦСМ');
INSERT INTO dbo.VerificationPlaces (Place) VALUES ('Новосибирск ЦСМ');

CREATE TABLE dbo.DeviceTypes
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Device] VARCHAR(50) NOT NULL,

	CONSTRAINT AK_Device UNIQUE(Device)
);
GO

INSERT INTO dbo.DeviceTypes (Device) VALUES ('Датчик');
INSERT INTO dbo.DeviceTypes (Device) VALUES ('Амперметр');
INSERT INTO dbo.DeviceTypes (Device) VALUES ('Вольтметр');
INSERT INTO dbo.DeviceTypes (Device) VALUES ('Счётчик');
INSERT INTO dbo.DeviceTypes (Device) VALUES ('Мультиметр');

 /*TODO: допольнить данные об устройстве*/
CREATE TABLE dbo.MeasuringInstruments
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Type] VARCHAR(20) NOT NULL,
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

INSERT INTO dbo.MeasuringInstruments 
	([Type], DeviceId, Cost, [Period], CategoryId, KindId, PlaceId, 
	 Gold, Silver, Platinum, Paladium, Mercury)
	VALUES ('МЗД-1.6', '1', NULL, '12', '1', '1', '1', NULL, NULL, NULL, NULL, NULL);

INSERT INTO dbo.MeasuringInstruments 
	([Type], DeviceId, Cost, [Period], CategoryId, KindId, PlaceId, 
	 Gold, Silver, Platinum, Paladium, Mercury)
	VALUES ('Lurre EA-7', '2', '2500', '24', '1', '2', '2', '24', '11', '2', '34', '97');
