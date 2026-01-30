using CenterChangesManager.BLL;
using DevExpress.XtraEditors;
using System.Data;

namespace CenterChangesManager.Main.Setting_Control
{
    public partial class ctrChangeTypes : DevExpress.XtraEditors.XtraUserControl
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode;
        int ID;
        clsChangeType type;
        public ctrChangeTypes()
        {
            InitializeComponent();
        }


        private void ResetDefaultValue()
        {
            if (Mode == enMode.AddNew)
            {
                type = new clsChangeType();

            }

            txtChangeType.Text = string.Empty;
            FillChangeTypeGrid();
        }

        private void FillChangeTypeGrid()
        {
            DataTable dt = new DataTable();
            dt = clsChangeType.GetAllChangeType();

            gridControl1.DataSource = dt;

            if (gridView1.Columns["TypeID"] != null)
            {

                gridView1.Columns["TypeID"].Visible = false;
            }

            gridView1.Columns["TypeName"].Caption = "أنواع المتغيرات ";

        }

        private void _LoadData()
        {
            if (ID <= 0)
            {
                XtraMessageBox.Show("خطا فى استرجاع البيانات ");
                return;

            }

            type = clsChangeType.Find(ID);

            if (type != null)
            {
                txtChangeType.Text = type.ChangeTypeName;

            }
            else
            {
                XtraMessageBox.Show("خطا فى استرجاع البيانات ");
            }
        }

        public void LoadControl(int ID = 0)
        {
            Mode = (ID == 0) ? enMode.AddNew : enMode.Update;
            ResetDefaultValue();
            if (Mode == enMode.Update)
            {
                this.ID = ID;
                _LoadData();
            }


        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (e.FocusedRowHandle < 0)
            {
                return;
            }

            ID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("TypeID"));

            _LoadData();

        }

        private void SaveAll()
        {
            type.ChangeTypeName = txtChangeType.Text.Trim();

            if (type.SaveChangeType())
            {
                XtraMessageBox.Show("تم حفظ البيانات بنجاح");
                Mode = enMode.AddNew;
                ResetDefaultValue();

            }
            else
                XtraMessageBox.Show("تعذر  حفظ البيانات  ");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtChangeType.Text))
            {
                XtraMessageBox.Show("لا يمكن حفظ بيانات فارغه ");
                return;
            }

            SaveAll();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("هل انت متاكد من حذف هذه القميه ", "تنيبه", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsChangeType.DELETEChangeType(ID))
                {
                    XtraMessageBox.Show("تم الحذف بنجاح ");
                    ResetDefaultValue();
                }
                else
                {
                    XtraMessageBox.Show("تعذرت عمليه الحذف ");
                }
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }
    }
}
