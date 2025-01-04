using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UIAPI_PRACTICA02
{
    class Menu
    {
        public static Form1 form1 = null;
        
        public static FormAsignacionRuta formAsignacionRuta = null;
        public static FormListadoRutas formListadoRutas = null;
        public void AddMenuItems()
        {
            SAPbouiCOM.Menus oMenus = null;
            SAPbouiCOM.MenuItem oMenuItem = null;

            oMenus = Application.SBO_Application.Menus;

            SAPbouiCOM.MenuCreationParams oCreationPackage = null;
            oCreationPackage = ((SAPbouiCOM.MenuCreationParams)(Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams)));
            oMenuItem = Application.SBO_Application.Menus.Item("43520"); // moudles'

            oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_POPUP;
            oCreationPackage.UniqueID = "UIAPI_PRACTICA02";
            oCreationPackage.String = "Asignador de Rutas";
            oCreationPackage.Enabled = true;
            oCreationPackage.Position = -1;
            String iconoAddon = @"\\WIN-HV928VPQJRH\Logos\IconoCamion-16x16.bmp";
            oCreationPackage.Image = iconoAddon;

            oMenus = oMenuItem.SubMenus;

            try
            {
                //  If the manu already exists this code will fail
                oMenus.AddEx(oCreationPackage);
            }
            catch (Exception e)
            {

            }

            try
            {
                // Get the menu collection of the newly added pop-up item
                oMenuItem = Application.SBO_Application.Menus.Item("UIAPI_PRACTICA02");
                oMenus = oMenuItem.SubMenus;

                // SubMenu Desarrollo
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreationPackage.UniqueID = "UIAPI_PRACTICA02.Form1";
                oCreationPackage.String = "Modulo Desarrollo";
                //oMenus.AddEx(oCreationPackage);
                    
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreationPackage.UniqueID = "UIAPI_PRACTICA02.FormFacturasSinAsignar";
                oCreationPackage.String = "Facturas sin Asignar";
                oMenus.AddEx(oCreationPackage);
                

                // SubMenu Asignacion de Rutas
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreationPackage.UniqueID = "UIAPI_PRACTICA02.FormAsignacionRuta";
                oCreationPackage.String = "Asignacion de Rutas";
                oMenus.AddEx(oCreationPackage);

                // SubMenu Listado de Rutas
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreationPackage.UniqueID = "UIAPI_PRACTICA02.FormListadoRutas";
                oCreationPackage.String = "Listado de Rutas";
                oMenus.AddEx(oCreationPackage);
            }
            catch (Exception er)
            { //  Menu already exists
                Application.SBO_Application.SetStatusBarMessage("Menu Already Exists", SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }

            
        }

        public void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                if (pVal.BeforeAction && pVal.MenuUID == "UIAPI_PRACTICA02.Form1")
                {
                    Form1 form1 = new Form1();
                    form1.Show();

                }
                else if (pVal.BeforeAction && pVal.MenuUID == "UIAPI_PRACTICA02.FormFacturasSinAsignar")
                {
                    FormFacturasSinAsignar formFacturasSinAsignar = new FormFacturasSinAsignar();
                    formFacturasSinAsignar.Show();
                   
                }
                else if (pVal.BeforeAction && pVal.MenuUID == "UIAPI_PRACTICA02.FormAsignacionRuta")
                {
                    FormAsignacionRuta formAsignacionRuta = new FormAsignacionRuta();
                    formAsignacionRuta.Show();
                    
                }
                else if (pVal.BeforeAction && pVal.MenuUID == "UIAPI_PRACTICA02.FormListadoRutas")
                {
                    FormListadoRutas formListadoRutas = new FormListadoRutas();      
                    formListadoRutas.Show();

                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.ToString(), 1, "Ok", "", "");
            }
        }


    }
}
