namespace CenterChanges
{
    partial class ctrChangeLog
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            colType = new DevExpress.XtraGrid.Columns.GridColumn();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            cmbDependency = new DevExpress.XtraEditors.LookUpEdit();
            cmbVillage = new DevExpress.XtraEditors.LookUpEdit();
            cmbCity = new DevExpress.XtraEditors.LookUpEdit();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colChangeNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCity = new DevExpress.XtraGrid.Columns.GridColumn();
            colVillage = new DevExpress.XtraGrid.Columns.GridColumn();
            colDependency = new DevExpress.XtraGrid.Columns.GridColumn();
            colLatitude = new DevExpress.XtraGrid.Columns.GridColumn();
            colLongitude = new DevExpress.XtraGrid.Columns.GridColumn();
            colOwner = new DevExpress.XtraGrid.Columns.GridColumn();
            colInspector = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbDependency.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbVillage.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbCity.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            SuspendLayout();
            // 
            // colType
            // 
            colType.AppearanceCell.Font = new Font("Segoe UI", 10F);
            colType.AppearanceCell.Options.HighPriority = true;
            colType.AppearanceCell.Options.UseFont = true;
            colType.AppearanceHeader.Font = new Font("Segoe UI", 12F);
            colType.AppearanceHeader.Options.UseFont = true;
            colType.Caption = "نوع المتغير";
            colType.FieldName = "ChangeType";
            colType.Name = "colType";
            colType.Visible = true;
            colType.VisibleIndex = 9;
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(cmbDependency);
            layoutControl1.Controls.Add(cmbVillage);
            layoutControl1.Controls.Add(cmbCity);
            layoutControl1.Controls.Add(gridControl1);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(1270, 723);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // cmbDependency
            // 
            cmbDependency.Location = new Point(16, 16);
            cmbDependency.Name = "cmbDependency";
            cmbDependency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbDependency.Size = new Size(474, 28);
            cmbDependency.StyleController = layoutControl1;
            cmbDependency.TabIndex = 7;
            cmbDependency.EditValueChanged += cmbDependency_EditValueChanged;
            // 
            // cmbVillage
            // 
            cmbVillage.Location = new Point(556, 16);
            cmbVillage.Name = "cmbVillage";
            cmbVillage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbVillage.Size = new Size(270, 28);
            cmbVillage.StyleController = layoutControl1;
            cmbVillage.TabIndex = 6;
            cmbVillage.EditValueChanged += cmbVillage_EditValueChanged;
            // 
            // cmbCity
            // 
            cmbCity.Location = new Point(892, 16);
            cmbCity.Name = "cmbCity";
            cmbCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbCity.Size = new Size(302, 28);
            cmbCity.StyleController = layoutControl1;
            cmbCity.TabIndex = 5;
            cmbCity.EditValueChanged += cmbCity_EditValueChanged;
            // 
            // gridControl1
            // 
            gridControl1.Location = new Point(16, 50);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(1238, 657);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI", 13F);
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.Row.Font = new Font("Segoe UI", 12F);
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colChangeNumber, colDate, colCity, colVillage, colDependency, colLatitude, colLongitude, colOwner, colType, colInspector, colStatus });
            gridFormatRule1.Column = colType;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.PredefinedName = "Green Text";
            formatConditionRuleValue1.Value1 = "قانوني";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.Column = colType;
            gridFormatRule2.ColumnApplyTo = colType;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.PredefinedName = "Red Text";
            formatConditionRuleValue2.Value1 = "غير قانوني";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridView1.FormatRules.Add(gridFormatRule1);
            gridView1.FormatRules.Add(gridFormatRule2);
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            // 
            // colId
            // 
            colId.AppearanceCell.Font = new Font("Segoe UI", 10F);
            colId.AppearanceCell.Options.HighPriority = true;
            colId.AppearanceCell.Options.UseFont = true;
            colId.AppearanceHeader.Font = new Font("Segoe UI", 12F);
            colId.AppearanceHeader.Options.UseFont = true;
            colId.Caption = "م";
            colId.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colId.FieldName = "LogID";
            colId.Name = "colId";
            colId.Visible = true;
            colId.VisibleIndex = 0;
            // 
            // colChangeNumber
            // 
            colChangeNumber.AppearanceCell.Font = new Font("Segoe UI", 10F);
            colChangeNumber.AppearanceCell.Options.HighPriority = true;
            colChangeNumber.AppearanceCell.Options.UseFont = true;
            colChangeNumber.AppearanceHeader.Font = new Font("Segoe UI", 12F);
            colChangeNumber.AppearanceHeader.Options.UseFont = true;
            colChangeNumber.Caption = "رقم المتغير";
            colChangeNumber.FieldName = "ChangeNumber";
            colChangeNumber.Name = "colChangeNumber";
            colChangeNumber.Visible = true;
            colChangeNumber.VisibleIndex = 1;
            // 
            // colDate
            // 
            colDate.AppearanceCell.Font = new Font("Segoe UI", 10F);
            colDate.AppearanceCell.Options.HighPriority = true;
            colDate.AppearanceCell.Options.UseFont = true;
            colDate.AppearanceHeader.Font = new Font("Segoe UI", 12F);
            colDate.AppearanceHeader.Options.UseFont = true;
            colDate.Caption = "التاريخ";
            colDate.FieldName = "ChangeDate";
            colDate.Name = "colDate";
            colDate.Visible = true;
            colDate.VisibleIndex = 2;
            // 
            // colCity
            // 
            colCity.AppearanceCell.Font = new Font("Segoe UI", 10F);
            colCity.AppearanceCell.Options.HighPriority = true;
            colCity.AppearanceCell.Options.UseFont = true;
            colCity.AppearanceHeader.Font = new Font("Segoe UI", 12F);
            colCity.AppearanceHeader.Options.UseFont = true;
            colCity.Caption = "المدينة";
            colCity.FieldName = "CityName";
            colCity.Name = "colCity";
            colCity.Visible = true;
            colCity.VisibleIndex = 3;
            // 
            // colVillage
            // 
            colVillage.AppearanceCell.Font = new Font("Segoe UI", 10F);
            colVillage.AppearanceCell.Options.HighPriority = true;
            colVillage.AppearanceCell.Options.UseFont = true;
            colVillage.AppearanceHeader.Font = new Font("Segoe UI", 12F);
            colVillage.AppearanceHeader.Options.UseFont = true;
            colVillage.Caption = "القرية";
            colVillage.FieldName = "VillageName";
            colVillage.Name = "colVillage";
            colVillage.Visible = true;
            colVillage.VisibleIndex = 4;
            // 
            // colDependency
            // 
            colDependency.AppearanceCell.Font = new Font("Segoe UI", 10F);
            colDependency.AppearanceCell.Options.HighPriority = true;
            colDependency.AppearanceCell.Options.UseFont = true;
            colDependency.AppearanceHeader.Font = new Font("Segoe UI", 12F);
            colDependency.AppearanceHeader.Options.UseFont = true;
            colDependency.Caption = "التابع";
            colDependency.FieldName = "DependencyName";
            colDependency.Name = "colDependency";
            colDependency.Visible = true;
            colDependency.VisibleIndex = 5;
            // 
            // colLatitude
            // 
            colLatitude.AppearanceCell.Font = new Font("Segoe UI", 10F);
            colLatitude.AppearanceCell.Options.HighPriority = true;
            colLatitude.AppearanceCell.Options.UseFont = true;
            colLatitude.AppearanceHeader.Font = new Font("Segoe UI", 12F);
            colLatitude.AppearanceHeader.Options.UseFont = true;
            colLatitude.Caption = "خط العرض";
            colLatitude.DisplayFormat.FormatString = "n6";
            colLatitude.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colLatitude.FieldName = "Latitude";
            colLatitude.Name = "colLatitude";
            colLatitude.Visible = true;
            colLatitude.VisibleIndex = 6;
            // 
            // colLongitude
            // 
            colLongitude.AppearanceCell.Font = new Font("Segoe UI", 10F);
            colLongitude.AppearanceCell.Options.HighPriority = true;
            colLongitude.AppearanceCell.Options.UseFont = true;
            colLongitude.AppearanceHeader.Font = new Font("Segoe UI", 12F);
            colLongitude.AppearanceHeader.Options.UseFont = true;
            colLongitude.Caption = "خط الطول";
            colLongitude.DisplayFormat.FormatString = "n6";
            colLongitude.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colLongitude.FieldName = "Longitude";
            colLongitude.Name = "colLongitude";
            colLongitude.Visible = true;
            colLongitude.VisibleIndex = 7;
            // 
            // colOwner
            // 
            colOwner.AppearanceCell.Font = new Font("Segoe UI", 10F);
            colOwner.AppearanceCell.Options.HighPriority = true;
            colOwner.AppearanceCell.Options.UseFont = true;
            colOwner.AppearanceHeader.Font = new Font("Segoe UI", 12F);
            colOwner.AppearanceHeader.Options.UseFont = true;
            colOwner.Caption = "اسم المالك";
            colOwner.FieldName = "OwnerName";
            colOwner.Name = "colOwner";
            colOwner.Visible = true;
            colOwner.VisibleIndex = 8;
            // 
            // colInspector
            // 
            colInspector.AppearanceCell.Font = new Font("Segoe UI", 10F);
            colInspector.AppearanceCell.Options.HighPriority = true;
            colInspector.AppearanceCell.Options.UseFont = true;
            colInspector.AppearanceHeader.Font = new Font("Segoe UI", 12F);
            colInspector.AppearanceHeader.Options.UseFont = true;
            colInspector.Caption = "القائم بالمعاينه";
            colInspector.FieldName = "InspectorName";
            colInspector.Name = "colInspector";
            colInspector.Visible = true;
            colInspector.VisibleIndex = 10;
            // 
            // colStatus
            // 
            colStatus.AppearanceCell.Font = new Font("Segoe UI", 10F);
            colStatus.AppearanceCell.Options.HighPriority = true;
            colStatus.AppearanceCell.Options.UseFont = true;
            colStatus.AppearanceHeader.Font = new Font("Segoe UI", 12F);
            colStatus.AppearanceHeader.Options.UseFont = true;
            colStatus.Caption = "داخل /خارج الحيز";
            colStatus.FieldName = "LocationStatus";
            colStatus.Name = "colStatus";
            colStatus.Visible = true;
            colStatus.VisibleIndex = 11;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4 });
            Root.Name = "Root";
            Root.Size = new Size(1270, 723);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gridControl1;
            layoutControlItem1.Location = new Point(0, 34);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(1244, 663);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AllowHtmlStringInCaption = true;
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.AppearanceItemCaptionDisabled.Font = new Font("Segoe UI", 11F);
            layoutControlItem2.AppearanceItemCaptionDisabled.Options.UseFont = true;
            layoutControlItem2.Control = cmbCity;
            layoutControlItem2.Location = new Point(876, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(368, 34);
            layoutControlItem2.Text = "المدينه";
            layoutControlItem2.TextSize = new Size(44, 20);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AllowHtmlStringInCaption = true;
            layoutControlItem3.AppearanceItemCaption.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem3.AppearanceItemCaptionDisabled.Font = new Font("Segoe UI", 11F);
            layoutControlItem3.AppearanceItemCaptionDisabled.Options.UseFont = true;
            layoutControlItem3.Control = cmbVillage;
            layoutControlItem3.Location = new Point(540, 0);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(336, 34);
            layoutControlItem3.Text = "القرية";
            layoutControlItem3.TextSize = new Size(44, 20);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AllowHtmlStringInCaption = true;
            layoutControlItem4.AppearanceItemCaption.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem4.AppearanceItemCaptionDisabled.Font = new Font("Segoe UI", 11F);
            layoutControlItem4.AppearanceItemCaptionDisabled.Options.UseFont = true;
            layoutControlItem4.Control = cmbDependency;
            layoutControlItem4.Location = new Point(0, 0);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(540, 34);
            layoutControlItem4.Text = "التوابع";
            layoutControlItem4.TextSize = new Size(44, 20);
            // 
            // ctrChangeLog
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "ctrChangeLog";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1270, 723);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cmbDependency.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbVillage.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbCity.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LookUpEdit cmbCity;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit cmbDependency;
        private DevExpress.XtraEditors.LookUpEdit cmbVillage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colChangeNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCity;
        private DevExpress.XtraGrid.Columns.GridColumn colVillage;
        private DevExpress.XtraGrid.Columns.GridColumn colDependency;
        private DevExpress.XtraGrid.Columns.GridColumn colLatitude;
        private DevExpress.XtraGrid.Columns.GridColumn colLongitude;
        private DevExpress.XtraGrid.Columns.GridColumn colOwner;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colInspector;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
