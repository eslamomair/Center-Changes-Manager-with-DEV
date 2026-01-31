namespace CenterChangesManager.Main.Login
{
    partial class frmLogin
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
            panelControl1 = new DevExpress.XtraEditors.PanelControl();
            txtShowPassword = new DevExpress.XtraEditors.CheckEdit();
            chkRemmeberMe = new DevExpress.XtraEditors.CheckEdit();
            txtPassword = new DevExpress.XtraEditors.TextEdit();
            txtUserName = new DevExpress.XtraEditors.TextEdit();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            btnLogn = new DevExpress.XtraEditors.SimpleButton();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            pbLogo = new DevExpress.XtraEditors.PictureEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            panelRight = new DevExpress.XtraEditors.PanelControl();
            btnCreateFirstAdmin = new DevExpress.XtraEditors.SimpleButton();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtShowPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkRemmeberMe.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUserName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelRight).BeginInit();
            panelRight.SuspendLayout();
            SuspendLayout();
            // 
            // panelControl1
            // 
            panelControl1.Appearance.BackColor = Color.WhiteSmoke;
            panelControl1.Appearance.Options.UseBackColor = true;
            panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelControl1.Controls.Add(txtShowPassword);
            panelControl1.Controls.Add(chkRemmeberMe);
            panelControl1.Controls.Add(txtPassword);
            panelControl1.Controls.Add(txtUserName);
            panelControl1.Controls.Add(btnCancel);
            panelControl1.Controls.Add(btnLogn);
            panelControl1.Controls.Add(labelControl6);
            panelControl1.Controls.Add(labelControl5);
            panelControl1.Controls.Add(labelControl3);
            panelControl1.Dock = DockStyle.Fill;
            panelControl1.Location = new Point(0, 0);
            panelControl1.Name = "panelControl1";
            panelControl1.Size = new Size(738, 574);
            panelControl1.TabIndex = 0;
            // 
            // txtShowPassword
            // 
            txtShowPassword.Location = new Point(48, 274);
            txtShowPassword.Name = "txtShowPassword";
            txtShowPassword.Properties.Appearance.Font = new Font("Cairo", 12F, FontStyle.Bold);
            txtShowPassword.Properties.Appearance.ForeColor = Color.Black;
            txtShowPassword.Properties.Appearance.Options.UseFont = true;
            txtShowPassword.Properties.Appearance.Options.UseForeColor = true;
            txtShowPassword.Properties.Caption = "اظهار كلمه المرور ";
            txtShowPassword.Size = new Size(166, 34);
            txtShowPassword.TabIndex = 12;
            // 
            // chkRemmeberMe
            // 
            chkRemmeberMe.Location = new Point(195, 274);
            chkRemmeberMe.Name = "chkRemmeberMe";
            chkRemmeberMe.Properties.Appearance.Font = new Font("Cairo", 12F, FontStyle.Bold);
            chkRemmeberMe.Properties.Appearance.ForeColor = Color.Black;
            chkRemmeberMe.Properties.Appearance.Options.UseFont = true;
            chkRemmeberMe.Properties.Appearance.Options.UseForeColor = true;
            chkRemmeberMe.Properties.Caption = "تذكرنى";
            chkRemmeberMe.Size = new Size(141, 34);
            chkRemmeberMe.TabIndex = 11;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(37, 209);
            txtPassword.Name = "txtPassword";
            txtPassword.Properties.Appearance.Font = new Font("Cairo SemiBold", 12F, FontStyle.Bold);
            txtPassword.Properties.Appearance.Options.UseFont = true;
            txtPassword.Properties.AutoHeight = false;
            txtPassword.Size = new Size(306, 59);
            txtPassword.TabIndex = 10;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(37, 78);
            txtUserName.Name = "txtUserName";
            txtUserName.Properties.Appearance.Font = new Font("Cairo SemiBold", 12F, FontStyle.Bold);
            txtUserName.Properties.Appearance.Options.UseFont = true;
            txtUserName.Properties.AutoHeight = false;
            txtUserName.Size = new Size(306, 59);
            txtUserName.TabIndex = 9;
            // 
            // btnCancel
            // 
            btnCancel.Appearance.Font = new Font("Cairo SemiBold", 12F, FontStyle.Bold);
            btnCancel.Appearance.Options.UseFont = true;
            btnCancel.ImageOptions.Image = Properties.Resources.cancel_32x32;
            btnCancel.Location = new Point(37, 436);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(306, 59);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "الغاء";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnLogn
            // 
            btnLogn.Appearance.Font = new Font("Cairo SemiBold", 12F, FontStyle.Bold);
            btnLogn.Appearance.Options.UseFont = true;
            btnLogn.ImageOptions.Image = Properties.Resources.encrypt_32x32;
            btnLogn.Location = new Point(37, 349);
            btnLogn.Name = "btnLogn";
            btnLogn.Size = new Size(306, 59);
            btnLogn.TabIndex = 7;
            btnLogn.Text = "تسجيل الدخول";
            btnLogn.Click += btnLogin_Click;
            // 
            // labelControl6
            // 
            labelControl6.Appearance.Font = new Font("Cairo", 14F, FontStyle.Bold);
            labelControl6.Appearance.ForeColor = Color.Black;
            labelControl6.Appearance.Options.UseFont = true;
            labelControl6.Appearance.Options.UseForeColor = true;
            labelControl6.AppearanceHovered.Font = new Font("Cairo ExtraBold", 14F, FontStyle.Bold);
            labelControl6.AppearanceHovered.ForeColor = Color.LawnGreen;
            labelControl6.AppearanceHovered.Options.UseFont = true;
            labelControl6.AppearanceHovered.Options.UseForeColor = true;
            labelControl6.Location = new Point(225, 154);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new Size(111, 36);
            labelControl6.TabIndex = 5;
            labelControl6.Text = "كلمه المرور : ";
            // 
            // labelControl5
            // 
            labelControl5.Appearance.Font = new Font("Cairo", 14F, FontStyle.Bold);
            labelControl5.Appearance.ForeColor = Color.Black;
            labelControl5.Appearance.Options.UseFont = true;
            labelControl5.Appearance.Options.UseForeColor = true;
            labelControl5.AppearanceHovered.Font = new Font("Cairo ExtraBold", 14F, FontStyle.Bold);
            labelControl5.AppearanceHovered.ForeColor = Color.LawnGreen;
            labelControl5.AppearanceHovered.Options.UseFont = true;
            labelControl5.AppearanceHovered.Options.UseForeColor = true;
            labelControl5.Location = new Point(200, 36);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new Size(139, 36);
            labelControl5.TabIndex = 4;
            labelControl5.Text = "اسم المستخدم : ";
            // 
            // labelControl3
            // 
            labelControl3.Appearance.Font = new Font("Cairo", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelControl3.Appearance.ForeColor = Color.Black;
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Appearance.Options.UseForeColor = true;
            labelControl3.AppearanceHovered.Font = new Font("Cairo ExtraBold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelControl3.AppearanceHovered.ForeColor = Color.LawnGreen;
            labelControl3.AppearanceHovered.Options.UseFont = true;
            labelControl3.AppearanceHovered.Options.UseForeColor = true;
            labelControl3.Dock = DockStyle.Bottom;
            labelControl3.Location = new Point(0, 544);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(178, 30);
            labelControl3.TabIndex = 3;
            labelControl3.Text = "Created By  :   Islam Omair";
            // 
            // pbLogo
            // 
            pbLogo.BackgroundImageLayout = ImageLayout.None;
            pbLogo.EditValue = Properties.Resources.remove_the_white_bac;
            pbLogo.Location = new Point(32, 12);
            pbLogo.Name = "pbLogo";
            pbLogo.Properties.Appearance.BackColor = Color.Transparent;
            pbLogo.Properties.Appearance.Options.UseBackColor = true;
            pbLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pbLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pbLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            pbLogo.Size = new Size(306, 340);
            pbLogo.TabIndex = 0;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new Font("Cairo", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.AppearanceHovered.Font = new Font("Cairo ExtraBold", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelControl1.AppearanceHovered.ForeColor = Color.LawnGreen;
            labelControl1.AppearanceHovered.Options.UseFont = true;
            labelControl1.AppearanceHovered.Options.UseForeColor = true;
            labelControl1.Location = new Point(112, 329);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(104, 60);
            labelControl1.TabIndex = 1;
            labelControl1.Text = "اهلا بك";
            // 
            // panelRight
            // 
            panelRight.Controls.Add(btnCreateFirstAdmin);
            panelRight.Controls.Add(labelControl4);
            panelRight.Controls.Add(labelControl2);
            panelRight.Controls.Add(labelControl1);
            panelRight.Controls.Add(pbLogo);
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(368, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(370, 574);
            panelRight.TabIndex = 1;
            panelRight.Paint += panelControl2_Paint;
            // 
            // btnCreateFirstAdmin
            // 
            btnCreateFirstAdmin.Appearance.BackColor = Color.Transparent;
            btnCreateFirstAdmin.Appearance.BorderColor = Color.Transparent;
            btnCreateFirstAdmin.Appearance.Font = new Font("Cairo SemiBold", 12F, FontStyle.Bold);
            btnCreateFirstAdmin.Appearance.ForeColor = Color.WhiteSmoke;
            btnCreateFirstAdmin.Appearance.Options.UseBackColor = true;
            btnCreateFirstAdmin.Appearance.Options.UseBorderColor = true;
            btnCreateFirstAdmin.Appearance.Options.UseFont = true;
            btnCreateFirstAdmin.Appearance.Options.UseForeColor = true;
            btnCreateFirstAdmin.AppearanceHovered.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            btnCreateFirstAdmin.AppearanceHovered.Options.UseForeColor = true;
            btnCreateFirstAdmin.ImageOptions.Image = Properties.Resources.editdatasource_32x32;
            btnCreateFirstAdmin.Location = new Point(66, 459);
            btnCreateFirstAdmin.LookAndFeel.SkinMaskColor = Color.Transparent;
            btnCreateFirstAdmin.LookAndFeel.SkinMaskColor2 = Color.Transparent;
            btnCreateFirstAdmin.LookAndFeel.SkinName = "WXI";
            btnCreateFirstAdmin.LookAndFeel.UseDefaultLookAndFeel = false;
            btnCreateFirstAdmin.Name = "btnCreateFirstAdmin";
            btnCreateFirstAdmin.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            btnCreateFirstAdmin.Size = new Size(217, 59);
            btnCreateFirstAdmin.TabIndex = 13;
            btnCreateFirstAdmin.Text = "إنشاء حساب جديد";
            btnCreateFirstAdmin.Click += simpleButton3_Click;
            // 
            // labelControl4
            // 
            labelControl4.Appearance.Font = new Font("Cairo", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.AppearanceHovered.Font = new Font("Cairo ExtraBold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelControl4.AppearanceHovered.ForeColor = Color.LawnGreen;
            labelControl4.AppearanceHovered.Options.UseFont = true;
            labelControl4.AppearanceHovered.Options.UseForeColor = true;
            labelControl4.Dock = DockStyle.Bottom;
            labelControl4.Location = new Point(2, 542);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new Size(198, 30);
            labelControl4.TabIndex = 4;
            labelControl4.Text = "01117384210   -  01287467673";
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new Font("Cairo", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.AppearanceHovered.Font = new Font("Cairo ExtraBold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelControl2.AppearanceHovered.ForeColor = Color.LawnGreen;
            labelControl2.AppearanceHovered.Options.UseFont = true;
            labelControl2.AppearanceHovered.Options.UseForeColor = true;
            labelControl2.Location = new Point(32, 395);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(283, 42);
            labelControl2.TabIndex = 2;
            labelControl2.Text = "نظام اداره المتغيرات المكانية";
            // 
            // frmLogin
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 574);
            Controls.Add(panelRight);
            Controls.Add(panelControl1);
            Font = new Font("Segoe UI", 12F);
            FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmLogin";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLogin";
            Load += frmLogin_Load;
            Shown += frmLogin_Shown;
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtShowPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkRemmeberMe.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUserName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelRight).EndInit();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PictureEdit pbLogo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelRight;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnLogn;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.CheckEdit chkRemmeberMe;
        private DevExpress.XtraEditors.CheckEdit txtShowPassword;
        private DevExpress.XtraEditors.SimpleButton btnCreateFirstAdmin;
    }
}