using SAPbobsCOM;
using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Xml;

namespace UIAPI_PRACTICA02
{
    [FormAttribute("UIAPI_PRACTICA02.Form1", "Form1.b1f")]
    class Form1 : UserFormBase
    {
        public Form1()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_10").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_14").Specific));
            this.Folder2 = ((SAPbouiCOM.Folder)(this.GetItem("Item_15").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_16").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_18").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_19").Specific));
            this.EditText5.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText5_ChooseFromListAfter);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_6").Specific));
            this.Button2.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button2_ClickBefore);
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_7").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_21").Specific));
            this.Button3.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button3_ClickBefore);
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_22").Specific));
            this.Button4 = ((SAPbouiCOM.Button)(this.GetItem("Item_23").Specific));
            this.OptionBtn0 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_24").Specific));
            this.OptionBtn1 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_25").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_26").Specific));
            this.ComboBox2 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_27").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
           

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.Folder Folder2;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.Button Button2;

        private void Button2_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            //BubbleEvent = true; Codigo por defecto que no se usa
            //throw new System.NotImplementedException();

            int respuesta = 0;

            respuesta = Application.SBO_Application.MessageBox("Estas Seguro que deseas abandonar la ventana?", 1, "SI", "NO", "Cancelar");

            if (respuesta == 1)
            {
                BubbleEvent = true;
                UIAPIRawForm.Close();
            }
            else
            {
                BubbleEvent = false;
            }

        }

        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.Button Button3;

        private void Button3_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //throw new System.NotImplementedException();
            bool ret = false;
            string sqlstring = string.Empty;

            SAPbobsCOM.Company oCompany = null;

            //Representa la conexion a la compañia
            oCompany = ((SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany());

            //Objeto para generar una query o consulta en la compañia
            SAPbobsCOM.Recordset oRecordSet = (Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            sqlstring = "Select \"ItemCode\",\"ItemName\" from [dbo].[OITM]";

            oRecordSet.DoQuery(sqlstring);

            //Le agregamos un valor en blanco al ComboBox
            ComboBox0.ValidValues.Add("", "");

            while (!oRecordSet.EoF)
            {
                if (oRecordSet.Fields.Item(0).Value.ToString().Trim().Length > 0)
                {
                    ComboBox0.ValidValues.Add(oRecordSet.Fields.Item(0).Value.ToString().Trim(), oRecordSet.Fields.Item(1).Value.ToString().Trim());
                }
                oRecordSet.MoveNext();
            }

        }

        private void EditText5_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {
                if(chooseFromListEvent.SelectedObjects != null)
                {
                    //si seleccionamos al menos una linea
                    if(chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText5.Value = chooseFromListEvent.SelectedObjects.GetValue("CardCode", 0).ToString();
                        EditText6.Value = chooseFromListEvent.SelectedObjects.GetValue("CardName", 0).ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.Button Button4;


        private SAPbouiCOM.OptionBtn OptionBtn0;
        private SAPbouiCOM.OptionBtn OptionBtn1;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.ComboBox ComboBox2;
    }
}