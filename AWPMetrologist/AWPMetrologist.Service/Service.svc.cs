using AWPMetrologist.Common.Converter;
using AWPMetrologist.Common.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AWPMetrologistService
{
    public class Service : IService
    {

        public List<MeasuringSystem> GetMeasuringSystemsJson()
        {
            return GetMeasuringSystems();
        }

        public List<Exploitation> GetExploitationsJson()
        {
            return GetExploitations();
        }

        public List<FactoryManufacturer> GetFactoryManufacturersJson()
        {
            return GetFactoryManufacturers();
        }

        public List<InstallationLocation> GetInstallationLocationsJson()
        {
            return GetInstallationLocations();
        }

        public List<MeasuredParameter> GetMeasuredParametersJson()
        {
            return GetMeasuredParameters();
        }

        public List<Measuring> GetMeasuringsJson()
        {
            return GetMeasurings();
        }

        public List<MSCategory> GetMSCategoriesJson()
        {
            return GetMSCategories();
        }

        public List<MSKind> GetMSKindsJson()
        {
            return GetMSKinds();
        }

        public List<Repair> GetRepairsJson()
        {
            return GetRepairs();
        }

        public List<RepairOrganization> GetRepairOrganizationsJson()
        {
            return GetRepairOrganizations();
        }

        public List<RepairReason> GetRepairReasonsJson()
        {
            return GetRepairReasons();
        }

        public List<Storage> GetStoragesJson()
        {
            return GetStorages();
        }

        public List<TechnicalCondition> GetTechnicalConditionsJson()
        {
            return GetTechnicalConditions();
        }

        public List<Unit> GetUnitsJson()
        {
            return GetUnits();
        }

        public List<Verification> GetVerificationsJson()
        {
            return GetVerifications();
        }

        public List<VerificationMethod> GetVerificationMethodsJson()
        {
            return GetVerificationMethods();
        }

        public List<DeviceStatus> GetDeviceStatusesJson()
        {
            return GetDeviceStatuses();
        }

        public List<MeasuringSystem> GetHandbookMeasuringSystemDataJson()
        {
            return GetHandbookMeasuringSystemData();
        }

        public List<MeasuringSystem> GetMeasuringSystemsVerificationJson()
        {
            return GetMeasuringSystemsVerification();
        }

        private List<MeasuringSystem> GetMeasuringSystems()
        {
            var ms = new List<MeasuringSystem>();

            string sqlStr = "SELECT * FROM dbo.MeasuringSystem AS m " +
                            "LEFT JOIN ...";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        // TODO: Add converter
                        // ms.Add();
                    }
                }
            }

            return ms;
        }

        private List<Exploitation> GetExploitations()
        {
            var exploitations = new List<Exploitation>();

            string sqlStr = "SELECT * FROM dbo.Exploitation AS e" +
                            "...";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        // TODO: Add converter
                        // exploitations.Add();
                    }
                }
            }
            return exploitations;
        }

        private List<FactoryManufacturer> GetFactoryManufacturers()
        {
            var fm = new List<FactoryManufacturer>();

            string sqlStr = "SELECT * FROM dbo.FactoryManufacturer";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        fm.Add(MIConverter.FromDRToFactoryManufacturer(dr));
                    }
                }
            }

            return fm;
        }

        private List<InstallationLocation> GetInstallationLocations()
        {
            var il = new List<InstallationLocation>();

            string sqlStr = "SELECT * FROM dbo.InstallationLocation";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        il.Add(MIConverter.FromDRToInstallationLocation(dr));
                    }
                }
            }

            return il;
        }

        private List<MeasuredParameter> GetMeasuredParameters()
        {
            var mp = new List<MeasuredParameter>();

            string sqlStr = "SELECT * FROM dbo.MeasuredParameter";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        mp.Add(MIConverter.FromDRToMeasuredParameter(dr));
                    }
                }
            }

            return mp;
        }

        private List<Measuring> GetMeasurings()
        {
            var m = new List<Measuring>();

            string sqlStr = "SELECT * FROM";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        // m.Add();
                    }
                }
            }

            return m;
        }

        private List<MSCategory> GetMSCategories()
        {
            var categories = new List<MSCategory>();

            string sqlStr = "SELECT * FROM dbo.MSCategory";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        categories.Add(MIConverter.FromDRToCategory(dr));
                    }
                }
            }

            return categories;
        }

        private List<MSKind> GetMSKinds()
        {
            var kinds = new List<MSKind>();

            string sqlStr = "SELECT * FROM dbo.MSKind";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        kinds.Add(MIConverter.FromDRToKind(dr));
                    }
                }
            }

            return kinds;
        }

        private List<Repair> GetRepairs()
        {
            var repairs = new List<Repair>();

            string sqlStr = "SELECT * FROM ";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        // repairs.Add();
                    }
                }
            }

            return repairs;
        }

        private List<RepairOrganization> GetRepairOrganizations()
        {
            var organizations = new List<RepairOrganization>();

            string sqlStr = "SELECT * FROM dbo.RepairOrganization";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        organizations.Add(MIConverter.FromDRToRepairOrganization(dr));
                    }
                }
            }

            return organizations;
        }

        private List<RepairReason> GetRepairReasons()
        {
            var reasons = new List<RepairReason>();

            string sqlStr = "SELECT * FROM dbo.RepairReason";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        reasons.Add(MIConverter.FromDRToRepairReason(dr));
                    }
                }
            }

            return reasons;
        }

        private List<Storage> GetStorages()
        {
            var storages = new List<Storage>();

            string sqlStr = "SELECT * FROM dbo.Storage";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        storages.Add(MIConverter.FromDRToStorage(dr));
                    }
                }
            }

            return storages;
        }

        private List<TechnicalCondition> GetTechnicalConditions()
        {
            var conditons = new List<TechnicalCondition>();

            string sqlStr = "SELECT * FROM dbo.TechnicalCondition";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        conditons.Add(MIConverter.FromDRToTechnicalCondition(dr));
                    }
                }
            }

            return conditons;
        }

        private List<Unit> GetUnits()
        {
            var units = new List<Unit>();

            string sqlStr = "SELECT * FROM dbo.Unit";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        units.Add(MIConverter.FromDRToUnit(dr));
                    }
                }
            }

            return units;
        }

        private List<Verification> GetVerifications()
        {
            var verifications = new List<Verification>();

            string sqlStr = "SELECT * FROM";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        // verifications.Add();
                    }
                }
            }


            return verifications;
        }

        private List<VerificationMethod> GetVerificationMethods()
        {
            var methods = new List<VerificationMethod>();

            string sqlStr = "SELECT * FROM dbo.VerificationMethod";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        methods.Add(MIConverter.FromDRToVerificationMethod(dr));
                    }
                }
            }

            return methods;
        }

        private List<DeviceStatus> GetDeviceStatuses()
        {
            var statuses = new List<DeviceStatus>();

            string sqlStr = "SELECT * FROM";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    // statuses.Add();
                }
            }

            return statuses;
        }

        private List<MeasuringSystem> GetHandbookMeasuringSystemData()
        {
            var ms = new List<MeasuringSystem>();

            string sqlStr = "SELECT ms.Id, ms.MSCategoryId, ms.MeasuringId, " +
                            "ms.ExploitationId, e.VerificationId, " +
                            "m.MSKindId, v.Period, ms.Name, " +
                            "ms.MSType, ms.Cost, c.Category, " +
                            "k.Kind, il.Location, e.InstallationLocationId " +
                            "FROM dbo.MeasuringSystem AS ms " +
                            "LEFT JOIN dbo.MSCategory AS c ON ms.MSCategoryId = c.Id " +
                            "LEFT JOIN dbo.Measuring AS m ON ms.MeasuringId = m.Id " +
                            "LEFT JOIN dbo.MSKind AS k ON m.MSKindId = k.Id " +
                            "LEFT JOIN dbo.Exploitation AS e ON ms.ExploitationId = e.Id " +
                            "LEFT JOIN dbo.InstallationLocation AS il ON e.InstallationLocationId = il.Id " +
                            "LEFT JOIN dbo.Verification AS v ON e.VerificationId = v.Id; ";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ms.Add(MIConverter.FromDRToHandbookMeasuringSystemData(dr));
                }
            }

            return ms;
        }

        private List<MeasuringSystem> GetMeasuringSystemsVerification()
        {
            var ms = new List<MeasuringSystem>();
            
            string sqlStr = "SELECT ms.Id, MeasuringId, ExploitationId, MSType, " +
                            "Name, SerialNumber, MSKindId, Kind, VerificationId, " +
                            "VerificationMethodId, Method, VerificationPlace, " +
                            "CertificateNumber, VerificationResut, Replaced, LastDate, " +
                            "NextDate, Period, " +
                            "InstallationLocationId, StorageId, RepairId, " +
                            "SendToStore, PrimOrSec, InstallationDate, " +
                            "Indicator, InventoryNumber, InstrumentReplacementDate " +
                            "FROM dbo.MeasuringSystem AS ms " +
                            "LEFT JOIN dbo.Measuring AS m ON ms.MeasuringId = m.Id " +
                            "LEFT JOIN dbo.MSKind AS k ON m.MSKindId = k.Id " +
                            "LEFT JOIN dbo.Exploitation AS e ON ms.ExploitationId = e.Id " +
                            "LEFT JOIN dbo.InstallationLocation AS l ON e.InstallationLocationId = l.Id " +
                            "LEFT OUTER JOIN dbo.Storage AS s ON e.StorageId = s.Id " +
                            "LEFT OUTER JOIN dbo.Repair AS r ON e.RepairId = r.Id " +
                            "LEFT JOIN dbo.Verification AS v ON e.VerificationId = v.Id " +
                            "LEFT OUTER JOIN dbo.VerificationMethod AS vm ON v.VerificationMethodId = vm.Id;";

            using (DataTable dt = SendQueryToDB(sqlStr))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ms.Add(MIConverter.FromDRToMeasuringSystemVerification(dr));
                }
            }

            return ms;
        }

        private DataTable SendQueryToDB(string sqlQuery)
        {
            using (DataSet ds = new DataSet())
            {
                using (SqlConnection sqlCon = new SqlConnection(_connectionString))
                {
                    try
                    {
                        sqlCon.Open();
                        using (SqlDataAdapter sqlDA = new SqlDataAdapter(sqlQuery, sqlCon))
                        {
                            sqlDA.Fill(ds);
                        }
                    }
                    catch (Exception ex)
                    {
                        // TODO: Loggining
                        Console.WriteLine(ex.Message);
                        return new DataTable();
                    }
                    finally
                    {
                        sqlCon.Close();
                    }
                }

                return ds.Tables[0];
            }
        }





        public bool AddMSCategory(MSCategory category)
        {
            int result;
            string sqlStr = "INSERT INTO dbo.MSCategory VALUES(@Category)";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar).Value = category.Category;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool AddFactoryManufacturer(FactoryManufacturer factory)
        {
            int result;
            string sqlStr = "INSERT INTO dbo.FactoryManufacturer VALUES(@Factory)";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Factory", SqlDbType.NVarChar).Value = factory.Factory;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool AddInstallationLocation(InstallationLocation location)
        {
            int result;
            string sqlStr = "INSERT INTO dbo.InstallationLocation VALUES(@Location)";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location.Location;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool AddMeasuredParameter(MeasuredParameter parameter)
        {
            int result;
            string sqlStr = "INSERT INTO dbo.MeasuredParameter VALUES(@Parameter)";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Parameter", SqlDbType.NVarChar).Value = parameter.Parameter;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool AddMSKind(MSKind kind)
        {
            int result;
            string sqlStr = "INSERT INTO dbo.MSKind VALUES(@Kind)";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Kind", SqlDbType.NVarChar).Value = kind.Kind;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool AddRepairOrganization(RepairOrganization organization)
        {
            int result;
            string sqlStr = "INSERT INTO dbo.RepairOrganization VALUES(@Organization)";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Organization", SqlDbType.NVarChar).Value = organization.Organization;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool AddRepairReason(RepairReason reason)
        {
            int result;
            string sqlStr = "INSERT INTO dbo.RepairReason VALUES(@Reason)";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Reason", SqlDbType.NVarChar).Value = reason.Reason;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool AddStorage(Storage storage)
        {
            int result;
            string sqlStr = "INSERT INTO dbo.Storage VALUES(@StorageValue)";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@StorageValue", SqlDbType.NVarChar).Value = storage.StorageValue;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool AddTechnicalCondition(TechnicalCondition condition)
        {
            int result;
            string sqlStr = "INSERT INTO dbo.TechnicalCondition VALUES(@Condition)";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Condition", SqlDbType.NVarChar).Value = condition.Condition;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool AddUnit(Unit unit)
        {
            int result;
            string sqlStr = "INSERT INTO dbo.Unit VALUES(@UnitValue)";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@UnitValue", SqlDbType.NVarChar).Value = unit.UnitValue;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool AddVerificationMethod(VerificationMethod method)
        {
            int result;
            string sqlStr = "INSERT INTO dbo.VerificationMethod VALUES(@Method)";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Method", SqlDbType.NVarChar).Value = method.Method;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool AddMeasuringSystem(MeasuringSystem system)
        {
            int result;
            string sqlStr = "INSERT INTO dbo.MeasuringSystem VALUES(@Category, @Measuring, @Factory," +
                            " @Exploitation, @Name, @Type, @SerialNumber, @ProductionDate, @LifeTime, @Cost)";
            int measuringId = AddMeasuring(system.Measuring);
            int exploitationId = AddExploitation(system.Exploitation);
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Category", SqlDbType.Int).Value = system.MSCategory.Id;
                cmd.Parameters.Add("@Measuring", SqlDbType.Int).Value = measuringId;
                cmd.Parameters.Add("@Factory", SqlDbType.Int).Value = system.FactoryManufacturer.Id;
                cmd.Parameters.Add("@Exploitation", SqlDbType.Int).Value = exploitationId;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = system.Name;
                cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = system.MSType;
                cmd.Parameters.Add("@SerialNumber", SqlDbType.NVarChar).Value = system.SerialNumber;
                cmd.Parameters.Add("@ProductionDate", SqlDbType.Date).Value = system.ProductionDate.Date;
                cmd.Parameters.Add("@LifeTime", SqlDbType.Int).Value = system.LifeTime;
                cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = system.Cost;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }
            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public int AddExploitation(Exploitation exploitation)
        {
            object result;
            string sqlStr = "INSERT INTO dbo.Exploitation VALUES(@Verification," +
                            " @Location, @Storage, @Repair, @Send, @PrimSec," +
                            " @InstallationDate, @Indicator, @Invertory, @ReplaceDate);" +
                            "SELECT SCOPE_IDENTITY();";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Verification", SqlDbType.Int).Value = (exploitation.Verification != null) ? exploitation.Verification.Id : (object)DBNull.Value;
                cmd.Parameters.Add("@Location", SqlDbType.Int).Value = exploitation.InstallationLocation.Id;
                cmd.Parameters.Add("@Storage", SqlDbType.Int).Value = (exploitation.Storage != null) ? exploitation.Storage.Id : (object)DBNull.Value;
                cmd.Parameters.Add("@Repair", SqlDbType.Int).Value = (exploitation.Repair != null) ? exploitation.Repair.Id : (object)DBNull.Value;
                cmd.Parameters.Add("@Send", SqlDbType.Date).Value = exploitation.SentToStore.Date;
                cmd.Parameters.Add("@PrimSec", SqlDbType.Bit).Value = exploitation.PrimOrSec;
                cmd.Parameters.Add("@InstallationDate", SqlDbType.Date).Value = exploitation.InstallationDate.Date;
                cmd.Parameters.Add("@Indicator", SqlDbType.Bit).Value = exploitation.Indicator;
                cmd.Parameters.Add("@Invertory", SqlDbType.NVarChar).Value = exploitation.InventoryNumber;
                cmd.Parameters.Add("@ReplaceDate", SqlDbType.Date).Value = exploitation.InstrumentReplacementDate.Date;
                sqlCon.Open();
                result = cmd.ExecuteScalar();
            }
            return Convert.ToInt32(result);
        }

        public int AddMeasuring(Measuring measuring)
        {
            object result;
            string sqlStr = "INSERT INTO dbo.Measuring VALUES(@Unit, @Kind, @Param," +
                            " @Accuracy, @Lower, @Upper, @Error);" +
                            "SELECT SCOPE_IDENTITY();";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Unit", SqlDbType.Int).Value = measuring.Unit.Id;
                cmd.Parameters.Add("@Kind", SqlDbType.Int).Value = measuring.MSKind.Id;
                cmd.Parameters.Add("@Param", SqlDbType.Int).Value = measuring.MeasuredParameter.Id;
                cmd.Parameters.Add("@Accuracy", SqlDbType.Float).Value = measuring.Accuracy;
                cmd.Parameters.Add("@Lower", SqlDbType.Int).Value = measuring.LowerLimit;
                cmd.Parameters.Add("@Upper", SqlDbType.Int).Value = measuring.UpperLimit;
                cmd.Parameters.Add("@Error", SqlDbType.Float).Value = measuring.Error;
                sqlCon.Open();
                result = cmd.ExecuteScalar();
            }
            return Convert.ToInt32(result);
        }

        public int AddVerification(Verification verification)
        {
            object result;
            string sqlStr = "INSERT INTO dbo.Verification VALUES(@Method, @Place, @Last," +
                            " @Period, @Next, @Certification, @Result, @Replaced);" +
                            "SELECT SCOPE_IDENTITY();";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Method", SqlDbType.Int).Value = verification.VerificationMethod.Id;
                cmd.Parameters.Add("@Place", SqlDbType.NVarChar).Value = verification.VerificationPlace;
                cmd.Parameters.Add("@Last", SqlDbType.Date).Value = verification.LastDate.Date;
                cmd.Parameters.Add("@Period", SqlDbType.Int).Value = verification.Period;
                cmd.Parameters.Add("@Next", SqlDbType.Date).Value = verification.NextDate.Date;
                cmd.Parameters.Add("@Certification", SqlDbType.NVarChar).Value = verification.CertificateNumber;
                cmd.Parameters.Add("@Result", SqlDbType.Bit).Value = verification.VerificationResult;
                cmd.Parameters.Add("@Replaced", SqlDbType.Bit).Value = verification.Replaced;
                sqlCon.Open();
                result = cmd.ExecuteScalar();
            }
            int id = Convert.ToInt32(result);
            return id;
        }

        public bool AddRepair(Repair repair)
        {
            int result;
            string sqlStr = "INSERT INTO dbo.Repair VALUES(@Reason, @Organization, @Date)";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Reason", SqlDbType.Int).Value = repair.RepairReason.Id;
                cmd.Parameters.Add("@Organization", SqlDbType.Int).Value = repair.RepairOrganization.Id;
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = repair.RepairDate.Date;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }
            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteMSCategory(MSCategory category)
        {
            int result;
            string sqlStr = "DELETE FROM dbo.MSCategory WHERE Id=@Id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = category.Id;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteFactoryManufacturer(FactoryManufacturer factory)
        {
            int result;
            string sqlStr = "DELETE FROM dbo.FactoryManufacturer WHERE Id=@Id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = factory.Id;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteInstallationLocation(InstallationLocation location)
        {
            int result;
            string sqlStr = "DELETE FROM dbo.InstallationLocation WHERE Id=@Id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = location.Id;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteMeasuredParameter(MeasuredParameter parameter)
        {
            int result;
            string sqlStr = "DELETE FROM dbo.MeasuredParameter WHERE Id=@Id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = parameter.Id;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteMSKind(MSKind kind)
        {
            int result;
            string sqlStr = "DELETE FROM dbo.MSKind WHERE Id=@Id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = kind.Id;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteRepairOrganization(RepairOrganization organization)
        {
            int result;
            string sqlStr = "DELETE FROM dbo.RepairOrganization WHERE Id=@Id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = organization.Id;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteRepairReason(RepairReason reason)
        {
            int result;
            string sqlStr = "DELETE FROM dbo.RepairReason WHERE Id=@Id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = reason.Id;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteStorage(Storage storage)
        {
            int result;
            string sqlStr = "DELETE FROM dbo.Storage WHERE Id=@Id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = storage.Id;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteTechnicalCondition(TechnicalCondition condition)
        {
            int result;
            string sqlStr = "DELETE FROM dbo.TechnicalCondition WHERE Id=@Id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = condition.Id;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteUnit(Unit unit)
        {
            int result;
            string sqlStr = "DELETE FROM dbo.Unit WHERE Id=@Id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = unit.Id;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteVerificationMethod(VerificationMethod method)
        {
            int result;
            string sqlStr = "DELETE FROM dbo.VerificationMethod WHERE Id=@Id";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = method.Id;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }

            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateExploitation(Exploitation exploitation)
        {
            int result;
            string sqlStr = "UPDATE dbo.Exploitation SET " +
                            "InstallationLocationId=@LocationId, StorageId=@StorageId, VerificationId=@VerificationId, " +
                            "RepairId=@RepairId, SendToStore=@SendToStore, PrimOrSec=@PrimOrSec, " +
                            "InstallationDate=@InstallationDate, Indicator=@Indicator, " +
                            "InventoryNumber=@Number, InstrumentReplacementDate=@ReplacementDate " +
                            "WHERE Id=@Id;";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@VerificationId", SqlDbType.Int).Value = exploitation.Verification != null ? exploitation.Verification.Id : (object)DBNull.Value;
                cmd.Parameters.Add("@LocationId", SqlDbType.Int).Value = exploitation.InstallationLocation.Id;
                cmd.Parameters.Add("StorageId", SqlDbType.Int).Value = exploitation.Storage != null ? exploitation.Storage.Id : (object)DBNull.Value;
                cmd.Parameters.Add("@RepairId", SqlDbType.Int).Value = exploitation.Repair != null ? exploitation.Repair.Id : (object)DBNull.Value;
                cmd.Parameters.Add("@SendToStore", SqlDbType.Date).Value = exploitation.SentToStore.Date;
                cmd.Parameters.Add("@PrimOrSec", SqlDbType.Bit).Value = exploitation.PrimOrSec;
                cmd.Parameters.Add("@InstallationDate", SqlDbType.Date).Value = exploitation.InstallationDate.Date;
                cmd.Parameters.Add("@Indicator", SqlDbType.Bit).Value = exploitation.Indicator;
                cmd.Parameters.Add("@Number", SqlDbType.NVarChar).Value = exploitation.InventoryNumber;
                cmd.Parameters.Add("@ReplacementDate", SqlDbType.Date).Value = exploitation.InstrumentReplacementDate.Date;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = exploitation.Id;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }
            if (result != 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateVerification(Verification verification)
        {
            int result;
            string sqlStr = "UPDATE dbo.Verification SET VerificationMethodId=@Method, " +
                            "VerificationPlace=@Place, LastDate=@LastDate, Period=@Period, " +
                            "NextDate=@NextDate, CertificateNumber=@Number, VerificationResut=@Result, " +
                            "Replaced=@Replaced WHERE Id=@Id;";
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlCon);
                cmd.Parameters.Add("@Method", SqlDbType.Int).Value = verification.VerificationMethod.Id;
                cmd.Parameters.Add("@Place", SqlDbType.NVarChar).Value = verification.VerificationPlace;
                cmd.Parameters.Add("@LastDate", SqlDbType.Date).Value = verification.LastDate.Date;
                cmd.Parameters.Add("NextDate", SqlDbType.Date).Value = verification.NextDate.Date;
                cmd.Parameters.Add("@Period", SqlDbType.Int).Value = verification.Period;
                cmd.Parameters.Add("@Number", SqlDbType.NVarChar).Value = verification.CertificateNumber;
                cmd.Parameters.Add("@Result", SqlDbType.Bit).Value = verification.VerificationResult;
                cmd.Parameters.Add("@Replaced", SqlDbType.Bit).Value = verification.Replaced;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = verification.Id;
                sqlCon.Open();
                result = cmd.ExecuteNonQuery();
            }
            if (result != 0)
            {
                return true;
            }
            return false;
        }

        private string _connectionString = "Data Source=DESKTOP-1V00CT8;Initial Catalog=ms;Integrated Security=True";
    }
}
