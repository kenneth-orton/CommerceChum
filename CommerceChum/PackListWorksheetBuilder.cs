using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CommerceApp
{
    class PackListWorksheetBuilder
    {
        private static ExcelPackage excelPkg;
        private static ExcelWorksheet excelWs;
        private ExcelRange cell;

        private static int startProductRow = 21;

        private string shipDate;
        private string shipVia;
        private string trackNum;
        private string poNum;
        private string outputFile;

        private ListView lstVwQuote;
        private Customer customer;

        private static int seed; 

        public PackListWorksheetBuilder(string templateFilePath, ListView lstVwQuote, string shipDate, string shipVia, string trackNum, string poNum,
                                       Customer customer, string outputFile)
        {
            FileInfo fileInfo = new FileInfo(templateFilePath);
            excelPkg = new ExcelPackage(fileInfo);
            excelWs = excelPkg.Workbook.Worksheets[1];

            this.lstVwQuote = lstVwQuote;
            this.shipDate = shipDate;
            this.shipVia = shipVia;
            this.trackNum = trackNum;
            this.poNum = poNum;
            this.customer = customer;
            this.outputFile = outputFile;
            seed = (int)DateTime.UtcNow.Ticks;
        }

        private static ThreadLocal<Random> randomWrapper = new ThreadLocal<Random>(() =>
            new Random(Interlocked.Increment(ref seed))
        );

        public static Random GetThreadRandom()
        {
            return randomWrapper.Value;
        }

        private string buildShipAddressString(ShipAddress address)
        {
            StringBuilder output = new StringBuilder();

            output.Append(address.coName + '\n');
            output.Append(address.addr1 + '\n');
            if (address.addr2.Trim() != "")
                output.Append(address.addr2 + '\n');
            output.Append(address.city + ", ");
            output.Append(address.state + " ");
            output.Append(address.zip + '\n');
            output.Append(address.phoneNo);

            return output.ToString();
        }

        public void insertCellData()
        {
            int rowIndex = startProductRow;

            Random rndGen = GetThreadRandom();

            var sheetCell = excelWs.Cells[11, 21]; // pack list #
            sheetCell.Value = rndGen.Next();
            
            sheetCell = excelWs.Cells[11, 14]; // customer PO
            sheetCell.Value = poNum;

            sheetCell = excelWs.Cells[14, 14]; // ship date
            sheetCell.Value = shipDate;

            sheetCell = excelWs.Cells[17, 14]; // ship via
            sheetCell.Value = shipVia;

            sheetCell = excelWs.Cells[18, 14]; // tracking number
            sheetCell.Value = trackNum;

            sheetCell = excelWs.Cells[12, 1]; // ship addr
            sheetCell.Value = buildShipAddressString(customer.shipAddress);

            // insert product rows
            foreach (ListViewItem item in lstVwQuote.Items)
            {
                for (int colIndex = 1; colIndex <= item.SubItems.Count; colIndex++)
                {
                    if (colIndex == 1) // part name
                    {
                        sheetCell = excelWs.Cells[rowIndex, 4];
                        sheetCell.Value = item.SubItems[colIndex - 1].Text;
                    }
                    else if (colIndex == 2) // description
                    {
                        sheetCell = excelWs.Cells[rowIndex, 8];
                        sheetCell.Value = item.SubItems[colIndex - 1].Text;
                    }
                    else if (colIndex == 4) // qty
                    {
                        sheetCell = excelWs.Cells[rowIndex, 1];
                        sheetCell.Value = Double.Parse(item.SubItems[colIndex - 1].Text);
                        sheetCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }
                }
                rowIndex += 1;
            }
            rowIndex += 1;
            cell = excelWs.Cells[rowIndex, 4];
        }

        public void saveExcelFile()
        {
            // Save and open the Excel file
            try
            {
                Byte[] bin = excelPkg.GetAsByteArray();
                File.WriteAllBytes(outputFile, bin);
                MessageBox.Show("Export to Excel Success", "Process Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(outputFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export to Excel Failed: \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
