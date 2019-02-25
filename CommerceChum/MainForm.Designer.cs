using System;

namespace CommerceChum
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabDatabase = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSameAsBilling = new System.Windows.Forms.CheckBox();
            this.lblShipPhoneNumber = new System.Windows.Forms.Label();
            this.txtShipPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblShipCoName = new System.Windows.Forms.Label();
            this.txtShipCoName = new System.Windows.Forms.TextBox();
            this.lblShipZip = new System.Windows.Forms.Label();
            this.lblShipState = new System.Windows.Forms.Label();
            this.lblShipCountry = new System.Windows.Forms.Label();
            this.lblShipCity = new System.Windows.Forms.Label();
            this.txtShipZip = new System.Windows.Forms.TextBox();
            this.txtShipState = new System.Windows.Forms.TextBox();
            this.txtShipCountry = new System.Windows.Forms.TextBox();
            this.txtShipCity = new System.Windows.Forms.TextBox();
            this.lblShipAddr2 = new System.Windows.Forms.Label();
            this.txtShipAddr2 = new System.Windows.Forms.TextBox();
            this.lblShipAddr1 = new System.Windows.Forms.Label();
            this.txtShipAddr1 = new System.Windows.Forms.TextBox();
            this.grpBillAddr = new System.Windows.Forms.GroupBox();
            this.txtBillContact = new System.Windows.Forms.TextBox();
            this.lblBillContactName = new System.Windows.Forms.Label();
            this.lblBillPayTerms = new System.Windows.Forms.Label();
            this.txtBillPayTerms = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBillPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblCoName1 = new System.Windows.Forms.Label();
            this.txtBillCoName = new System.Windows.Forms.TextBox();
            this.lblBillZip = new System.Windows.Forms.Label();
            this.lblBillState = new System.Windows.Forms.Label();
            this.lblBillCountry = new System.Windows.Forms.Label();
            this.lblBillCity = new System.Windows.Forms.Label();
            this.txtBillZip = new System.Windows.Forms.TextBox();
            this.txtBillState = new System.Windows.Forms.TextBox();
            this.txtBillCountry = new System.Windows.Forms.TextBox();
            this.txtBillCity = new System.Windows.Forms.TextBox();
            this.lblBillAddr2 = new System.Windows.Forms.Label();
            this.txtBillAddr2 = new System.Windows.Forms.TextBox();
            this.lblBillAddr1 = new System.Windows.Forms.Label();
            this.txtBillAddr1 = new System.Windows.Forms.TextBox();
            this.grpCustomers = new System.Windows.Forms.GroupBox();
            this.mskTxtCustomerID = new System.Windows.Forms.MaskedTextBox();
            this.rdoRemoveCustomer = new System.Windows.Forms.RadioButton();
            this.btnCustomerSubmit = new System.Windows.Forms.Button();
            this.rdoAddCustomer = new System.Windows.Forms.RadioButton();
            this.cboDBCustomers = new System.Windows.Forms.ComboBox();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.grpInventoryEdit = new System.Windows.Forms.GroupBox();
            this.rdoDBRemove = new System.Windows.Forms.RadioButton();
            this.rdoDBAdd = new System.Windows.Forms.RadioButton();
            this.btnDBActions = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mskTxtDBPrice = new System.Windows.Forms.MaskedTextBox();
            this.txtDBPartDesc = new System.Windows.Forms.TextBox();
            this.txtDBPartName = new System.Windows.Forms.TextBox();
            this.cboProductsEdit = new System.Windows.Forms.ComboBox();
            this.tabQuote = new System.Windows.Forms.TabPage();
            this.grpOutputSelection = new System.Windows.Forms.GroupBox();
            this.txtTrackNum = new System.Windows.Forms.TextBox();
            this.lblTrackNum = new System.Windows.Forms.Label();
            this.dteShipDate = new System.Windows.Forms.DateTimePicker();
            this.lblShipDate = new System.Windows.Forms.Label();
            this.txtShipVia = new System.Windows.Forms.TextBox();
            this.lblShipVia = new System.Windows.Forms.Label();
            this.lblPONum = new System.Windows.Forms.Label();
            this.txtPONum = new System.Windows.Forms.TextBox();
            this.cboCustomers = new System.Windows.Forms.ComboBox();
            this.rdoQuote = new System.Windows.Forms.RadioButton();
            this.rdoPackingList = new System.Windows.Forms.RadioButton();
            this.rdoInvoice = new System.Windows.Forms.RadioButton();
            this.btnMoveItemDown = new System.Windows.Forms.Button();
            this.btnMoveItemUp = new System.Windows.Forms.Button();
            this.grpPayType = new System.Windows.Forms.GroupBox();
            this.rdoPayPal = new System.Windows.Forms.RadioButton();
            this.rdoPayBank = new System.Windows.Forms.RadioButton();
            this.rdoPayCheck = new System.Windows.Forms.RadioButton();
            this.grpDiscount = new System.Windows.Forms.GroupBox();
            this.chkDiscPercent = new System.Windows.Forms.CheckBox();
            this.mskTxtDiscount = new System.Windows.Forms.MaskedTextBox();
            this.grpProdSelect = new System.Windows.Forms.GroupBox();
            this.cboProducts = new System.Windows.Forms.ComboBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.lblQty = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.grpShipping = new System.Windows.Forms.GroupBox();
            this.rdoIntl = new System.Windows.Forms.RadioButton();
            this.rdoDomestic = new System.Windows.Forms.RadioButton();
            this.mskTxtShipCost = new System.Windows.Forms.MaskedTextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lstVwQuote = new System.Windows.Forms.ListView();
            this.mskTxtTotal = new System.Windows.Forms.MaskedTextBox();
            this.mskTxtShipCostTotal = new System.Windows.Forms.MaskedTextBox();
            this.mskTxtTransFee = new System.Windows.Forms.MaskedTextBox();
            this.mskTxtDiscountTotal = new System.Windows.Forms.MaskedTextBox();
            this.mskTxtSubtotal = new System.Windows.Forms.MaskedTextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblShippingCost = new System.Windows.Forms.Label();
            this.lblTransFee = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.tabFrame = new System.Windows.Forms.TabControl();
            this.chkSpecialPricing = new System.Windows.Forms.CheckBox();
            this.grpSpecialPricing = new System.Windows.Forms.GroupBox();
            this.lblCustIDSpecPrice = new System.Windows.Forms.Label();
            this.mskTxtCustIDSpecPrice = new System.Windows.Forms.MaskedTextBox();
            this.lblPartName = new System.Windows.Forms.Label();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.lblSpecialPrice = new System.Windows.Forms.Label();
            this.mskTextSpecialPrice = new System.Windows.Forms.MaskedTextBox();
            this.btnSpecialPrice = new System.Windows.Forms.Button();
            this.tabDatabase.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpBillAddr.SuspendLayout();
            this.grpCustomers.SuspendLayout();
            this.grpInventoryEdit.SuspendLayout();
            this.tabQuote.SuspendLayout();
            this.grpOutputSelection.SuspendLayout();
            this.grpPayType.SuspendLayout();
            this.grpDiscount.SuspendLayout();
            this.grpProdSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.grpShipping.SuspendLayout();
            this.tabFrame.SuspendLayout();
            this.grpSpecialPricing.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDatabase
            // 
            this.tabDatabase.Controls.Add(this.grpSpecialPricing);
            this.tabDatabase.Controls.Add(this.groupBox1);
            this.tabDatabase.Controls.Add(this.grpBillAddr);
            this.tabDatabase.Controls.Add(this.grpCustomers);
            this.tabDatabase.Controls.Add(this.grpInventoryEdit);
            this.tabDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Size = new System.Drawing.Size(547, 593);
            this.tabDatabase.TabIndex = 2;
            this.tabDatabase.Text = "Database";
            this.tabDatabase.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSameAsBilling);
            this.groupBox1.Controls.Add(this.lblShipPhoneNumber);
            this.groupBox1.Controls.Add(this.txtShipPhoneNumber);
            this.groupBox1.Controls.Add(this.lblShipCoName);
            this.groupBox1.Controls.Add(this.txtShipCoName);
            this.groupBox1.Controls.Add(this.lblShipZip);
            this.groupBox1.Controls.Add(this.lblShipState);
            this.groupBox1.Controls.Add(this.lblShipCountry);
            this.groupBox1.Controls.Add(this.lblShipCity);
            this.groupBox1.Controls.Add(this.txtShipZip);
            this.groupBox1.Controls.Add(this.txtShipState);
            this.groupBox1.Controls.Add(this.txtShipCountry);
            this.groupBox1.Controls.Add(this.txtShipCity);
            this.groupBox1.Controls.Add(this.lblShipAddr2);
            this.groupBox1.Controls.Add(this.txtShipAddr2);
            this.groupBox1.Controls.Add(this.lblShipAddr1);
            this.groupBox1.Controls.Add(this.txtShipAddr1);
            this.groupBox1.Location = new System.Drawing.Point(3, 317);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 132);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shipping Address";
            // 
            // chkSameAsBilling
            // 
            this.chkSameAsBilling.AutoSize = true;
            this.chkSameAsBilling.Checked = true;
            this.chkSameAsBilling.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSameAsBilling.Location = new System.Drawing.Point(12, 19);
            this.chkSameAsBilling.Name = "chkSameAsBilling";
            this.chkSameAsBilling.Size = new System.Drawing.Size(98, 17);
            this.chkSameAsBilling.TabIndex = 24;
            this.chkSameAsBilling.Text = "Same As Billing";
            this.chkSameAsBilling.UseVisualStyleBackColor = true;
            this.chkSameAsBilling.CheckedChanged += new System.EventHandler(this.chkSameAsBilling_CheckedChanged);
            // 
            // lblShipPhoneNumber
            // 
            this.lblShipPhoneNumber.AutoSize = true;
            this.lblShipPhoneNumber.Location = new System.Drawing.Point(359, 83);
            this.lblShipPhoneNumber.Name = "lblShipPhoneNumber";
            this.lblShipPhoneNumber.Size = new System.Drawing.Size(41, 13);
            this.lblShipPhoneNumber.TabIndex = 23;
            this.lblShipPhoneNumber.Text = "Phone:";
            // 
            // txtShipPhoneNumber
            // 
            this.txtShipPhoneNumber.Location = new System.Drawing.Point(352, 99);
            this.txtShipPhoneNumber.Name = "txtShipPhoneNumber";
            this.txtShipPhoneNumber.Size = new System.Drawing.Size(93, 20);
            this.txtShipPhoneNumber.TabIndex = 22;
            // 
            // lblShipCoName
            // 
            this.lblShipCoName.AutoSize = true;
            this.lblShipCoName.Location = new System.Drawing.Point(9, 44);
            this.lblShipCoName.Name = "lblShipCoName";
            this.lblShipCoName.Size = new System.Drawing.Size(85, 13);
            this.lblShipCoName.TabIndex = 21;
            this.lblShipCoName.Text = "Company Name:";
            // 
            // txtShipCoName
            // 
            this.txtShipCoName.Location = new System.Drawing.Point(6, 60);
            this.txtShipCoName.Name = "txtShipCoName";
            this.txtShipCoName.Size = new System.Drawing.Size(162, 20);
            this.txtShipCoName.TabIndex = 20;
            this.txtShipCoName.TextChanged += new System.EventHandler(this.txtShipCoName_TextChanged);
            // 
            // lblShipZip
            // 
            this.lblShipZip.AutoSize = true;
            this.lblShipZip.Location = new System.Drawing.Point(177, 83);
            this.lblShipZip.Name = "lblShipZip";
            this.lblShipZip.Size = new System.Drawing.Size(25, 13);
            this.lblShipZip.TabIndex = 14;
            this.lblShipZip.Text = "Zip:";
            // 
            // lblShipState
            // 
            this.lblShipState.AutoSize = true;
            this.lblShipState.Location = new System.Drawing.Point(93, 83);
            this.lblShipState.Name = "lblShipState";
            this.lblShipState.Size = new System.Drawing.Size(35, 13);
            this.lblShipState.TabIndex = 15;
            this.lblShipState.Text = "State:";
            // 
            // lblShipCountry
            // 
            this.lblShipCountry.AutoSize = true;
            this.lblShipCountry.Location = new System.Drawing.Point(243, 83);
            this.lblShipCountry.Name = "lblShipCountry";
            this.lblShipCountry.Size = new System.Drawing.Size(46, 13);
            this.lblShipCountry.TabIndex = 16;
            this.lblShipCountry.Text = "Country:";
            // 
            // lblShipCity
            // 
            this.lblShipCity.AutoSize = true;
            this.lblShipCity.Location = new System.Drawing.Point(9, 83);
            this.lblShipCity.Name = "lblShipCity";
            this.lblShipCity.Size = new System.Drawing.Size(27, 13);
            this.lblShipCity.TabIndex = 17;
            this.lblShipCity.Text = "City:";
            // 
            // txtShipZip
            // 
            this.txtShipZip.Location = new System.Drawing.Point(174, 99);
            this.txtShipZip.Name = "txtShipZip";
            this.txtShipZip.Size = new System.Drawing.Size(60, 20);
            this.txtShipZip.TabIndex = 8;
            this.txtShipZip.TextChanged += new System.EventHandler(this.txtShipZip_TextChanged);
            // 
            // txtShipState
            // 
            this.txtShipState.Location = new System.Drawing.Point(90, 99);
            this.txtShipState.Name = "txtShipState";
            this.txtShipState.Size = new System.Drawing.Size(78, 20);
            this.txtShipState.TabIndex = 9;
            this.txtShipState.TextChanged += new System.EventHandler(this.txtShipState_TextChanged);
            // 
            // txtShipCountry
            // 
            this.txtShipCountry.Location = new System.Drawing.Point(240, 99);
            this.txtShipCountry.Name = "txtShipCountry";
            this.txtShipCountry.Size = new System.Drawing.Size(106, 20);
            this.txtShipCountry.TabIndex = 10;
            this.txtShipCountry.TextChanged += new System.EventHandler(this.txtShipCountry_TextChanged);
            // 
            // txtShipCity
            // 
            this.txtShipCity.Location = new System.Drawing.Point(6, 99);
            this.txtShipCity.Name = "txtShipCity";
            this.txtShipCity.Size = new System.Drawing.Size(78, 20);
            this.txtShipCity.TabIndex = 11;
            this.txtShipCity.TextChanged += new System.EventHandler(this.txtShipCity_TextChanged);
            // 
            // lblShipAddr2
            // 
            this.lblShipAddr2.AutoSize = true;
            this.lblShipAddr2.Location = new System.Drawing.Point(354, 44);
            this.lblShipAddr2.Name = "lblShipAddr2";
            this.lblShipAddr2.Size = new System.Drawing.Size(57, 13);
            this.lblShipAddr2.TabIndex = 18;
            this.lblShipAddr2.Text = "Address 2:";
            // 
            // txtShipAddr2
            // 
            this.txtShipAddr2.Location = new System.Drawing.Point(351, 60);
            this.txtShipAddr2.Name = "txtShipAddr2";
            this.txtShipAddr2.Size = new System.Drawing.Size(185, 20);
            this.txtShipAddr2.TabIndex = 12;
            // 
            // lblShipAddr1
            // 
            this.lblShipAddr1.AutoSize = true;
            this.lblShipAddr1.Location = new System.Drawing.Point(177, 44);
            this.lblShipAddr1.Name = "lblShipAddr1";
            this.lblShipAddr1.Size = new System.Drawing.Size(57, 13);
            this.lblShipAddr1.TabIndex = 19;
            this.lblShipAddr1.Text = "Address 1:";
            // 
            // txtShipAddr1
            // 
            this.txtShipAddr1.Location = new System.Drawing.Point(174, 60);
            this.txtShipAddr1.Name = "txtShipAddr1";
            this.txtShipAddr1.Size = new System.Drawing.Size(171, 20);
            this.txtShipAddr1.TabIndex = 13;
            this.txtShipAddr1.TextChanged += new System.EventHandler(this.txtShipAddr1_TextChanged);
            // 
            // grpBillAddr
            // 
            this.grpBillAddr.Controls.Add(this.chkSpecialPricing);
            this.grpBillAddr.Controls.Add(this.txtBillContact);
            this.grpBillAddr.Controls.Add(this.lblBillContactName);
            this.grpBillAddr.Controls.Add(this.lblBillPayTerms);
            this.grpBillAddr.Controls.Add(this.txtBillPayTerms);
            this.grpBillAddr.Controls.Add(this.label4);
            this.grpBillAddr.Controls.Add(this.txtBillPhoneNumber);
            this.grpBillAddr.Controls.Add(this.lblCoName1);
            this.grpBillAddr.Controls.Add(this.txtBillCoName);
            this.grpBillAddr.Controls.Add(this.lblBillZip);
            this.grpBillAddr.Controls.Add(this.lblBillState);
            this.grpBillAddr.Controls.Add(this.lblBillCountry);
            this.grpBillAddr.Controls.Add(this.lblBillCity);
            this.grpBillAddr.Controls.Add(this.txtBillZip);
            this.grpBillAddr.Controls.Add(this.txtBillState);
            this.grpBillAddr.Controls.Add(this.txtBillCountry);
            this.grpBillAddr.Controls.Add(this.txtBillCity);
            this.grpBillAddr.Controls.Add(this.lblBillAddr2);
            this.grpBillAddr.Controls.Add(this.txtBillAddr2);
            this.grpBillAddr.Controls.Add(this.lblBillAddr1);
            this.grpBillAddr.Controls.Add(this.txtBillAddr1);
            this.grpBillAddr.Location = new System.Drawing.Point(3, 161);
            this.grpBillAddr.Name = "grpBillAddr";
            this.grpBillAddr.Size = new System.Drawing.Size(541, 150);
            this.grpBillAddr.TabIndex = 2;
            this.grpBillAddr.TabStop = false;
            this.grpBillAddr.Text = "Billing Address";
            // 
            // txtBillContact
            // 
            this.txtBillContact.Location = new System.Drawing.Point(7, 40);
            this.txtBillContact.Name = "txtBillContact";
            this.txtBillContact.Size = new System.Drawing.Size(162, 20);
            this.txtBillContact.TabIndex = 25;
            // 
            // lblBillContactName
            // 
            this.lblBillContactName.AutoSize = true;
            this.lblBillContactName.Location = new System.Drawing.Point(7, 24);
            this.lblBillContactName.Name = "lblBillContactName";
            this.lblBillContactName.Size = new System.Drawing.Size(78, 13);
            this.lblBillContactName.TabIndex = 24;
            this.lblBillContactName.Text = "Contact Name:";
            // 
            // lblBillPayTerms
            // 
            this.lblBillPayTerms.AutoSize = true;
            this.lblBillPayTerms.Location = new System.Drawing.Point(352, 24);
            this.lblBillPayTerms.Name = "lblBillPayTerms";
            this.lblBillPayTerms.Size = new System.Drawing.Size(60, 13);
            this.lblBillPayTerms.TabIndex = 23;
            this.lblBillPayTerms.Text = "Pay Terms:";
            // 
            // txtBillPayTerms
            // 
            this.txtBillPayTerms.Location = new System.Drawing.Point(345, 40);
            this.txtBillPayTerms.Name = "txtBillPayTerms";
            this.txtBillPayTerms.Size = new System.Drawing.Size(86, 20);
            this.txtBillPayTerms.TabIndex = 22;
            this.txtBillPayTerms.TextChanged += new System.EventHandler(this.txtBillPayTerms_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Phone:";
            // 
            // txtBillPhoneNumber
            // 
            this.txtBillPhoneNumber.Location = new System.Drawing.Point(351, 121);
            this.txtBillPhoneNumber.Name = "txtBillPhoneNumber";
            this.txtBillPhoneNumber.Size = new System.Drawing.Size(94, 20);
            this.txtBillPhoneNumber.TabIndex = 22;
            this.txtBillPhoneNumber.TextChanged += new System.EventHandler(this.txtBillPhoneNumber_TextChanged);
            // 
            // lblCoName1
            // 
            this.lblCoName1.AutoSize = true;
            this.lblCoName1.Location = new System.Drawing.Point(179, 24);
            this.lblCoName1.Name = "lblCoName1";
            this.lblCoName1.Size = new System.Drawing.Size(85, 13);
            this.lblCoName1.TabIndex = 21;
            this.lblCoName1.Text = "Company Name:";
            // 
            // txtBillCoName
            // 
            this.txtBillCoName.Location = new System.Drawing.Point(176, 40);
            this.txtBillCoName.Name = "txtBillCoName";
            this.txtBillCoName.Size = new System.Drawing.Size(162, 20);
            this.txtBillCoName.TabIndex = 20;
            this.txtBillCoName.TextChanged += new System.EventHandler(this.txtBillCoName_TextChanged);
            // 
            // lblBillZip
            // 
            this.lblBillZip.AutoSize = true;
            this.lblBillZip.Location = new System.Drawing.Point(177, 105);
            this.lblBillZip.Name = "lblBillZip";
            this.lblBillZip.Size = new System.Drawing.Size(25, 13);
            this.lblBillZip.TabIndex = 14;
            this.lblBillZip.Text = "Zip:";
            // 
            // lblBillState
            // 
            this.lblBillState.AutoSize = true;
            this.lblBillState.Location = new System.Drawing.Point(93, 105);
            this.lblBillState.Name = "lblBillState";
            this.lblBillState.Size = new System.Drawing.Size(35, 13);
            this.lblBillState.TabIndex = 15;
            this.lblBillState.Text = "State:";
            // 
            // lblBillCountry
            // 
            this.lblBillCountry.AutoSize = true;
            this.lblBillCountry.Location = new System.Drawing.Point(243, 105);
            this.lblBillCountry.Name = "lblBillCountry";
            this.lblBillCountry.Size = new System.Drawing.Size(46, 13);
            this.lblBillCountry.TabIndex = 16;
            this.lblBillCountry.Text = "Country:";
            // 
            // lblBillCity
            // 
            this.lblBillCity.AutoSize = true;
            this.lblBillCity.Location = new System.Drawing.Point(9, 105);
            this.lblBillCity.Name = "lblBillCity";
            this.lblBillCity.Size = new System.Drawing.Size(27, 13);
            this.lblBillCity.TabIndex = 17;
            this.lblBillCity.Text = "City:";
            // 
            // txtBillZip
            // 
            this.txtBillZip.Location = new System.Drawing.Point(174, 121);
            this.txtBillZip.Name = "txtBillZip";
            this.txtBillZip.Size = new System.Drawing.Size(60, 20);
            this.txtBillZip.TabIndex = 8;
            this.txtBillZip.TextChanged += new System.EventHandler(this.txtBillZip_TextChanged);
            // 
            // txtBillState
            // 
            this.txtBillState.Location = new System.Drawing.Point(90, 121);
            this.txtBillState.Name = "txtBillState";
            this.txtBillState.Size = new System.Drawing.Size(78, 20);
            this.txtBillState.TabIndex = 9;
            this.txtBillState.TextChanged += new System.EventHandler(this.txtBillState_TextChanged);
            // 
            // txtBillCountry
            // 
            this.txtBillCountry.Location = new System.Drawing.Point(240, 121);
            this.txtBillCountry.Name = "txtBillCountry";
            this.txtBillCountry.Size = new System.Drawing.Size(106, 20);
            this.txtBillCountry.TabIndex = 10;
            this.txtBillCountry.TextChanged += new System.EventHandler(this.txtBillCountry_TextChanged);
            // 
            // txtBillCity
            // 
            this.txtBillCity.Location = new System.Drawing.Point(6, 121);
            this.txtBillCity.Name = "txtBillCity";
            this.txtBillCity.Size = new System.Drawing.Size(78, 20);
            this.txtBillCity.TabIndex = 11;
            this.txtBillCity.TextChanged += new System.EventHandler(this.txtBillCity_TextChanged);
            // 
            // lblBillAddr2
            // 
            this.lblBillAddr2.AutoSize = true;
            this.lblBillAddr2.Location = new System.Drawing.Point(187, 65);
            this.lblBillAddr2.Name = "lblBillAddr2";
            this.lblBillAddr2.Size = new System.Drawing.Size(57, 13);
            this.lblBillAddr2.TabIndex = 18;
            this.lblBillAddr2.Text = "Address 2:";
            // 
            // txtBillAddr2
            // 
            this.txtBillAddr2.Location = new System.Drawing.Point(184, 81);
            this.txtBillAddr2.Name = "txtBillAddr2";
            this.txtBillAddr2.Size = new System.Drawing.Size(184, 20);
            this.txtBillAddr2.TabIndex = 12;
            // 
            // lblBillAddr1
            // 
            this.lblBillAddr1.AutoSize = true;
            this.lblBillAddr1.Location = new System.Drawing.Point(10, 65);
            this.lblBillAddr1.Name = "lblBillAddr1";
            this.lblBillAddr1.Size = new System.Drawing.Size(57, 13);
            this.lblBillAddr1.TabIndex = 19;
            this.lblBillAddr1.Text = "Address 1:";
            // 
            // txtBillAddr1
            // 
            this.txtBillAddr1.Location = new System.Drawing.Point(7, 81);
            this.txtBillAddr1.Name = "txtBillAddr1";
            this.txtBillAddr1.Size = new System.Drawing.Size(171, 20);
            this.txtBillAddr1.TabIndex = 13;
            this.txtBillAddr1.TextChanged += new System.EventHandler(this.txtBillAddr1_TextChanged);
            // 
            // grpCustomers
            // 
            this.grpCustomers.Controls.Add(this.mskTxtCustomerID);
            this.grpCustomers.Controls.Add(this.rdoRemoveCustomer);
            this.grpCustomers.Controls.Add(this.btnCustomerSubmit);
            this.grpCustomers.Controls.Add(this.rdoAddCustomer);
            this.grpCustomers.Controls.Add(this.cboDBCustomers);
            this.grpCustomers.Controls.Add(this.lblCustomerID);
            this.grpCustomers.Location = new System.Drawing.Point(3, 102);
            this.grpCustomers.Name = "grpCustomers";
            this.grpCustomers.Size = new System.Drawing.Size(541, 55);
            this.grpCustomers.TabIndex = 1;
            this.grpCustomers.TabStop = false;
            this.grpCustomers.Text = "Customers";
            // 
            // mskTxtCustomerID
            // 
            this.mskTxtCustomerID.Location = new System.Drawing.Point(249, 19);
            this.mskTxtCustomerID.Mask = "99999";
            this.mskTxtCustomerID.Name = "mskTxtCustomerID";
            this.mskTxtCustomerID.PromptChar = ' ';
            this.mskTxtCustomerID.Size = new System.Drawing.Size(58, 20);
            this.mskTxtCustomerID.TabIndex = 16;
            this.mskTxtCustomerID.TextChanged += new System.EventHandler(this.mskTxtCustomerID_TextChanged);
            // 
            // rdoRemoveCustomer
            // 
            this.rdoRemoveCustomer.AutoSize = true;
            this.rdoRemoveCustomer.Location = new System.Drawing.Point(392, 20);
            this.rdoRemoveCustomer.Name = "rdoRemoveCustomer";
            this.rdoRemoveCustomer.Size = new System.Drawing.Size(65, 17);
            this.rdoRemoveCustomer.TabIndex = 3;
            this.rdoRemoveCustomer.Text = "Remove";
            this.rdoRemoveCustomer.UseVisualStyleBackColor = true;
            this.rdoRemoveCustomer.CheckedChanged += new System.EventHandler(this.rdoRemoveCustomer_CheckedChanged);
            // 
            // btnCustomerSubmit
            // 
            this.btnCustomerSubmit.Location = new System.Drawing.Point(460, 17);
            this.btnCustomerSubmit.Name = "btnCustomerSubmit";
            this.btnCustomerSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnCustomerSubmit.TabIndex = 14;
            this.btnCustomerSubmit.Text = "Submit";
            this.btnCustomerSubmit.UseVisualStyleBackColor = true;
            this.btnCustomerSubmit.Click += new System.EventHandler(this.btnCustomerSubmit_Click);
            // 
            // rdoAddCustomer
            // 
            this.rdoAddCustomer.AutoSize = true;
            this.rdoAddCustomer.Checked = true;
            this.rdoAddCustomer.Location = new System.Drawing.Point(319, 20);
            this.rdoAddCustomer.Name = "rdoAddCustomer";
            this.rdoAddCustomer.Size = new System.Drawing.Size(67, 17);
            this.rdoAddCustomer.TabIndex = 1;
            this.rdoAddCustomer.TabStop = true;
            this.rdoAddCustomer.Text = "Add/Edit";
            this.rdoAddCustomer.UseVisualStyleBackColor = true;
            this.rdoAddCustomer.CheckedChanged += new System.EventHandler(this.rdoAddCustomer_CheckedChanged);
            // 
            // cboDBCustomers
            // 
            this.cboDBCustomers.FormattingEnabled = true;
            this.cboDBCustomers.Location = new System.Drawing.Point(6, 19);
            this.cboDBCustomers.Name = "cboDBCustomers";
            this.cboDBCustomers.Size = new System.Drawing.Size(210, 21);
            this.cboDBCustomers.TabIndex = 0;
            this.cboDBCustomers.SelectedIndexChanged += new System.EventHandler(this.cboDBCustomers_SelectedIndexChanged);
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(222, 22);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(21, 13);
            this.lblCustomerID.TabIndex = 15;
            this.lblCustomerID.Text = "ID:";
            // 
            // grpInventoryEdit
            // 
            this.grpInventoryEdit.Controls.Add(this.rdoDBRemove);
            this.grpInventoryEdit.Controls.Add(this.rdoDBAdd);
            this.grpInventoryEdit.Controls.Add(this.btnDBActions);
            this.grpInventoryEdit.Controls.Add(this.label3);
            this.grpInventoryEdit.Controls.Add(this.label2);
            this.grpInventoryEdit.Controls.Add(this.label1);
            this.grpInventoryEdit.Controls.Add(this.mskTxtDBPrice);
            this.grpInventoryEdit.Controls.Add(this.txtDBPartDesc);
            this.grpInventoryEdit.Controls.Add(this.txtDBPartName);
            this.grpInventoryEdit.Controls.Add(this.cboProductsEdit);
            this.grpInventoryEdit.Location = new System.Drawing.Point(3, 8);
            this.grpInventoryEdit.Name = "grpInventoryEdit";
            this.grpInventoryEdit.Size = new System.Drawing.Size(541, 88);
            this.grpInventoryEdit.TabIndex = 0;
            this.grpInventoryEdit.TabStop = false;
            this.grpInventoryEdit.Text = "Inventory";
            // 
            // rdoDBRemove
            // 
            this.rdoDBRemove.AutoSize = true;
            this.rdoDBRemove.Location = new System.Drawing.Point(352, 20);
            this.rdoDBRemove.Name = "rdoDBRemove";
            this.rdoDBRemove.Size = new System.Drawing.Size(65, 17);
            this.rdoDBRemove.TabIndex = 17;
            this.rdoDBRemove.Text = "Remove";
            this.rdoDBRemove.UseVisualStyleBackColor = true;
            this.rdoDBRemove.CheckedChanged += new System.EventHandler(this.rdoDBRemove_CheckedChanged);
            // 
            // rdoDBAdd
            // 
            this.rdoDBAdd.AutoSize = true;
            this.rdoDBAdd.Checked = true;
            this.rdoDBAdd.Location = new System.Drawing.Point(279, 20);
            this.rdoDBAdd.Name = "rdoDBAdd";
            this.rdoDBAdd.Size = new System.Drawing.Size(67, 17);
            this.rdoDBAdd.TabIndex = 15;
            this.rdoDBAdd.TabStop = true;
            this.rdoDBAdd.Text = "Add/Edit";
            this.rdoDBAdd.UseVisualStyleBackColor = true;
            this.rdoDBAdd.CheckedChanged += new System.EventHandler(this.rdoDBAdd_CheckedChanged);
            // 
            // btnDBActions
            // 
            this.btnDBActions.Location = new System.Drawing.Point(460, 57);
            this.btnDBActions.Name = "btnDBActions";
            this.btnDBActions.Size = new System.Drawing.Size(75, 23);
            this.btnDBActions.TabIndex = 14;
            this.btnDBActions.Text = "Submit";
            this.btnDBActions.UseVisualStyleBackColor = true;
            this.btnDBActions.Click += new System.EventHandler(this.btnDBActions_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(404, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Name";
            // 
            // mskTxtDBPrice
            // 
            this.mskTxtDBPrice.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mskTxtDBPrice.Location = new System.Drawing.Point(407, 59);
            this.mskTxtDBPrice.Mask = "$9999";
            this.mskTxtDBPrice.Name = "mskTxtDBPrice";
            this.mskTxtDBPrice.PromptChar = ' ';
            this.mskTxtDBPrice.Size = new System.Drawing.Size(50, 20);
            this.mskTxtDBPrice.TabIndex = 10;
            this.mskTxtDBPrice.Text = "0";
            // 
            // txtDBPartDesc
            // 
            this.txtDBPartDesc.Location = new System.Drawing.Point(112, 59);
            this.txtDBPartDesc.Name = "txtDBPartDesc";
            this.txtDBPartDesc.Size = new System.Drawing.Size(289, 20);
            this.txtDBPartDesc.TabIndex = 3;
            this.txtDBPartDesc.TextChanged += new System.EventHandler(this.txtDBPartDesc_TextChanged);
            // 
            // txtDBPartName
            // 
            this.txtDBPartName.Location = new System.Drawing.Point(6, 59);
            this.txtDBPartName.Name = "txtDBPartName";
            this.txtDBPartName.Size = new System.Drawing.Size(100, 20);
            this.txtDBPartName.TabIndex = 2;
            this.txtDBPartName.TextChanged += new System.EventHandler(this.txtDBPartName_TextChanged);
            // 
            // cboProductsEdit
            // 
            this.cboProductsEdit.FormattingEnabled = true;
            this.cboProductsEdit.Location = new System.Drawing.Point(6, 19);
            this.cboProductsEdit.Name = "cboProductsEdit";
            this.cboProductsEdit.Size = new System.Drawing.Size(257, 21);
            this.cboProductsEdit.TabIndex = 1;
            this.cboProductsEdit.SelectedIndexChanged += new System.EventHandler(this.cboProductsEdit_SelectedIndexChanged);
            // 
            // tabQuote
            // 
            this.tabQuote.Controls.Add(this.grpOutputSelection);
            this.tabQuote.Controls.Add(this.btnMoveItemDown);
            this.tabQuote.Controls.Add(this.btnMoveItemUp);
            this.tabQuote.Controls.Add(this.grpPayType);
            this.tabQuote.Controls.Add(this.grpDiscount);
            this.tabQuote.Controls.Add(this.grpProdSelect);
            this.tabQuote.Controls.Add(this.grpShipping);
            this.tabQuote.Controls.Add(this.btnGenerate);
            this.tabQuote.Controls.Add(this.lstVwQuote);
            this.tabQuote.Controls.Add(this.mskTxtTotal);
            this.tabQuote.Controls.Add(this.mskTxtShipCostTotal);
            this.tabQuote.Controls.Add(this.mskTxtTransFee);
            this.tabQuote.Controls.Add(this.mskTxtDiscountTotal);
            this.tabQuote.Controls.Add(this.mskTxtSubtotal);
            this.tabQuote.Controls.Add(this.lblDiscount);
            this.tabQuote.Controls.Add(this.lblTotal);
            this.tabQuote.Controls.Add(this.lblShippingCost);
            this.tabQuote.Controls.Add(this.lblTransFee);
            this.tabQuote.Controls.Add(this.lblSubTotal);
            this.tabQuote.Location = new System.Drawing.Point(4, 22);
            this.tabQuote.Name = "tabQuote";
            this.tabQuote.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuote.Size = new System.Drawing.Size(547, 593);
            this.tabQuote.TabIndex = 0;
            this.tabQuote.Text = "Quote";
            this.tabQuote.UseVisualStyleBackColor = true;
            // 
            // grpOutputSelection
            // 
            this.grpOutputSelection.Controls.Add(this.txtTrackNum);
            this.grpOutputSelection.Controls.Add(this.lblTrackNum);
            this.grpOutputSelection.Controls.Add(this.dteShipDate);
            this.grpOutputSelection.Controls.Add(this.lblShipDate);
            this.grpOutputSelection.Controls.Add(this.txtShipVia);
            this.grpOutputSelection.Controls.Add(this.lblShipVia);
            this.grpOutputSelection.Controls.Add(this.lblPONum);
            this.grpOutputSelection.Controls.Add(this.txtPONum);
            this.grpOutputSelection.Controls.Add(this.cboCustomers);
            this.grpOutputSelection.Controls.Add(this.rdoQuote);
            this.grpOutputSelection.Controls.Add(this.rdoPackingList);
            this.grpOutputSelection.Controls.Add(this.rdoInvoice);
            this.grpOutputSelection.Location = new System.Drawing.Point(3, 126);
            this.grpOutputSelection.Name = "grpOutputSelection";
            this.grpOutputSelection.Size = new System.Drawing.Size(538, 89);
            this.grpOutputSelection.TabIndex = 73;
            this.grpOutputSelection.TabStop = false;
            this.grpOutputSelection.Text = "Customer";
            // 
            // txtTrackNum
            // 
            this.txtTrackNum.Location = new System.Drawing.Point(411, 56);
            this.txtTrackNum.Name = "txtTrackNum";
            this.txtTrackNum.Size = new System.Drawing.Size(121, 20);
            this.txtTrackNum.TabIndex = 12;
            // 
            // lblTrackNum
            // 
            this.lblTrackNum.AutoSize = true;
            this.lblTrackNum.Location = new System.Drawing.Point(343, 59);
            this.lblTrackNum.Name = "lblTrackNum";
            this.lblTrackNum.Size = new System.Drawing.Size(62, 13);
            this.lblTrackNum.TabIndex = 11;
            this.lblTrackNum.Text = "Tracking #:";
            // 
            // dteShipDate
            // 
            this.dteShipDate.Enabled = false;
            this.dteShipDate.Location = new System.Drawing.Point(190, 56);
            this.dteShipDate.Name = "dteShipDate";
            this.dteShipDate.Size = new System.Drawing.Size(147, 20);
            this.dteShipDate.TabIndex = 10;
            // 
            // lblShipDate
            // 
            this.lblShipDate.AutoSize = true;
            this.lblShipDate.Location = new System.Drawing.Point(127, 59);
            this.lblShipDate.Name = "lblShipDate";
            this.lblShipDate.Size = new System.Drawing.Size(57, 13);
            this.lblShipDate.TabIndex = 8;
            this.lblShipDate.Text = "Ship Date:";
            // 
            // txtShipVia
            // 
            this.txtShipVia.Enabled = false;
            this.txtShipVia.Location = new System.Drawing.Point(62, 56);
            this.txtShipVia.Name = "txtShipVia";
            this.txtShipVia.Size = new System.Drawing.Size(59, 20);
            this.txtShipVia.TabIndex = 7;
            // 
            // lblShipVia
            // 
            this.lblShipVia.AutoSize = true;
            this.lblShipVia.Location = new System.Drawing.Point(7, 59);
            this.lblShipVia.Name = "lblShipVia";
            this.lblShipVia.Size = new System.Drawing.Size(49, 13);
            this.lblShipVia.TabIndex = 6;
            this.lblShipVia.Text = "Ship Via:";
            // 
            // lblPONum
            // 
            this.lblPONum.AutoSize = true;
            this.lblPONum.Location = new System.Drawing.Point(436, 22);
            this.lblPONum.Name = "lblPONum";
            this.lblPONum.Size = new System.Drawing.Size(25, 13);
            this.lblPONum.TabIndex = 5;
            this.lblPONum.Text = "PO:";
            // 
            // txtPONum
            // 
            this.txtPONum.Enabled = false;
            this.txtPONum.Location = new System.Drawing.Point(467, 19);
            this.txtPONum.Name = "txtPONum";
            this.txtPONum.Size = new System.Drawing.Size(58, 20);
            this.txtPONum.TabIndex = 4;
            // 
            // cboCustomers
            // 
            this.cboCustomers.Enabled = false;
            this.cboCustomers.FormattingEnabled = true;
            this.cboCustomers.Location = new System.Drawing.Point(6, 19);
            this.cboCustomers.Name = "cboCustomers";
            this.cboCustomers.Size = new System.Drawing.Size(206, 21);
            this.cboCustomers.TabIndex = 3;
            this.cboCustomers.SelectedIndexChanged += new System.EventHandler(this.cboCustomers_SelectedIndexChanged);
            // 
            // rdoQuote
            // 
            this.rdoQuote.AutoSize = true;
            this.rdoQuote.Checked = true;
            this.rdoQuote.Location = new System.Drawing.Point(221, 20);
            this.rdoQuote.Name = "rdoQuote";
            this.rdoQuote.Size = new System.Drawing.Size(54, 17);
            this.rdoQuote.TabIndex = 2;
            this.rdoQuote.TabStop = true;
            this.rdoQuote.Text = "Quote";
            this.rdoQuote.UseVisualStyleBackColor = true;
            this.rdoQuote.CheckedChanged += new System.EventHandler(this.rdoQuote_CheckedChanged);
            // 
            // rdoPackingList
            // 
            this.rdoPackingList.AutoSize = true;
            this.rdoPackingList.Location = new System.Drawing.Point(347, 20);
            this.rdoPackingList.Name = "rdoPackingList";
            this.rdoPackingList.Size = new System.Drawing.Size(83, 17);
            this.rdoPackingList.TabIndex = 1;
            this.rdoPackingList.Text = "Packing List";
            this.rdoPackingList.UseVisualStyleBackColor = true;
            this.rdoPackingList.CheckedChanged += new System.EventHandler(this.rdoPackingList_CheckedChanged);
            // 
            // rdoInvoice
            // 
            this.rdoInvoice.AutoSize = true;
            this.rdoInvoice.Location = new System.Drawing.Point(281, 20);
            this.rdoInvoice.Name = "rdoInvoice";
            this.rdoInvoice.Size = new System.Drawing.Size(60, 17);
            this.rdoInvoice.TabIndex = 0;
            this.rdoInvoice.Text = "Invoice";
            this.rdoInvoice.UseVisualStyleBackColor = true;
            this.rdoInvoice.CheckedChanged += new System.EventHandler(this.rdoInvoice_CheckedChanged);
            // 
            // btnMoveItemDown
            // 
            this.btnMoveItemDown.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveItemDown.Location = new System.Drawing.Point(503, 391);
            this.btnMoveItemDown.Name = "btnMoveItemDown";
            this.btnMoveItemDown.Size = new System.Drawing.Size(36, 38);
            this.btnMoveItemDown.TabIndex = 14;
            this.btnMoveItemDown.UseVisualStyleBackColor = true;
            this.btnMoveItemDown.Click += new System.EventHandler(this.btnMoveItemDown_Click);
            // 
            // btnMoveItemUp
            // 
            this.btnMoveItemUp.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveItemUp.Location = new System.Drawing.Point(503, 221);
            this.btnMoveItemUp.Name = "btnMoveItemUp";
            this.btnMoveItemUp.Size = new System.Drawing.Size(36, 38);
            this.btnMoveItemUp.TabIndex = 13;
            this.btnMoveItemUp.UseVisualStyleBackColor = true;
            this.btnMoveItemUp.Click += new System.EventHandler(this.btnMoveItemUp_Click);
            // 
            // grpPayType
            // 
            this.grpPayType.Controls.Add(this.rdoPayPal);
            this.grpPayType.Controls.Add(this.rdoPayBank);
            this.grpPayType.Controls.Add(this.rdoPayCheck);
            this.grpPayType.Location = new System.Drawing.Point(354, 71);
            this.grpPayType.Name = "grpPayType";
            this.grpPayType.Size = new System.Drawing.Size(185, 49);
            this.grpPayType.TabIndex = 63;
            this.grpPayType.TabStop = false;
            this.grpPayType.Text = "Payment";
            // 
            // rdoPayPal
            // 
            this.rdoPayPal.AutoSize = true;
            this.rdoPayPal.Checked = true;
            this.rdoPayPal.Location = new System.Drawing.Point(6, 21);
            this.rdoPayPal.Name = "rdoPayPal";
            this.rdoPayPal.Size = new System.Drawing.Size(58, 17);
            this.rdoPayPal.TabIndex = 9;
            this.rdoPayPal.TabStop = true;
            this.rdoPayPal.Text = "PayPal";
            this.rdoPayPal.UseVisualStyleBackColor = true;
            this.rdoPayPal.CheckedChanged += new System.EventHandler(this.rdoPayPal_CheckedChanged);
            // 
            // rdoPayBank
            // 
            this.rdoPayBank.AutoSize = true;
            this.rdoPayBank.Location = new System.Drawing.Point(128, 21);
            this.rdoPayBank.Name = "rdoPayBank";
            this.rdoPayBank.Size = new System.Drawing.Size(50, 17);
            this.rdoPayBank.TabIndex = 11;
            this.rdoPayBank.TabStop = true;
            this.rdoPayBank.Text = "Bank";
            this.rdoPayBank.UseVisualStyleBackColor = true;
            this.rdoPayBank.CheckedChanged += new System.EventHandler(this.rdoPayBank_CheckedChanged);
            // 
            // rdoPayCheck
            // 
            this.rdoPayCheck.AutoSize = true;
            this.rdoPayCheck.Location = new System.Drawing.Point(68, 21);
            this.rdoPayCheck.Name = "rdoPayCheck";
            this.rdoPayCheck.Size = new System.Drawing.Size(56, 17);
            this.rdoPayCheck.TabIndex = 10;
            this.rdoPayCheck.TabStop = true;
            this.rdoPayCheck.Text = "Check";
            this.rdoPayCheck.UseVisualStyleBackColor = true;
            this.rdoPayCheck.CheckedChanged += new System.EventHandler(this.rdoPayCheck_CheckedChanged);
            // 
            // grpDiscount
            // 
            this.grpDiscount.Controls.Add(this.chkDiscPercent);
            this.grpDiscount.Controls.Add(this.mskTxtDiscount);
            this.grpDiscount.Location = new System.Drawing.Point(211, 71);
            this.grpDiscount.Name = "grpDiscount";
            this.grpDiscount.Size = new System.Drawing.Size(137, 49);
            this.grpDiscount.TabIndex = 62;
            this.grpDiscount.TabStop = false;
            this.grpDiscount.Text = "Discount";
            // 
            // chkDiscPercent
            // 
            this.chkDiscPercent.AutoSize = true;
            this.chkDiscPercent.Location = new System.Drawing.Point(9, 22);
            this.chkDiscPercent.Name = "chkDiscPercent";
            this.chkDiscPercent.Size = new System.Drawing.Size(63, 17);
            this.chkDiscPercent.TabIndex = 7;
            this.chkDiscPercent.Text = "Percent";
            this.chkDiscPercent.UseVisualStyleBackColor = true;
            this.chkDiscPercent.CheckedChanged += new System.EventHandler(this.chkDiscPercent_CheckedChanged);
            // 
            // mskTxtDiscount
            // 
            this.mskTxtDiscount.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mskTxtDiscount.Location = new System.Drawing.Point(73, 19);
            this.mskTxtDiscount.Mask = "$9999";
            this.mskTxtDiscount.Name = "mskTxtDiscount";
            this.mskTxtDiscount.PromptChar = ' ';
            this.mskTxtDiscount.Size = new System.Drawing.Size(50, 20);
            this.mskTxtDiscount.TabIndex = 8;
            this.mskTxtDiscount.Text = "0";
            this.mskTxtDiscount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mskTxtDiscount_MouseClick);
            this.mskTxtDiscount.TextChanged += new System.EventHandler(this.mskTxtDiscount_TextChanged);
            // 
            // grpProdSelect
            // 
            this.grpProdSelect.Controls.Add(this.cboProducts);
            this.grpProdSelect.Controls.Add(this.btnAddProduct);
            this.grpProdSelect.Controls.Add(this.btnRemoveProduct);
            this.grpProdSelect.Controls.Add(this.lblQty);
            this.grpProdSelect.Controls.Add(this.numericUpDown);
            this.grpProdSelect.Location = new System.Drawing.Point(6, 6);
            this.grpProdSelect.Name = "grpProdSelect";
            this.grpProdSelect.Size = new System.Drawing.Size(533, 59);
            this.grpProdSelect.TabIndex = 60;
            this.grpProdSelect.TabStop = false;
            this.grpProdSelect.Text = "Product Selection";
            // 
            // cboProducts
            // 
            this.cboProducts.FormattingEnabled = true;
            this.cboProducts.Location = new System.Drawing.Point(6, 21);
            this.cboProducts.Name = "cboProducts";
            this.cboProducts.Size = new System.Drawing.Size(267, 21);
            this.cboProducts.TabIndex = 0;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(363, 20);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 23);
            this.btnAddProduct.TabIndex = 2;
            this.btnAddProduct.Text = "Add";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Location = new System.Drawing.Point(449, 20);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveProduct.TabIndex = 3;
            this.btnRemoveProduct.Text = "Remove";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(280, 25);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(26, 13);
            this.lblQty.TabIndex = 3;
            this.lblQty.Text = "Qty:";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(310, 22);
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown.TabIndex = 1;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // grpShipping
            // 
            this.grpShipping.Controls.Add(this.rdoIntl);
            this.grpShipping.Controls.Add(this.rdoDomestic);
            this.grpShipping.Controls.Add(this.mskTxtShipCost);
            this.grpShipping.Location = new System.Drawing.Point(7, 71);
            this.grpShipping.Name = "grpShipping";
            this.grpShipping.Size = new System.Drawing.Size(198, 49);
            this.grpShipping.TabIndex = 61;
            this.grpShipping.TabStop = false;
            this.grpShipping.Text = "Shipping Cost";
            // 
            // rdoIntl
            // 
            this.rdoIntl.AutoSize = true;
            this.rdoIntl.Location = new System.Drawing.Point(52, 23);
            this.rdoIntl.Name = "rdoIntl";
            this.rdoIntl.Size = new System.Drawing.Size(83, 17);
            this.rdoIntl.TabIndex = 5;
            this.rdoIntl.TabStop = true;
            this.rdoIntl.Text = "International";
            this.rdoIntl.UseVisualStyleBackColor = true;
            this.rdoIntl.CheckedChanged += new System.EventHandler(this.rdoIntl_CheckedChanged);
            // 
            // rdoDomestic
            // 
            this.rdoDomestic.AutoSize = true;
            this.rdoDomestic.Checked = true;
            this.rdoDomestic.Location = new System.Drawing.Point(6, 23);
            this.rdoDomestic.Name = "rdoDomestic";
            this.rdoDomestic.Size = new System.Drawing.Size(40, 17);
            this.rdoDomestic.TabIndex = 4;
            this.rdoDomestic.TabStop = true;
            this.rdoDomestic.Text = "US";
            this.rdoDomestic.UseVisualStyleBackColor = true;
            this.rdoDomestic.CheckedChanged += new System.EventHandler(this.rdoDomestic_CheckedChanged);
            // 
            // mskTxtShipCost
            // 
            this.mskTxtShipCost.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mskTxtShipCost.Location = new System.Drawing.Point(141, 21);
            this.mskTxtShipCost.Mask = "$9999";
            this.mskTxtShipCost.Name = "mskTxtShipCost";
            this.mskTxtShipCost.PromptChar = ' ';
            this.mskTxtShipCost.Size = new System.Drawing.Size(50, 20);
            this.mskTxtShipCost.TabIndex = 6;
            this.mskTxtShipCost.Text = "0";
            this.mskTxtShipCost.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mskTxtShipCost_MouseClick);
            this.mskTxtShipCost.TextChanged += new System.EventHandler(this.mskTxtShipCost_TextChanged);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(466, 565);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 15;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lstVwQuote
            // 
            this.lstVwQuote.FullRowSelect = true;
            this.lstVwQuote.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstVwQuote.HideSelection = false;
            this.lstVwQuote.Location = new System.Drawing.Point(7, 221);
            this.lstVwQuote.MultiSelect = false;
            this.lstVwQuote.Name = "lstVwQuote";
            this.lstVwQuote.Scrollable = false;
            this.lstVwQuote.Size = new System.Drawing.Size(485, 207);
            this.lstVwQuote.TabIndex = 12;
            this.lstVwQuote.UseCompatibleStateImageBehavior = false;
            this.lstVwQuote.View = System.Windows.Forms.View.Details;
            this.lstVwQuote.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lstVwQuote_ColumnWidthChanging);
            this.lstVwQuote.SelectedIndexChanged += new System.EventHandler(this.lstVwQuote_SelectedIndexChanged);
            // 
            // mskTxtTotal
            // 
            this.mskTxtTotal.Location = new System.Drawing.Point(477, 539);
            this.mskTxtTotal.Mask = "$99999";
            this.mskTxtTotal.Name = "mskTxtTotal";
            this.mskTxtTotal.ReadOnly = true;
            this.mskTxtTotal.Size = new System.Drawing.Size(64, 20);
            this.mskTxtTotal.TabIndex = 72;
            this.mskTxtTotal.TabStop = false;
            this.mskTxtTotal.Text = "0";
            this.mskTxtTotal.TextChanged += new System.EventHandler(this.mskTxtTotal_TextChanged);
            // 
            // mskTxtShipCostTotal
            // 
            this.mskTxtShipCostTotal.Location = new System.Drawing.Point(477, 487);
            this.mskTxtShipCostTotal.Mask = "$99999";
            this.mskTxtShipCostTotal.Name = "mskTxtShipCostTotal";
            this.mskTxtShipCostTotal.ReadOnly = true;
            this.mskTxtShipCostTotal.Size = new System.Drawing.Size(64, 20);
            this.mskTxtShipCostTotal.TabIndex = 71;
            this.mskTxtShipCostTotal.TabStop = false;
            this.mskTxtShipCostTotal.Text = "0";
            this.mskTxtShipCostTotal.TextChanged += new System.EventHandler(this.mskTxtShipCostTotal_TextChanged);
            // 
            // mskTxtTransFee
            // 
            this.mskTxtTransFee.Location = new System.Drawing.Point(477, 513);
            this.mskTxtTransFee.Mask = "$99999";
            this.mskTxtTransFee.Name = "mskTxtTransFee";
            this.mskTxtTransFee.ReadOnly = true;
            this.mskTxtTransFee.Size = new System.Drawing.Size(64, 20);
            this.mskTxtTransFee.TabIndex = 70;
            this.mskTxtTransFee.TabStop = false;
            this.mskTxtTransFee.Text = "0";
            // 
            // mskTxtDiscountTotal
            // 
            this.mskTxtDiscountTotal.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mskTxtDiscountTotal.Location = new System.Drawing.Point(477, 460);
            this.mskTxtDiscountTotal.Mask = "$99999";
            this.mskTxtDiscountTotal.Name = "mskTxtDiscountTotal";
            this.mskTxtDiscountTotal.ReadOnly = true;
            this.mskTxtDiscountTotal.Size = new System.Drawing.Size(64, 20);
            this.mskTxtDiscountTotal.TabIndex = 69;
            this.mskTxtDiscountTotal.TabStop = false;
            this.mskTxtDiscountTotal.Text = "0";
            this.mskTxtDiscountTotal.TextChanged += new System.EventHandler(this.mskTxtDiscountTotal_TextChanged);
            // 
            // mskTxtSubtotal
            // 
            this.mskTxtSubtotal.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mskTxtSubtotal.Location = new System.Drawing.Point(477, 434);
            this.mskTxtSubtotal.Mask = "$99999";
            this.mskTxtSubtotal.Name = "mskTxtSubtotal";
            this.mskTxtSubtotal.ReadOnly = true;
            this.mskTxtSubtotal.Size = new System.Drawing.Size(64, 20);
            this.mskTxtSubtotal.TabIndex = 68;
            this.mskTxtSubtotal.TabStop = false;
            this.mskTxtSubtotal.Text = "0";
            this.mskTxtSubtotal.TextChanged += new System.EventHandler(this.mskTxtSubtotal_TextChanged);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(412, 464);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(61, 13);
            this.lblDiscount.TabIndex = 67;
            this.lblDiscount.Text = "Discount:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(433, 543);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(40, 13);
            this.lblTotal.TabIndex = 66;
            this.lblTotal.Text = "Total:";
            // 
            // lblShippingCost
            // 
            this.lblShippingCost.AutoSize = true;
            this.lblShippingCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShippingCost.Location = new System.Drawing.Point(413, 490);
            this.lblShippingCost.Name = "lblShippingCost";
            this.lblShippingCost.Size = new System.Drawing.Size(60, 13);
            this.lblShippingCost.TabIndex = 65;
            this.lblShippingCost.Text = "Shipping:";
            // 
            // lblTransFee
            // 
            this.lblTransFee.AutoSize = true;
            this.lblTransFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransFee.Location = new System.Drawing.Point(399, 510);
            this.lblTransFee.Name = "lblTransFee";
            this.lblTransFee.Size = new System.Drawing.Size(74, 26);
            this.lblTransFee.TabIndex = 64;
            this.lblTransFee.Text = "Transaction\r\nFee:";
            this.lblTransFee.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(415, 438);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(58, 13);
            this.lblSubTotal.TabIndex = 63;
            this.lblSubTotal.Text = "Subtotal:";
            // 
            // tabFrame
            // 
            this.tabFrame.Controls.Add(this.tabQuote);
            this.tabFrame.Controls.Add(this.tabDatabase);
            this.tabFrame.Location = new System.Drawing.Point(13, 7);
            this.tabFrame.Name = "tabFrame";
            this.tabFrame.SelectedIndex = 0;
            this.tabFrame.Size = new System.Drawing.Size(555, 619);
            this.tabFrame.TabIndex = 0;
            this.tabFrame.TabStop = false;
            this.tabFrame.Tag = "";
            // 
            // chkSpecialPricing
            // 
            this.chkSpecialPricing.AutoSize = true;
            this.chkSpecialPricing.Location = new System.Drawing.Point(440, 42);
            this.chkSpecialPricing.Name = "chkSpecialPricing";
            this.chkSpecialPricing.Size = new System.Drawing.Size(96, 17);
            this.chkSpecialPricing.TabIndex = 26;
            this.chkSpecialPricing.Text = "Special Pricing";
            this.chkSpecialPricing.UseVisualStyleBackColor = true;
            // 
            // grpSpecialPricing
            // 
            this.grpSpecialPricing.Controls.Add(this.btnSpecialPrice);
            this.grpSpecialPricing.Controls.Add(this.mskTextSpecialPrice);
            this.grpSpecialPricing.Controls.Add(this.lblSpecialPrice);
            this.grpSpecialPricing.Controls.Add(this.txtPartName);
            this.grpSpecialPricing.Controls.Add(this.lblPartName);
            this.grpSpecialPricing.Controls.Add(this.mskTxtCustIDSpecPrice);
            this.grpSpecialPricing.Controls.Add(this.lblCustIDSpecPrice);
            this.grpSpecialPricing.Location = new System.Drawing.Point(3, 455);
            this.grpSpecialPricing.Name = "grpSpecialPricing";
            this.grpSpecialPricing.Size = new System.Drawing.Size(541, 55);
            this.grpSpecialPricing.TabIndex = 3;
            this.grpSpecialPricing.TabStop = false;
            this.grpSpecialPricing.Text = "Special Pricing";
            // 
            // lblCustIDSpecPrice
            // 
            this.lblCustIDSpecPrice.AutoSize = true;
            this.lblCustIDSpecPrice.Location = new System.Drawing.Point(6, 22);
            this.lblCustIDSpecPrice.Name = "lblCustIDSpecPrice";
            this.lblCustIDSpecPrice.Size = new System.Drawing.Size(68, 13);
            this.lblCustIDSpecPrice.TabIndex = 0;
            this.lblCustIDSpecPrice.Text = "Customer ID:";
            // 
            // mskTxtCustIDSpecPrice
            // 
            this.mskTxtCustIDSpecPrice.Location = new System.Drawing.Point(80, 19);
            this.mskTxtCustIDSpecPrice.Mask = "99999";
            this.mskTxtCustIDSpecPrice.Name = "mskTxtCustIDSpecPrice";
            this.mskTxtCustIDSpecPrice.PromptChar = ' ';
            this.mskTxtCustIDSpecPrice.Size = new System.Drawing.Size(58, 20);
            this.mskTxtCustIDSpecPrice.TabIndex = 17;
            // 
            // lblPartName
            // 
            this.lblPartName.AutoSize = true;
            this.lblPartName.Location = new System.Drawing.Point(144, 22);
            this.lblPartName.Name = "lblPartName";
            this.lblPartName.Size = new System.Drawing.Size(60, 13);
            this.lblPartName.TabIndex = 18;
            this.lblPartName.Text = "Part Name:";
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(207, 19);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(100, 20);
            this.txtPartName.TabIndex = 19;
            // 
            // lblSpecialPrice
            // 
            this.lblSpecialPrice.AutoSize = true;
            this.lblSpecialPrice.Location = new System.Drawing.Point(316, 22);
            this.lblSpecialPrice.Name = "lblSpecialPrice";
            this.lblSpecialPrice.Size = new System.Drawing.Size(34, 13);
            this.lblSpecialPrice.TabIndex = 20;
            this.lblSpecialPrice.Text = "Price:";
            // 
            // mskTextSpecialPrice
            // 
            this.mskTextSpecialPrice.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mskTextSpecialPrice.Location = new System.Drawing.Point(351, 19);
            this.mskTextSpecialPrice.Mask = "$9999";
            this.mskTextSpecialPrice.Name = "mskTextSpecialPrice";
            this.mskTextSpecialPrice.PromptChar = ' ';
            this.mskTextSpecialPrice.Size = new System.Drawing.Size(50, 20);
            this.mskTextSpecialPrice.TabIndex = 21;
            this.mskTextSpecialPrice.Text = "0";
            // 
            // btnSpecialPrice
            // 
            this.btnSpecialPrice.Location = new System.Drawing.Point(413, 17);
            this.btnSpecialPrice.Name = "btnSpecialPrice";
            this.btnSpecialPrice.Size = new System.Drawing.Size(75, 23);
            this.btnSpecialPrice.TabIndex = 22;
            this.btnSpecialPrice.Text = "Submit";
            this.btnSpecialPrice.UseVisualStyleBackColor = true;
            this.btnSpecialPrice.Click += new System.EventHandler(this.btnSpecialPrice_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 631);
            this.Controls.Add(this.tabFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desk Jockey";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabDatabase.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpBillAddr.ResumeLayout(false);
            this.grpBillAddr.PerformLayout();
            this.grpCustomers.ResumeLayout(false);
            this.grpCustomers.PerformLayout();
            this.grpInventoryEdit.ResumeLayout(false);
            this.grpInventoryEdit.PerformLayout();
            this.tabQuote.ResumeLayout(false);
            this.tabQuote.PerformLayout();
            this.grpOutputSelection.ResumeLayout(false);
            this.grpOutputSelection.PerformLayout();
            this.grpPayType.ResumeLayout(false);
            this.grpPayType.PerformLayout();
            this.grpDiscount.ResumeLayout(false);
            this.grpDiscount.PerformLayout();
            this.grpProdSelect.ResumeLayout(false);
            this.grpProdSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.grpShipping.ResumeLayout(false);
            this.grpShipping.PerformLayout();
            this.tabFrame.ResumeLayout(false);
            this.grpSpecialPricing.ResumeLayout(false);
            this.grpSpecialPricing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabDatabase;
        private System.Windows.Forms.GroupBox grpInventoryEdit;
        private System.Windows.Forms.RadioButton rdoDBRemove;
        private System.Windows.Forms.RadioButton rdoDBAdd;
        private System.Windows.Forms.Button btnDBActions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mskTxtDBPrice;
        private System.Windows.Forms.TextBox txtDBPartDesc;
        private System.Windows.Forms.TextBox txtDBPartName;
        private System.Windows.Forms.ComboBox cboProductsEdit;
        private System.Windows.Forms.TabPage tabQuote;
        private System.Windows.Forms.Button btnMoveItemDown;
        private System.Windows.Forms.Button btnMoveItemUp;
        private System.Windows.Forms.GroupBox grpPayType;
        private System.Windows.Forms.RadioButton rdoPayPal;
        private System.Windows.Forms.RadioButton rdoPayBank;
        private System.Windows.Forms.RadioButton rdoPayCheck;
        private System.Windows.Forms.MaskedTextBox mskTxtTotal;
        private System.Windows.Forms.MaskedTextBox mskTxtShipCostTotal;
        private System.Windows.Forms.MaskedTextBox mskTxtTransFee;
        private System.Windows.Forms.MaskedTextBox mskTxtDiscountTotal;
        private System.Windows.Forms.MaskedTextBox mskTxtSubtotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblShippingCost;
        private System.Windows.Forms.Label lblTransFee;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.GroupBox grpDiscount;
        private System.Windows.Forms.CheckBox chkDiscPercent;
        private System.Windows.Forms.MaskedTextBox mskTxtDiscount;
        private System.Windows.Forms.GroupBox grpProdSelect;
        private System.Windows.Forms.ComboBox cboProducts;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.GroupBox grpShipping;
        private System.Windows.Forms.RadioButton rdoIntl;
        private System.Windows.Forms.RadioButton rdoDomestic;
        private System.Windows.Forms.MaskedTextBox mskTxtShipCost;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ListView lstVwQuote;
        private System.Windows.Forms.TabControl tabFrame;
        private System.Windows.Forms.GroupBox grpOutputSelection;
        private System.Windows.Forms.RadioButton rdoQuote;
        private System.Windows.Forms.RadioButton rdoPackingList;
        private System.Windows.Forms.RadioButton rdoInvoice;
        private System.Windows.Forms.ComboBox cboCustomers;
        private System.Windows.Forms.GroupBox grpCustomers;
        private System.Windows.Forms.RadioButton rdoRemoveCustomer;
        private System.Windows.Forms.RadioButton rdoAddCustomer;
        private System.Windows.Forms.ComboBox cboDBCustomers;
        private System.Windows.Forms.GroupBox grpBillAddr;
        private System.Windows.Forms.Label lblCoName1;
        private System.Windows.Forms.TextBox txtBillCoName;
        private System.Windows.Forms.Label lblBillZip;
        private System.Windows.Forms.Label lblBillState;
        private System.Windows.Forms.Label lblBillCountry;
        private System.Windows.Forms.Label lblBillCity;
        private System.Windows.Forms.TextBox txtBillZip;
        private System.Windows.Forms.TextBox txtBillState;
        private System.Windows.Forms.TextBox txtBillCountry;
        private System.Windows.Forms.TextBox txtBillCity;
        private System.Windows.Forms.Label lblBillAddr2;
        private System.Windows.Forms.TextBox txtBillAddr2;
        private System.Windows.Forms.Label lblBillAddr1;
        private System.Windows.Forms.TextBox txtBillAddr1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBillPhoneNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblShipPhoneNumber;
        private System.Windows.Forms.TextBox txtShipPhoneNumber;
        private System.Windows.Forms.Label lblShipCoName;
        private System.Windows.Forms.TextBox txtShipCoName;
        private System.Windows.Forms.Label lblShipZip;
        private System.Windows.Forms.Label lblShipState;
        private System.Windows.Forms.Label lblShipCountry;
        private System.Windows.Forms.Label lblShipCity;
        private System.Windows.Forms.TextBox txtShipZip;
        private System.Windows.Forms.TextBox txtShipState;
        private System.Windows.Forms.TextBox txtShipCountry;
        private System.Windows.Forms.TextBox txtShipCity;
        private System.Windows.Forms.Label lblShipAddr2;
        private System.Windows.Forms.TextBox txtShipAddr2;
        private System.Windows.Forms.Label lblShipAddr1;
        private System.Windows.Forms.TextBox txtShipAddr1;
        private System.Windows.Forms.CheckBox chkSameAsBilling;
        private System.Windows.Forms.Button btnCustomerSubmit;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.MaskedTextBox mskTxtCustomerID;
        private System.Windows.Forms.Label lblBillPayTerms;
        private System.Windows.Forms.TextBox txtBillPayTerms;
        private System.Windows.Forms.Label lblPONum;
        private System.Windows.Forms.TextBox txtPONum;
        private System.Windows.Forms.DateTimePicker dteShipDate;
        private System.Windows.Forms.Label lblShipDate;
        private System.Windows.Forms.TextBox txtShipVia;
        private System.Windows.Forms.Label lblShipVia;
        private System.Windows.Forms.TextBox txtTrackNum;
        private System.Windows.Forms.Label lblTrackNum;
        private System.Windows.Forms.TextBox txtBillContact;
        private System.Windows.Forms.Label lblBillContactName;
        private System.Windows.Forms.CheckBox chkSpecialPricing;
        private System.Windows.Forms.GroupBox grpSpecialPricing;
        private System.Windows.Forms.MaskedTextBox mskTxtCustIDSpecPrice;
        private System.Windows.Forms.Label lblCustIDSpecPrice;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.Label lblPartName;
        private System.Windows.Forms.Button btnSpecialPrice;
        private System.Windows.Forms.MaskedTextBox mskTextSpecialPrice;
        private System.Windows.Forms.Label lblSpecialPrice;
    }
}

