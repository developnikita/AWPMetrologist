/*CREATE TABLE dbo.Users
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Login] VARCHAR(20) NOT NULL,
	[Full_name] VARCHAR(100) NOT NULL,
	[EncryptedPassword] VARCHAR(512) NOT NULL

	CONSTRAINT AK_Login UNIQUE(Login)
);
GO
*/

CREATE TABLE dbo.MSCategory
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Category] VARCHAR(100) NOT NULL
);
GO

CREATE TABLE dbo.FactoryManufacturer
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Factory] VARCHAR(100) NOT NULL
);
GO

CREATE TABLE dbo.Unit
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Unit] VARCHAR(5) NOT NULL
);
GO

CREATE TABLE dbo.MSKind
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Kind] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE dbo.InstallationLocation
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Location] VARCHAR(100) NOT NULL
);
GO

CREATE TABLE dbo.TechnicalCondition
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Condition] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE dbo.MeasuredParameter
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Parameter] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE dbo.RepairOrganization
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Organization] VARCHAR(100) NOT NULL
);
GO

CREATE TABLE dbo.Storage
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Storage] VARCHAR(100) NOT NULL
);
GO

CREATE TABLE dbo.StorageInformation
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[StorageId] INT NOT NULL FOREIGN KEY REFERENCES dbo.Storage(Id),
	[StorageDate] DATE NOT NULL
);
GO

CREATE TABLE dbo.RepairReason
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Reason] VARCHAR(25) NOT NULL
);
GO

CREATE TABLE dbo.Repair
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[RepairReasonId] INT NOT NULL FOREIGN KEY REFERENCES dbo.RepairReason,
	[RepairOrganizationId] INT NOT NULL FOREIGN KEY REFERENCES dbo.RepairOrganization,
	[RepairDate] DATE NOT NULL
);
GO

CREATE TABLE dbo.VerificationMethod
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Method] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE dbo.VerificationPlace
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Place] VARCHAR(100) NOT NULL
);
GO

CREATE TABLE dbo.Verification
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[VerificationMethodId] INT NOT NULL FOREIGN KEY REFERENCES dbo.VerificationMethod(Id),
	[VerificationPlaceId] INT NOT NULL FOREIGN KEY REFERENCES dbo.VerificationPlace(Id),
	[LastDate] DATE NOT NULL,
	[Period] INT NOT NULL,
	[NextDate] DATE NOT NULL,
	[CertificateNumber] VARCHAR(100) NOT NULL,
	[VerificationResut] BIT,
	[Replaced] BIT
);
GO

CREATE TABLE dbo.Measuring
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[UnitId] INT NOT NULL FOREIGN KEY REFERENCES dbo.Unit(Id),
	[Accuracy] FLOAT(5) NOT NULL,
	[LowerLimit] INT NOT NULL,
	[UpperLimit] INT NOT NULL,
	[Error] FLOAT(6) NOT NULL,
	[MSKindId] INT NOT NULL FOREIGN KEY REFERENCES dbo.MSKind(Id),
	[MeasuredParameterId] INT NOT NULL FOREIGN KEY REFERENCES dbo.MeasuredParameter(Id)
);
GO

CREATE TABLE dbo.Exploitation
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[InstallationLocationId] INT NOT NULL FOREIGN KEY REFERENCES dbo.InstallationLocation(Id),
	[PrimOrSec] BIT,
	[TechnicalConditionId] INT NOT NULL FOREIGN KEY REFERENCES dbo.TechnicalCondition(Id),
	[VerificationId] INT NOT NULL FOREIGN KEY REFERENCES dbo.Verification(Id),
	[RepairId] INT FOREIGN KEY REFERENCES dbo.Repair(Id),
	[StorageInformationId] INT FOREIGN KEY REFERENCES dbo.StorageInformation(Id),
	[InstallationDate] DATE NOT NULL,
	[Indicator] BIT,
	[InventoryNumber] VARCHAR(100) NOT NULL,
	[InstrumentReplacementDate] DATE NOT NULL
);
GO

CREATE TABLE dbo.MeasuringSystem
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL,
	[MSCategoryId] INT NOT NULL FOREIGN KEY REFERENCES dbo.MSCategory(Id),
	[MeasuringId] INT NOT NULL FOREIGN KEY REFERENCES dbo.Measuring(Id),
	[FactoryManufacturerId] INT NOT NULL FOREIGN KEY REFERENCES dbo.FactoryManufacturer(Id),
	[SerialNumber] VARCHAR(50) NOT NULL,
	[ProductionDate] DATE NOT NULL,
	[LifeTime] INT NOT NULL,
	[Cost] FLOAT(2),
	[ExploitationId] INT NOT NULL FOREIGN KEY REFERENCES dbo.Exploitation(Id)
);
GO