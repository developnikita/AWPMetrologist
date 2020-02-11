using AWPMetrologist.Service.Converter;
using AWPMetrologistService.DataContract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AWPMetrologistService
{
    public class Service : IService
    {

        public List<MeasuringInstrument> GetMSJson()
        {
            return GetMS();
        }

        public List<MICategory> GetMICategoriesJson()
        {
            return GetMICategories();
        }

        public List<MIDevice> GetMIDevicesJson()
        {
            return GetMIDevices();
        }

        public List<MIKind> GetMIKindJson()
        {
            return GetMIKinds();
        }

        public List<VerificationPlace> GetVerificationPlacesJson()
        {
            return GetVerificationPlaces();
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
                        // TODO: Loggining
                        // System.Console.WriteLine(ex.Message);
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

        private List<MICategory> GetMICategories()
        {
            var categories = new List<MICategory>();

            using (DataSet ds = new DataSet())
            {
                using (SqlConnection sqlCon = new SqlConnection(_conntectionString))
                {
                    try
                    {
                        sqlCon.Open();
                        string sqlStr = "SELECT * FROM dbo.Categories";
                        using (SqlDataAdapter sqlDA = new SqlDataAdapter(sqlStr, sqlCon))
                        {
                            sqlDA.Fill(ds);
                        }
                    }
                    catch
                    {
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
                        categories.Add(MIConverter.FromDataRowToCategory(dr));
                    }
                }
            }

            return categories;
        }

        private List<MIDevice> GetMIDevices()
        {
            var devices = new List<MIDevice>();

            using (DataSet ds = new DataSet())
            {
                using (SqlConnection sqlCon = new SqlConnection(_conntectionString))
                {
                    try
                    {
                        sqlCon.Open();
                        string sqlStr = "SELECT * FROM dbo.DeviceTypes";
                        using (SqlDataAdapter sqlDA = new SqlDataAdapter(sqlStr, sqlCon))
                        {
                            sqlDA.Fill(ds);
                        }
                    }
                    catch
                    {
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
                        devices.Add(MIConverter.FromDataRowToDevice(dr));
                    }
                }
            }

            return devices;
        }

        private List<MIKind> GetMIKinds()
        {
            var kinds = new List<MIKind>();

            using (DataSet ds = new DataSet())
            {
                using (SqlConnection sqlCon = new SqlConnection(_conntectionString))
                {
                    try
                    {
                        sqlCon.Open();
                        string sqlStr = "SELECT * FROM dbo.Kinds";
                        using (SqlDataAdapter sqlDA = new SqlDataAdapter(sqlStr, sqlCon))
                        {
                            sqlDA.Fill(ds);
                        }
                    }
                    catch
                    {
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
                        kinds.Add(MIConverter.FromDataRowToKind(dr));
                    }
                }
            }

            return kinds;
        }

        private List<VerificationPlace> GetVerificationPlaces()
        {
            var places = new List<VerificationPlace>();

            using (DataSet ds = new DataSet())
            {
                using (SqlConnection sqlCon = new SqlConnection(_conntectionString))
                {
                    try
                    {
                        sqlCon.Open();
                        string sqlStr = "SELECT * FROM dbo.VerificationPlaces";
                        using (SqlDataAdapter sqlDA = new SqlDataAdapter(sqlStr, sqlCon))
                        {
                            sqlDA.Fill(ds);
                        }
                    }
                    catch
                    {
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
                        places.Add(MIConverter.FromDataRowToPlace(dr));
                    }
                }
            }

            return places;
        }

        private string _conntectionString = "Data Source=DESKTOP-1V00CT8;Initial Catalog=ms;Integrated Security=True";
    }
}
