using CenterChanges.Genraic;
using CenterChangesManager.BLL;
using DevExpress.XtraEditors;
using System.IO;

namespace CenterChanges
{
    public partial class ctrAddChange : DevExpress.XtraEditors.XtraUserControl
    {
        private int EditChange = -1;
        private clsChangesLog _currentLog;
        clsChangeAttachment _changeAttachment;

        public string MessageTitle
        {
            set { _MessageTitle = value; }
            get { return _MessageTitle; }
        }
        private string _MessageTitle;
        enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode;
        public ctrAddChange()
        {
            InitializeComponent();
        }

        private void ResetDefault()
        {
            if (_Mode == enMode.AddNew)
            {
                _currentLog = new clsChangesLog();

                _MessageTitle = "اضافه متغير جديد";
            }
            else
            {
                _MessageTitle = $"تحديث بيانات  المتغير رقم {EditChange} ";
            }

            txtAdress.Text = "";
            txtChangeNumber.Text = "";
            txtLatitude.Text = "";
            txtLongitude.Text = "";
            txtNote.Text = "";
            txtOwner.Text = "";
            cmbChangeType.EditValue = 1;
            cmbCity.EditValue = -1;
            cmbDependency.EditValue = -1;
            cmbLocationStatus.EditValue = 1;
            cmbVillage.EditValue = -1;

        }

        public void StartLoad(int logId = 0, string change = "")
        {

            bool isExist = clsChangesLog.ExistsWithIdOrChange(logId, change);

            if (isExist)
            {
                _Mode = enMode.Update;
                if (!string.IsNullOrEmpty(change))
                {
                    _currentLog = clsChangesLog.Find(change);

                }
                else
                {
                    _currentLog = clsChangesLog.Find(logId);
                }
            }
            else
            {
                _Mode = enMode.AddNew;
            }

            ResetDefault();


            if (_Mode == enMode.Update)
            {
                if (_currentLog != null)
                {
                    _LoadData();

                }
                else
                {
                    XtraMessageBox.Show("خطا فى تحميل البيانات ");
                    return;
                }
            }


        }


        private void _LoadData()
        {

            txtAdress.Text = _currentLog.LogData.Address;
            txtChangeNumber.Text = _currentLog.LogData.ChangeNumber;
            txtNote.Text = _currentLog.LogData.Note;
            txtOwner.Text = _currentLog.LogData.OwnerName;
            txtLatitude.Text = Convert.ToString(_currentLog.LogData.Latitude);
            txtLongitude.Text = Convert.ToString(_currentLog.LogData.Longitude); ;
            cmbCity.EditValue = _currentLog.LogData.CityID ?? -1;
            cmbVillage.EditValue = _currentLog.LogData.VillageID ?? -1;
            cmbDependency.EditValue = _currentLog.LogData.Dependency_ID ?? -1;
            cmbInspector.EditValue = _currentLog.LogData.Inspector_ID;
            cmbChangeType.EditValue = _currentLog.LogData.ChangeType_ID;
            cmbInspector.EditValue = _currentLog.LogData.Inspector_ID;
            dtpDataChange.EditValue = _currentLog.LogData.ChangeDate;

            cmbLocationStatus.EditValue = _currentLog.LogData.LocationStatusID;


        }

        #region Fill cmb

        private void FillCity()
        {
            clsGuiHelper.FillCombo(cmbCity, clsCity.GetAllCities(true), "CityName", "CityID");
        }
        private void FillVillages(int CityID)
        {


            if (CityID == -1)
            {
                // مسح القرى عند اختيار "الكل"
                cmbVillage.Properties.DataSource = null;
                cmbDependency.Properties.DataSource = null;
                return;
            }

            if (cmbCity.EditValue is int Q)
            {
                clsGuiHelper.FillCombo(cmbVillage, clsVillage.GetAllVillagesByCityID(Q, true), "VillageName", "VillageID");

                foreach (DevExpress.XtraEditors.Controls.LookUpColumnInfo col in cmbVillage.Properties.Columns)
                {
                    if (col.FieldName != "VillageName")
                    {
                        col.Visible = false;
                    }
                }

                // 4. إخفاء الهيدر ليكون الشكل نظيفاً
                cmbVillage.Properties.ShowHeader = false;
            }
        }


