using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWPMetrologist
{
    public class Client
    {

        // public List<MeasuringIn>

        public Client Instance
        {
            get
            {
                return _instance;
            }
        }

        private Client _instance = new Client();
    }
}
