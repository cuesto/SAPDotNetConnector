using SAPDotNetConnector.DataAccess;
using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;

namespace SAPDotNetConnector
{
    class SapR3
    {
        public RfcDestination rfcDest;

        public SapR3()
        {
            SAPSystemConnect sapCfg = new SAPSystemConnect();

            RfcDestinationManager.RegisterDestinationConfiguration(sapCfg);

            //System Id
            rfcDest = RfcDestinationManager.GetDestination("DAM");
        }

        public IRfcFunction getFunction(RfcDestination destination, string function, Dictionary<string, string> param)
        {
            try
            {
                RfcRepository repo = destination.Repository;
                //declare function
                IRfcFunction listfunc = repo.CreateFunction(function);
                //send parameters
                foreach (var p in param)
                {
                    if (p.Key != "")
                    {
                        listfunc.SetValue(p.Key, p.Value);
                    }
                }
                //call function
                listfunc.Invoke(destination);

                //get table
                return listfunc;
            }
            catch (RfcCommunicationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (RfcLogonException e)
            {
                // user could not logon...
                Console.WriteLine("Cannot Connect - " + e.Message);
            }
            catch (RfcAbapRuntimeException e)
            {
                // serious problem on ABAP system side...
            }
            catch (RfcAbapBaseException e)
            {
                // The function module returned an ABAP exception, an ABAP message
                // or an ABAP class-based exception...
            }
            return null;
        }
    }
}
