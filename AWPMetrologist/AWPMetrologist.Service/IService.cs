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
        List<MeasuringInstrument> GetMSJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<MICategory> GetMICategoriesJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<MIDevice> GetMIDevicesJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<MIKind> GetMIKindJson();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<VerificationPlace> GetVerificationPlacesJson();

        // TODO: Add your service operations here
    }
}
