using CenterChanges.Genraic;
using CenterChangesManager.BLL;
using CenterChangesManager.Common;

namespace CenterChanges
{
    public partial class ctrChangeLog : DevExpress.XtraEditors.XtraUserControl
    {
        public delegate void OnSelectedChangeID(object sender, int ID);
        public event OnSelectedChangeID onSelected;
        public int GetSelectedChangeID()
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                object Row = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LogID");

                if (Row != null && int.TryParse(Row.ToString(), out int Id))
                {
                    onSelected?.Invoke(this, Id);
                    return Id;
                }

            }
            return -1;
        }

        public string GetChangeNumberSelected()
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                object row = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ChangeNumber");

                if (row != null)
                {
                    return row.ToString();
                }
            }
            return "";
        }

        private List<ChangesLog> _originalData;
        public ctrChangeLog()
        {
            InitializeComponent();

        }

        private void FillDGV()
        {
            _originalData = clsChangesLog.GetChangesList();
            gridControl1.DataSource = _originalData;
            FillCittes();

            //  lblResultCount.Text = $"النتائج: {_dataView.Count}";// عرض عدد النتائج
        }


        #region Fillcmb
        private void FillCittes()
        {


            clsGuiHelper.FillCombo(cmbCity, clsCity.GetAllCities(true), "CityName", "CityID");



        }

        private void FillVaillages(int CityID)
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
                clsGuiHelper.FillCombo(cmbVillage, clsVillage.GetAllVillagesByCityID(Q, true), "VillageName", "Village_ID");
            }


        }


        private void FillDependency(int VailageID)
        {


            if (VailageID == -1)
            {
                // مسح القرى عند اختيار "الكل"
                cmbVillage.Properties.DataSource = null;
                cmbDependency.Properties.DataSource = null;
                return;
            }


            if (cmbVillage.EditValue is int D)
            {
                clsGuiHelper.FillCombo(cmbDependency, clsDependency.GetAllDependenciesByVillageID(D, true), "DependencyName", "DependencyID");
            }


        }

        #endregion

        private void cmbCity_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbCity.EditValue != null && cmbCity.EditValue is int cityID)
            {
                if (cityID != -1)
                    FillVaillages(cityID);
                cmbVillage.EditValue = -1;
                FilterData();
            }
        }


        void FilterData()
        {
            // بنبدأ بفلتر فاضي
            string filterString = "";

            // 1. فلترة المدينة
            // نتأكد إنه مختار قيمة، وإن القيمة دي مش "الكل" (-1)
            if (cmbCity.EditValue != null && Convert.ToInt32(cmbCity.EditValue) != -1)
            {
                // [CityID] ده هو اسم العمود (FieldName) في الجريد فيو
                filterString += $"[CityID] = {cmbCity.EditValue}";
            }

            // 2. فلترة القرية
            if (cmbVillage.EditValue != null && Convert.ToInt32(cmbVillage.EditValue) != -1)
            {
                // لو كان فيه شرط قبله (زي المدينة)، لازم نحط AND
                if (filterString != "") filterString += " AND ";

                filterString += $"[Village_ID] = {cmbVillage.EditValue}";
            }

            if (cmbDependency.EditValue != null && Convert.ToInt32(cmbDependency.EditValue) != -1)
            {
                if (filterString != "") filterString += " AND ";

                filterString += $"[DependencyID] = {cmbDependency.EditValue}";
            }

            // 3. تطبيق الفلتر على الجريد
            gridView1.ActiveFilterString = filterString;
        }

        private void cmbDependency_EditValueChanged(object sender, EventArgs e)
        {


            FilterData();


        }

        private void cmbVillage_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbVillage.EditValue != null && cmbVillage.EditValue is int villageID)
            {
                if (villageID != -1)
                    FillDependency(villageID);
                cmbDependency.EditValue = -1;
            }

        }

        public void StartFillLog()
        {
            FillDGV();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                object Row = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LogID");

                if (Row != null && int.TryParse(Row.ToString(), out int Id))
                {
                    onSelected?.Invoke(this, Id);

                }

            }

        }
    }
}