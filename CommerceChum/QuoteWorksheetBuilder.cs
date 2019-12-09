using System;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Windows.Forms;
using System.IO;

namespace CommerceApp
{
    class QuoteWorksheetBuilder
    {
        private static ExcelPackage excelPkg; 
        private static ExcelWorksheet excelWs; 
        private ExcelRange cell;

        private static int finalProductRow;
        private static int rowIndex;
        private static int colIndex;

        private int totalRow;
        private int transFeeRow;
        private int shippingRow;
        private int discountRow;
        private int subtotalRow;

        private bool subtotalCellExists;
        private bool payByBank;
        private bool payByPaypal;

        private double discountField;
        private double shippingField;

        private string transFeeCalc;
        private string filePath;
        private string discountCalc;
        private static string wkshtName = "Quote";

        private ListView lstVwQuote;
        private CheckBox chkDiscPercent;
        private RadioButton rdoPayCheck;

        private Label lblTotal;
        private Label lblShippingCost;
        private Label lblSubTotal;
        private Label lblDiscount;
        private Label lblTransFee;

        private MaskedTextBox mskTxtDiscountTotal;
        private MaskedTextBox mskTxtShipCostTotal;
        private MaskedTextBox mskTxtTransFee;

        public QuoteWorksheetBuilder(MaskedTextBox mskTxtDiscountTotal, MaskedTextBox mskTxtShipCostTotal, RadioButton rdoPayBank, RadioButton rdoPayPal,
                                     ListView lstVwQuote, Label lblSubTotal, Label lblDiscount, CheckBox chkDiscPercent, string discountCalc, string filePath,
                                     Label lblShippingCost, RadioButton rdoPayCheck, Label lblTransFee, MaskedTextBox mskTxtTransFee, string transFeeCalc, Label lblTotal)
        {
            excelPkg = new ExcelPackage();
            excelPkg.Workbook.Worksheets.Add(wkshtName);
            excelWs = excelPkg.Workbook.Worksheets[1];
            excelWs.Name = wkshtName;

            this.lstVwQuote = lstVwQuote;
            this.lblSubTotal = lblSubTotal;
            this.lblDiscount = lblDiscount;
            this.mskTxtDiscountTotal = mskTxtDiscountTotal;
            this.chkDiscPercent = chkDiscPercent;
            this.discountCalc = discountCalc;
            this.lblShippingCost = lblShippingCost;
            this.mskTxtShipCostTotal = mskTxtShipCostTotal;
            this.rdoPayCheck = rdoPayCheck;
            this.lblTransFee = lblTransFee;
            this.mskTxtTransFee = mskTxtTransFee;
            this.transFeeCalc = transFeeCalc;
            this.filePath = filePath;
            this.lblTotal = lblTotal;

            discountField = Double.Parse(mskTxtDiscountTotal.Text.Replace("$", ""));
            shippingField = Double.Parse(mskTxtShipCostTotal.Text.Replace("$", ""));

            payByBank = rdoPayBank.Checked;
            payByPaypal = rdoPayPal.Checked;

            totalRow = 0;
            transFeeRow = 0;
            shippingRow = 0;
            discountRow = 0;
            subtotalRow = 0;
            finalProductRow = 0;
            rowIndex = 1;
            colIndex = 1;

            subtotalCellExists = false;
        }

        public void insertHeader()
        {
            foreach (ColumnHeader header in lstVwQuote.Columns)
            {
                var headerCell = excelWs.Cells[rowIndex, colIndex];
                headerCell.Style.Font.Bold = true;
                headerCell.Value = header.Text;
                colIndex += 1;
            }
        }

        public void insertProductRows()
        {
            double totalOfProducts = 0;
            rowIndex = 2;
            // insert product rows
            foreach (ListViewItem item in lstVwQuote.Items)
            {
                for (colIndex = 1; colIndex <= item.SubItems.Count; colIndex++)
                {
                    var productCell = excelWs.Cells[rowIndex, colIndex];
                    if (colIndex == 4) // format quantity cells
                    {
                        productCell.Value = Double.Parse(item.SubItems[colIndex - 1].Text);
                        productCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }
                    else if (colIndex == 3 || colIndex == 5) // format currency cells
                    {
                        productCell.Value = Double.Parse(item.SubItems[colIndex - 1].Text.Replace("$", ""));
                        productCell.Style.Numberformat.Format = "$#,###.00";
                        if (colIndex == 5)
                        {
                            productCell.Formula = "C" + rowIndex.ToString() + "*D" + rowIndex.ToString();
                            totalOfProducts += (double)Double.Parse(item.SubItems[colIndex - 1].Text.Replace("$", ""));
                        }
                    }
                    else
                    {
                        productCell.Value = item.SubItems[colIndex - 1].Text;
                    }
                }
                finalProductRow = rowIndex;
                rowIndex += 1;
            }
            rowIndex += 1;
            cell = excelWs.Cells[rowIndex, 4];
        }

