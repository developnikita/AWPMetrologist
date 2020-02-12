using AWPMetrologistService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AWPMetrologist.ConsoleService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Service)))
            {
                host.Open();
                Console.WriteLine("Service hosted Sucessfully");
                Console.WriteLine("Put some character for close service");
                Console.ReadLine();
            }
        }
    }
}
