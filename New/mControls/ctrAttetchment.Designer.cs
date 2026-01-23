namespace CenterChanges
{
    partial class ctrAttachment
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsuiButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrAttachment));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsuiButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsuiButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            windowsuiButtonPanel1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            winExplorerView1 = new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView();
            FileName = new DevExpress.XtraGrid.Columns.GridColumn();
            FileSizeFormatted = new DevExpress.XtraGrid.Columns.GridColumn();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            xtraOpenFileDialog1 = new DevExpress.XtraEditors.XtraOpenFileDialog(components);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)winExplorerView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(labelControl1);
            layoutControl1.Controls.Add(windowsuiButtonPanel1);
            layoutControl1.Controls.Add(gridControl1);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(729, 586);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new Point(533, 16);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(180, 28);
            labelControl1.StyleController = layoutControl1;
            labelControl1.TabIndex = 7;
            labelControl1.Text = "مرفقات المتغير رقم ...";
            // 
            // windowsuiButtonPanel1
            // 
            windowsuiButtonImageOptions1.Image = (Image)resources.GetObject("windowsuiButtonImageOptions1.Image");
            windowsuiButtonImageOptions2.Image = (Image)resources.GetObject("windowsuiButtonImageOptions2.Image");
            windowsuiButtonImageOptions3.Image = (Image)resources.GetObject("windowsuiButtonImageOptions3.Image");
            windowsuiButtonPanel1.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraBars.Docking2010.WindowsUIButton("إضافة مرفق", true, windowsuiButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "Add", -1, false), new DevExpress.XtraBars.Docking2010.WindowsUIButton("فتح الملف", true, windowsuiButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "Open", -1, false), new DevExpress.XtraBars.Docking2010.WindowsUIButton("حذف", true, windowsuiButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "Delete", -1, false) });
            windowsuiButtonPanel1.Location = new Point(16, 487);
            windowsuiButtonPanel1.Name = "windowsuiButtonPanel1";
            windowsuiButtonPanel1.Size = new Size(697, 55);
            windowsuiButtonPanel1.TabIndex = 6;
            windowsuiButtonPanel1.Text = "windowsuiButtonPanel1";
            windowsuiButtonPanel1.ButtonClick += windowsuiButtonPanel1_ButtonClick;
            // 
            // gridControl1
            // 
            gridControl1.Location = new Point(16, 50);
            gridControl1.MainView = winExplorerView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(697, 431);
            gridControl1.TabIndex = 5;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { winExplorerView1 });
            // 
            // winExplorerView1
            // 
            winExplorerView1.Appearance.ItemNormal.Font = new Font("Segoe UI", 11F);
            winExplorerView1.Appearance.ItemNormal.Options.UseFont = true;
            winExplorerView1.Appearance.ItemNormal.Options.UseTextOptions = true;
            winExplorerView1.Appearance.ItemNormal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            winExplorerView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { FileName, FileSizeFormatted });
            winExplorerView1.ColumnSet.DescriptionColumn = FileSizeFormatted;
            winExplorerView1.ColumnSet.TextColumn = FileName;
            winExplorerView1.GridControl = gridControl1;
            winExplorerView1.Name = "winExplorerView1";
            winExplorerView1.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.Content;
            winExplorerView1.OptionsViewStyles.Content.ItemWidth = 695;
            // 
            // FileName
            // 
            FileName.Caption = "gridColumn1";
            FileName.FieldName = "FileName";
            FileName.Name = "FileName";
            FileName.Visible = true;
            FileName.VisibleIndex = 0;
            // 
            // FileSizeFormatted
            // 
            FileSizeFormatted.Caption = "gridColumn2";
            FileSizeFormatted.FieldName = "FileSizeFormatted";
            FileSizeFormatted.Name = "FileSizeFormatted";
            FileSizeFormatted.Visible = true;
            FileSizeFormatted.VisibleIndex = 0;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { emptySpaceItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4 });
            Root.Name = "Root";
            Root.Size = new Size(729, 586);
            Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(0, 532);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(703, 28);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = gridControl1;
            layoutControlItem2.Location = new Point(0, 34);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(703, 437);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = windowsuiButtonPanel1;
            layoutControlItem3.Location = new Point(0, 471);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(703, 61);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AppearanceItemCaption.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem4.AppearanceItemCaptionDisabled.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            layoutControlItem4.AppearanceItemCaptionDisabled.Options.UseFont = true;
            layoutControlItem4.Control = labelControl1;
            layoutControlItem4.Location = new Point(0, 0);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(703, 34);
            layoutControlItem4.Text = "مرفقات المتغير رقم ...";
            layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem4.TextVisible = false;
            // 
            // xtraOpenFileDialog1
            // 
            xtraOpenFileDialog1.FileName = "xtraOpenFileDialog1";
            // 
            // ctrAttachment
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "ctrAttachment";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(729, 586);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)winExplorerView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsuiButtonPanel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView winExplorerView1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn FileName;
        private DevExpress.XtraGrid.Columns.GridColumn FileSizeFormatted;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialog1;
    }
}
