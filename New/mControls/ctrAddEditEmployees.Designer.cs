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
            components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            cmbCity = new DevExpress.XtraEditors.LookUpEdit();
            txtPhone = new DevExpress.XtraEditors.TextEdit();
            txtFullName = new DevExpress.XtraEditors.TextEdit();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            item0 = new DevExpress.XtraLayout.EmptySpaceItem();
            item1 = new DevExpress.XtraLayout.EmptySpaceItem();
            item2 = new DevExpress.XtraLayout.EmptySpaceItem();
            dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(components);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbCity.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPhone.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFullName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)item0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)item1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)item2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dxValidationProvider1).BeginInit();
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
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(601, 249, 650, 400);
            layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(477, 513);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // btnSave
            // 
            btnSave.Appearance.Font = new Font("Segoe UI", 12F);
            btnSave.Appearance.Options.UseFont = true;
            btnSave.Location = new Point(197, 469);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(57, 28);
            btnSave.StyleController = layoutControl1;
            btnSave.TabIndex = 5;
            btnSave.Text = "حفظ";
            btnSave.Click += btnSave_Click;
            // 
            // cmbCity
            // 
            cmbCity.Location = new Point(197, 427);
            cmbCity.Name = "cmbCity";
            cmbCity.Properties.Appearance.Font = new Font("Segoe UI", 12F);
            cmbCity.Properties.Appearance.Options.UseFont = true;
            cmbCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbCity.Size = new Size(75, 36);
            cmbCity.StyleController = layoutControl1;
            cmbCity.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "يرجى اختيار المدينة";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            dxValidationProvider1.SetValidationRule(cmbCity, conditionValidationRule1);
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(197, 385);
            txtPhone.Name = "txtPhone";
            txtPhone.Properties.Appearance.Font = new Font("Segoe UI", 12F);
            txtPhone.Properties.Appearance.Options.UseFont = true;
            txtPhone.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            txtPhone.Properties.MaskSettings.Set("MaskManagerSignature", "isOptimistic=False");
            txtPhone.Properties.UseMaskAsDisplayFormat = true;
            txtPhone.Size = new Size(75, 36);
            txtPhone.StyleController = layoutControl1;
            txtPhone.TabIndex = 3;
            // 
            // txtFullName
            // 
            txtFullName.EditValue = "";
            txtFullName.Location = new Point(197, 343);
            txtFullName.Name = "txtFullName";
            txtFullName.Properties.Appearance.Font = new Font("Segoe UI", 12F);
            txtFullName.Properties.Appearance.Options.UseFont = true;
            txtFullName.Size = new Size(75, 36);
            txtFullName.StyleController = layoutControl1;
            txtFullName.TabIndex = 2;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "يجب إدخال اسم الموظف";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            dxValidationProvider1.SetValidationRule(txtFullName, conditionValidationRule3);
            // 
            // gridControl1
            // 
            gridControl1.Location = new Point(94, 16);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(278, 321);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.DoubleClick += gridView1_DoubleClick;
            // 
            // Root
            // 
            Root.CustomizationFormText = "Root";
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, emptySpaceItem1, emptySpaceItem2, emptySpaceItem3, emptySpaceItem4, emptySpaceItem5, layoutControlItem5, item0, item1, item2 });
            Root.Name = "Root";
            Root.Size = new Size(477, 513);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gridControl1;
            layoutControlItem1.ControlAlignment = ContentAlignment.TopRight;
            layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            layoutControlItem1.Location = new Point(78, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(284, 327);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Segoe UI", 11F);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.Control = txtFullName;
            layoutControlItem2.ControlAlignment = ContentAlignment.TopRight;
            layoutControlItem2.CustomizationFormText = "الاسم";
            layoutControlItem2.Location = new Point(181, 327);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(181, 42);
            layoutControlItem2.Text = "الاسم";
            layoutControlItem2.TextSize = new Size(84, 20);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Font = new Font("Segoe UI", 11F);
            layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem3.Control = txtPhone;
            layoutControlItem3.ControlAlignment = ContentAlignment.TopRight;
            layoutControlItem3.CustomizationFormText = "الهاتف";
            layoutControlItem3.Location = new Point(181, 369);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(181, 42);
            layoutControlItem3.Text = "الهاتف";
            layoutControlItem3.TextSize = new Size(84, 20);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AppearanceItemCaption.Font = new Font("Segoe UI", 11F);
            layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem4.Control = cmbCity;
            layoutControlItem4.ControlAlignment = ContentAlignment.TopRight;
            layoutControlItem4.CustomizationFormText = "البلد التابع لها";
            layoutControlItem4.Location = new Point(181, 411);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(181, 42);
            layoutControlItem4.Text = "البلد التابع لها";
            layoutControlItem4.TextSize = new Size(84, 20);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            emptySpaceItem1.Location = new Point(244, 453);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(118, 34);
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            emptySpaceItem2.Location = new Point(0, 327);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(181, 42);
            // 
            // emptySpaceItem3
            // 
            emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            emptySpaceItem3.Location = new Point(0, 369);
            emptySpaceItem3.Name = "emptySpaceItem3";
            emptySpaceItem3.Size = new Size(181, 42);
            // 
            // emptySpaceItem4
            // 
            emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            emptySpaceItem4.Location = new Point(0, 411);
            emptySpaceItem4.Name = "emptySpaceItem4";
            emptySpaceItem4.Size = new Size(181, 42);
            // 
            // emptySpaceItem5
            // 
            emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            emptySpaceItem5.Location = new Point(0, 453);
            emptySpaceItem5.Name = "emptySpaceItem5";
            emptySpaceItem5.Size = new Size(181, 34);
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = btnSave;
            layoutControlItem5.ControlAlignment = ContentAlignment.TopRight;
            layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            layoutControlItem5.Location = new Point(181, 453);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(63, 34);
            layoutControlItem5.TextVisible = false;
            // 
            // item0
            // 
            item0.CustomizationFormText = "item0";
            item0.Location = new Point(362, 0);
            item0.Name = "item0";
            item0.Size = new Size(89, 327);
            // 
            // item1
            // 
            item1.CustomizationFormText = "item1";
            item1.Location = new Point(0, 0);
            item1.Name = "item1";
            item1.Size = new Size(78, 327);
            // 
            // item2
            // 
            item2.CustomizationFormText = "item2";
            item2.Location = new Point(362, 327);
            item2.Name = "item2";
            item2.Size = new Size(89, 160);
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
            ((System.ComponentModel.ISupportInitialize)cmbCity.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPhone.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFullName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)item0).EndInit();
            ((System.ComponentModel.ISupportInitialize)item1).EndInit();
            ((System.ComponentModel.ISupportInitialize)item2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dxValidationProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LookUpEdit cmbCity;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem item0;
        private DevExpress.XtraLayout.EmptySpaceItem item1;
        private DevExpress.XtraLayout.EmptySpaceItem item2;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}
