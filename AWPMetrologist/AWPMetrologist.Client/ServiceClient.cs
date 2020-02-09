using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWPMetrologist
{
    public class ServiceClient
    {

        // public List<MeasuringIn>

        public ServiceClient Instance
        {
            get
            {
                return _instance;
            }
        }

        private ServiceClient _instance = new ServiceClient();
    }
}
