using AWPMetrologist.Common.DataModel;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace AWPMetrologistService
{
    [ServiceContract]
    public interface IService
    {
        // NOTE: check WebInvoke
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<MeasuringSystem> GetMeasuringSystemsJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<Exploitation> GetExploitationsJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<FactoryManufacturer> GetFactoryManufacturersJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<InstallationLocation> GetInstallationLocationsJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<MeasuredParameter> GetMeasuredParametersJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<Measuring> GetMeasuringsJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<MSCategory> GetMSCategoriesJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<MSKind> GetMSKindsJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<Repair> GetRepairsJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<RepairOrganization> GetRepairOrganizationsJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<RepairReason> GetRepairReasonsJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<Storage> GetStoragesJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<TechnicalCondition> GetTechnicalConditionsJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<Unit> GetUnitsJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<Verification> GetVerificationsJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<VerificationMethod> GetVerificationMethodsJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<DeviceStatus> GetDeviceStatusesJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<MeasuringSystem> GetHandbookMeasuringSystemDataJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<MeasuringSystem> GetMeasuringSystemsVerificationJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<MSType> GetMSTypesJson();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<DeviceStatus> GetDeviceStatusesForAnalyzJson(MSType type, TechnicalCondition condition);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool AddMSCategory(MSCategory category);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool AddFactoryManufacturer(FactoryManufacturer factory);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool AddInstallationLocation(InstallationLocation location);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool AddMeasuredParameter(MeasuredParameter parameter);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool AddMSKind(MSKind kind);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool AddRepairOrganization(RepairOrganization organization);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool AddRepairReason(RepairReason reason);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool AddStorage(Storage storage);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool AddTechnicalCondition(TechnicalCondition condition);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool AddUnit(Unit unit);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool AddVerificationMethod(VerificationMethod method);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool AddMeasuringSystem(MeasuringSystem system);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        int AddExploitation(Exploitation exploitation);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        int AddMeasuring(Measuring measuring);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        int AddVerification(Verification verification);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool AddRepair(Repair repair);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool AddDeviceStatus(DeviceStatus deviceStatus);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool AddMSType(MSType type);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool DeleteMSCategory(MSCategory category);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool DeleteFactoryManufacturer(FactoryManufacturer factory);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool DeleteInstallationLocation(InstallationLocation location);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool DeleteMeasuredParameter(MeasuredParameter parameter);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool DeleteMSKind(MSKind kind);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool DeleteRepairOrganization(RepairOrganization organization);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool DeleteRepairReason(RepairReason reason);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool DeleteStorage(Storage storage);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool DeleteTechnicalCondition(TechnicalCondition condition);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool DeleteUnit(Unit unit);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool DeleteVerificationMethod(VerificationMethod method);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool DeleteMSType(MSType type);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool UpdateExploitation(Exploitation exploitation);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool UpdateVerification(Verification verification);

        // TODO: Add your service operations here
    }
}
