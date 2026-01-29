using CenterChangesManager.BLL.Global;
using DevExpress.XtraEditors;
using System.IO;

namespace CenterChangesManager.Main.Setting_Control
{
    public partial class ctrCompanySettings : DevExpress.XtraEditors.XtraUserControl
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode;
        clsOrganization Organization;
        int ID;
        public ctrCompanySettings()
        {
            InitializeComponent();
        }


        private void ReseatDefault()
        {
            if (Mode == enMode.AddNew)
            {
                Organization = new clsOrganization();
            }


            txtAboutDept.Text = string.Empty;
            txtDeptName.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            txtFullAddress.Text = string.Empty;
            txtOrgName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtSubDeptName.Text = string.Empty;
            pbOrgLogo.Image = null;

        }

        private void _LoadData()
        {
            Organization = clsOrganization.GetOrganization();

            if (Organization == null)
            {
                XtraMessageBox.Show("خطا فى تحميل البيانات ");
            }

            txtAboutDept.Text = Organization.Org.AboutDept;
            txtDeptName.Text = Organization.Org.DeptName;
            txtEmailAddress.Text = Organization.Org.EmailAddress;
            txtFullAddress.Text = Organization.Org.FullAddress;
            txtOrgName.Text = Organization.Org.OrgName;
            txtPhoneNumber.Text = Organization.Org.PhoneNumber;
            txtSubDeptName.Text = Organization.Org.SubDeptName;


            if (Organization.Org.OrgLogo != null && Organization.Org.OrgLogo.Length > 0)
            {
                // إنشاء مخزن مؤقت (Stream) ووضع مصفوفة البايتات بداخله
                using (MemoryStream ms = new MemoryStream(Organization.Org.OrgLogo))
                {
                    // تحويل البيانات من الـ Stream إلى كائن Image وعرضه في أداة الـ PictureEdit
                    pbOrgLogo.Image = Image.FromStream(ms);
                }
            }
            else
            {
                // في حال عدم وجود صورة في قاعدة البيانات، يفضل وضع صورة افتراضية أو مسح الأداة
                pbOrgLogo.Image = null;
            }

        }

        public void LoadOrganization(int ID = 0)
        {
            Mode = (ID == 0) ? enMode.AddNew : enMode.Update;

            ReseatDefault();
            if (Mode == enMode.Update)
            {
                this.ID = ID;
                _LoadData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (true)
            {
                return;
            }


            Organization.Org.AboutDept = txtAboutDept.Text.Trim();
            Organization.Org.DeptName = txtDeptName.Text.Trim();
            Organization.Org.EmailAddress = txtEmailAddress.Text.Trim();
            Organization.Org.FullAddress = txtFullAddress.Text.Trim();
            Organization.Org.OrgName = txtOrgName.Text.Trim();
            Organization.Org.PhoneNumber = txtPhoneNumber.Text.Trim();
            Organization.Org.SubDeptName = txtSubDeptName.Text.Trim();

            if (pbOrgLogo.Image != null)
            {


                using (MemoryStream ms = new MemoryStream())
                {

                    pbOrgLogo.Image.Save(ms, pbOrgLogo.Image.RawFormat);

                    Organization.Org.OrgLogo = ms.ToArray();

                }

            }
            else
            {
                Organization.Org.OrgLogo = null;
            }

            if (Organization.Save())
            {
                MessageBox.Show("تم حفظ بيانات الإدارة بنجاح", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ، يرجى المحاولة مرة أخرى", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Mode = enMode.AddNew;
            ReseatDefault();
        }

        private void btnOrgLogo_Click(object sender, EventArgs e)
        {
            using (XtraOpenFileDialog df = new XtraOpenFileDialog())
            {

                df.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (df.ShowDialog() == DialogResult.OK)
                {
                    pbOrgLogo.Image = Image.FromFile(df.FileName);
                }
                else
                    pbOrgLogo.Image = null;
            }
        }
    }
}
