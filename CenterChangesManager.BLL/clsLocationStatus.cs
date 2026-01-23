using CenterChangesManager.DAL;
using System.Data;

namespace CenterChangesManager.BLL
{
    public class clsLocationStatus
    {
        public int StatusID { get; private set; }
        public string StatusName { get; set; }

        public clsLocationStatus()
        {
            StatusID = -1; // new record
        }

        private clsLocationStatus(int id, string name)
        {
            StatusID = id;
            StatusName = name;
        }

        // ========== جلب كل الحالات ==========
        public static DataTable GetAll()
        {
            return clsLocationStatusesData.GetAllStatuses();
        }

        // ========== جلب حالة واحدة ==========
        public static clsLocationStatus Find(int statusID)
        {
            var result = clsLocationStatusesData.GetStatusByID(statusID);
            if (result == null)
                return null;

            return new clsLocationStatus(result.StatusID, result.StatusName);
        }

        // ========== حفظ (تحديث أو إضافة) ==========
        public bool Save()
        {
            if (StatusID == -1)
            {
                // Add
                StatusID = clsLocationStatusesData.AddNewStatus(StatusName);
                return StatusID > 0;
            }
            else
            {
                // Update
                return clsLocationStatusesData.UpdateStatus(StatusID, StatusName);
            }
        }

        // ========== حذف ==========
        public bool Delete()
        {
            if (StatusID == -1)
                return false;

            return clsLocationStatusesData.DeleteStatus(StatusID);
        }
    }
}
