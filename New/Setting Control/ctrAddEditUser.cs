using CenterChangesManager.BLL;
using CenterChangesManager.Common;
using CenterChangesManager.Main.Utilities;
using static CenterChangesManager.BLL.Global.clsPermissions;

namespace CenterChangesManager.Main.Setting_Control
{
    public partial class ctrAddEditUser : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _isUserNameValid = false;
        int ID;
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode;
        private clsUser? _User;

        public ctrAddEditUser()
        {
            InitializeComponent();
        }

        private void ReseatDefaultValue()
        {

            if (Mode == enMode.AddNew)
            {
                _User = new clsUser();
            }
            txtConfirmPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFullNameUser.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUserName.Text = string.Empty;

            chkAllPermission.Checked = false;
            chkPermissionAddChange.Checked = false;
            chkPermissionDeleteAttachments.Checked = false;
            chkPermissionDeleteChange.Checked = false;
            chkPermissionDeleteUser.Checked = false;
            chkPermissionEditChange.Checked = false;
            chkPermissionEditPermission.Checked = false;
            chkPermissionSenderReport.Checked = false;
            chkPermissionShowReport.Checked = false;

        }

        private async Task _LoadData()
        {
            _User = await clsUser.FindAsync(ID);

            if (_User == null)
            {
                clsHelperClass.Error("خطا فى تحميل البيانات ");
                return;
            }



            txtEmail.Text = _User.UserData.Email;
            txtFullNameUser.Text = _User.UserData.FullName;

            txtUserName.Text = _User.UserData.UserName;

            enPermissions userPerms = (enPermissions)_User.UserData.Permession;


            chkAllPermission.Checked = ((userPerms & enPermissions.All) == enPermissions.All);


            chkPermissionAddChange.Checked = ((userPerms & enPermissions.AddVariable) == enPermissions.AddVariable);
            chkPermissionEditChange.Checked = ((userPerms & enPermissions.EditVariable) == enPermissions.EditVariable);
            chkPermissionDeleteChange.Checked = ((userPerms & enPermissions.DeleteVariable) == enPermissions.DeleteVariable);
            chkPermissionDeleteAttachments.Checked = ((userPerms & enPermissions.DeleteAttachments) == enPermissions.DeleteAttachments);
            chkPermissionDeleteUser.Checked = ((userPerms & enPermissions.DeleteUser) == enPermissions.DeleteUser);
            chkPermissionEditPermission.Checked = ((userPerms & enPermissions.EditPermissions) == enPermissions.EditPermissions);
            chkPermissionSenderReport.Checked = ((userPerms & enPermissions.ExportData) == enPermissions.ExportData);
            chkPermissionShowReport.Checked = ((userPerms & enPermissions.ViewReports) == enPermissions.ViewReports);



        }

        public async void StartUserControl(int id = 0)
        {
            Mode = id == 0 ? enMode.AddNew : enMode.Update;

            ReseatDefaultValue();
            if (Mode == enMode.Update)
            {
                ID = id;
                await _LoadData();
            }
        }

        private enPermissions GetPermissions()
        {
            if (chkAllPermission.Checked)
                return enPermissions.All;

            return
                (chkPermissionAddChange.Checked ? enPermissions.AddVariable : enPermissions.None) |
                (chkPermissionEditChange.Checked ? enPermissions.EditVariable : enPermissions.None) |
                (chkPermissionDeleteChange.Checked ? enPermissions.DeleteVariable : enPermissions.None) |
                (chkPermissionShowReport.Checked ? enPermissions.ViewReports : enPermissions.None) |
                (chkPermissionSenderReport.Checked ? enPermissions.ExportData : enPermissions.None) |
                (chkPermissionDeleteAttachments.Checked ? enPermissions.DeleteAttachments : enPermissions.None) |
                //(chkPermission.Checked ? enPermissions.ManageUsers : enPermissions.None) |
                (chkPermissionEditPermission.Checked ? enPermissions.EditPermissions : enPermissions.None) |
                (chkPermissionDeleteUser.Checked ? enPermissions.DeleteUser : enPermissions.None);
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate())
            {
                return;
            }
            if (!_isUserNameValid)
            {
                clsHelperClass.ShowMessage("لا يمكن الحفظ، اسم المستخدم غير صالح أو مكرر.", "تنبيه");
                txtUserName.Focus();
                return;
            }

            if (Mode == enMode.AddNew)
            {

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    txtPassword.ErrorText = "يجب إدخال كلمة مرور للمستخدم الجديد";
                    return;
                }

                UserRegisterData registerData = new UserRegisterData
                {
                    UserName = txtUserName.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    FullName = txtFullNameUser.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    IsActive = true,
                    Permession = (int)GetPermissions()

                };

                _User = clsUser.CreateNew(registerData);

            }
            else
            {
                txtUserName.Enabled = false;
                _User.UserData.FullName = txtFullNameUser.Text.Trim();
                _User.UserData.Email = txtEmail.Text.Trim();
                //  _User.UserData.UserName = txtUserName.Text.Trim(); 
                _User.UserData.Permession = (int)GetPermissions();

                //فحص هل ادخل المستخدم باسورد جديد 
                if (!string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
                {
                    PasswordHasher.CreatePasswordHash(txtPassword.Text.Trim(),
                        out string hash, out string salat, out int memory, out int itreations, out int paralllwlism);

                    _User.UserData.PasswordHash = hash;
                    _User.UserData.PasswordSalt = salat;
                    _User.UserData.ArgonMemorySize = memory;
                    _User.UserData.ArgonIterations = itreations;
                    _User.UserData.ArgonParallelism = paralllwlism;


                }
            }




            if (await _User.Save())
            {
                clsHelperClass.Success(" تم حفظ المستخدم بنجاح ");
                Mode = enMode.Update;
                ReseatDefaultValue();
            }
            else
                clsHelperClass.Error("تعذر حفظ المستخدم");
        }

        private async void txtUserName_Leave(object sender, EventArgs e)
        {
            // تنظيف النص أولاً
            string currentName = txtUserName.Text.Trim();
            if (string.IsNullOrWhiteSpace(currentName)) return;

            // 1. الفحص المبدئي: هل الاسم موجود في قاعدة البيانات؟
            bool isNameTaken = await clsUser.IsUserNameUsedAsync(currentName);

            // 2. منطق الاستثناء (Business Logic for Update)
            // Guard against _User being null to avoid possible null reference.
            if (Mode == enMode.Update && _User != null && _User.UserData != null && _User.UserData.UserName == currentName)
            {
                // إذا كان وضع تعديل + الاسم لم يتغير = نعتبره غير مأخوذ (مسموح)
                isNameTaken = false;
            }

            // 3. تطبيق النتيجة على الشاشة ومتغير الصلاحية
            if (isNameTaken)
            {
                // الاسم مأخوذ (مشكلة)
                txtUserName.Properties.Appearance.BorderColor = Color.Red;
                txtUserName.Properties.Appearance.Options.UseBorderColor = true;

                clsHelperClass.ShowMessage("عفوا اسم المستخدم موجود من قبل", "تنبيه");


                _isUserNameValid = false;
            }
            else
            {

                txtUserName.Properties.Appearance.BorderColor = Color.Empty;
                txtUserName.Properties.Appearance.Options.UseBorderColor = false;

                _isUserNameValid = true;
            }
        }

        private void txtConfirmPassword_EditValueChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;

            if (password != confirm)
            {
                txtConfirmPassword.ErrorText = "كلمة المرور غير متطابقة";
            }
            else
            {

                txtConfirmPassword.ErrorText = "";
            }
        }
    }
}
