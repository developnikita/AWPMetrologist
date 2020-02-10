using AWPMetrologistService.DataContract;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                        string sqlStr = "SELECT * FROM dbo.MeasuringInstruments";
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
                        // TODO: Converter from sql data to program data.
                        mi.Add(new MeasuringInstrument()
                        {
                            // Поля базы данных.
                        });
                    }
                }
            }

            return mi;
        }

        private string _conntectionString = "Data Source=DESKTOP-1V00CT8;Initial Catalog=ms;Integrated Security=True";
    }
}
