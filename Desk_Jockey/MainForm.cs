using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DeskJockey
{
    public partial class MainForm : Form
    {
        DatabaseManager dbMngr = new DatabaseManager();
        private List<Product> rsProduct = null;
        private Product selectedProduct = null;
        private List<Customer> rsCustomer = null;
        private Customer selectedCustomer = null;
        private static string folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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
            //dbMngr = new DatabaseManager();
            populateFormFromCombobox(cboProducts, CBOBoxID.ONE);
            populateFormFromCombobox(cboCustomers, CBOBoxID.THREE);
            grpShipping.Enabled = false;
            grpDiscount.Enabled = false;
            btnGenerate.Enabled = false;
            txtTrackNum.Enabled = false;
            grpPayType.Enabled = false;
            btnMoveItemUp.Text = ((char)0x25B2).ToString();
            btnMoveItemDown.Text = ((char)0x25BC).ToString();
            dteShipDate.Format = DateTimePickerFormat.Custom;
            dteShipDate.CustomFormat = "MM/dd/yyyy";
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
            if ((comboBox.SelectedItem == null) || (!rsCustomer.Exists(customer => customer.companyName == comboBox.SelectedItem.ToString())))
            {
                selectedCustomer = new Customer();
                selectedCustomer.billAddress = new BillAddress();
                selectedCustomer.shipAddress = new ShipAddress();
                return;
            }
            selectedCustomer = rsCustomer.Find(customer => customer.companyName == comboBox.SelectedItem.ToString());
        }

        private void getSelectedProduct(ComboBox comboBox)
        {
            if ((comboBox.SelectedItem == null) || (!rsProduct.Exists(product => product.name == comboBox.SelectedItem.ToString())))
            {
                selectedProduct = new Product();
                return;
            }
            selectedProduct = rsProduct.Find(product => product.name == comboBox.SelectedItem.ToString());
        }

        private void populateFormFromCombobox(ComboBox comboBox, CBOBoxID cboID)
        {
            int i = 0;
            comboBox.Items.Clear();
            comboBox.Items.Insert(i++, "");

            switch (cboID)
            {
                case CBOBoxID.ONE:
                    rsProduct = dbMngr.products;
                    //getSelectedProduct(comboBox);
                    foreach (var product in rsProduct)
                    {
                        if (product.active)
                            comboBox.Items.Insert(i++, product.name);
                    }

                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 1;
                    break;
                case CBOBoxID.TWO:
                    rsProduct = dbMngr.products;
                    //getSelectedProduct(comboBox);
                    foreach (var product in rsProduct)
                    {
                        if (product.active)
                            comboBox.Items.Insert(i++, product.name);
                    }

                    if (cboProductsEdit.Items.Count > 0)
                    {
                        comboBox.SelectedIndex = 1;
                        txtDBPartName.Text = selectedProduct.name;
                        txtDBPartDesc.Text = selectedProduct.description;
                        mskTxtDBPrice.Text = selectedProduct.price.ToString();
                    }
                    break;
                case CBOBoxID.THREE:
                    rsCustomer = dbMngr.customers;
                    //getSelectedCustomer(comboBox);
                    foreach (var customer in rsCustomer)
                    {
                        if (customer.active)
                            comboBox.Items.Insert(i++, customer.companyName);
                    }

                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 1;
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
            var item = lstVwQuote.FindItemWithText(selectedProduct.name);

            if (item != null)
                lstVwQuote.Items.Remove(item);

            double price = selectedProduct.price;
            decimal qty = numericUpDown.Value;
            double extendedPrice = price * (double)qty;

            ListViewItem lstVwItm = new ListViewItem(selectedProduct.name);
            lstVwItm.SubItems.Add(selectedProduct.description);
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
                mskTxtDiscount.Text = "0";
                mskTxtDiscountTotal.Text = "0";
                mskTxtShipCost.Text = "0";
                mskTxtShipCostTotal.Text = "0";
                mskTxtTransFee.Text = "0";
                mskTxtTotal.Text = "0";
                chkDiscPercent.Checked = false;
                grpPayType.Enabled = false;

                btnGenerate.Enabled = rdoQuote.Checked ? false : true;
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
                discount = subtotal * (percentDiscount / 100);
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
                mask += "9";

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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (rdoQuote.Checked)
            {
                string filePath = System.IO.Path.Combine(folder, "Quote.xlsx");
                if (fileAvailable(filePath))
                    exportQuoteToExcel(filePath);                    
            }
            else if (rdoInvoice.Checked)
            {
                string filePath = System.IO.Path.Combine(folder, "InvoiceTemplate.xlsx");
                if (fileAvailable(filePath) && checkUserInput())
                    createExcelInvoice(filePath);
            }
            else if (rdoPackingList.Checked)
            {
                string filePath = System.IO.Path.Combine(folder, "PackListTemplate.xlsx");
                if (fileAvailable(filePath) && checkUserInput())
                    createExcelPackList(filePath);
            }
        }

        private void createExcelPackList(string filePath)
        {
            throw new NotImplementedException();
        }

        private bool checkUserInput()
        {
            string result = "";

            if (cboCustomers.SelectedIndex <= 0)
                result = "Customer ";
            else if (string.IsNullOrWhiteSpace(txtPONum.Text))
                result = "PO Number ";
            else if (string.IsNullOrWhiteSpace(txtShipVia.Text))
                result = "Ship Via ";
            else if (string.IsNullOrWhiteSpace(txtTrackNum.Text))
                result = "Tracking # ";
            else if (lstVwQuote.Items.Count == 0)
                result = "Parts List ";

            if (result != "")
            {
                MessageBox.Show("  Error: " + result + "entry not valid. \n Re-enter information and try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private string buildBillAddressString(BillAddress address)
        {
            StringBuilder output = new StringBuilder();

            output.Append(address.contactName + '\n');
            output.Append(address.addr1 + '\n');
            if (address.addr2.Trim() != "")
                output.Append(address.addr2 + '\n');
            output.Append(address.city + ", ");
            output.Append(address.state + " ");
            output.Append(address.zip + '\n');
            output.Append(address.phoneNo);

            return output.ToString();
        }

        private string buildShipAddressString(ShipAddress address)
        {
            StringBuilder output = new StringBuilder();

            output.Append(address.contactName + '\n');
            output.Append(address.addr1 + '\n');
            if(address.addr2.Trim() != "")
                output.Append(address.addr2 + '\n');
            output.Append(address.city + ", ");
            output.Append(address.state + " ");
            output.Append(address.zip + '\n');
            output.Append(address.phoneNo);

            return output.ToString();
        }

        private void createExcelInvoice(string templateFilePath)
        {
            int nextInvoiceNum = DatabaseManager.getNextInvoiceNumber();
            string companyName = cboCustomers.SelectedItem.ToString();

            dteShipDate.Format = DateTimePickerFormat.Custom;
            //dteShipDate.CustomFormat = "yyyy-MM-dd hh:mm:ss";

            getSelectedCustomer(cboDBCustomers);
            string billAddr = buildBillAddressString(selectedCustomer.billAddress);
            string shipAddr = buildShipAddressString(selectedCustomer.shipAddress);

            mskTxtCustomerID.Text = selectedCustomer.customerID.ToString();

            InvoiceWorksheetBuilder invoiceWksht = new InvoiceWorksheetBuilder(templateFilePath);
            invoiceWksht.insertCellData(lstVwQuote, dteShipDate.Text, txtShipVia.Text, txtTrackNum.Text, txtPONum.Text, nextInvoiceNum, selectedCustomer.payTerms, billAddr, shipAddr);

            string outFileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), companyName + "-" + nextInvoiceNum + ".xlsx");
            invoiceWksht.saveExcelFile(outFileName);
        }

        private bool fileAvailable(string filePath)
        {
            bool result = true;
            FileStream stream = null;

            if (!File.Exists(filePath) && (rdoInvoice.Checked || rdoPackingList.Checked))
                result = false;

            if (!result && rdoInvoice.Checked)
            {
                MessageBox.Show("  Error: missing InvoiceTemplate.xlsx,\n Make sure file is in the proper directory", "Failed",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!result && rdoPackingList.Checked)
            {
                MessageBox.Show("  Error: missing PackListTemplate.xlsx,\n Make sure file is in the proper directory", "Failed",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!File.Exists(filePath))
                    result = true;
                else
                {
                    try
                    {
                        stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                        stream.Close();
                        result = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("  File is currently opened,\n close the file and try again", "Failed",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                        result = false;
                    }
                }
            }

            return result;
        }

        private void mskTxtTotal_TextChanged(object sender, EventArgs e)
        {
            double shipCost = 0;
            Double.TryParse(mskTxtShipCostTotal.Text.Replace("$", String.Empty), out shipCost);
            if (shipCost > 0)
                btnGenerate.Enabled = true;
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

        private void exportQuoteToExcel(string filePath)
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
        }

        private void cboProductsEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            getSelectedProduct(cboProductsEdit);
            cboProducts.SelectedIndex = cboProductsEdit.SelectedIndex;

            if (cboProductsEdit.SelectedIndex > 0)
            {
                txtDBPartName.Text = selectedProduct.name;
                txtDBPartDesc.Text = selectedProduct.description;
                mskTxtDBPrice.Text = selectedProduct.price.ToString();
            }
        }

        private void btnDBActions_Click(object sender, EventArgs e)
        {
            if (rdoDBAdd.Checked)
            {
                string partName = txtDBPartName.Text;
                string partDesc = txtDBPartDesc.Text;
                double partPrice = 0.0;
                Double.TryParse(mskTxtDBPrice.Text.Replace("$", String.Empty), out partPrice);

                Product newProduct = new Product(0, partName, partDesc, partPrice);
                dbMngr.insertPart(newProduct);
            }

            if (rdoDBRemove.Checked)
            {
                getSelectedProduct(cboProductsEdit);

                string msg = string.Format("Are you sure you want to delete \"{0}\" from the database?", selectedProduct.name);
                DialogResult result = MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                    dbMngr.removePart(selectedProduct);
                else
                    return;
            }

            initDBTab();
            initQuoteTab();
        }

        private void partInputChecks()
        {
            btnDBActions.Enabled = (string.IsNullOrWhiteSpace(txtDBPartName.Text) || string.IsNullOrWhiteSpace(txtDBPartDesc.Text)) ? false : true;
        }

        private void txtDBPartName_TextChanged(object sender, EventArgs e)
        {
            if (rdoDBAdd.Checked)
                partInputChecks();
        }

        private void txtDBPartDesc_TextChanged(object sender, EventArgs e)
        {
            if (rdoDBAdd.Checked)
                partInputChecks();
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
            txtShipCoName.Text = selectedCustomer.shipAddress.contactName;
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

            txtBillCoName.Text = selectedCustomer.billAddress.contactName;
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
            dteShipDate.Enabled = true;
            txtShipVia.Enabled = true;
            btnGenerate.Enabled = true;
            txtTrackNum.Enabled = true;
        }

        private void rdoPackingList_CheckedChanged(object sender, EventArgs e)
        {
            txtPONum.Enabled = true;
            cboCustomers.Enabled = true;
            dteShipDate.Enabled = true;
            txtShipVia.Enabled = true;
            btnGenerate.Enabled = true;
            txtTrackNum.Enabled = true;
        }

        private void rdoQuote_CheckedChanged(object sender, EventArgs e)
        {
            txtPONum.Enabled = false;
            cboCustomers.Enabled = false;
            dteShipDate.Enabled = false;
            txtShipVia.Enabled = false;
            btnGenerate.Enabled = false;
            txtTrackNum.Enabled = false;
        }

        private void rdoDBRemove_CheckedChanged(object sender, EventArgs e)
        {
            btnDBActions.Enabled = true;
        }

        private void rdoDBAdd_CheckedChanged(object sender, EventArgs e)
        {
            btnDBActions.Enabled = false;
            partInputChecks();
        }

        private void rdoAddCustomer_CheckedChanged(object sender, EventArgs e)
        {
            btnCustomerSubmit.Enabled = false;
            customerInputChecks();
        }

        private void rdoRemoveCustomer_CheckedChanged(object sender, EventArgs e)
        {
            btnCustomerSubmit.Enabled = true;
        }

        private void btnCustomerSubmit_Click(object sender, EventArgs e)
        {
            if (rdoAddCustomer.Checked)
            {
                int customerID = 0;
                Int32.TryParse(mskTxtCustomerID.Text, out customerID);
                Customer newCustomer = new Customer(customerID, cboDBCustomers.Text, /*.SelectedItem.ToString()*/ txtBillPayTerms.Text, chkSameAsBilling.Checked);
                newCustomer.billAddress = new BillAddress(customerID, txtBillCoName.Text, txtBillAddr1.Text, txtBillAddr2.Text, txtBillCity.Text, txtBillState.Text, txtBillZip.Text, txtBillCountry.Text, txtBillPhoneNumber.Text);
                newCustomer.shipAddress = new ShipAddress(newCustomer.billAddress);

                if (!chkSameAsBilling.Checked)
                {
                    newCustomer.shipAddress = new ShipAddress(customerID, txtShipCoName.Text, txtShipAddr1.Text, txtShipAddr2.Text, txtShipCity.Text, txtShipState.Text, txtShipZip.Text, txtShipCountry.Text, txtShipPhoneNumber.Text);
                    newCustomer.addressSame = false;
                }

                dbMngr.insertCustomer(newCustomer);
            }

            if (rdoRemoveCustomer.Checked)
            {
                getSelectedCustomer(cboDBCustomers);

                string msg = string.Format("Are you sure you want to delete \"{0}\" from the database?", selectedCustomer.companyName);
                DialogResult result = MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                    dbMngr.removeCustomer(selectedCustomer);
                else
                    return;
            }

            initDBTab();
            initQuoteTab();
        }

        private void customerInputChecks()
        {
            btnCustomerSubmit.Enabled = false;

            if (string.IsNullOrWhiteSpace(mskTxtCustomerID.Text) || string.IsNullOrWhiteSpace(txtBillCoName.Text) ||
                string.IsNullOrWhiteSpace(txtBillAddr1.Text) || string.IsNullOrWhiteSpace(txtBillCity.Text) ||
                string.IsNullOrWhiteSpace(txtBillState.Text) || string.IsNullOrWhiteSpace(txtBillZip.Text) ||
                string.IsNullOrWhiteSpace(txtBillCountry.Text) || string.IsNullOrWhiteSpace(txtBillPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(txtBillPayTerms.Text))
                return;
            if (!chkSameAsBilling.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtShipCoName.Text) || string.IsNullOrWhiteSpace(txtShipAddr1.Text) ||
                    string.IsNullOrWhiteSpace(txtShipCity.Text) || string.IsNullOrWhiteSpace(txtShipState.Text) ||
                    string.IsNullOrWhiteSpace(txtShipZip.Text) || string.IsNullOrWhiteSpace(txtShipCountry.Text))
                    return;
            }
            btnCustomerSubmit.Enabled = true;
        }

        private void txtBillCoName_TextChanged(object sender, EventArgs e)
        {
            if (rdoAddCustomer.Checked)
                customerInputChecks();
        }

        private void txtBillAddr1_TextChanged(object sender, EventArgs e)
        {
            if (rdoAddCustomer.Checked)
                customerInputChecks();
        }

        private void txtBillCity_TextChanged(object sender, EventArgs e)
        {
            if (rdoAddCustomer.Checked)
                customerInputChecks();
        }

        private void txtBillState_TextChanged(object sender, EventArgs e)
        {
            if (rdoAddCustomer.Checked)
                customerInputChecks();
        }

        private void txtBillZip_TextChanged(object sender, EventArgs e)
        {
            if (rdoAddCustomer.Checked)
                customerInputChecks();
        }

        private void txtBillCountry_TextChanged(object sender, EventArgs e)
        {
            if (rdoAddCustomer.Checked)
                customerInputChecks();
        }

        private void txtBillPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (rdoAddCustomer.Checked)
                customerInputChecks();
        }

        private void txtBillPayTerms_TextChanged(object sender, EventArgs e)
        {
            if (rdoAddCustomer.Checked)
                customerInputChecks();
        }

        private void txtShipCoName_TextChanged(object sender, EventArgs e)
        {
            if (rdoAddCustomer.Checked)
                customerInputChecks();
        }

        private void txtShipAddr1_TextChanged(object sender, EventArgs e)
        {
            if (rdoAddCustomer.Checked)
                customerInputChecks();
        }

        private void txtShipCity_TextChanged(object sender, EventArgs e)
        {
            if (rdoAddCustomer.Checked)
                customerInputChecks();
        }

        private void txtShipState_TextChanged(object sender, EventArgs e)
        {
            if (rdoAddCustomer.Checked)
                customerInputChecks();
        }

        private void txtShipZip_TextChanged(object sender, EventArgs e)
        {
            if (rdoAddCustomer.Checked)
                customerInputChecks();
        }

        private void txtShipCountry_TextChanged(object sender, EventArgs e)
        {
            if (rdoAddCustomer.Checked)
                customerInputChecks();
        }

        private void mskTxtCustomerID_TextChanged(object sender, EventArgs e)
        {
            if (rdoAddCustomer.Checked)
                customerInputChecks();
        }
    }
}
