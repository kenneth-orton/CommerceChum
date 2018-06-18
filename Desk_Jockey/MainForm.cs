using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DeskJockey
{
    public partial class MainForm : Form
    {
        private List<Product> rsProduct = null;
        private Product selectedProduct = null;
        private List<Customer> rsCustomer = null;
        private Customer selectedCustomer = null;
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
            populateFormFromCombobox(cboProducts, CBOBoxID.ONE);
            populateFormFromCombobox(cboCustomers, CBOBoxID.THREE);
            grpShipping.Enabled = false;
            grpDiscount.Enabled = false;
            btnGenQuote.Enabled = false;
            grpPayType.Enabled = false;
            btnMoveItemUp.Text = ((char)0x25B2).ToString();
            btnMoveItemDown.Text = ((char)0x25BC).ToString();
        }

        private enum CBOBoxID { ONE, TWO, THREE, FOUR, FIVE, SIX };
        private void initDBTab()
        {
            populateFormFromCombobox(cboProductsEdit, CBOBoxID.TWO);
            populateFormFromCombobox(cboDBCustomers, CBOBoxID.THREE);
            enableShippingInput();
        }

        private void getSelectedCustomer(ComboBox comboBox)
        {
            if (comboBox.SelectedItem == null)
            {
                selectedProduct = null;
                return;
            }
            if (!rsCustomer.Exists(customer => customer.companyName == comboBox.SelectedItem.ToString()))
            {
                selectedProduct = null;
                return;
            }
            selectedCustomer = rsCustomer.Find(customer => customer.companyName == comboBox.SelectedItem.ToString());
        }

        private void getSelectedProduct(ComboBox comboBox)
        {
            if (comboBox.SelectedItem == null)
            {
                selectedCustomer = null;
                return;
            }
            if (!rsProduct.Exists(product => product.productName == comboBox.SelectedItem.ToString()))
            {
                selectedCustomer = null;
                return;
            }
            selectedProduct = rsProduct.Find(product => product.productName == comboBox.SelectedItem.ToString());
        }
        
        private void populateFormFromCombobox(ComboBox comboBox, CBOBoxID cboID)
        {
            comboBox.Items.Clear();

            int i = 0;
            switch (cboID)
            {
                case CBOBoxID.ONE:
                    rsProduct = DatabaseManager.getDBProducts();
                    getSelectedProduct(comboBox);
                    foreach (var product in rsProduct)
                        comboBox.Items.Insert(i++, product.productName);

                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                    break;
                case CBOBoxID.TWO:
                    rsProduct = DatabaseManager.getDBProducts();
                    getSelectedProduct(comboBox);
                    foreach (var product in rsProduct)
                        comboBox.Items.Insert(i++, product.productName);

                    if (cboProductsEdit.Items.Count > 0)
                    {
                        comboBox.SelectedIndex = 0;
                        txtDBPartName.Text = selectedProduct.productName;
                        txtDBPartDesc.Text = selectedProduct.productDescription;
                        mskTxtDBPrice.Text = selectedProduct.price.ToString();
                    }
                    break;
                case CBOBoxID.THREE:
                    rsCustomer = DatabaseManager.getDBCustomers();
                    getSelectedCustomer(comboBox);
                    foreach (var customer in rsCustomer)
                        comboBox.Items.Insert(i++, customer.companyName);

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
            getSelectedProduct(cboProducts);
            var item = lstVwQuote.FindItemWithText(selectedProduct.productName);

            if (item != null)
                lstVwQuote.Items.Remove(item);

            double price = selectedProduct.price;
            decimal qty = numericUpDown.Value;
            double extendedPrice = price * (double)qty;

            ListViewItem lstVwItm = new ListViewItem(selectedProduct.productName); 
            lstVwItm.SubItems.Add(selectedProduct.productDescription);
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
            //int prodID = DatabaseManager.getProductIndex(partName);
            if (!rsProduct.Exists(product => product.productName == partName))
            {
                selectedProduct = null;
                return;
            }
            selectedProduct = rsProduct.Find(product => product.productName == partName);
            if (selectedProduct.productID >= 0)
                cboProducts.SelectedIndex = selectedProduct.productID - 1;
        }

        private void cboProductsEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            getSelectedProduct(cboProductsEdit);
            cboProducts.SelectedIndex = cboProductsEdit.SelectedIndex;
            
            if (cboProductsEdit.SelectedIndex >= 0) 
            {
                txtDBPartName.Text = selectedProduct.productName;
                txtDBPartDesc.Text = selectedProduct.productDescription;
                mskTxtDBPrice.Text = selectedProduct.price.ToString();
            }
        }

        /* TODO: figure out way to insert into result set lists and insert/update database so
           that a remove and add operation is not needed to just update the database item  */
        private void btnDBActions_Click(object sender, EventArgs e)
        {
            getSelectedProduct(cboProductsEdit);

            string partName = txtDBPartName.Text;
            string partDesc = txtDBPartDesc.Text;
            double partPrice = 0.0;
            Double.TryParse(mskTxtDBPrice.Text.Replace("$", String.Empty), out partPrice);

            if (rdoDBAdd.Checked)
            {
                if (!DatabaseManager.partExists(partName)) // new product
                    DatabaseManager.insertPart(partName, partDesc, partPrice);
                else
                {
                    DatabaseManager.removePart(selectedProduct);
                    DatabaseManager.insertPart(partName, partDesc, partPrice);
                }
            }

            if (rdoDBRemove.Checked)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item from database?", "Warning",
                                                       MessageBoxButtons.YesNo, MessageBoxIcon.Information, 
                                                       MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    DatabaseManager.removePart(selectedProduct);
                    DatabaseManager.insertPart(partName, partDesc, partPrice, false);
                }
                else
                    return;
            }
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
            if (chkSameAsBilling.Checked)
                clearShippingAddrInfo();
            else
                addShippingAddrInfo();
        }

        private void clearShippingAddrInfo()
        {
            txtShipCoName.Text = "";
            txtShipAddr1.Text = "";
            txtShipAddr2.Text = "";
            txtShipCity.Text = "";
            txtShipState.Text = "";
            txtShipZip.Text = "";
            txtShipCountry.Text = "";
            txtShipPhoneNumber.Text = "";
        }

        private void addShippingAddrInfo()
        {
            txtShipCoName.Text = selectedCustomer.companyName;
            txtShipAddr1.Text = selectedCustomer.shipAddress.addr1;
            txtShipAddr2.Text = selectedCustomer.shipAddress.addr2;
            txtShipCity.Text = selectedCustomer.shipAddress.city;
            txtShipState.Text = selectedCustomer.shipAddress.state;
            txtShipZip.Text = selectedCustomer.shipAddress.zip;
            txtShipCountry.Text = selectedCustomer.shipAddress.country;
            txtShipPhoneNumber.Text = selectedCustomer.shipAddress.phoneNo;
        }

        private void cboDBCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            getSelectedCustomer(cboDBCustomers);
            mskTxtCustomerID.Text = selectedCustomer.customerID.ToString();

            txtBillCoName.Text = selectedCustomer.companyName;
            txtBillAddr1.Text = selectedCustomer.billAddress.addr1;
            txtBillAddr2.Text = selectedCustomer.billAddress.addr2;
            txtBillCity.Text = selectedCustomer.billAddress.city;
            txtBillState.Text = selectedCustomer.billAddress.state;
            txtBillZip.Text = selectedCustomer.billAddress.zip;
            txtBillCountry.Text = selectedCustomer.billAddress.country;
            txtBillPhoneNumber.Text = selectedCustomer.billAddress.phoneNo;
            txtBillPayTerms.Text = selectedCustomer.payTerms;

            if (selectedCustomer.addressSame)
            {
                chkSameAsBilling.Checked = true;
                clearShippingAddrInfo();
            }
            else
            {
                chkSameAsBilling.Checked = false;
                addShippingAddrInfo();
            }
        }

        private void cboCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            getSelectedCustomer(cboCustomers);
        }

        private void rdoInvoice_CheckedChanged(object sender, EventArgs e)
        {
            txtPONum.Enabled = true;
            cboCustomers.Enabled = true;
        }

        private void rdoPackingList_CheckedChanged(object sender, EventArgs e)
        {
            txtPONum.Enabled = true;
            cboCustomers.Enabled = true;
        }

        private void rdoExcelSheet_CheckedChanged(object sender, EventArgs e)
        {
            txtPONum.Enabled = false;
            cboCustomers.Enabled = false;
        }
    }
}
