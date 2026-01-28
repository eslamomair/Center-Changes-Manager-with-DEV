using CenterChangesManager.DAL;
using System.Data;

namespace CenterChangesManager.BLL
{
    public class clsInspector
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int InspectorID { get; set; }
        public string InspectorName { get; set; }
        public int City_ID { get; set; }
        public string Phone { get; set; }
        public int? Village_ID { get; set; }
        public clsInspector()
        {
            this.InspectorID = -1;
            this.InspectorName = "";
            this.City_ID = -1;
            this.Phone = "";
            this.Village_ID = null;
            this.Mode = enMode.AddNew;
        }

        private clsInspector(int id, string name, int cityid, string phone, int VillageID)
        {
            this.InspectorID = id;
            this.InspectorName = name;
            this.City_ID = cityid;
            this.Phone = phone;
            this.Village_ID = VillageID;
            this.Mode = enMode.Update;
        }

        public static clsInspector Find(int id)
        {
            string name = "", phone = "";
            int cityid = -1, Village_ID = -1;
            if (clsInspectorData.GetInspectorInfoByID(id, ref name, ref cityid, ref phone, ref Village_ID))
                return new clsInspector(id, name, cityid, phone, Village_ID);
            else return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew()) { Mode = enMode.Update; return true; } else return false;
                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        private bool _AddNew()
        {
            this.InspectorID = clsInspectorData.AddNew(this.InspectorName, this.City_ID, this.Phone, this.Village_ID);
            return (this.InspectorID != -1);
        }

        private bool _Update()
        {
            return clsInspectorData.Update(this.InspectorID, this.InspectorName, this.City_ID, this.Phone, this.Village_ID);
        }

        public static bool Delete(int id)
        {
            return clsInspectorData.Delete(id);
        }

        public static DataTable GetAllInspectors()
        {
            return clsInspectorData.GetAllInspectors();
        }
        public static DataTable GetAllInspectorsByID(int CityID)
        {
            return clsInspectorData.GetAllInspectorsByCityID(CityID);
        }

        public static DataTable GetAllIspectorandCityName()
        {
            return clsInspectorData.GetIspectorAndCity();
        }


        /// ارجاع جميع الموظفين بناء على معرف المدينه 
        public static DataTable GetVillageInspectorsByCity(int cityid)
        {
            return clsInspectorData.GetVillageInspectorsByCity(cityid);
        }

    }
}