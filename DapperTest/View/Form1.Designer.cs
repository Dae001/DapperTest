namespace DapperTest
{
    partial class Form1
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
            this.btnCustomerID = new DevExpress.XtraEditors.SimpleButton();
            this.txtCustomerID = new DevExpress.XtraEditors.TextEdit();
            this.lblCustomerID = new DevExpress.XtraEditors.LabelControl();
            this.txtCompanyName = new DevExpress.XtraEditors.TextEdit();
            this.btnCustomerAll = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdCusttomer = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblCustname = new DevExpress.XtraEditors.LabelControl();
            this.lblOrderDate = new DevExpress.XtraEditors.LabelControl();
            this.txtOderDate = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCusttomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOderDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCustomerID
            // 
            this.btnCustomerID.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerID.Appearance.Options.UseFont = true;
            this.btnCustomerID.Location = new System.Drawing.Point(471, 67);
            this.btnCustomerID.Name = "btnCustomerID";
            this.btnCustomerID.Size = new System.Drawing.Size(75, 25);
            this.btnCustomerID.TabIndex = 0;
            this.btnCustomerID.Text = "검  색";
            this.btnCustomerID.Click += new System.EventHandler(this.btnCustomerID_Click);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.EditValue = "HANAR";
            this.txtCustomerID.Location = new System.Drawing.Point(81, 38);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.Properties.Appearance.Options.UseFont = true;
            this.txtCustomerID.Size = new System.Drawing.Size(189, 22);
            this.txtCustomerID.TabIndex = 1;
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerID.Appearance.Options.UseFont = true;
            this.lblCustomerID.Location = new System.Drawing.Point(27, 38);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(39, 15);
            this.lblCustomerID.TabIndex = 2;
            this.lblCustomerID.Text = "고객ID:";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.EditValue = "";
            this.txtCompanyName.Location = new System.Drawing.Point(81, 66);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyName.Properties.Appearance.Options.UseFont = true;
            this.txtCompanyName.Size = new System.Drawing.Size(189, 22);
            this.txtCompanyName.TabIndex = 3;
            // 
            // btnCustomerAll
            // 
            this.btnCustomerAll.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerAll.Appearance.Options.UseFont = true;
            this.btnCustomerAll.Location = new System.Drawing.Point(471, 36);
            this.btnCustomerAll.Name = "btnCustomerAll";
            this.btnCustomerAll.Size = new System.Drawing.Size(75, 25);
            this.btnCustomerAll.TabIndex = 0;
            this.btnCustomerAll.Text = "검색 All";
            this.btnCustomerAll.Click += new System.EventHandler(this.btnCustomerAll_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtCustomerID);
            this.groupControl1.Controls.Add(this.txtOderDate);
            this.groupControl1.Controls.Add(this.txtCompanyName);
            this.groupControl1.Controls.Add(this.lblOrderDate);
            this.groupControl1.Controls.Add(this.btnCustomerID);
            this.groupControl1.Controls.Add(this.lblCustname);
            this.groupControl1.Controls.Add(this.lblCustomerID);
            this.groupControl1.Controls.Add(this.btnCustomerAll);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(567, 143);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // grdCusttomer
            // 
            this.grdCusttomer.Location = new System.Drawing.Point(12, 180);
            this.grdCusttomer.MainView = this.gridView1;
            this.grdCusttomer.Name = "grdCusttomer";
            this.grdCusttomer.Size = new System.Drawing.Size(546, 288);
            this.grdCusttomer.TabIndex = 5;
            this.grdCusttomer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdCusttomer;
            this.gridView1.Name = "gridView1";
            // 
            // lblCustname
            // 
            this.lblCustname.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustname.Appearance.Options.UseFont = true;
            this.lblCustname.Location = new System.Drawing.Point(39, 69);
            this.lblCustname.Name = "lblCustname";
            this.lblCustname.Size = new System.Drawing.Size(27, 15);
            this.lblCustname.TabIndex = 2;
            this.lblCustname.Text = "성명:";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDate.Appearance.Options.UseFont = true;
            this.lblOrderDate.Location = new System.Drawing.Point(39, 97);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(27, 15);
            this.lblOrderDate.TabIndex = 2;
            this.lblOrderDate.Text = "날짜:";
            // 
            // txtOderDate
            // 
            this.txtOderDate.EditValue = "1996-07-08";
            this.txtOderDate.Location = new System.Drawing.Point(81, 94);
            this.txtOderDate.Name = "txtOderDate";
            this.txtOderDate.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOderDate.Properties.Appearance.Options.UseFont = true;
            this.txtOderDate.Size = new System.Drawing.Size(189, 22);
            this.txtOderDate.TabIndex = 3;
            // 
            // Form1
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 499);
            this.Controls.Add(this.grdCusttomer);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCusttomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOderDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCustomerID;
        private DevExpress.XtraEditors.TextEdit txtCustomerID;
        private DevExpress.XtraEditors.LabelControl lblCustomerID;
        private DevExpress.XtraEditors.TextEdit txtCompanyName;
        private DevExpress.XtraEditors.SimpleButton btnCustomerAll;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grdCusttomer;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtOderDate;
        private DevExpress.XtraEditors.LabelControl lblOrderDate;
        private DevExpress.XtraEditors.LabelControl lblCustname;
    }
}

