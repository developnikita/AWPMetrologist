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

INSERT INTO dbo.Kinds (Kind) VALUES ('��������� ��������');
INSERT INTO dbo.Kinds (Kind) VALUES ('������������� ���������');
INSERT INTO dbo.Kinds (Kind) VALUES ('�����������');

CREATE TABLE dbo.Categories
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Category] VARCHAR(50) NOT NULL,

	CONSTRAINT AK_Category UNIQUE(Category)
);
GO

INSERT INTO dbo.Categories (Category) VALUES ('�� ���������� �������');
INSERT INTO dbo.Categories (Category) VALUES ('�� �� ���������� �������');

CREATE TABLE dbo.VerificationPlaces
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Place] VARCHAR(50) NOT NULL,

	CONSTRAINT AK_Place UNIQUE(Place)
);
GO

INSERT INTO dbo.VerificationPlaces (Place) VALUES ('�������� ���');
INSERT INTO dbo.VerificationPlaces (Place) VALUES ('����������� ���');
INSERT INTO dbo.VerificationPlaces (Place) VALUES ('���� ���');
INSERT INTO dbo.VerificationPlaces (Place) VALUES ('����������� ���');

CREATE TABLE dbo.DeviceTypes
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Device] VARCHAR(50) NOT NULL,

	CONSTRAINT AK_Device UNIQUE(Device)
);
GO

INSERT INTO dbo.DeviceTypes (Device) VALUES ('������');
INSERT INTO dbo.DeviceTypes (Device) VALUES ('���������');
INSERT INTO dbo.DeviceTypes (Device) VALUES ('���������');
INSERT INTO dbo.DeviceTypes (Device) VALUES ('�������');
INSERT INTO dbo.DeviceTypes (Device) VALUES ('����������');

 /*TODO: ���������� ������ �� ����������*/
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
	VALUES ('���-1.6', '1', NULL, '12', '1', '1', '1', NULL, NULL, NULL, NULL, NULL);

INSERT INTO dbo.MeasuringInstruments 
	([Type], DeviceId, Cost, [Period], CategoryId, KindId, PlaceId, 
	 Gold, Silver, Platinum, Paladium, Mercury)
	VALUES ('Lurre EA-7', '2', '2500', '24', '1', '2', '2', '24', '11', '2', '34', '97');
