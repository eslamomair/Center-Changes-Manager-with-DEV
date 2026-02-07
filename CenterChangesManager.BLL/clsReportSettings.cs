using CenterChangesManager.Common;
using CenterChangesManager.DAL;

namespace CenterChangesManager.BLL
{
    public class clsReportSettings
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode;
        public ReportSettings ReportData { get; set; }

        public clsReportSettings()
        {
            ReportData = new ReportSettings();
            Mode = enMode.AddNew;
        }


        private clsReportSettings(ReportSettings report)
        {
            ReportData = report;
            Mode = enMode.Update;
        }

        // دالة لاستدعاء الإعدادات وعرضها
        public static clsReportSettings GetCurrentSettings()
        {
            var settings = clsReportSettingsData.GetActiveSettings();

            // لو لم نجد إعدادات (لأول مرة)، نرجع كلاس فارغ لتجنب الأخطاء
            if (settings == null)
                return new clsReportSettings();

            return new clsReportSettings(settings);
        }


        private bool _AddNew()
        {
            this.ReportData.IsActive = true;
            this.ReportData.CreatedAt = DateTime.Now;
            this.ReportData.UpdatedAt = DateTime.Now;
            this.ReportData.ID = clsReportSettingsData.AddNew(ReportData);

            return this.ReportData.ID > -1;
        }

        private bool _Update()
        {
            this.ReportData.UpdatedAt = DateTime.Now;
            return clsReportSettingsData.Update(this.ReportData);
        }


        public bool Save()
        {
            return _AddNew();

        }
    }
}
