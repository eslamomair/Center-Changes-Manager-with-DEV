using CenterChangesManager.BLL;
using CenterChangesManager.Main.Login;
using DevExpress.XtraBars.FluentDesignSystem;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;

namespace CenterChanges
{
    public partial class frmMain : FluentDesignForm
    {

        frmLogin login;

        public frmMain(frmLogin frmLogin)
        {
            login = frmLogin;
            InitializeComponent();
            btnHome_Click(null, null);
        }



        private void NavigateToPage(NavigationPage page, string title = "", string subtitle = "")
        {
            if (page == null) return;

            navigationFrame1.SelectedPage = page;

            if (string.IsNullOrEmpty(subtitle))
                subtitle = "إدارة " + title;

            lblHeaderTitle.Text =
                $"<size=14><b>{title}</b></size><br>" +
                $"<size=10><color=gray>{subtitle}</color></size>";
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            NavigateToPage(navigationPageHome, "اداره المتغيرات المكانية", "الصفحه الرئيسية");
            ctrDashboardChanges1.LoadControl();
        }

        private void btnChangeLog_Click(object sender, EventArgs e)
        {
            NavigateToPage(navigationPageVariablesLog, "اداره المتغيرات المكانيه ", "سجل المتغيرات");
            ctrChangeLog1.StartFillLog();

        }

        private void btnAddChanges_Click(object sender, EventArgs e)
        {
            NavigateToPage(navigationPageAddVariable, "اداره المتغيرات المكانيه", "اضافه متغير جديد");
            ctrAddChange1.StartLoad();
        }

        private void btnEditChange_Click(object sender, EventArgs e)
        {
            int SelectedChangeInChangeLog = ctrChangeLog1.GetSelectedChangeID();
            if (SelectedChangeInChangeLog != -1)
            {
                NavigateToPage(navigationPageEditVariable, "اداره المتغيرات المكانيه", $" {SelectedChangeInChangeLog}  تعديل المتغير رقم  ");
                ctrAddChange2.StartLoad(SelectedChangeInChangeLog);
            }
            else
            {
                XtraMessageBox.Show("لتعديل متغير يجب اختيار متغير من سجل المتغيرات اولا ...سيتم توجيه الى سجل المتغيرات لاختيار متغير لتعديله ", "معلومات ");
                btnChangeLog_Click(null, null);
            }
        }

        private void btnDeleteChange_Click(object sender, EventArgs e)
        {


            int SelectedChangeInChangeLog = ctrChangeLog1.GetSelectedChangeID();
            if (SelectedChangeInChangeLog != -1)
            {

                if (XtraMessageBox.Show($"هل انت متاكد من حذف المتغير رقم {SelectedChangeInChangeLog}  لا يمكن التراجع عن الحذف", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    clsChangesLog.DeletePermanently(SelectedChangeInChangeLog);
                    ctrChangeLog1.StartFillLog();

                }
                else
                    XtraMessageBox.Show("تم التراجع عن عمليه الحذف");

            }
            else
            {
                XtraMessageBox.Show("لتعديل متغير يجب اختيار متغير من سجل المتغيرات اولا ...سيتم توجيه الى سجل المتغيرات لاختيار متغير لتعديله ", "معلومات ");
                btnChangeLog_Click(null, null);
            }
        }

        private void btnAttachments_Click(object sender, EventArgs e)
        {
            ctrChangeLog1.onSelected += CtrChangeLog1_onSelected;

            int ID = ctrChangeLog1.GetSelectedChangeID();
            if (ID != -1)
            {
                NavigateToPage(navigationPageAttachments, "اداره المتغيرات المكانيه", "مرفقات المتغير رقم   " + ID.ToString());
                ctrAttachment1.LoadAttachments(ID);

            }
        }

        private void CtrChangeLog1_onSelected(object sender, int ID)
        {
            //throw new NotImplementedException();
        }

        private void btnCitesAndVillage_Click(object sender, EventArgs e)
        {
            NavigateToPage(navigationPageCitcyAndVilage, "City");
            ctrCity1.InitializeDefaultState();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            NavigateToPage(navigationPageEmployee, "الموظفين ");
            ctrAddEditEmployees1.LoadEmployee();
        }

        private void accordionControlElement13_Click(object sender, EventArgs e)
        {
            NavigateToPage(navigationCompanyInfo, "اعداد بيانات الجهة ");
            ctrCompanySettings1.LoadOrganization(1);
        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
            NavigateToPage(navigationChangeType, "بيانات المخالفات ");
            ctrChangeTypes1.LoadControl();
        }
    }
}
