using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPDotNetConnector.DataAccess
{
    class SAPSystemConnect : IDestinationConfiguration
    {
        public bool ChangeEventsSupported()
        {
            return false;
            //throw new NotImplementedException();
        }

        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        public RfcConfigParameters GetParameters(string destinationName)
        {
            RfcConfigParameters parms = new RfcConfigParameters();
            if ("DAM".Equals(destinationName))
            {
                parms.Add(RfcConfigParameters.AppServerHost, "127.0.0.1");
                parms.Add(RfcConfigParameters.SystemNumber, "00");
                parms.Add(RfcConfigParameters.User, "username");
                parms.Add(RfcConfigParameters.Password, "password");
                parms.Add(RfcConfigParameters.Client, "220");
                parms.Add(RfcConfigParameters.Language, "ES");
                parms.Add(RfcConfigParameters.PoolSize, "5");
                parms.Add(RfcConfigParameters.MaxPoolSize, "10");
                parms.Add(RfcConfigParameters.IdleTimeout, "600");
            }
            //throw new NotImplementedException();
            return parms;
        }
    }
}
