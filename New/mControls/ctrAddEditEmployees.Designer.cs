namespace CenterChangesManager.Main.mControls
{
    partial class ctrAddEditEmployees
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            txtFullName = new DevExpress.XtraEditors.TextEdit();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            txtPhone = new DevExpress.XtraEditors.TextEdit();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            cmbCity = new DevExpress.XtraEditors.LookUpEdit();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFullName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPhone.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbCity.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(btnSave);
            layoutControl1.Controls.Add(cmbCity);
            layoutControl1.Controls.Add(txtPhone);
            layoutControl1.Controls.Add(txtFullName);
            layoutControl1.Controls.Add(gridControl1);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Font = new Font("Segoe UI", 12F);
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(477, 513);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5, emptySpaceItem1 });
            Root.Name = "Root";
            Root.Size = new Size(477, 513);
            Root.TextVisible = false;
            // 
            // gridControl1
            // 
            gridControl1.Location = new Point(16, 16);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(445, 321);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gridControl1;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(451, 327);
            layoutControlItem1.TextVisible = false;
            // 
            // txtFullName
            // 
            txtFullName.EditValue = "";
            txtFullName.Location = new Point(16, 343);
            txtFullName.Name = "txtFullName";
            txtFullName.Properties.Appearance.Font = new Font("Segoe UI", 12F);
            txtFullName.Properties.Appearance.Options.UseFont = true;
            txtFullName.Size = new Size(345, 36);
            txtFullName.StyleController = layoutControl1;
            txtFullName.TabIndex = 2;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Segoe UI", 11F);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.Control = txtFullName;
            layoutControlItem2.Location = new Point(0, 327);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(451, 42);
            layoutControlItem2.Text = "الاسم";
            layoutControlItem2.TextSize = new Size(84, 20);
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(16, 385);
            txtPhone.Name = "txtPhone";
            txtPhone.Properties.Appearance.Font = new Font("Segoe UI", 12F);
            txtPhone.Properties.Appearance.Options.UseFont = true;
            txtPhone.Size = new Size(345, 36);
            txtPhone.StyleController = layoutControl1;
            txtPhone.TabIndex = 3;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Font = new Font("Segoe UI", 11F);
            layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem3.Control = txtPhone;
            layoutControlItem3.Location = new Point(0, 369);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(451, 42);
            layoutControlItem3.Text = "الهاتف";
            layoutControlItem3.TextSize = new Size(84, 20);
            // 
            // cmbCity
            // 
            cmbCity.Location = new Point(16, 427);
            cmbCity.Name = "cmbCity";
            cmbCity.Properties.Appearance.Font = new Font("Segoe UI", 12F);
            cmbCity.Properties.Appearance.Options.UseFont = true;
            cmbCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbCity.Size = new Size(345, 36);
            cmbCity.StyleController = layoutControl1;
            cmbCity.TabIndex = 4;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AppearanceItemCaption.Font = new Font("Segoe UI", 11F);
            layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem4.Control = cmbCity;
            layoutControlItem4.Location = new Point(0, 411);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(451, 42);
            layoutControlItem4.Text = "البلد التابع لها";
            layoutControlItem4.TextSize = new Size(84, 20);
            // 
            // btnSave
            // 
            btnSave.Appearance.Font = new Font("Segoe UI", 12F);
            btnSave.Appearance.Options.UseFont = true;
            btnSave.Location = new Point(16, 469);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(219, 28);
            btnSave.StyleController = layoutControl1;
            btnSave.TabIndex = 5;
            btnSave.Text = "حفظ";
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = btnSave;
            layoutControlItem5.Location = new Point(0, 453);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(225, 34);
            layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(225, 453);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(226, 34);
            // 
            // ctrAddEditEmployees
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "ctrAddEditEmployees";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(477, 513);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFullName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPhone.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbCity.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LookUpEdit cmbCity;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