        private void FillDependency(int VillagesID)
        {


            if (VillagesID == -1)
            {
                // مسح القرى عند اختيار "الكل"
                cmbVillage.Properties.DataSource = null;
                cmbDependency.Properties.DataSource = null;
                return;
            }


            if (cmbVillage.EditValue is int D)
            {
                clsGuiHelper.FillCombo(cmbDependency, clsDependency.GetAllDependenciesByVillageID(D, true), "DependencyName", "Dependency_ID");
            }


            if (cmbDependency.Properties.Columns["Village_ID"] != null)
                cmbDependency.Properties.Columns["Village_ID"].Visible = false;
            cmbVillage.Properties.ShowHeader = false;
        }


        public void FillLocationStatuses()
        {
            cmbLocationStatus.Properties.DataSource = clsLocationStatus.GetAll();
            cmbLocationStatus.Properties.DisplayMember = "StatusName";
            cmbLocationStatus.Properties.ValueMember = "StatusID";

            cmbLocationStatus.Properties.ForceInitialize();
            cmbLocationStatus.Properties.PopulateColumns();

            cmbLocationStatus.Properties.Columns["StatusID"].Visible = false;
            cmbLocationStatus.Properties.ShowHeader = false;
        }

        private void FillChangeTypes()
        {
            cmbChangeType.Properties.DataSource = clsChangeType.GetAllChangeType();
            cmbChangeType.Properties.DisplayMember = "TypeName";
            cmbChangeType.Properties.ValueMember = "TypeID";

            cmbChangeType.Properties.ForceInitialize();
            cmbChangeType.Properties.PopulateColumns();

            cmbChangeType.Properties.Columns["TypeID"].Visible = false;
            cmbChangeType.Properties.ShowHeader = false;
        }


        private void FillInspectors(int cityID)
        {
            // نتأكد إننا عملنا using CenterChangesManager.BLL; فوق
            cmbInspector.Properties.DataSource = clsInspector.GetAllInspectorsByID(cityID);

            cmbInspector.Properties.DisplayMember = "InspectorName";
            cmbInspector.Properties.ValueMember = "Inspector_ID";
            cmbInspector.Properties.ForceInitialize();
            cmbInspector.Properties.PopulateColumns();

            cmbInspector.Properties.ShowHeader = true;

            if (cmbInspector.Properties.Columns["Inspector_ID"] != null)
                cmbInspector.Properties.Columns["Inspector_ID"].Visible = false;

            if (cmbInspector.Properties.Columns["City_ID"] != null)
                cmbInspector.Properties.Columns["City_ID"].Visible = false;

            // ج: تغيير اسم عمود الاسم
            if (cmbInspector.Properties.Columns["InspectorName"] != null)
                cmbInspector.Properties.Columns["InspectorName"].Caption = "الاسم";

            if (cmbInspector.Properties.Columns["Phone"] != null)
                cmbInspector.Properties.Columns["Phone"].Caption = "رقم التليفون";
        }

        #endregion


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            _currentLog.LogData.Address = txtAdress.Text.Trim();
            _currentLog.LogData.ChangeNumber = txtChangeNumber.Text.Trim();
            _currentLog.LogData.Note = txtNote.Text.Trim();
            _currentLog.LogData.OwnerName = txtOwner.Text.Trim();


            if (decimal.TryParse(txtLatitude.Text.Trim(), out decimal L))
                _currentLog.LogData.Latitude = L;
            if (decimal.TryParse(txtLongitude.Text.Trim(), out decimal D))
                _currentLog.LogData.Longitude = D;

