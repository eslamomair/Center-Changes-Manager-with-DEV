using DevExpress.XtraEditors;

namespace CenterChangesManager.Main.Utilities
{
    public static class clsHelperClass
    {

        public static void Success(string message)
        {
            XtraMessageBox.Show(message, "نجاح", (MessageBoxButtons)MessageBoxIcon.Information);
        }

        public static void Error(string message)
        {
            XtraMessageBox.Show(message, "فشل", (MessageBoxButtons)MessageBoxIcon.Error);
        }

        public static bool Confirm(string message)
        {

            return XtraMessageBox.Show(message, "تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
        }
    }
}
