using CenterChangesManager.Common;
using CenterChangesManager.DAL;
using System.Data;

namespace CenterChangesManager.BLL
{
    public class clsChangesLog
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public ChangesLog? LogData { get; set; } = new ChangesLog();

        // المشيد الافتراضي (لإضافة سجل جديد)
        public clsChangesLog()
        {

            this.LogData.LogID = -1;
            this.LogData.CityID = -1;
            this.LogData.VillageID = -1;
            this.LogData.DependencyID = -1;
            this.LogData.ChangeNumber = "";
            this.LogData.Latitude = 0;
            this.LogData.Longitude = 0;
            this.LogData.ChangeDate = DateTime.Now;
            this.LogData.Address = "";
            this.LogData.LocationStatusID = -1;
            this.LogData.OwnerName = "";
            this.LogData.ChangeTypeID = -1;
            this.LogData.InspectorID = -1;
            this.LogData.Note = "";
            this.LogData.CreatedBy = -1;
            this.LogData.IsActive = true;
            this.Mode = enMode.AddNew;
        }

        // مشيد خاص (يستخدم داخلياً عند البحث Find)
        private clsChangesLog(int? logID, int? cityID, int? villageID, int? dependencyID,
            string? changeNumber, decimal? latitude, decimal? longitude, DateTime? changeDate,
            string? address, int? locationStatusID, string? ownerName, int? changeTypeID,
            int? inspectorID, string? incomingDocs, bool? isActive)
        {
            this.LogData.LogID = logID;
            this.LogData.CityID = cityID;
            this.LogData.VillageID = villageID;
            this.LogData.DependencyID = dependencyID;
            this.LogData.ChangeNumber = changeNumber;
            this.LogData.Latitude = latitude;
            this.LogData.Longitude = longitude;
            this.LogData.ChangeDate = changeDate;
            this.LogData.Address = address;
            this.LogData.LocationStatusID = locationStatusID;
            this.LogData.OwnerName = ownerName;
            this.LogData.ChangeTypeID = changeTypeID;
            this.LogData.InspectorID = inspectorID;
            this.LogData.Note = incomingDocs;
            this.LogData.IsActive = isActive;

            // بما أن البيانات جاءت من قاعدة البيانات، فالوضع هو Update
            this.Mode = enMode.Update;
        }

        // ==========================================
        // دوال البحث (Find)
        // ==========================================
        public static clsChangesLog? Find(int? LogID)
        {
            // تعريف المتغيرات لاستقبال البيانات من الـ ref parameters
            int? cityID = -1, villageID = -1, dependencyID = -1;
            string? changeNumber = "";
            decimal? latitude = 0, longitude = 0;
            DateTime? changeDate = DateTime.Now;
            string? address = "", ownerName = "", Note = "";
            int? locationStatusID = -1, changeTypeID = -1, inspectorID = -1;
            bool? isActive = false;

            if (clsChangesLogData.GetChangesLogByID(LogID, ref cityID, ref villageID, ref dependencyID,
                ref changeNumber, ref latitude, ref longitude, ref changeDate, ref address,
                ref locationStatusID, ref ownerName, ref changeTypeID, ref inspectorID,
                ref Note, ref isActive))
            {
                // إرجاع كائن معبأ بالبيانات
                return new clsChangesLog(LogID, cityID, villageID, dependencyID, changeNumber,
                    latitude, longitude, changeDate, address, locationStatusID, ownerName,
                    changeTypeID, inspectorID, Note, isActive);
            }
            else
            {
                return null;
            }
        }

        public static clsChangesLog? Find(string? ChangeNumber)
        {
            // تعريف المتغيرات لاستقبال البيانات من الـ ref parameters
            int? cityID = -1, villageID = -1, dependencyID = -1;
            int? LogID = 0;
            decimal? latitude = 0, longitude = 0;
            DateTime? changeDate = DateTime.Now;
            string? address = "", ownerName = "", incomingDocs = "";
            int? locationStatusID = -1, changeTypeID = -1, inspectorID = -1;
            bool? isActive = false;

            if (clsChangesLogData.GetChangesLogByChangeNumber(ref LogID, ref cityID, ref villageID, ref dependencyID,
                 ChangeNumber, ref latitude, ref longitude, ref changeDate, ref address,
                ref locationStatusID, ref ownerName, ref changeTypeID, ref inspectorID,
                ref incomingDocs, ref isActive))
            {
                // إرجاع كائن معبأ بالبيانات
                return new clsChangesLog(LogID, cityID, villageID, dependencyID, ChangeNumber,
                    latitude, longitude, changeDate, address, locationStatusID, ownerName,
                    changeTypeID, inspectorID, incomingDocs, isActive);
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
            this.LogData.LogID = clsChangesLogData.AddNewChangesLog(
                this.LogData.CityID, this.LogData.VillageID, this.LogData.DependencyID, this.LogData.ChangeNumber,
                this.LogData.Latitude, this.LogData.Longitude, this.LogData.ChangeDate, this.LogData.Address,
                this.LogData.LocationStatusID, this.LogData.OwnerName, this.LogData.ChangeTypeID,
                this.LogData.InspectorID, this.LogData.Note, this.LogData.CreatedBy);

            return (this.LogData.LogID != -1);
        }

        private bool _Update()
        {
            return clsChangesLogData.UpdateChangesLog(
                this.LogData.LogID, this.LogData.CityID, this.LogData.VillageID, this.LogData.DependencyID,
                this.LogData.ChangeNumber, this.LogData.Latitude, this.LogData.Longitude, this.LogData.ChangeDate,
                this.LogData.Address, this.LogData.LocationStatusID, this.LogData.OwnerName,
                this.LogData.ChangeTypeID, this.LogData.InspectorID, this.LogData.Note,
                this.LogData.LastModifiedBy); // نرسل المستخدم الذي قام بالتعديل
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
