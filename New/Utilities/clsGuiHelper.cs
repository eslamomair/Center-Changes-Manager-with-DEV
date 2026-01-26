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


        // دي دالة جديدة بنفس الاسم بس بتقبل DataTable
        public static void FillCombo(DevExpress.XtraEditors.LookUpEdit cmb, System.Data.DataTable data, string displayMember, string valueMember)
        {
            cmb.Properties.DataSource = data;
            cmb.Properties.DisplayMember = displayMember;
            cmb.Properties.ValueMember = valueMember;

            // 2. إنشاء الأعمدة بناءً على الداتا سورس
            cmb.Properties.PopulateColumns();

            // 3. (حل المشكلة الثانية) إخفاء رؤوس الأعمدة
            cmb.Properties.ShowHeader = false;

            // 4. إخفاء عمود الـ ID (الذي هو valueMember) لكي لا يظهر للمستخدم
            if (cmb.Properties.Columns[valueMember] != null)
            {
                cmb.Properties.Columns[valueMember].Visible = false;
            }

            // 5. ضبط العرض القسري (اختياري) لضمان ظهور النص
            // هذا يضمن أن العمود الظاهر الوحيد هو الـ DisplayMember
            cmb.Properties.ForceInitialize();
        }
    }
}