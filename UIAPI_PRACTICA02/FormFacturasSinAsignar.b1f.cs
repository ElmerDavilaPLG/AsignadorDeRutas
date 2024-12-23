using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIAPI_PRACTICA02
{
    [FormAttribute("UIAPI_PRACTICA02.FormFacturasSinAsignar", "FormFacturasSinAsignar.b1f")]
    class FormFacturasSinAsignar : UserFormBase
    {
        private SAPbobsCOM.Company oCompany;
        public FormFacturasSinAsignar()
        {
            
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            //          this.Matrix1.MatrixLoadBefore += new SAPbouiCOM._IMatrixEvents_MatrixLoadBeforeEventHandler(this.Matrix1_MatrixLoadBefore);
            this.OnInitializeFormEvents();
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_2").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_5").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_9").Specific));
            this.EditText2.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText2_ChooseFromListAfter);
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_3").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_10").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
           

        }

        private void OnCustomInitialize()
        {
            oCompany = (SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany();
            //SAPbobsCOM.Company oCompany = (SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany();
            SAPbobsCOM.Recordset oRset = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string Query = "SELECT Facturas, Creacion, Bultos, Cliente, Nombre, Direccion, Comuna, Comentarios, Ruta FROM PLG_VW_FACTURAS_SIN_ASIGNAR";
            oRset.DoQuery(Query);
            if (oRset.RecordCount > 0)
            {
                for (int i = 0; i < oRset.RecordCount; i++)
                {
                    Matrix1.AddRow();
                    ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colFactura").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Facturas").Value.ToString();
                    ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colCreaci").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Creacion").Value.ToString();
                    ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colBultos").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Bultos").Value.ToString();
                    ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colClient").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Cliente").Value.ToString();
                    ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colNombre").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Nombre").Value.ToString();
                    ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colDirecc").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Direccion").Value.ToString();
                    ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colComuna").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Comuna").Value.ToString();
                    ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colComent").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Comentarios").Value.ToString();
                    ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colRuta").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Ruta").Value.ToString();
                    oRset.MoveNext();
                }
            }

            Matrix1.AutoResizeColumns();
        }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.Matrix Matrix1;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;

        private void EditText2_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));

            try
            {
                if (chooseFromListEvent.SelectedObjects != null)
                {
                    //si seleccionamos al menos una linea
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText2.Value = chooseFromListEvent.SelectedObjects.GetValue("CardCode", 0).ToString();
                        EditText3.Value = chooseFromListEvent.SelectedObjects.GetValue("CardName", 0).ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.StaticText StaticText6;

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            Button0.Item.Enabled = false;
            Matrix1.Clear();
            String fechaInicio = EditText0.Value.ToString().Trim();
            String fechaFin = EditText1.Value.ToString().Trim();
            String Socio = EditText2.Value.ToString().Trim();

            //SAPbobsCOM.Company oCompany = (SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany();
            SAPbobsCOM.Recordset oRset = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);


            string Query = string.Format("EXEC PLG_SP_BUSCAR_FACTURAS_SIN_ASIGNAR '{0}','{1}','{2}'", fechaInicio, fechaFin, Socio);
            
            oRset.DoQuery(Query);

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item("FormFacturasSinAsignar");
                oForm.Freeze(true);

                if (oRset.RecordCount > 0)
                {
                    for (int i = 0; i < oRset.RecordCount; i++)
                    {
                        Matrix1.AddRow();
                        ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colFactura").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Facturas").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colCreaci").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Creacion").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colBultos").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Bultos").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colClient").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Cliente").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colNombre").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Nombre").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colDirecc").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Direccion").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colComuna").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Comuna").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colComent").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Comentarios").Value.ToString();
                        ((SAPbouiCOM.EditText)Matrix1.Columns.Item("colRuta").Cells.Item(i + 1).Specific).Value = oRset.Fields.Item("Ruta").Value.ToString();
                        oRset.MoveNext();
                    }
                }

                oForm.Freeze(false);
            }
            catch (Exception e)
            {
                Application.SBO_Application.MessageBox(e.ToString(), 1, "Ok", "", "");
            }

            //EditText0.Value = "";
            //EditText1.Value = "";
            EditText2.Value = "";
            EditText3.Value = "";

            Button0.Item.Enabled = true;

        }

    }
}
