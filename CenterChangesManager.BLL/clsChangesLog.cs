using CenterChangesManager.Common;
using CenterChangesManager.DAL;
using System.Data;

namespace CenterChangesManager.BLL
{
    public class clsChangesLog
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public ChangesLog? LogData { get; set; }

        // المشيد الافتراضي (لإضافة سجل جديد)
        public clsChangesLog()
        {

            this.LogData = new ChangesLog();
            this.Mode = enMode.AddNew;
        }

        // مشيد خاص (يستخدم داخلياً عند البحث Find)
        private clsChangesLog(ChangesLog logObj)
        {
            this.LogData = logObj;

            // بما أن البيانات جاءت من قاعدة البيانات، فالوضع هو Update
            this.Mode = enMode.Update;
        }

        // ==========================================
        // دوال البحث (Find)
        // ==========================================
        public static clsChangesLog? Find(int? LogID)
        {

            ChangesLog? foundLog = clsChangesLogData.GetChangesLogByID(LogID);
            if (foundLog != null)
            {
                // إرجاع كائن معبأ بالبيانات
                return new clsChangesLog(foundLog);
            }
            else
            {
                return null;
            }
        }

        public static clsChangesLog? Find(string? ChangeNumber)
        {
            ChangesLog? log = clsChangesLogData.GetChangesLogByChangeNumber(ChangeNumber);

            if (log != null)
            {
                // إرجاع كائن معبأ بالبيانات
                return new clsChangesLog(log);
            }
            else
            {
                return null;
            }
        }


        // ==========================================
        // دالة الحفظ (Save)
        // ==========================================
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        private bool _AddNew()
        {
            this.LogData.LogID = clsChangesLogData.AddNewChangesLog(this.LogData);

            return (this.LogData.LogID != -1);
        }

        private bool _Update()
        {
            return clsChangesLogData.UpdateChangesLog(this.LogData);
        }

        // ==========================================
        // دوال الحذف والتحقق والقوائم
        // ==========================================

        // حذف ناعم (Soft Delete)
        public bool Delete(string? deletedBy)
        {
            return clsChangesLogData.DeleteChangesLog(this.LogData.LogID, deletedBy);
        }

        // حذف نهائي (Static لأنه لا يحتاج تحميل الكائن)
        public static bool DeletePermanently(int? logID)
        {
            return clsChangesLogData.PermanentDeleteChangesLog(logID);
        }

        public static DataTable GetAllChangesLogs()
        {
            return clsChangesLogData.GetAllChangesLog();
        }

        public static DataTable SearchByChangeNumber(string? changeNumber)
        {
            return clsChangesLogData.SearchByChangeNumber(changeNumber);
        }

        public static bool IsChangeNumberExists(string? changeNumber, int? excludeLogID = -1)
        {
            return clsChangesLogData.IsChangeNumberExists(changeNumber, excludeLogID);
        }

        public static DataTable GetFilteredChanges(DateTime? fromDate, DateTime? toDate, int? cityId, int? typeId)
        {
            // دالة بسيطة تمرر القيم للـ DAL
            return clsChangesLogData.GetChangesLogByFilter(fromDate, toDate, cityId, typeId);
        }

        public static List<ChangesLog> GetChangesList()
        {
            return clsChangesLogData.GetListAllChangesLog();
        }


        public static bool ExistsWithIdOrChange(int ID, string Chane)
        {
            return clsChangesLogData.Exists(ID, Chane);
        }
    }
}
