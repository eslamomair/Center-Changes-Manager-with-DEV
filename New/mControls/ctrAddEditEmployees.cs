using CenterChanges.Genraic;
using CenterChangesManager.BLL;

namespace CenterChangesManager.Main.mControls
{
    public partial class ctrAddEditEmployees : DevExpress.XtraEditors.XtraUserControl
    {
        public ctrAddEditEmployees()
        {
            InitializeComponent();
        }

        private void FillEmployee()
        {
            clsGuiHelper.FillCombo(cmbCity, clsInspector.GetAllInspectors(), "InspectorName", "InspectorID");
        }


    }
}
