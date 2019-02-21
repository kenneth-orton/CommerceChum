using System;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Windows.Forms;
using System.IO;

namespace DeskJockey
{
    class InvoiceWorksheetBuilder
    {
        private static ExcelPackage excelPkg; 
        private static ExcelWorksheet excelWs; 
        private ExcelRange cell;
        private static int startProductRow = 23;
        private static int finalProductRow;

        public InvoiceWorksheetBuilder(string templateFilePath)
        {                     
            FileInfo fileInfo = new FileInfo(templateFilePath);
            excelPkg = new ExcelPackage(fileInfo);
            excelWs = excelPkg.Workbook.Worksheets[1];
        }

        public void insertCellData(ListView lstVwQuote, string shipDate, string shipVia, string trackNum, string poNum, int nextInvoiceNum, 
                                   string payTerms, string billAddr, string shipAddr)
        {
            double totalOfProducts = 0;
            int rowIndex = startProductRow;

            var sheetCell = excelWs.Cells[2, 22]; // invoice #
            sheetCell.Value = nextInvoiceNum;

            sheetCell = excelWs.Cells[5, 22]; // invoice date
            sheetCell.Value = DateTime.Now.ToString("MM/dd/yyyy"); //current date

            sheetCell = excelWs.Cells[8, 22]; // customer PO
            sheetCell.Value = poNum;

            sheetCell = excelWs.Cells[11, 22]; // tracking number
            sheetCell.Value = trackNum;

            sheetCell = excelWs.Cells[11, 9]; // payment terms 
            sheetCell.Value = payTerms;

            sheetCell = excelWs.Cells[11, 14]; // ship via
            sheetCell.Value = shipVia;

            sheetCell = excelWs.Cells[11, 18]; // ship date
            sheetCell.Value = shipDate;

            sheetCell = excelWs.Cells[15, 1]; // bill addr
            sheetCell.Value = billAddr;

            sheetCell = excelWs.Cells[15, 16]; // ship addr
            sheetCell.Value = shipAddr;
            
            sheetCell = excelWs.Cells[45, 24]; // subtotal cell
            sheetCell.Formula = "SUM(X23:X44)";

            sheetCell = excelWs.Cells[48, 24];
            sheetCell.Formula = "SUM(X45:X47)"; // grand total cell

            // insert product rows
            foreach (ListViewItem item in lstVwQuote.Items)
            {
                for (int colIndex = 1; colIndex <= item.SubItems.Count; colIndex++)
                {
                    if (colIndex == 1)
                    {
                        sheetCell = excelWs.Cells[rowIndex, 4];
                        sheetCell.Value = item.SubItems[colIndex - 1].Text;
                    }
                    else if (colIndex == 2)
                    {
                        sheetCell = excelWs.Cells[rowIndex, 8];
                        sheetCell.Value = item.SubItems[colIndex - 1].Text;
                    }
                    else if (colIndex == 4) // format quantity cells
                    {
                        sheetCell = excelWs.Cells[rowIndex, 1];
                        sheetCell.Value = Double.Parse(item.SubItems[colIndex - 1].Text);
                        sheetCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }
                    else if (colIndex == 3 || colIndex == 5) // format currency cells
                    {
                        int celCol = colIndex == 3 ? 20 : 24;
                        sheetCell = excelWs.Cells[rowIndex, celCol];

                        sheetCell.Value = Double.Parse(item.SubItems[colIndex - 1].Text.Replace("$", ""));
                        sheetCell.Style.Numberformat.Format = "$#,###.00";
                        if (colIndex == 5)
                        {
                            sheetCell.Formula = "A" + rowIndex.ToString() + "*T" + rowIndex.ToString();
                            totalOfProducts += (double)Double.Parse(item.SubItems[colIndex - 1].Text.Replace("$", ""));
                        }
                    }

                }
                finalProductRow = rowIndex;
                rowIndex += 1;
            }
            rowIndex += 1;
            cell = excelWs.Cells[rowIndex, 4];
        }

        public void saveExcelFile(string filePath)
        {
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
