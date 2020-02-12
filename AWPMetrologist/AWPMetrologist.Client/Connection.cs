using System;
using System.Collections.Generic;

namespace AWPMetrologist.Client
{
    public class Connection
    {

        private Connection()
        {
            _client.Endpoint.Address = new System.ServiceModel.EndpointAddress(new Uri("http://localhost:64455/Service"));
        }

        // public List<MeasuringIn>

        public List<ServiceReference.MeasuringInstrument> GetMeasuringInstruments()
        {
            var result = _client.GetMSJsonAsync();

            result.Wait();

            if (result.Result != null)
            {
                return new List<ServiceReference.MeasuringInstrument>(result.Result);
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
