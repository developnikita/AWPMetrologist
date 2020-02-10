using System;
using System.Net;
using System.Windows;
using System.ServiceModel;

namespace AWPMetrologist
{
    public class Connection
    {

        private Connection()
        {
            _client.Endpoint.Address = new System.ServiceModel.EndpointAddress(new Uri("http://localhost:64455/Service"));
        }

        // public List<MeasuringIn>

        public void Test()
        {
            var result = _client.GetMSJsonAsync();

            /*
            var serviceClient = new Client.ServiceReference.ServiceClient();
            var data = serviceClient.GetMSJsonAsync();
            if (data.Result == null)
            {
                System.Console.WriteLine("Работает");
            }
            */
        }

        public static Connection Instance
        {
            get
            {
                return _instance;
            }
        }

        private static Connection _instance = new Connection();
        private Client.ServiceReference.ServiceClient _client = new Client.ServiceReference.ServiceClient();
    }
}
