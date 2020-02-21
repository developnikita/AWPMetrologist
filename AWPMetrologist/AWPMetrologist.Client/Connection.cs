using AWPMetrologist.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWPMetrologist.Client
{
    public class Connection
    {

        private Connection()
        {
            string ip = IpAddressService.Ip;
            string port = IpAddressService.Port;
            _client.Endpoint.Address = new System.ServiceModel.EndpointAddress(new Uri("http://" + ip + ":" + port + "/Service"));
        }

        public async Task<List<ServiceReference.MeasuringInstrument>> GetMeasuringInstruments()
        {
            var results = await _client.GetMSJsonAsync();

            if (results != null)
            {
                return results.ToList();
            }
            else
            {
                return new List<ServiceReference.MeasuringInstrument>();
            }
        }

        public static Connection Instance
        {
            get
            {
                return _instance;
            }
        }

        private static Connection _instance = new Connection();
        private ServiceReference.ServiceClient _client = new ServiceReference.ServiceClient();
    }
}
