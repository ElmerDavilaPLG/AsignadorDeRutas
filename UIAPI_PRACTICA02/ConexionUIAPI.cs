using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbouiCOM.Framework;

namespace UIAPI_PRACTICA02
{
    
    class ConexionUIAPI
    {
      
        private static SAPbobsCOM.Company oCompany;

        private ConexionUIAPI()
        {
            oCompany = (SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany();
        }
        public static SAPbobsCOM.Company conectarUIAPI()
        {
            if (oCompany == null)
            {
                ConexionUIAPI conexion = new ConexionUIAPI();
            }
            return oCompany;
        }

    }
}
