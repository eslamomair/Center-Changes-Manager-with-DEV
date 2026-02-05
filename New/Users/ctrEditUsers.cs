using CenterChangesManager.BLL;
using CenterChangesManager.Main.Setting_Control;
using CenterChangesManager.Main.Utilities;

namespace CenterChangesManager.Main.Users
{
    public partial class ctrEditUsers : DevExpress.XtraEditors.XtraUserControl
    {
        public ctrEditUsers()
        {
            InitializeComponent();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = gridView1;
            int rowHandel = view.FocusedRowHandle;

            if (rowHandel < 0) return;

            string tag = e.Button.Tag.ToString();

            if (tag == "Edit")
            {
                int userId = Convert.ToInt32(view.GetRowCellValue(rowHandel, "UserData.UserID"));

                // 2. تجهيز شاشة التعديل
                ctrUserManagement userManagement = new ctrUserManagement();
                userManagement.StartUserControl(userId); // تحميل البيانات داخلها
                userManagement.Dock = DockStyle.Fill;    // ملء الفراغ

                // 3. إنشاء نافذة (Container) لتحمل هذه الشاشة
                DevExpress.XtraEditors.XtraForm frmCallback = new DevExpress.XtraEditors.XtraForm();

                // ضبط خصائص النافذة
                frmCallback.Controls.Add(userManagement); // إضافة الشاشة للنافذة
                frmCallback.Size = new Size(900, 650);    // حجم مناسب
                frmCallback.StartPosition = FormStartPosition.CenterScreen; // تظهر في المنتصف
                frmCallback.Text = "تعديل بيانات المستخدم";
                frmCallback.RightToLeft = RightToLeft.Yes; // دعم العربي


                frmCallback.ShowDialog();

                // 5. تحديث الجريد فيو بعد إغلاق شاشة التعديل لرؤية التغييرات
                FillDataGrid();
            }
            else if (tag == "Delete")
            {

                if (clsHelperClass.Confirm("هل انت متاكد من حذف هذا المستخدم "))
                {
                    clsUser.DeleteAsync(rowHandel);
                    clsHelperClass.Success("تم حذف المستخدم بنجاح");
                    view.DeleteRow(rowHandel);
                }




            }
        }

        private async void FillDataGrid()
        {
            var user = await clsUser.GetAllUsersAsync();

            gridControl1.DataSource = user;
        }


        public void StartControl()
        {
            FillDataGrid();
        }
    }
}