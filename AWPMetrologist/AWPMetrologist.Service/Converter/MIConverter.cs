using AWPMetrologistService.DataContract;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace AWPMetrologist.Service.Converter
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
    }
}