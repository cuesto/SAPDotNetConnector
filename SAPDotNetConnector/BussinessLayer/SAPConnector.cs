using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;

namespace SAPDotNetConnector.Business_Layer
{
    class SAPConnector
    {
        private SapR3 sap;
        private IRfcFunction funct;
        private Dictionary<string, string> param;

        public SAPConnector()
        {
            param = new Dictionary<string, string>();
            sap = new SapR3();
        }

        public void ReadFromSAP()
        {
            IRfcTable tClients;

            //function parameters
            param.Clear();
            param.Add("sociedad", "2000");

            IRfcFunction list = sap.getFunction(sap.rfcDest, "ZF_CLIENTES", param);
            tClients = list.GetTable("T_CLIENTES");
            list.Invoke(sap.rfcDest);

            // call items
            for (int i = 0; i < tClients.RowCount; i++)
            {
                tClients.CurrentIndex = i;
                //get Id Client
                String idClient = tClients.GetString("KUNNR").ToString();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        public void WriteToSAP()
        {
            //function parameters
            param.Clear();

            // SAP function
            funct = sap.getFunction(sap.rfcDest, "ZF_INTERFAZ_IVEND_SAP2", param);

            // detail structure
            IRfcTable tDetail = funct.GetTable("T_DETALLES");
            tDetail.Insert();  // This adds a new row to the table:
            tDetail.CurrentIndex = tDetail.Count - 1;

            // assign value to table
            tDetail.SetValue("SOCIEDAD", 2000);
            tDetail.SetValue("TIENDA", "tienda");
            tDetail.SetValue("FECHA", DateTime.Today);

            // call function to insert the record
            funct.Invoke(sap.rfcDest);
            // This table returns information about the transaction on
            IRfcTable tReturn = funct.GetTable("T_RETURN");
        }
    }
}

        
    

