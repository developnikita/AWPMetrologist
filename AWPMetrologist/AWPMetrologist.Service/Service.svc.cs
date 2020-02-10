using AWPMetrologist.Service.Converter;
using AWPMetrologistService.DataContract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AWPMetrologistService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {

        public List<MeasuringInstrument> GetMSJson()
        {
            return GetMS();
        }

        private List<MeasuringInstrument> GetMS()
        {
            var mi = new List<MeasuringInstrument>();

            using (DataSet ds = new DataSet())
            {
                using (SqlConnection sqlCon = new SqlConnection(_conntectionString))
                {
                    try
                    {
                        sqlCon.Open();
                        string sqlStr = "SELECT * FROM dbo.MeasuringInstruments AS m " +
                                        "LEFT JOIN dbo.DeviceTypes AS d ON m.DeviceId = d.Id " +
                                        "LEFT JOIN dbo.Kinds AS k ON m.KindId = k.Id " +
                                        "LEFT JOIN dbo.VerificationPlaces AS v ON m.PlaceId = v.Id " +
                                        "LEFT JOIN dbo.Categories AS c ON m.CategoryId = c.Id";
                        using (SqlDataAdapter sqlDA = new SqlDataAdapter(sqlStr, sqlCon))
                        {
                            sqlDA.Fill(ds);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                        return null;
                    }
                    finally
                    {
                        sqlCon.Close();
                    }
                }

                using (DataTable dt = ds.Tables[0])
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        mi.Add(MIConverter.FromDataRowToMI(dr));
                    }
                }
            }

            return mi;
        }

        private string _conntectionString = "Data Source=DESKTOP-1V00CT8;Initial Catalog=ms;Integrated Security=True";
    }
}
