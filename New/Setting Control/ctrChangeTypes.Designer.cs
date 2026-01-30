namespace CenterChangesManager.Main.Setting_Control
{
    partial class ctrChangeTypes
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
            btnRemove = new DevExpress.XtraEditors.SimpleButton();
            btnEdit = new DevExpress.XtraEditors.SimpleButton();
            btnAdd = new DevExpress.XtraEditors.SimpleButton();
            txtChangeType = new DevExpress.XtraEditors.TextEdit();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtChangeType.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem4).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(btnRemove);
            layoutControl1.Controls.Add(btnEdit);
            layoutControl1.Controls.Add(btnAdd);
            layoutControl1.Controls.Add(txtChangeType);
            layoutControl1.Controls.Add(gridControl1);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(898, 273, 650, 400);
            layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(891, 518);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // btnRemove
            // 
            btnRemove.Appearance.Font = new Font("Segoe UI", 14F);
            btnRemove.Appearance.Options.UseFont = true;
            btnRemove.Location = new Point(243, 390);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(126, 32);
            btnRemove.StyleController = layoutControl1;
            btnRemove.TabIndex = 8;
            btnRemove.Text = "حذف";
            btnRemove.Click += btnRemove_Click;
            // 
            // btnEdit
            // 
            btnEdit.Appearance.Font = new Font("Segoe UI", 14F);
            btnEdit.Appearance.Options.UseFont = true;
            btnEdit.Location = new Point(375, 390);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(122, 32);
            btnEdit.StyleController = layoutControl1;
            btnEdit.TabIndex = 7;
            btnEdit.Text = "تعديل";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Appearance.Font = new Font("Segoe UI", 14F);
            btnAdd.Appearance.Options.UseFont = true;
            btnAdd.Location = new Point(503, 390);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(138, 32);
            btnAdd.StyleController = layoutControl1;
            btnAdd.TabIndex = 6;
            btnAdd.Text = "اضافه";
            btnAdd.Click += btnAdd_Click;
            // 
            // txtChangeType
            // 
            txtChangeType.Location = new Point(444, 348);
            txtChangeType.Name = "txtChangeType";
            txtChangeType.Properties.Appearance.Font = new Font("Segoe UI", 12F);
            txtChangeType.Properties.Appearance.Options.UseFont = true;
            txtChangeType.Size = new Size(111, 36);
            txtChangeType.StyleController = layoutControl1;
            txtChangeType.TabIndex = 5;
            // 
            // gridControl1
            // 
            gridControl1.Font = new Font("Segoe UI", 12F);
            gridControl1.Location = new Point(243, 16);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(398, 326);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { emptySpaceItem1, emptySpaceItem2, emptySpaceItem3, layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5, emptySpaceItem4 });
            Root.Name = "Root";
            Root.Size = new Size(891, 518);
            Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(227, 412);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(404, 80);
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.Location = new Point(0, 0);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(227, 492);
            // 
            // emptySpaceItem3
            // 
            emptySpaceItem3.Location = new Point(631, 0);
            emptySpaceItem3.Name = "emptySpaceItem3";
            emptySpaceItem3.Size = new Size(234, 492);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gridControl1;
            layoutControlItem1.Location = new Point(227, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(404, 332);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Segoe UI", 12F);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.AppearanceItemCaptionDisabled.Font = new Font("Segoe UI", 12F);
            layoutControlItem2.AppearanceItemCaptionDisabled.Options.UseFont = true;
            layoutControlItem2.Control = txtChangeType;
            layoutControlItem2.Location = new Point(428, 332);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(203, 42);
            layoutControlItem2.Text = "نوع المتغير";
            layoutControlItem2.TextSize = new Size(70, 21);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = btnAdd;
            layoutControlItem3.Location = new Point(487, 374);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(144, 38);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = btnEdit;
            layoutControlItem4.Location = new Point(359, 374);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(128, 38);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = btnRemove;
            layoutControlItem5.Location = new Point(227, 374);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(132, 38);
            layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            emptySpaceItem4.Location = new Point(227, 332);
            emptySpaceItem4.Name = "emptySpaceItem4";
            emptySpaceItem4.Size = new Size(201, 42);
            // 
            // ctrChangeTypes
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "ctrChangeTypes";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(891, 518);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtChangeType.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.TextEdit txtChangeType;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
    }
}