        public void insertSubtotalRow()
        {
            if (discountField > 0 || shippingField > 0 || payByBank || payByPaypal)
            {
                subtotalRow = rowIndex;
                rowIndex += 1;
                cell.Style.Font.Bold = true;
                cell.Value = lblSubTotal.Text.Replace(":", "");
                cell = excelWs.Cells[subtotalRow, 5];
                cell.Style.Numberformat.Format = "$#,###.00";
                cell.Formula = "SUM(E2:E" + finalProductRow.ToString() + ")";
                subtotalCellExists = true;
            }
        }

        public void insertDiscountRow()
        {
            if (discountField > 0)
            {
                discountRow = rowIndex;
                rowIndex += 1;
                cell = excelWs.Cells[discountRow, 4];
                cell.Style.Font.Bold = true;
                cell.Value = lblDiscount.Text.Replace(":", "");
                cell = excelWs.Cells[discountRow, 5];
                cell.Value = Double.Parse(mskTxtDiscountTotal.Text.Replace("$", ""));
                cell.Style.Numberformat.Format = "$#,###.00";
                if (chkDiscPercent.Checked)
                    cell.Formula = "E" + subtotalRow.ToString() + discountCalc;
                else
                    cell.Formula = discountCalc;
            }
        }

        public void insertShippingRow()
        {
            if (shippingField > 0)
            {
                shippingRow = rowIndex;
                rowIndex += 1;
                cell = excelWs.Cells[shippingRow, 4];
                cell.Style.Font.Bold = true;
                cell.Value = lblShippingCost.Text.Replace(":", "");
                cell = excelWs.Cells[shippingRow, 5];
                cell.Value = Double.Parse(mskTxtShipCostTotal.Text.Replace("$", ""));
                cell.Style.Numberformat.Format = "$#,###.00";
            }
        }

        public void insertTransactionFeeRow()
        {
            if (!rdoPayCheck.Checked)
            {
                transFeeRow = rowIndex;
                rowIndex += 1;
                cell = excelWs.Cells[transFeeRow, 4];
                cell.Style.Font.Bold = true;
                cell.Value = lblTransFee.Text.Replace(":", "");
                cell = excelWs.Cells[transFeeRow, 5];
                cell.Value = Double.Parse(mskTxtTransFee.Text.Replace("$", ""));
                cell.Style.Numberformat.Format = "$#,###.00";
                string transFeeCell = "";
                if (!payByBank)
                {
                    if (discountField > 0 && shippingField > 0)
                        transFeeCell = "(E" + subtotalRow.ToString() + "-E" + discountRow.ToString() + "+E" + shippingRow.ToString() + ")" + transFeeCalc;
                    else if (discountField > 0 && shippingField == 0)
                        transFeeCell = "(E" + subtotalRow.ToString() + "-E" + discountRow.ToString() + ")" + transFeeCalc;
                    else if (discountField == 0 && shippingField > 0)
                        transFeeCell = "(E" + subtotalRow.ToString() + "+E" + shippingRow.ToString() + ")" + transFeeCalc;
                    else
                        transFeeCell = "E" + subtotalRow.ToString() + transFeeCalc;
                    cell.Formula = transFeeCell;
                }
            }
        }

        public void insertTotalRow()
        {
            totalRow = rowIndex;
            if (subtotalCellExists)
            {
                cell = excelWs.Cells[totalRow, 4];
                cell.Style.Font.Bold = true;
                cell.Value = lblTotal.Text.Replace(":", "");
                cell = excelWs.Cells[totalRow, 5];
                cell.Style.Numberformat.Format = "$#,###.00";
                if (discountField > 0)
                    cell.Formula = "(E" + subtotalRow.ToString() + "-E" + discountRow.ToString() + ")+" + "SUM(E" + (discountRow + 1).ToString() + ":E" + (totalRow - 1).ToString() + ")";
                else
                    cell.Formula = "SUM(E" + subtotalRow.ToString() + ":E" + (totalRow - 1).ToString() + ")";
            }
            else
            {
                cell = excelWs.Cells[totalRow, 4];
                cell.Style.Font.Bold = true;
                cell.Value = lblTotal.Text.Replace(":", "");
                cell = excelWs.Cells[totalRow, 5];
                cell.Style.Numberformat.Format = "$#,###.00";
                cell.Formula = "SUM(E2:E" + finalProductRow.ToString() + ")";
            }
        }

        public void saveExcelFile()
        {
            excelWs.Cells[excelWs.Dimension.Address].AutoFitColumns();

            // Save and open the Excel file
            try
            {
                Byte[] bin = excelPkg.GetAsByteArray();
                File.WriteAllBytes(filePath, bin);
                MessageBox.Show("Export to Excel Success", "Process Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export to Excel Failed: \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
