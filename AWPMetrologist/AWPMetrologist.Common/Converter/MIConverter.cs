using AWPMetrologist.Common.DataModel;
using System;
using System.Data;

namespace AWPMetrologist.Common.Converter
{
    public static class MIConverter
    {
        public static MSCategory FromDRToCategory(DataRow dr)
        {
            return new MSCategory()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Category = dr["Category"].ToString()
            };
        }

        public static FactoryManufacturer FromDRToFactoryManufacturer(DataRow dr)
        {
            return new FactoryManufacturer()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Factory = dr["Factory"].ToString()
            };
        }

        public static InstallationLocation FromDRToInstallationLocation(DataRow dr)
        {
            return new InstallationLocation()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Location = dr["Location"].ToString()
            };
        }

        public static MeasuredParameter FromDRToMeasuredParameter(DataRow dr)
        {
            return new MeasuredParameter()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Parameter = dr["Parameter"].ToString()
            };
        }

        public static MSKind FromDRToKind(DataRow dr)
        {
            return new MSKind()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Kind = dr["Kind"].ToString()
            };
        }

        public static RepairOrganization FromDRToRepairOrganization(DataRow dr)
        {
            return new RepairOrganization()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Organization = dr["Organization"].ToString()
            };
        }

        public static RepairReason FromDRToRepairReason(DataRow dr)
        {
            return new RepairReason()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Reason = dr["Reason"].ToString()
            };
        }

        public static Storage FromDRToStorage(DataRow dr)
        {
            return new Storage()
            {
                Id = Convert.ToInt32(dr["Id"]),
                StorageValue = dr["Storage"].ToString()
            };
        }

        public static TechnicalCondition FromDRToTechnicalCondition(DataRow dr)
        {
            return new TechnicalCondition()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Condition = dr["Condition"].ToString()
            };
        }

        public static Unit FromDRToUnit(DataRow dr)
        {
            return new Unit()
            {
                Id = Convert.ToInt32(dr["Id"]),
                UnitValue = dr["Unit"].ToString()
            };
        }

        public static VerificationMethod FromDRToVerificationMethod(DataRow dr)
        {
            return new VerificationMethod()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Method = dr["Method"].ToString()
            };
        }

        public static MeasuringSystem FromDRToHandbookMeasuringSystemData(DataRow dr)
        {
            return new MeasuringSystem()
            {
                Id = Convert.ToInt32(dr["Id"]),
                MSCategory = new MSCategory()
                {
                    Id = Convert.ToInt32(dr["MSCategoryId"]),
                    Category = dr["Category"].ToString()
                },
                Measuring = new Measuring()
                {
                    Id = Convert.ToInt32(dr["MeasuringId"]),
                    MSKind = new MSKind()
                    {
                        Id = Convert.ToInt32(dr["MSKindId"]),
                        Kind = dr["Kind"].ToString()
                    },
                },
                Exploitation = new Exploitation()
                {
                    Id = Convert.ToInt32(dr["ExploitationId"]),
                    InstallationLocation = new InstallationLocation()
                    {
                        Id = Convert.ToInt32(dr["InstallationLocationId"]),
                        Location = dr["Location"].ToString()
                    }
                },
                Name = dr["Name"].ToString(),
                MSType = dr["MSType"].ToString(),
                Cost = Convert.ToInt32(dr["Cost"])
            };
        }
    }
}