using AWPMetrologistService.DataContract;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace AWPMetrologistService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        // TODO: check WebInvoke
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<MeasuringInstrument> GetMSJson();

        // TODO: Add your service operations here


    }
}
