namespace CenterChanges.ControlsCites
{
    partial class ctrCity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrCity));
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            btnSaveAllUC = new DevExpress.XtraEditors.SimpleButton();
            ucDependencies = new CenterChanges.mControls.ctrItemAll();
            ucVillage = new CenterChanges.mControls.ctrItemAll();
            ucCity = new CenterChanges.mControls.ctrItemAll();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(btnSaveAllUC);
            layoutControl1.Controls.Add(ucDependencies);
            layoutControl1.Controls.Add(ucVillage);
            layoutControl1.Controls.Add(ucCity);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(482, 636);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // btnSaveAllUC
            // 
            btnSaveAllUC.Appearance.Font = new Font("Segoe UI", 12F);
            btnSaveAllUC.Appearance.Options.UseFont = true;
            btnSaveAllUC.ImageOptions.Image = (Image)resources.GetObject("btnSaveAllUC.ImageOptions.Image");
            btnSaveAllUC.Location = new Point(16, 582);
            btnSaveAllUC.Name = "btnSaveAllUC";
            btnSaveAllUC.Size = new Size(189, 38);
            btnSaveAllUC.StyleController = layoutControl1;
            btnSaveAllUC.TabIndex = 4;
            btnSaveAllUC.Text = "simpleButton1";
            btnSaveAllUC.Click += btnSaveAllUC_Click;
            // 
            // ucDependencies
            // 
            ucDependencies.btnSaveText = "حفظ";
            ucDependencies.chkBox = "اختيار تابع ";
            ucDependencies.cmbInputTitle = "اختيار تابع ";
            ucDependencies.GroupHeaderForeColor = Color.FromArgb(255, 128, 255);
            ucDependencies.GroupTitle = "اضافه / اختيار تابع ";
            ucDependencies.IsChkVisible = true;
            ucDependencies.IscmbVisible = true;
            ucDependencies.IsSelectedCity = false;
            ucDependencies.ItemTextValue = "";
            ucDependencies.Location = new Point(16, 394);
            ucDependencies.Name = "ucDependencies";
            ucDependencies.RightToLeft = RightToLeft.Yes;
            ucDependencies.Size = new Size(450, 182);
            ucDependencies.TabIndex = 3;
            ucDependencies.txtInputTitle = "اضافه تابع ";
            ucDependencies.isSelectedCHK += ucDependencies_isSelectedCHK;
            ucDependencies.OnDeleteButtonClick += ucDependencies_OnDeleteButtonClick;
            ucDependencies.OnEditButtonClick += ucDependencies_OnEditButtonClick;
            ucDependencies.OnSaveClick += ucDependencies_OnSaveClick;
            // 
            // ucVillage
            // 
            ucVillage.btnSaveText = "حفظ";
            ucVillage.chkBox = "اختيار قريه";
            ucVillage.cmbInputTitle = "اختيار قريه ";
            ucVillage.GroupHeaderForeColor = Color.Lime;
            ucVillage.GroupTitle = "اضافه / اختيار قريه ";
            ucVillage.IsChkVisible = true;
            ucVillage.IscmbVisible = true;
            ucVillage.IsSelectedCity = false;
            ucVillage.ItemTextValue = "";
            ucVillage.Location = new Point(16, 206);
            ucVillage.Name = "ucVillage";
            ucVillage.RightToLeft = RightToLeft.Yes;
            ucVillage.Size = new Size(450, 182);
            ucVillage.TabIndex = 2;
            ucVillage.txtInputTitle = "اضافه قرية";
            ucVillage.isSelectedCHK += ucVillage_isSelectedCHK;
            ucVillage.OnDeleteButtonClick += ucVillage_OnDeleteButtonClick;
            ucVillage.OnEditButtonClick += ucVillage_OnEditButtonClick;
            ucVillage.OnSaveClick += ucVillage_OnSaveClick;
            // 
            // ucCity
            // 
            ucCity.btnSaveText = "حفظ";
            ucCity.chkBox = "اختيار مدينه";
            ucCity.cmbInputTitle = "اختيار مدينه";
            ucCity.GroupHeaderForeColor = Color.FromArgb(128, 128, 255);
            ucCity.GroupTitle = "اضافه / اختيار مدينه";
            ucCity.IsChkVisible = true;
            ucCity.IscmbVisible = true;
            ucCity.IsSelectedCity = false;
            ucCity.ItemTextValue = "";
            ucCity.Location = new Point(16, 16);
            ucCity.Name = "ucCity";
            ucCity.RightToLeft = RightToLeft.Yes;
            ucCity.Size = new Size(450, 184);
            ucCity.TabIndex = 0;
            ucCity.txtInputTitle = "اضافه مدينه ";
            ucCity.isSelectedCHK += ucCity_isSelectedCHK;
            ucCity.OnDeleteButtonClick += ucCity_OnDeleteButtonClick;
            ucCity.OnEditButtonClick += ucCity_OnEditButtonClick;
            ucCity.OnSaveClick += ucCity_OnSaveClick;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, emptySpaceItem1 });
            Root.Name = "Root";
            Root.Size = new Size(482, 636);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = ucCity;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(456, 190);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = ucVillage;
            layoutControlItem2.Location = new Point(0, 190);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(456, 188);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = ucDependencies;
            layoutControlItem3.Location = new Point(0, 378);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(456, 188);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = btnSaveAllUC;
            layoutControlItem4.Location = new Point(0, 566);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(195, 44);
            layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(195, 566);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(261, 44);
            // 
            // ctrCity
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "ctrCity";
            Size = new Size(482, 636);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private mControls.ctrItemAll ucDependencies;
        private mControls.ctrItemAll ucVillage;
        private mControls.ctrItemAll ucCity;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnSaveAllUC;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
