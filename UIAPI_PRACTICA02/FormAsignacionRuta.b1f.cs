using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIAPI_PRACTICA02
{
    [FormAttribute("UIAPI_PRACTICA02.FormAsignacionRuta", "FormAsignacionRuta.b1f")]
    class FormAsignacionRuta : UserFormBase
    {
        private SAPbobsCOM.Company oCompany;
        private SAPbouiCOM.Form oForm;

        public FormAsignacionRuta()
        {

        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_4").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_6").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_8").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_10").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_14").Specific));
            this.ComboBox0.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox0_ComboSelectAfter);
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_16").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_18").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_21").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("Item_22").Specific));
            this.EditText9.ValidateAfter += new SAPbouiCOM._IEditTextEvents_ValidateAfterEventHandler(this.EditText9_ValidateAfter);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.Button0_PressedBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.ComboBox3 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_29").Specific));
            this.ComboBox3.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox3_ComboSelectAfter);
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("Item_20").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_23").Specific));
            this.LinkedButton1 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_24").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_25").Specific));
            this.Button2.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button2_ClickBefore);
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_26").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_27").Specific));
            this.ComboBox2 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_28").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_30").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(Form_DataLoadAfter);

        }

        private void OnCustomInitialize()
        {
            oCompany = (SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany();
            oForm = Application.SBO_Application.Forms.ActiveForm;

            cargarComboBoxRutas();
            cargarComboBoxCombinaciones();

        }
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.EditText EditText9;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.ComboBox ComboBox3;


        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            

            //Si el formulario se pone en Modo OK
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
            {
                cargarComboBoxDirecciones();
                cargarComboBoxCombinaciones();
            }
        }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.LinkedButton LinkedButton1;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.ComboBox ComboBox2;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.EditText EditText0;

        //BOTON NUEVO GRUPO: Funciona para crear nuevo grupo de combinaciones
        private void Button2_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //throw new System.NotImplementedException();
            String fechaDespacho = EditText9.Value.ToString().Trim();

            SAPbobsCOM.Recordset oRecordGrupos = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string sqlGruposCreados = string.Format("EXEC \"PLG_SP_CREAR_NUEVO_GRUPO\" '{0}'", fechaDespacho);
            oRecordGrupos.DoQuery(sqlGruposCreados);
            string grupoNuevo = oRecordGrupos.Fields.Item("NuevoGrupo").Value.ToString();
            int cantidadGrupos = ComboBox2.ValidValues.Count;
            ComboBox2.ValidValues.Add(grupoNuevo, cantidadGrupos.ToString());
            ComboBox2.Select(grupoNuevo, SAPbouiCOM.BoSearchKey.psk_ByValue);

        }

        private void cargarComboBoxRutas()
        {
            SAPbobsCOM.Recordset oRecordSet = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string sqlString = "SELECT \"Code\",\"Name\" FROM \"@PLG_MRUTAS\"";
            oRecordSet.DoQuery(sqlString);

            int contador = 1;
            while (!oRecordSet.EoF)
            {
                if (oRecordSet.Fields.Item("Code").Value.ToString().Trim().Length > 0)
                    ComboBox3.ValidValues.Add(oRecordSet.Fields.Item("Code").Value.ToString() + " - " + oRecordSet.Fields.Item("Name").Value.ToString() , (contador++).ToString());
                oRecordSet.MoveNext();
            }
        }

        private void cargarComboBoxCombinaciones()
        {
            //COMBOBOX COMBINACIONES: Limpiando el combo
            while (ComboBox2.ValidValues.Count > 0)
            {
                ComboBox2.ValidValues.Remove(0, SAPbouiCOM.BoSearchKey.psk_Index);
            }
            

            String fechaDespacho = EditText9.Value.ToString();

            SAPbobsCOM.Recordset oRecordSet = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string sqlString = "SELECT DISTINCT \"U_PLG_COMBINACION\" FROM \"@PLG_ADMINFACTURAS\" WHERE \"U_PLG_FECHADESPACHO\" = '"+fechaDespacho+"'";
            oRecordSet.DoQuery(sqlString);

            int contadorValores = 0;
            while (!oRecordSet.EoF)
            {
                if (oRecordSet.Fields.Item("U_PLG_COMBINACION").Value.ToString().Trim().Length > 0)
                    ComboBox2.ValidValues.Add(oRecordSet.Fields.Item("U_PLG_COMBINACION").Value.ToString().Trim(), contadorValores.ToString());
                contadorValores++;
                oRecordSet.MoveNext();
            }
        }

        private void cargarComboBoxDirecciones()
        {
            //COMBO DIRECCION: Limpiando el combo
            while (ComboBox0.ValidValues.Count > 0)
            {
                ComboBox0.ValidValues.Remove(0, SAPbouiCOM.BoSearchKey.psk_Index);
            }
            String cliente = EditText5.Value.ToString().Trim();
            String factura = EditText2.Value.ToString().Trim();

            SAPbobsCOM.Recordset oRecordSet01 = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            SAPbobsCOM.Recordset oRecordSet02 = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            //Busqueda de las direcciones registradas en el maestro de socio para el cliente seleccionado
            string sqlDireccionesSocio = "SELECT \"Street\",\"County\" FROM \"CRD1\" WHERE \"CardCode\" = '" + cliente + "' AND \"AdresType\" = 'S'";
            oRecordSet01.DoQuery(sqlDireccionesSocio);

            //Busqueda de la direccion adicional de la factura seleccionada
            string sqlDireccionAdicionalFactura = "SELECT ISNULL(U_PLG_DIRECADICIONAL,'Sin Direccion Adicional') AS Direccion FROM OINV WHERE DocEntry = " + factura;
            oRecordSet02.DoQuery(sqlDireccionAdicionalFactura);

            // COMBO DIRECCION: Cargado el combo con las direcciones del cliente actual
            while (!oRecordSet01.EoF)
            {
                if (oRecordSet01.Fields.Item("Street").Value.ToString().Trim().Length > 0)
                    //La direccion que se debe mostrar es una concatenacion de la direccion y la comuna
                    ComboBox0.ValidValues.Add(oRecordSet01.Fields.Item("Street").Value.ToString(), oRecordSet01.Fields.Item("County").Value.ToString());
                
                oRecordSet01.MoveNext();
            }
            ComboBox0.ValidValues.Add(oRecordSet02.Fields.Item("Direccion").Value.ToString().Trim(), "Sin Comuna Definida");
        }

        //COMBOBOX de Rutas: Actualiza el campo de N° Orden de carga cuando se cambia de ruta en el combobox
        private void ComboBox3_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            string fechaDespacho = EditText9.Value.ToString(); // Retorna en el formato yyyyMMdd
            

            string rutaAsignada = ComboBox3.Selected.Value;
            int posicionEspacio = rutaAsignada.IndexOf(' ');

            SAPbobsCOM.Recordset oRecordRutaSeleccionada = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string sqlCodigoRutaSelect = "SELECT \"Code\" FROM \"@PLG_MRUTAS\" WHERE \"Code\" = '" + rutaAsignada.Substring(0, posicionEspacio) + "'";
            oRecordRutaSeleccionada.DoQuery(sqlCodigoRutaSelect);

            string codigoRuta = oRecordRutaSeleccionada.Fields.Item("Code").Value.ToString();

            EditText1.Value = codigoRuta + "-" + fechaDespacho;

        }

        //EditText Fecha de Despacho: Actualiza el codigo de lista de ruta cuando se actualiza esta fecha
        private void EditText9_ValidateAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            string fechaDespacho = EditText9.Value.ToString();
            string rutaAsignada = String.Empty;
            string codigoRuta = String.Empty;

            if (ComboBox3.Selected == null)
            {
                rutaAsignada = "";
            }
            else
            {
                rutaAsignada = ComboBox3.Selected.Value;
                int posicionEspacio = rutaAsignada.IndexOf(' ');

                SAPbobsCOM.Recordset oRecordRutaSeleccionada = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string sqlCodigoRutaSelect = "SELECT \"Code\" FROM \"@PLG_MRUTAS\" WHERE \"Code\" = '" + rutaAsignada.Substring(0, posicionEspacio) + "'";
                oRecordRutaSeleccionada.DoQuery(sqlCodigoRutaSelect);

                codigoRuta = oRecordRutaSeleccionada.Fields.Item("Code").Value.ToString();
            }
            cargarComboBoxCombinaciones();
            EditText1.Value = codigoRuta + "-" + fechaDespacho;
        }


        //BOTON ACTUALIZAR: Actualiza el codigo de la lista de ruta al momento de presionarlo como actualizar
        /*private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            
        }*/

        //COMBOBOX DIRECCIONES: Despues que se seleccionar la direccion se llena en automatico la comuna
        private void ComboBox0_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            string direccionSeleccionada = ComboBox0.Value.ToString();

            //throw new System.NotImplementedException();
            SAPbobsCOM.Recordset oRecordComunaSeleccionada = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string sqlComunaSeleccionada = "SELECT ISNULL(\"County\",'Sin Comuna') AS \"Comuna\" FROM \"CRD1\" WHERE \"Street\" = '" + direccionSeleccionada + "'";
            oRecordComunaSeleccionada.DoQuery(sqlComunaSeleccionada);
            string comuna = oRecordComunaSeleccionada.Fields.Item("Comuna").Value.ToString();
            if (comuna == "")
            {
                EditText6.Value = "Sin Comuna";
            }
            else
            {
                EditText6.Value = comuna;
            }

        }
        private void Button0_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            oForm = Application.SBO_Application.Forms.ActiveForm;

            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                string fechaDespacho = EditText9.Value.ToString();

                string rutaAsignada = ComboBox3.Selected.Value;
                int posicionEspacio = rutaAsignada.IndexOf(' ');

                SAPbobsCOM.Recordset oRecordRutaSeleccionada = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string sqlCodigoRutaSelect = "SELECT \"Code\" FROM \"@PLG_MRUTAS\" WHERE \"Code\" = '" + rutaAsignada.Substring(0, posicionEspacio) + "'";
                oRecordRutaSeleccionada.DoQuery(sqlCodigoRutaSelect);

                string codigoRuta = oRecordRutaSeleccionada.Fields.Item("Code").Value.ToString();

                EditText1.Value = codigoRuta + "-" + fechaDespacho;
            }
        }
    }
}
