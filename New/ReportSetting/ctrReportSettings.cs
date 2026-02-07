using CenterChangesManager.BLL;
using CenterChangesManager.Main.Utilities;

namespace CenterChangesManager.Main.ReportSetting
{
    public partial class ctrReportSettings : DevExpress.XtraEditors.XtraUserControl
    {

        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode;
        int ID;
        private clsReportSettings _settings;
        public ctrReportSettings()
        {
            InitializeComponent();
        }

        private void ReseatDefaultsValues()
        {
            if (Mode == enMode.AddNew)
            {
                _settings = new clsReportSettings();
            }

            txtGovernorateName.Text = string.Empty;
            txtCenterName.Text = string.Empty;
            txtSubCenterName.Text = string.Empty;
            txtDepartmentName.Text = string.Empty;
            txtRecipientRank.Text = string.Empty;
            txtRecipientJobTitle.Text = string.Empty;
            txtRecipientEntityName.Text = string.Empty;
            txtTechName.Text = string.Empty;
            txtManagerName.Text = string.Empty;
            txtCenterHeadName.Text = string.Empty;
        }

        private void chkIsSubCenterVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsSubCenterVisible.Checked)
            {
                txtSubCenterName.Enabled = true;
            }
            else
                txtSubCenterName.Enabled = false;
        }

        public void _LoadData()
        {
            _settings = clsReportSettings.GetCurrentSettings();

            if (_settings == null)
            {
                clsMessageDialogHelper.Error("خطا فى تحميل البيانات ");
                return;
            }


            txtGovernorateName.Text = _settings.ReportData.GovernorateName;
            txtCenterName.Text = _settings.ReportData.CenterName;
            //  txtSubCenterName.Text             = _settings.ReportData.SubCenterName;
            txtDepartmentName.Text = _settings.ReportData.DepartmentName;
            txtRecipientRank.Text = _settings.ReportData.RecipientRank;
            txtRecipientJobTitle.Text = _settings.ReportData.RecipientJobTitle;
            txtRecipientEntityName.Text = _settings.ReportData.RecipientEntityName;
            txtTechName.Text = _settings.ReportData.TechName;
            txtManagerName.Text = _settings.ReportData.ManagerName;
            txtCenterHeadName.Text = _settings.ReportData.CenterHeadName;
            chkIsSubCenterVisible.Checked = _settings.ReportData.IsSubCenterVisible;
            txtSubCenterName.Text = chkIsSubCenterVisible.Checked ? _settings.ReportData.SubCenterName : "";
        }

        public void StartControl(int id = 0)
        {
            Mode = (id == 0) ? enMode.AddNew : enMode.Update;
            ReseatDefaultsValues();
            if (Mode == enMode.Update)
            {

                ID = id;
                _LoadData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _settings.ReportData.GovernorateName = txtGovernorateName.Text.Trim();
            _settings.ReportData.CenterName = txtCenterName.Text.Trim();

            _settings.ReportData.DepartmentName = txtDepartmentName.Text.Trim();
            _settings.ReportData.RecipientRank = txtRecipientRank.Text.Trim();
            _settings.ReportData.RecipientJobTitle = txtRecipientJobTitle.Text.Trim();
            _settings.ReportData.RecipientEntityName = txtRecipientEntityName.Text.Trim();
            _settings.ReportData.TechName = txtTechName.Text.Trim();
            _settings.ReportData.ManagerName = txtManagerName.Text.Trim();
            _settings.ReportData.CenterHeadName = txtCenterHeadName.Text.Trim();
            _settings.ReportData.IsSubCenterVisible = chkIsSubCenterVisible.Checked;

            _settings.ReportData.SubCenterName = chkIsSubCenterVisible.Checked ? txtSubCenterName.Text.Trim() : "";

            if (_settings.Save())
            {
                clsMessageDialogHelper.Success("تم حفظ البيانات بنجاح ");
                Mode = enMode.Update;
            }
            else
            {
                clsMessageDialogHelper.Error("تعذر حفظ البيانات ");
            }

        }

    }
}
