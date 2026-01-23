namespace CenterChanges.mControls
{
    partial class ctrItemAll
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
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            chk = new DevExpress.XtraEditors.CheckButton();
            cmb = new DevExpress.XtraEditors.LookUpEdit();
            txtInput = new DevExpress.XtraEditors.TextEdit();
            btn = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            lGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            popupMenu1 = new DevExpress.XtraBars.PopupMenu(components);
            btnEdit = new DevExpress.XtraBars.BarButtonItem();
            btnDelete = new DevExpress.XtraBars.BarButtonItem();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmb.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtInput.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lGroup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(chk);
            layoutControl1.Controls.Add(cmb);
            layoutControl1.Controls.Add(txtInput);
            layoutControl1.Controls.Add(btn);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(821, 345, 650, 400);
            layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(420, 216);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // chk
            // 
            chk.Appearance.Font = new Font("Segoe UI", 12F);
            chk.Appearance.Options.UseFont = true;
            chk.Location = new Point(280, 143);
            chk.Name = "chk";
            chk.Size = new Size(108, 28);
            chk.StyleController = layoutControl1;
            chk.TabIndex = 3;
            chk.Text = "checkButton2";
            chk.CheckedChanged += chk_CheckedChanged;
            // 
            // cmb
            // 
            cmb.Location = new Point(32, 101);
            cmb.Name = "cmb";
            cmb.Properties.Appearance.Font = new Font("Segoe UI", 12F);
            cmb.Properties.Appearance.Options.UseFont = true;
            cmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmb.Properties.ButtonClick += cmb_Properties_ButtonClick;
            cmb.Size = new Size(257, 36);
            cmb.StyleController = layoutControl1;
            cmb.TabIndex = 2;
            cmb.EditValueChanged += cmb_EditValueChanged;
            cmb.MouseDown += cmb_MouseDown;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(32, 59);
            txtInput.Name = "txtInput";
            txtInput.Properties.Appearance.Font = new Font("Segoe UI", 12F);
            txtInput.Properties.Appearance.Options.UseFont = true;
            txtInput.Size = new Size(257, 36);
            txtInput.StyleController = layoutControl1;
            txtInput.TabIndex = 0;
            // 
            // btn
            // 
            btn.Appearance.Font = new Font("Segoe UI", 15F);
            btn.Appearance.Options.UseFont = true;
            btn.Location = new Point(32, 143);
            btn.Name = "btn";
            btn.Size = new Size(143, 35);
            btn.StyleController = layoutControl1;
            btn.TabIndex = 4;
            btn.Text = "simpleButton1";
            btn.Click += btn_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lGroup });
            Root.Name = "Root";
            Root.Size = new Size(420, 216);
            Root.TextVisible = false;
            // 
            // lGroup
            // 
            lGroup.AppearanceGroup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lGroup.AppearanceGroup.Options.UseFont = true;
            lGroup.AppearanceItemCaption.Font = new Font("Segoe UI", 12F);
            lGroup.AppearanceItemCaption.Options.UseFont = true;
            lGroup.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            lGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem3, layoutControlItem2, layoutControlItem4, layoutControlItem5, emptySpaceItem2 });
            lGroup.Location = new Point(0, 0);
            lGroup.Name = "lGroup";
            lGroup.Size = new Size(394, 190);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Font = new Font("Segoe UI", 12F);
            layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem3.AppearanceItemCaptionDisabled.Font = new Font("Segoe UI", 12F);
            layoutControlItem3.AppearanceItemCaptionDisabled.Options.UseFont = true;
            layoutControlItem3.Control = cmb;
            layoutControlItem3.Location = new Point(0, 42);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(362, 42);
            layoutControlItem3.Text = "اختيار مدينه";
            layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Right;
            layoutControlItem3.TextSize = new Size(83, 21);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Segoe UI", 12F);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.AppearanceItemCaptionDisabled.Font = new Font("Segoe UI", 12F);
            layoutControlItem2.AppearanceItemCaptionDisabled.Options.UseFont = true;
            layoutControlItem2.Control = txtInput;
            layoutControlItem2.Location = new Point(0, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(362, 42);
            layoutControlItem2.Text = "اضافه مدينه ";
            layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Right;
            layoutControlItem2.TextSize = new Size(83, 21);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = btn;
            layoutControlItem4.Location = new Point(0, 84);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(149, 47);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = chk;
            layoutControlItem5.Location = new Point(248, 84);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(114, 47);
            layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.Location = new Point(149, 84);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(99, 47);
            // 
            // popupMenu1
            // 
            popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(btnEdit), new DevExpress.XtraBars.LinkPersistInfo(btnDelete) });
            popupMenu1.Manager = barManager1;
            popupMenu1.Name = "popupMenu1";
            // 
            // btnEdit
            // 
            btnEdit.Caption = "تعديل الاسم";
            btnEdit.Id = 0;
            btnEdit.ImageOptions.Image = global::CenterChangesManager.Main.Properties.Resources.edit_16x161;
            btnEdit.ImageOptions.LargeImage = global::CenterChangesManager.Main.Properties.Resources.edit_32x32;
            btnEdit.Name = "btnEdit";
            btnEdit.ItemClick += btnEdit_ItemClick;
            // 
            // btnDelete
            // 
            btnDelete.Caption = "حذف";
            btnDelete.Id = 1;
            btnDelete.ImageOptions.Image = global::CenterChangesManager.Main.Properties.Resources.delete_16x16;
            btnDelete.ImageOptions.LargeImage = global::CenterChangesManager.Main.Properties.Resources.delete_32x32;
            btnDelete.Name = "btnDelete";
            btnDelete.ItemClick += btnDelete_ItemClick;
            // 
            // barManager1
            // 
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { btnEdit, btnDelete });
            barManager1.MaxItemId = 2;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(420, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 216);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(420, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 0);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 216);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(420, 0);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 216);
            // 
            // ctrItemAll
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "ctrItemAll";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(420, 216);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cmb.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtInput.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)lGroup).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.CheckButton chk;
        private DevExpress.XtraEditors.LookUpEdit cmb;
        private DevExpress.XtraEditors.TextEdit txtInput;
        private DevExpress.XtraEditors.SimpleButton btn;
        private DevExpress.XtraLayout.LayoutControlGroup lGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
    }
}
