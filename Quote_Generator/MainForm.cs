using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DeskJockey
{
    public partial class MainForm : Form
    {
        private Dictionary<int, List<object>> productDict = null; // reduce repetition by creating/using Product class
        private Dictionary<int, Customer> customerDict = null;
        private static string folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string filePath = System.IO.Path.Combine(folder, "quote.xlsx");
        private string discountCalc;
        private string transFeeCalc;
        public MainForm()
        {
            InitializeComponent();
            cboProducts.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboProducts.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitQuoteListView();
            initQuoteTab();
            initDBTab();
        }

        private void initQuoteTab()
        {
            populateCombobox(cboProducts, CBOBoxID.ONE);
            grpShipping.Enabled = false;
            grpDiscount.Enabled = false;
            btnGenQuote.Enabled = false;
            grpPayType.Enabled = false;
            btnMoveItemUp.Text = ((char)0x25B2).ToString();
            btnMoveItemDown.Text = ((char)0x25BC).ToString();
        }

        private void refreshComboboxes()
        {
            populateCombobox(cboProducts, CBOBoxID.ONE);
            populateCombobox(cboProductsEdit, CBOBoxID.TWO);
        }

        private enum CBOBoxID {ONE, TWO, THREE, FOUR, FIVE, SIX};
        private void initDBTab()
        {
            populateCombobox(cboProductsEdit, CBOBoxID.TWO);
            populateCombobox(cboDBCustomers, CBOBoxID.THREE);
            enableShippingInput();
        }

        private void populateCombobox(ComboBox comboBox, CBOBoxID cboID)
        {
            comboBox.Items.Clear();
            
            switch(cboID)
            {
                case CBOBoxID.ONE:
                    productDict = DatabaseManager.getDBProducts();
                    foreach (KeyValuePair<int, List<object>> entry in productDict)
                        comboBox.Items.Insert(entry.Key, entry.Value[0].ToString());

                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                    break;
                case CBOBoxID.TWO:
                    productDict = DatabaseManager.getDBProducts();
                    foreach (KeyValuePair<int, List<object>> entry in productDict)
                        comboBox.Items.Insert(entry.Key, entry.Value[0].ToString());

                    if (cboProductsEdit.Items.Count > 0)
                    {
                        comboBox.SelectedIndex = 0;
                        txtDBPartName.Text = comboBox.Text;
                        txtDBPartDesc.Text = DatabaseManager.getProductDescription(comboBox.Text);
                        mskTxtDBPrice.Text = DatabaseManager.getProductPrice(comboBox.Text).ToString();
                    }
                    break;
                case CBOBoxID.THREE:
                    customerDict = DatabaseManager.getDBCustomers();
                    foreach (KeyValuePair<int, Customer> entry in customerDict)
                        comboBox.Items.Insert(entry.Key, entry.Value.companyName);
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                    break;
            }
        }

        private void InitQuoteListView()
        {
            ColumnHeader header = new ColumnHeader();
            header.Text = "PN";
            header.Width = 100;
            header.TextAlign = HorizontalAlignment.Center;
            lstVwQuote.Columns.Add(header);

            header = new ColumnHeader();
            header.Text = "Description";
            header.Width = 250;
            header.TextAlign = HorizontalAlignment.Left;
            lstVwQuote.Columns.Add(header);

            header = new ColumnHeader();
            header.Text = "Price";
            header.Width = 50;
            header.TextAlign = HorizontalAlignment.Left;
            lstVwQuote.Columns.Add(header);

            header = new ColumnHeader();
            header.Text = "Qty";
            header.Width = 35;
            header.TextAlign = HorizontalAlignment.Center;
            lstVwQuote.Columns.Add(header);

            header = new ColumnHeader();
            header.Text = "Ext Price";
            header.Width = 60;
            header.TextAlign = HorizontalAlignment.Left;
            lstVwQuote.Columns.Add(header);

            lstVwQuote.FullRowSelect = true;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (!productDict.ContainsKey(cboProducts.SelectedIndex))
                return;
            string partName = productDict[cboProducts.SelectedIndex][0].ToString();
            var item = lstVwQuote.FindItemWithText(partName.ToString());

            if (item != null)
                lstVwQuote.Items.Remove(item);

            double price = Convert.ToDouble(productDict[cboProducts.SelectedIndex][2]); //price
            decimal qty = numericUpDown.Value;
            double extendedPrice = price * (double)qty;

            ListViewItem lstVwItm = new ListViewItem(partName); //name
            lstVwItm.SubItems.Add(productDict[cboProducts.SelectedIndex][1].ToString()); //description
            lstVwItm.SubItems.Add(string.Format("{0}{1}", "$", price.ToString()));
            lstVwItm.SubItems.Add(qty.ToString());
            lstVwItm.SubItems.Add(string.Format("{0}{1}", "$", extendedPrice.ToString()));
            lstVwQuote.Items.Add(lstVwItm);

            numericUpDown.Value = 1;

            if (lstVwQuote.Items.Count > 0)
            {
                if (grpShipping.Enabled == false)
                    grpShipping.Enabled = true;
                if (grpDiscount.Enabled == false)
                    grpDiscount.Enabled = true;
                if (grpPayType.Enabled == false)
                    grpPayType.Enabled = true;
            }
            updateSubtotal();
            cboProducts.Focus();
        }

        private void updateSubtotal()
        {
            double subtotal = 0;
            double parseValue;
            if (lstVwQuote.Items.Count > 0)
            {
                foreach (ListViewItem column in lstVwQuote.Items)
                {
                    Double.TryParse(column.SubItems[4].Text.Replace("$", String.Empty), out parseValue);
                    subtotal += parseValue;
                }
            }
            mskTxtSubtotal.Text = subtotal.ToString();
        }

        private void updateTotal()
        {
            double parseValue = 0;
            double total = 0;

            Double.TryParse(mskTxtSubtotal.Text.Replace("$", String.Empty), out parseValue);
            total += parseValue;
            Double.TryParse(mskTxtDiscountTotal.Text.Replace("$", String.Empty), out parseValue);
            total -= parseValue;
            Double.TryParse(mskTxtShipCostTotal.Text.Replace("$", String.Empty), out parseValue);
            total += parseValue;
            Double.TryParse(mskTxtTransFee.Text.Replace("$", String.Empty), out parseValue);
            total += parseValue;

            mskTxtTotal.Mask = Configure_Mask(total.ToString());
            mskTxtTotal.Text = total.ToString();
        }

        private void lstVwQuote_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = lstVwQuote.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (lstVwQuote.SelectedIndices.Count > 0)
            {
                int itemIndex = lstVwQuote.SelectedIndices[0];
                lstVwQuote.Items.RemoveAt(itemIndex);
            }
            
            if (lstVwQuote.Items.Count == 0)
            {
                grpShipping.Enabled = false;
                grpDiscount.Enabled = false;
                btnGenQuote.Enabled = false;
                mskTxtDiscount.Text = "0";
                mskTxtDiscountTotal.Text = "0";
                mskTxtShipCost.Text = "0";
                mskTxtShipCostTotal.Text = "0";
                mskTxtTransFee.Text = "0";
                mskTxtTotal.Text = "0";
                chkDiscPercent.Checked = false;
                grpPayType.Enabled = false;
            }

            updateSubtotal();
        }

        private void chkDiscPercent_CheckedChanged(object sender, EventArgs e)
        {
            if (mskTxtDiscount.Mask == "$9999")
                mskTxtDiscount.Mask = "%9999";
            else
                mskTxtDiscount.Mask = "$9999";
        }

        private void mskTxtShipCost_TextChanged(object sender, EventArgs e)
        {
            mskTxtShipCostTotal.Text = mskTxtShipCost.Text;
        }

        private void mskTxtDiscount_TextChanged(object sender, EventArgs e)
        {
            double discount = 0;
            if (chkDiscPercent.Checked)
            {
                double subtotal, percentDiscount;
                Double.TryParse(mskTxtSubtotal.Text.Replace("$", String.Empty), out subtotal);
                Double.TryParse(mskTxtDiscount.Text.Replace("%", String.Empty), out percentDiscount);
                discount = subtotal * (percentDiscount/100);
                discountCalc = "*" + (percentDiscount / 100).ToString();
            }
            else
            {
                Double.TryParse(mskTxtDiscount.Text.Replace("$", String.Empty), out discount);
                discountCalc = discount.ToString();
            }

            mskTxtDiscountTotal.Mask = Configure_Mask(discount.ToString());
            mskTxtDiscountTotal.Text = discount.ToString();
        }

        private string Configure_Mask(string valToMask)
        {
            string[] splitStr = valToMask.Split('.');
            string mask = "$";

            for (int i = 0; i < splitStr[0].Length; i++)
            {
                mask += "9";
            }

            mask += ".00";
            return mask;
        }

        private void mskTxtDiscount_MouseClick(object sender, MouseEventArgs e)
        {
            mskTxtDiscount.Select(mskTxtDiscount.Text.Length, 0);
        }

        private void mskTxtShipCost_MouseClick(object sender, MouseEventArgs e)
        {
            mskTxtShipCost.Select(mskTxtShipCost.Text.Length, 0);
        }

        private void updateTransactionFee()
        {
            double transFee = 0;
            double runningTotal = 0;
            double parseValue = 0;

            Double.TryParse(mskTxtSubtotal.Text.Replace("$", String.Empty), out parseValue);
            runningTotal += parseValue;
            Double.TryParse(mskTxtShipCostTotal.Text.Replace("$", String.Empty), out parseValue);
            runningTotal += parseValue;
            Double.TryParse(mskTxtDiscountTotal.Text.Replace("$", String.Empty), out parseValue);
            runningTotal -= parseValue;

            if (rdoPayBank.Checked)
            {
                transFee = 35.00;
                transFeeCalc = transFee.ToString();
            }
            else if (rdoPayPal.Checked)
            {
                if (rdoDomestic.Checked)
                {
                    transFee = runningTotal * 0.03;
                    transFeeCalc = "*0.03";
                }
                else
                {
                    transFee = runningTotal * 0.05;
                    transFeeCalc = "*0.05";
                }
            }

            string mask = Configure_Mask(transFee.ToString());
            mskTxtTransFee.Mask = mask;
            mskTxtTransFee.Text = transFee.ToString();
            updateTotal();
        }

        private void mskTxtSubtotal_TextChanged(object sender, EventArgs e)
        {
            updateTransactionFee();
        }

        private void mskTxtDiscountTotal_TextChanged(object sender, EventArgs e)
        {
            updateTransactionFee();
        }

        private void mskTxtShipCostTotal_TextChanged(object sender, EventArgs e)
        {
            updateTransactionFee();
        }

        private void rdoDomestic_CheckedChanged(object sender, EventArgs e)
        {
            updateTransactionFee();
        }

        private void rdoIntl_CheckedChanged(object sender, EventArgs e)
        {
            updateTransactionFee();
        }

        private void btnGenQuote_Click(object sender, EventArgs e)
        {
            if (rdoExcelSheet.Checked)
            {
                if (fileClosed(filePath))
                    exportQuoteToExcel();
                else
                    MessageBox.Show("Quote File is Currently Opened\n Close the file and try again", "Failed",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (rdoInvoice.Checked)
            {

            }
            else if (rdoPackingList.Checked)
            {

            }
        }

        private bool fileClosed(string fileName)
        {
            FileStream stream = null;

            if (!File.Exists(filePath))
                return true;
            try
            {
                stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
                stream.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void mskTxtTotal_TextChanged(object sender, EventArgs e)
        {
            double shipCost = 0;
            Double.TryParse(mskTxtShipCostTotal.Text.Replace("$", String.Empty), out shipCost);
            if (shipCost > 0)
                btnGenQuote.Enabled = true;
        }

        private void rdoPayPal_CheckedChanged(object sender, EventArgs e)
        {
            updateTransactionFee();
        }

        private void rdoPayCheck_CheckedChanged(object sender, EventArgs e)
        {
            updateTransactionFee();
        }

        private void rdoPayBank_CheckedChanged(object sender, EventArgs e)
        {
           updateTransactionFee();
        }

        private void exportQuoteToExcel()
        {
            QuoteWorksheetBuilder wsBuilder = new QuoteWorksheetBuilder(mskTxtDiscountTotal, mskTxtShipCostTotal, rdoPayBank, rdoPayPal);

            wsBuilder.insertHeader(lstVwQuote);
            wsBuilder.insertProductRows(lstVwQuote);
            wsBuilder.insertSubtotalRow(lblSubTotal);
            wsBuilder.insertDiscountRow(lblDiscount, mskTxtDiscountTotal, chkDiscPercent, discountCalc);
            wsBuilder.insertShippingRow(lblShippingCost, mskTxtShipCostTotal);
            wsBuilder.insertTransactionFeeRow(rdoPayCheck, lblTransFee, mskTxtTransFee, transFeeCalc);
            wsBuilder.insertTotalRow(lblTotal);
            wsBuilder.saveExcelFile(filePath);         
        }

        private void btnMoveItemUp_Click(object sender, EventArgs e)
        {
            if (lstVwQuote.SelectedIndices.Count > 0)
            {
                foreach (ListViewItem product in lstVwQuote.Items)
                {
                    int idx = product.Index - 1;
                    if (product.Selected && product.Index > 0)
                    {
                        lstVwQuote.Items.RemoveAt(product.Index);
                        lstVwQuote.Items.Insert(idx, product);
                    }
                }
            }
        }

        private void btnMoveItemDown_Click(object sender, EventArgs e)
        {
            if (lstVwQuote.SelectedIndices.Count > 0)
            {
                foreach (ListViewItem product in lstVwQuote.Items)
                {
                    int idx = product.Index + 1;
                    if (product.Selected && product.Index < lstVwQuote.Items.Count - 1)
                    {
                        lstVwQuote.Items.RemoveAt(product.Index);
                        lstVwQuote.Items.Insert(idx, product);
                    }
                }
            }
        }

        private void lstVwQuote_SelectedIndexChanged(object sender, EventArgs e)
        {
            string partName = "";
            if (lstVwQuote.SelectedIndices.Count > 0)
            {
                int itemIndex = lstVwQuote.SelectedIndices[0];
                partName = lstVwQuote.Items[itemIndex].SubItems[0].Text;
            }
            int prodID = DatabaseManager.getProductIndex(partName);
            if (prodID >= 0)
                cboProducts.SelectedIndex = prodID;
        }

        private void cboProductsEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboProducts.SelectedIndex = cboProductsEdit.SelectedIndex;

            if (cboProductsEdit.SelectedIndex >= 0) 
            {
                txtDBPartName.Text = cboProductsEdit.Text;
                txtDBPartDesc.Text = DatabaseManager.getProductDescription(cboProductsEdit.Text);
                mskTxtDBPrice.Text = DatabaseManager.getProductPrice(cboProductsEdit.Text).ToString();
            }
        }

        private void btnDBActions_Click(object sender, EventArgs e)
        {
            string partName = txtDBPartName.Text;
            string partDesc = txtDBPartDesc.Text;
            double partPrice = 0.0;
            Double.TryParse(mskTxtDBPrice.Text.Replace("$", String.Empty), out partPrice);
            bool activeBit = false;

            if (rdoDBAdd.Checked) 
                activeBit = true;

            if (rdoDBRemove.Checked)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item from database?", "Warning",
                                                       MessageBoxButtons.YesNo, MessageBoxIcon.Information, 
                                                       MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    DatabaseManager.removePart(partName);
                    DatabaseManager.insertPart(partName, partDesc, partPrice);
                    activeBit = false;
                }
                else
                    return;
            }

            DatabaseManager.updatePart(partName, partDesc, partPrice, activeBit);
            refreshComboboxes();

            initDBTab();
            initQuoteTab();
        }

        private void enableShippingInput()
        {
            bool boxChecked = !chkSameAsBilling.Checked;
            txtShipCoName.Enabled = boxChecked;
            txtShipAddr1.Enabled = boxChecked;
            txtShipAddr2.Enabled = boxChecked;
            txtShipCity.Enabled = boxChecked;
            txtShipState.Enabled = boxChecked;
            txtShipZip.Enabled = boxChecked;
            txtShipCountry.Enabled = boxChecked;
            txtShipPhoneNumber.Enabled = boxChecked;
        }

        private void chkSameAsBilling_CheckedChanged(object sender, EventArgs e)
        {
            enableShippingInput();
        }
    }
}
