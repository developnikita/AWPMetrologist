using AWPMetrologist.Common.DataModel;
using System;
using System.Data;

namespace AWPMetrologist.Common.Converter
{
    public static class MIConverter
    {
        public static MeasuringInstrument FromDataRowToMI(DataRow dr)
        {
            return new MeasuringInstrument()
            {
                Id = Convert.ToInt32(dr["Id"]),
                MSType = dr["Type"].ToString(),
                Device = new MIDevice()
                {
                    Id = Convert.ToInt32(dr["DeviceId"]),
                    Device = dr["Device"].ToString()
                },
                Cost = DBNull.Value.Equals(dr["Cost"]) ? null : (int?)Convert.ToInt32(dr["Cost"]),
                Period = Convert.ToInt32(dr["Period"]),
                Category = new MICategory()
                {
                    Id = Convert.ToInt32(dr["CategoryId"]),
                    Category = dr["Category"].ToString()
                },
                Kind = new MIKind()
                {
                    Id = Convert.ToInt32(dr["KindId"]),
                    Kind = dr["Kind"].ToString()
                },
                Place = new VerificationPlace()
                {
                    Id = Convert.ToInt32(dr["PlaceId"]),
                    Place = dr["Place"].ToString()
                },
                Gold = DBNull.Value.Equals(dr["Gold"]) ? null : (int?)Convert.ToInt32(dr["Gold"]),
                Silver = DBNull.Value.Equals(dr["Silver"]) ? null : (int?)Convert.ToInt32(dr["Silver"]),
                Platinum = DBNull.Value.Equals(dr["Platinum"]) ? null : (int?)Convert.ToInt32(dr["Platinum"]),
                Paladium = DBNull.Value.Equals(dr["Paladium"]) ? null : (int?)Convert.ToInt32(dr["Paladium"]),
                Mercury = DBNull.Value.Equals(dr["Mercury"]) ? null : (int?)Convert.ToInt32(dr["Mercury"])
            };
        }

        public static MICategory FromDataRowToCategory(DataRow dr)
        {
            return new MICategory()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Category = dr["Category"].ToString()
            };
        }

        public static MIDevice FromDataRowToDevice(DataRow dr)
        {
            return new MIDevice()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Device = dr["Device"].ToString()
            };
        }

        public static MIKind FromDataRowToKind(DataRow dr)
        {
            return new MIKind()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Kind = dr["Kind"].ToString()
            };
        }

        public static VerificationPlace FromDataRowToPlace(DataRow dr)
        {
            return new VerificationPlace()
            {
                Id = Convert.ToInt32(dr["Id"]),
                Place = dr["Place"].ToString()
            };
        }
    }
}