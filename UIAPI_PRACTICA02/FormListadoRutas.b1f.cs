using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIAPI_PRACTICA02
{
    [FormAttribute("UIAPI_PRACTICA02.FormListadoRutas", "FormListadoRutas.b1f")]
    class FormListadoRutas : UserFormBase
    {
        private SAPbobsCOM.Company oCompany;
        private SAPbouiCOM.Form oForm;
        public FormListadoRutas()
        {

        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.EditText0.KeyDownBefore += new SAPbouiCOM._IEditTextEvents_KeyDownBeforeEventHandler(this.EditText0_KeyDownBefore);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_11").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_12").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_17").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_13").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_7").Specific));
            this.ComboBox0.ComboSelectBefore += new SAPbouiCOM._IComboBoxEvents_ComboSelectBeforeEventHandler(this.ComboBox0_ComboSelectBefore);
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_4").Specific));
            this.ComboBox1.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox1_ComboSelectAfter);
            this.ComboBox2 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_5").Specific));
            this.ComboBox3 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_9").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {
            oCompany = (SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany();

            oForm = Application.SBO_Application.Forms.ActiveForm;

            cargarComboBoxRutas();
            cargarComboBoxChoferes();
            cargarComboBoxAcompanantes();
            cargarComboBoxVehiculos();

        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.ComboBox ComboBox2;
        private SAPbouiCOM.ComboBox ComboBox3;

        //EVENTO del Combo de Chofer: Al seleccionar un chofer carga en el Combobox de Vehiculo, su vehiculo asociado en el UDO
        private void ComboBox1_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            String chofer = this.ComboBox1.Selected.Value;
            //SAPbobsCOM.Company oCompany = (SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany();
            SAPbobsCOM.Recordset oRecordSetVehiculo = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string sqlStringVehiculo = "SELECT \"U_PLG_VEHICULO\" FROM \"@PLG_MCHOFERES\" WHERE \"Name\" = '" + chofer + "'";
            oRecordSetVehiculo.DoQuery(sqlStringVehiculo);
            this.ComboBox3.Select(oRecordSetVehiculo.Fields.Item("U_PLG_VEHICULO").Value.ToString(), SAPbouiCOM.BoSearchKey.psk_ByValue);

        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            //throw new System.NotImplementedException();
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
            {
                cargarMatrixListaRutas();
            }

        }

        private void cargarMatrixListaRutas()
        {
            Matrix0.Clear();
            oForm = Application.SBO_Application.Forms.ActiveForm;

            String fechaDespacho = EditText0.Value.ToString().Trim();

            //CORREGIR ESTE CAMPO PORQUE SE BORRO Y SE COLOCO UN COMBOBOX
            String ruta = ComboBox0.Value.ToString().Trim();

            if (fechaDespacho != "" && ruta != "")
            {
                SAPbobsCOM.Recordset oRset = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                String Query = string.Format("PLG_SP_FACTURAS_LISTAS_DESPACHO '{0}','{1}'", fechaDespacho, ruta);
                oRset.DoQuery(Query);

                try
                {
                    //oForm = Application.SBO_Application.Forms.Item("FormListadoRutas");
                    oForm.Freeze(true);

                    if (oRset.RecordCount > 0)
                    {
                        for (int i = 0; i < oRset.RecordCount; i++)
                        {
                            Matrix0.AddRow();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("colFactur").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Facturas").Value.ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("colComb").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Combinacion").Value.ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("colClient").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Cliente").Value.ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("colNombre").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Nombre").Value.ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("colDirecc").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Direccion").Value.ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("colComuna").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Comuna").Value.ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("colBultos").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Bultos").Value.ToString();
                            ((SAPbouiCOM.EditText)Matrix0.Columns.Item("colComent").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Comentarios").Value.ToString();
                            oRset.MoveNext();
                        }
                    }

                    oForm.Freeze(false);
                    oForm.Update();
                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_OK_MODE;
                }
                catch (Exception e)
                {

                }
            }
        }

        //COMBOBOX FECHA DESPACHO: Evita que se cambie la fecha cuando se encuentra en el modo OK o Actualizar
        private void EditText0_KeyDownBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //throw new System.NotImplementedException();
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                Application.SBO_Application.StatusBar.SetText("Solo se puede cambiar valores en este campo en el modo BUSCAR", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                BubbleEvent = false;
            }
        }

        //COMBOBOX RUTAS: Evita que se cambie una ruta cuando se encuentr en el modo OK o Actualizar
        private void ComboBox0_ComboSelectBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //throw new System.NotImplementedException();
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                Application.SBO_Application.StatusBar.SetText("Solo se puede cambiar valores en este campo en el modo BUSCAR", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                BubbleEvent = false;
            }
        }

        public void cargarComboBoxRutas()
        {
            //Cargar ComboBox de RUTAS
            SAPbobsCOM.Recordset oRecordSetRutas = (SAPbobsCOM.Recordset)this.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string sqlStringRutas = "SELECT \"Code\",\"Name\" FROM \"@PLG_MRUTAS\"";
            oRecordSetRutas.DoQuery(sqlStringRutas);
            int contador = 1;
            while (!oRecordSetRutas.EoF)
            {
                
                if (oRecordSetRutas.Fields.Item("Code").Value.ToString().Trim().Length > 0)
                {
                    string codigoRuta = oRecordSetRutas.Fields.Item("Code").Value.ToString();
                    string nombreRuta = oRecordSetRutas.Fields.Item("Name").Value.ToString();
                    ComboBox0.ValidValues.Add(codigoRuta + " - " + nombreRuta, (contador++).ToString());
                }
                oRecordSetRutas.MoveNext();
            }
        }
        private void cargarComboBoxChoferes()
        {
            //Carga ComboBox de Choferes
            SAPbobsCOM.Recordset oRecordSetChoferes = (SAPbobsCOM.Recordset)this.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string sqlStringChoferes = "SELECT \"Code\",\"Name\" FROM \"@PLG_MCHOFERES\" WHERE \"U_PLG_ESTADO\" = 'Y'";
            oRecordSetChoferes.DoQuery(sqlStringChoferes);

            while (!oRecordSetChoferes.EoF)
            {
                if (oRecordSetChoferes.Fields.Item("Code").Value.ToString().Trim().Length > 0)
                    ComboBox1.ValidValues.Add(oRecordSetChoferes.Fields.Item("Name").Value.ToString().Trim(), oRecordSetChoferes.Fields.Item("Code").Value.ToString().Trim());
                oRecordSetChoferes.MoveNext();
            }
        }

        private void cargarComboBoxAcompanantes()
        {
            //Carga ComboBox de Acompañantes
            SAPbobsCOM.Recordset oRecordSetAcompanantes = (SAPbobsCOM.Recordset)this.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string sqlStringAcompanantes = "SELECT \"Code\",\"Name\" FROM \"@PLG_MACOMPANANTES\" WHERE \"U_PLG_ESTADO\" = 'Y'";
            oRecordSetAcompanantes.DoQuery(sqlStringAcompanantes);

            while (!oRecordSetAcompanantes.EoF)
            {
                if (oRecordSetAcompanantes.Fields.Item("Code").Value.ToString().Trim().Length > 0)
                    ComboBox2.ValidValues.Add(oRecordSetAcompanantes.Fields.Item("Name").Value.ToString().Trim(), oRecordSetAcompanantes.Fields.Item("Code").Value.ToString().Trim());
                oRecordSetAcompanantes.MoveNext();
            }
        }

        private void cargarComboBoxVehiculos()
        {
            //Carga ComboBox de Vehiculos
            SAPbobsCOM.Recordset oRecordSetVehiculos = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string sqlStringVehiculos = "SELECT \"Code\",\"U_PLG_VEHICULO\" FROM \"@PLG_MCHOFERES\" WHERE \"U_PLG_ESTADO\" = 'Y'";
            oRecordSetVehiculos.DoQuery(sqlStringVehiculos);

            while (!oRecordSetVehiculos.EoF)
            {
                if (oRecordSetVehiculos.Fields.Item("Code").Value.ToString().Trim().Length > 0)
                    ComboBox3.ValidValues.Add(oRecordSetVehiculos.Fields.Item("U_PLG_VEHICULO").Value.ToString().Trim(), oRecordSetVehiculos.Fields.Item("Code").Value.ToString().Trim());
                oRecordSetVehiculos.MoveNext();
            }
        }
    }
}
