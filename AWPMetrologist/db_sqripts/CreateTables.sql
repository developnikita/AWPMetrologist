CREATE TABLE dbo.Users
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Login] VARCHAR(20) NOT NULL,
	[Full_name] VARCHAR(100) NOT NULL,
	[EncryptedPassword] VARCHAR(512) NOT NULL

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

CREATE TABLE dbo.Units
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Unit] VARCHAR(5) NOT NULL,

	CONSTRAINT AK_Unit UNIQUE(Unit)
);
GO

INSERT INTO dbo.Units (Unit) VALUES ('��');
INSERT INTO dbo.Units (Unit) VALUES ('��');
INSERT INTO dbo.Units (Unit) VALUES ('��');
INSERT INTO dbo.Units (Unit) VALUES ('���');
INSERT INTO dbo.Units (Unit) VALUES ('C�');
INSERT INTO dbo.Units (Unit) VALUES ('F�');
INSERT INTO dbo.Units (Unit) VALUES ('�^3');

CREATE TABLE dbo.MeasuringParameter
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Parameter] VARCHAR(20) NOT NULL,

	CONSTRAINT AK_Parameter UNIQUE(Parameter)
);
GO

INSERT INTO dbo.MeasuringParameter (Parameter) VALUES ('��������');
INSERT INTO dbo.MeasuringParameter (Parameter) VALUES ('�����������');
INSERT INTO dbo.MeasuringParameter (Parameter) VALUES ('�����');

CREATE TABLE dbo.TechnicalCondition 
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Condition] VARCHAR(20) NOT NULL,

	CONSTRAINT AK_Condition UNIQUE(Condition)
);
GO

INSERT INTO dbo.TechnicalCondition (Condition) VALUES ('���������');
INSERT INTO dbo.TechnicalCondition (Condition) VALUES ('������� ����������');
INSERT INTO dbo.TechnicalCondition (Condition) VALUES ('����� ������� ���������');
INSERT INTO dbo.TechnicalCondition (Condition) VALUES ('�������');

CREATE TABLE dbo.VerificationProcedure 
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Procedure] VARCHAR(20) NOT NULL,

	CONSTRAINT AK_Procedure UNIQUE([Procedure])
);
GO

INSERT INTO dbo.VerificationProcedure ([Procedure]) VALUES ('������ ������');
INSERT INTO dbo.VerificationProcedure ([Procedure]) VALUES ('������ ������');
INSERT INTO dbo.VerificationProcedure ([Procedure]) VALUES ('����������');

CREATE TABLE dbo.RepairReason 
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Reason] VARCHAR(20) NOT NULL,

	CONSTRAINT AK_Reason UNIQUE(Reason)
);
GO

INSERT INTO dbo.RepairReason (Reason) VALUES ('����� �� �����');
INSERT INTO dbo.RepairReason (Reason) VALUES ('�������� ������');
INSERT INTO dbo.RepairReason (Reason) VALUES ('������������ ���������');

CREATE TABLE dbo.RepairOrganization
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Organization] VARCHAR(30) NOT NULL,

	CONSTRAINT AK_Organization UNIQUE(Organization)
);
GO

INSERT INTO dbo.RepairOrganization (Organization) VALUES ('��� �����');
INSERT INTO dbo.RepairOrganization (Organization) VALUES ('��� ��������');
INSERT INTO dbo.RepairOrganization (Organization) VALUES ('�� ������');
INSERT INTO dbo.RepairOrganization (Organization) VALUES ('��� ����������');

CREATE TABLE dbo.Storage
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Storage] VARCHAR(50) NOT NULL,

	CONSTRAINT AK_Storage UNIQUE(Storage)
);
GO

INSERT INTO dbo.Storage (Storage) VALUES ('�� ������');
INSERT INTO dbo.Storage (Storage) VALUES ('�� �������');
INSERT INTO dbo.Storage (Storage) VALUES ('� ������� �����');

 /*TODO: ���������� ������ �� ����������*/
CREATE TABLE dbo.MeasuringInstruments
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Type] VARCHAR(20) NOT NULL,
	[DeviceId] INT FOREIGN KEY REFERENCES dbo.DeviceTypes(Id),
	[Cost] INT,
	[UnitId] INT FOREIGN KEY REFERENCES dbo.Units(Id),
	[Accuracy] FLOAT(10),
	[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id),
	[LowerLimit] INT,
	[UpperLimit] INT,
	[Error] FLOAT(10),
	[FactoryManufacturer] VARCHAR(50),
	[FactoryNumber] VARCHAR(50) NOT NULL,
	[ProductionDate] DATE,
	[LifeTime] INT NOT NULL,
	[KindId] INT FOREIGN KEY REFERENCES Kinds(Id),
	[PlaceId] INT FOREIGN KEY REFERENCES VerificationPlaces(Id),
	[InstallationPlace] VARCHAR(50) NOT NULL,
	[MParamId] INT FOREIGN KEY REFERENCES dbo.MeasuringParameter(Id),
	[FirstSecond] BIT,
	[TechCondId] INT FOREIGN KEY REFERENCES dbo.TechnicalCondition(Id),
	[VerificationProcId] INT FOREIGN KEY REFERENCES dbo.VerificationProcedure(Id),
	[RepairReasonId] INT FOREIGN KEY REFERENCES dbo.RepairReason(Id),
	[RepairDate] DATE NOT NULL,
	[RepairOrgId] INT FOREIGN KEY REFERENCES dbo.RepairOrganization(Id),
	[TransferStorageDate] DATE,
	[StorageId] INT FOREIGN KEY REFERENCES dbo.Storage(Id),
	[InstallDate] DATE NOT NULL,
	[Indicator] BIT,
	[InventoryNumber] VARCHAR(50) NOT NULL,
	[LastVerificationDate] DATE,
	[Period] INT NOT NULL,
	[NextVerificationDate] DATE,
	[ReplacementDate] DATE,
	[CertificateNumber] VARCHAR(50) NOT NULL
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
