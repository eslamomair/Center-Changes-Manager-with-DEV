using DevExpress.XtraEditors;

namespace CenterChangesManager.Main.Utilities
{
    public static class clsMessageDialogHelper
    {

        public static void Success(string message)
        {
            XtraMessageBox.Show(message, "نجاح", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        public static void Error(string message)
        {
            XtraMessageBox.Show(message, "فشل", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        public static bool Confirm(string message)
        {

            return XtraMessageBox.Show(message, "تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
        }

        public static void ShowMessage(string message, string title = "معلومه")
        {
            XtraMessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}
