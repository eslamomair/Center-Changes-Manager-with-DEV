using CenterChangesManager.Main.Login;
using DevExpress.XtraEditors;
namespace CenterChanges
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            WindowsFormsSettings.SetDPIAware();
            // الاستدعاء الصحيح للدالة بإرسال القيمة داخل الأقواس
            Application.Run(new frmLogin());
        }
    }
}