            if (cmbCity.EditValue is int CityId && CityId != -1)
                _currentLog.LogData.CityID = CityId;
            else
                _currentLog.LogData.CityID = null;

            if (cmbDependency.EditValue is int DepId && DepId != -1)
                _currentLog.LogData.Dependency_ID = DepId;
            else
                _currentLog.LogData.Dependency_ID = null;

            if (cmbVillage.EditValue is int VId && VId != -1)
                _currentLog.LogData.VillageID = VId;
            else
                _currentLog.LogData.VillageID = null;

            if (cmbInspector.EditValue is int Ins && Ins != -1)
                _currentLog.LogData.Inspector_ID = Ins;
            else _currentLog.LogData.Inspector_ID = -1;

            if (cmbChangeType.EditValue is int ChangeTypeId)
                _currentLog.LogData.ChangeType_ID = ChangeTypeId;
            else
            {
                XtraMessageBox.Show("Critical Error: cmbChangeType value is not a valid Integer. Please contact the developer.", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _currentLog.LogData.ChangeDate = dtpDataChange.DateTime;
            if (_Mode == enMode.AddNew)
            {

                _currentLog.LogData.CreatedBy = 1; // افتكر غيرها 
            }
            else
                _currentLog.LogData.LastModifiedBy = 1;

            if (cmbLocationStatus.EditValue is int LocId)
                _currentLog.LogData.LocationStatusID = LocId;
            else
            {
                XtraMessageBox.Show("Critical Error: LocationStatusID value is not a valid Integer. Please contact the developer.", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (_currentLog.Save())
            {
                if (XtraMessageBox.Show("هل ترغب فى اضافه مرفقات للمتغير الان ", "معلومات", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (AttachFile())
                        XtraMessageBox.Show("تم حفظ المتغير والمرفقات بنجاح ");
                    else
                        XtraMessageBox.Show("تعذر  حفظ المرفقات ", "Error", MessageBoxButtons.AbortRetryIgnore); ;
                }
                else
                {
                    XtraMessageBox.Show($"تم حفظ المتغير {_currentLog.LogData.LogID} بنجاح ");
                }
            }
            else
            {
                XtraMessageBox.Show("تعذر  حفظ المتغير  ", "Error", MessageBoxButtons.AbortRetryIgnore);
            }

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                FillCity();
                FillLocationStatuses();
                FillChangeTypes();

                cmbCity.EditValue = -1;
                cmbChangeType.EditValue = 1;
                cmbLocationStatus.EditValue = 1;
            }
        }

        private void cmbCity_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbCity.EditValue is int CityId && CityId != -1)
            {
                FillVillages(CityId);
                FillInspectors(CityId);
                cmbVillage.EditValue = -1;
                cmbDependency.Properties.DataSource = null;
            }
            else
            {
                cmbVillage.Properties.DataSource = null;
                cmbDependency.Properties.DataSource = null;
            }
        }

        private void cmbVillage_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbVillage.EditValue is int VillaId && VillaId != -1)
            {
                FillDependency(VillaId);
                cmbDependency.EditValue = -1;
            }
            else
            {
                cmbDependency.Properties.DataSource = null;
            }
        }

        private bool AttachFile()
        {
            if (xtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string FileName = xtraOpenFileDialog1.FileName;

                try
                {
                    _changeAttachment = new clsChangeAttachment();
                    _changeAttachment.Log_ID = _currentLog.LogData.LogID;
                    _changeAttachment.FileName = Path.GetFileName(FileName);
                    _changeAttachment.FileExtension = Path.GetExtension(FileName);
                    FileInfo info = new FileInfo(FileName);
                    _changeAttachment.FileSize = (int)info.Length;
                    _changeAttachment.UploadedBy = 1;//clsGlobal.CurrentUser.UserData.UserID;
                    byte[] FileBytes = File.ReadAllBytes(FileName);

                    if (_changeAttachment.Save(FileBytes))
                    {
                        return true;
                    }

                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
