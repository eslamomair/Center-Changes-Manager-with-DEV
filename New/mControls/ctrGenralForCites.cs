using CenterChanges.Genraic;
using System.ComponentModel;

namespace CenterChanges.mControls
{
    public partial class ctrItemAll : DevExpress.XtraEditors.XtraUserControl
    {
        public ctrItemAll()
        {
            InitializeComponent();
            cmb.Properties.NullText = string.Empty;

        }

        [Category("My Properties Comb Name")]

        ///النص الموجود فى الكومبوكس

        public string SelectedDisplayText
        {
            get
            {
                return cmb.Text;
            }
        }

        [Category("My Properties Title Name")]
        public string GroupTitle
        {
            get => lGroup.Text;
            set => lGroup.Text = value;
        }
        [Category("My Properties Title Name")]
        public string txtInputTitle
        {
            get => layoutControlItem2.Text;
            set => layoutControlItem2.Text = value;
        }
        [Category("My Properties Title Name")]
        public string cmbInputTitle
        {
            get => layoutControlItem3.Text;
            set =>
                layoutControlItem3.Text = value;

        }
        [Category("My Properties Title Name")]
        public string chkBox
        {
            get => chk.Text;
            set => chk.Text = value;
        }
        [Category("My Properties Title Name")]
        public string btnSaveText
        {
            get => btn.Text;
            set => btn.Text = value;
        }

        [Category("My Properties Selected")]
        public bool IsSelectedCity
        {
            get => chk.Checked;

            set => chk.Checked = value;

        }

        public bool IsChkVisible
        {
            get => chk.Visible;
            set => layoutControlItem5.Visibility = value ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        public bool IscmbVisible
        {
            get => layoutControlItem3.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            set
            {

                chk.Checked = value;

                layoutControlItem3.Visibility = value
                    ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                layoutControlItem2.Visibility = value
                    ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                    : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                layoutControlItem4.Visibility = value
                    ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                    : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        [Category("My Properties")]
        [Description("تغيير لون خلفية رأس الجروب")]
        public Color GroupHeaderForeColor
        {
            get
            {
                return
                    lGroup.AppearanceGroup.ForeColor;

            }
            set
            {
                lGroup.AppearanceGroup.ForeColor = value;
                lGroup.AppearanceGroup.BorderColor = value;
                lGroup.AppearanceGroup.Options.UseForeColor = true;
            }
        }
        [Category("My Properties")]
        public string ItemTextValue
        {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }


        public void FillCombo<T>(List<T> items, string valueMember, string displayMember, bool showOnlyDisplayColumn = true)
        {
            clsGuiHelper.FillCombo(cmb, items, displayMember, valueMember);

            if (showOnlyDisplayColumn)
            {
                cmb.Properties.Columns.Clear();
                cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember));
            }

        }


        public event EventHandler<bool> isSelectedCHK;
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            isSelectedCHK?.Invoke(this, chk.Checked);
            layoutControl1.Refresh();
        }

        public event EventHandler SelectedValueChanged;

        private void cmb_EditValueChanged(object sender, EventArgs e)
        {
            SelectedValueChanged?.Invoke(this, EventArgs.Empty);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            OnSaveClick?.Invoke(this, e);
        }

        private void cmb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                OnEditButtonClick?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnEditButtonClick?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler OnDeleteButtonClick;
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnDeleteButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void cmb_MouseDown(object sender, MouseEventArgs e)
        {
            if (cmb.EditValue == null || cmb.ItemIndex < 0)
            {
                return;
            }
            // 1. التأكد أن الضغطة كليك يمين
            if (e.Button == MouseButtons.Right)
            {
                // 2. إظهار القائمة
                // PointToScreen: مهمة جداً لتحويل مكان الماوس لإحداثيات الشاشة
                popupMenu1.ShowPopup(cmb.PointToScreen(e.Location));

                // (اختياري) لمنع ظهور قائمة النسخ واللصق الافتراضية الخاصة بالويندوز
                var args = e as DevExpress.Utils.DXMouseEventArgs;
                if (args != null) args.Handled = true;
            }
        }

        public event EventHandler OnEditButtonClick;


        public int SelectedId
        {
            get
            {
                if (cmb.EditValue == null) return 0;
                return Convert.ToInt32(cmb.EditValue);
            }
        }


        public event EventHandler OnSaveClick;




    }
}