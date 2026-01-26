using CenterChanges.Genraic;
using CenterChangesManager.BLL;
using DevExpress.XtraEditors;

namespace CenterChangesManager.Main.mControls
{
    public partial class ctrAddEditEmployees : DevExpress.XtraEditors.XtraUserControl
    {
        private enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode;
        clsInspector _CurrentEmployee;
        private int _ID;
        public ctrAddEditEmployees()
        {
            InitializeComponent();
        }

        private void FillCites()
        {
            clsGuiHelper.FillCombo(cmbCity, clsCity.GetAllCities(), "CityName", "CityID");

        }

        private void FillDataGrid()
        {
            gridControl1.DataSource = clsInspector.GetAllIspectorandCityName();

            // أولاً: إخفاء عمود آي دي المدينة
            if (gridView1.Columns["City_ID"] != null)
            {
                gridView1.Columns["City_ID"].Visible = false;
            }

            // ثانياً: تعريب أسماء الأعمدة
            if (gridView1.Columns["InspectorName"] != null)
            {
                gridView1.Columns["InspectorName"].Caption = "اسم الموظف";
            }

            if (gridView1.Columns["Phone"] != null)
            {
                gridView1.Columns["Phone"].Caption = "رقم الهاتف";
            }

            if (gridView1.Columns["City"] != null)
            {
                gridView1.Columns["City"].Caption = "المدينة / القرية";
            }


            if (gridView1.Columns["Inspector_ID"] != null)
            {
                gridView1.Columns["Inspector_ID"].Visible = false;
            }

        }

        private void ResetDefault()
        {
            if (_Mode == enMode.AddNew)
            {
                _CurrentEmployee = new clsInspector();

            }

            txtFullName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            FillCites();
            FillDataGrid();
        }

        private void _LoadData()
        {
            _CurrentEmployee = clsInspector.Find(_ID);

            if (_CurrentEmployee == null)
            {
                XtraMessageBox.Show("تعذر تحميل بيانات الموظف  ");
                return;
            }

            txtFullName.Text = _CurrentEmployee.InspectorName;
            txtPhone.Text = _CurrentEmployee.Phone;
            cmbCity.EditValue = _CurrentEmployee.City_ID;
        }

        public void LoadEmployee(int? ID = null)
        {
            _Mode = ID.HasValue ? enMode.Update : enMode.AddNew;
            ResetDefault();
            if (_Mode == enMode.Update)
            {
                _ID = Convert.ToInt32(ID);

                _LoadData();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (cmbCity.EditValue == null || !(cmbCity.EditValue is int))
            {
                XtraMessageBox.Show("من فضلك اختر المدينة/القرية", "خطأ في الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _CurrentEmployee.InspectorName = txtFullName.Text.Trim();
            _CurrentEmployee.Phone = txtPhone.Text.Trim();
            if (cmbCity.EditValue is int CityID && CityID > 0)
            {
                _CurrentEmployee.City_ID = CityID;

            }


            if (_CurrentEmployee.Save())
            {
                XtraMessageBox.Show("تم حفظ بيانات الموظف بنجاح", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                ResetDefault();
            }
            else
            {
                XtraMessageBox.Show("حدث خطأ أثناء عملية الحفظ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view.FocusedRowHandle >= 0)
            {
                int ID = Convert.ToInt32(view.GetFocusedRowCellValue("Inspector_ID"));
                _ID = ID;
                _LoadData();
            }
        }
    }
}
