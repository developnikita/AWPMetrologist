using System;
using System.Net;
using System.Windows;
using System.ServiceModel;

namespace AWPMetrologist
{
    public class Connection
    {

        // public List<MeasuringIn>

        public void Test()
        {
            var serviceClient = new Client.ServiceReference.ServiceClient();
            var data = serviceClient.GetMSJsonAsync();
            if (data.Result == null)
            {
                System.Console.WriteLine("Работает");
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
    }
}
