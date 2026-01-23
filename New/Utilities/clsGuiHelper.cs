using DevExpress.XtraEditors;

namespace CenterChanges.Genraic
{
    public class clsGuiHelper
    {

        public static void FillCombo<T>(LookUpEdit cmb, List<T> DataList, string displayMember, string valueMember)
        {
            cmb.Properties.DataSource = null;

            if (DataList == null || DataList.Count == 0) return;

            cmb.Properties.DataSource = DataList;
            cmb.Properties.ValueMember = valueMember;
            cmb.Properties.DisplayMember = displayMember;

            //cmb.Properties.NullText = "---الكل---";

            ////اضافه زر لمسح الاختيار 
            //bool hasDeleteButton = false;

            //foreach (EditorButton btn in cmb.Properties.Buttons)
            //{
            //    if (btn.Kind == ButtonPredefines.Delete)
            //    {
            //        hasDeleteButton = true;
            //        break;
            //    }
            //}

            //if (!hasDeleteButton)
            //{
            //    EditorButton btnDelete = new EditorButton(ButtonPredefines.Delete);
            //    btnDelete.ToolTip = "مسح الاختيار ( اختيار الكل)";
            //    cmb.Properties.Buttons.Add(btnDelete);
            //}


            //cmb.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;

            cmb.Properties.ForceInitialize();
            cmb.Properties.PopulateColumns();

            if (cmb.Properties.Columns[valueMember] != null)
            {
                cmb.Properties.Columns[valueMember].Visible = false;
            }

            cmb.Properties.ShowHeader = false;
        }
    }
}