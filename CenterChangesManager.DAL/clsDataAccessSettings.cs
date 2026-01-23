using System.Configuration;

namespace CenterChangesManager.DAL
{
    public static class clsDataAccessSettings
    {
        public static readonly string? ConnectionString;

        // هذا هو الـ Static Constructor - يعمل مرة واحدة فقط عند تشغيل التطبيق
        static clsDataAccessSettings()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["SpatialChangesDB"]?.ConnectionString;
        }
    }
}
