using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPDotNetConnector.Business_Layer;

namespace SAPDotNetConnector
{
    class Program
    {
        static void Main(string[] args)
        {
            SAPConnector sap = new SAPConnector();
            sap.ReadFromSAP();
            sap.WriteToSAP();
        }
    }
}
