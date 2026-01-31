using CenterChanges;
using CenterChangesManager.BLL;
using CenterChangesManager.BLL.Global;
using CenterChangesManager.Main.Utilities;
using DevExpress.XtraEditors;
using System.Drawing.Drawing2D;

namespace CenterChangesManager.Main.Login
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();

        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = panelRight.ClientRectangle;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(26, 77, 46),   // أخضر غامق
                Color.FromArgb(45, 122, 79),  // أخضر فاتح
                LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {

            clsUser User = await clsUser.LoginAsync(txtUserName.Text.Trim(), txtPassword.Text.Trim());


            if (User != null)
            {
                if (User.UserData.IsActive == false)
                {
                    XtraMessageBox.Show("المستخدم غير مفعل برجاء التواصل مع الادمن ");
                    return;
                }


                if (chkRemmeberMe.Checked)
                {
                    clsGlobal.SaveLoginInfo(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                }
                else
                    clsGlobal.SaveLoginInfo("", "");

                clsGlobal.CurrentUser = User;
                frmMain main = new frmMain(this);
                main.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show("خطا فى اسم المتسخدم او كلمه المرور ");
                return;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";
            if (clsGlobal.LoadLoginInfo(ref UserName, password: Password))
            {
                txtUserName.Text = UserName;
                chkRemmeberMe.Checked = true;
            }
            else
            {
                txtUserName.Text = "";
                chkRemmeberMe.Checked = false;
            }
        }

        private async void simpleButton3_Click(object sender, EventArgs e)
        {


            if (await clsUser.IsAnyUserExistsAsync())
            {
                clsHelperClass.Error("يجب تسجل المستخدمين  من داخل البرنامج ");
                return;
            }

            clsHelperClass.ShowMessage("سيتم انشاء ادمن النظام الان ، الادمن يمتلك جميع صلاحيات النظام ", "تاكيد");



        }

        private async void frmLogin_Shown(object sender, EventArgs e)
        {
            btnCreateFirstAdmin.Visible = !await clsUser.IsAnyUserExistsAsync();
        }
    }
}