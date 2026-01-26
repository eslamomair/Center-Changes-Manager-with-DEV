using CenterChangesManager.Common;
using CenterChangesManager.DAL;

namespace CenterChangesManager.BLL
{
    public class clsVillage
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public Village DataVillage { get; set; }

        public clsVillage()
        {
            DataVillage = new Village();
            this.DataVillage.VillageID = -1;
            this.DataVillage.VillageName = "";
            this.DataVillage.CityID = -1;
            this.Mode = enMode.AddNew;
        }

        private clsVillage(int id, string? name, int? cityId)
        {
            DataVillage = new Village();
            this.DataVillage.VillageID = id;
            this.DataVillage.VillageName = name;
            this.DataVillage.CityID = cityId;
            this.Mode = enMode.Update;
        }

        public static clsVillage Find(int id)
        {
            string? name = "";
            int? cityId = -1;
            if (clsVillageData.GetVillageInfoByID(id, ref name, ref cityId))
                return new clsVillage(id, name, cityId);
            else
                return null;
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
            this.DataVillage.VillageID = clsVillageData.AddNew(this.DataVillage.VillageName, this.DataVillage.CityID);
            return (this.DataVillage.VillageID != -1);
        }

        private bool _Update()
        {
            return clsVillageData.Update(this.DataVillage.VillageID, this.DataVillage.VillageName, this.DataVillage.CityID);
        }

        public static bool Delete(int id)
        {
            return clsVillageData.Delete(id);
        }

        public static List<Village> GetAllVillagesByCityID(int cityID, bool addTextAll = false)
        {
            var c = clsVillageData.GetAllVillagesByCityID(cityID);
            if (addTextAll)
            {
                c.Insert(0, new Village { CityID = -1, VillageID = -1, VillageName = "--الكل--" });
                return c;
            }
            return c;
        }
        public static List<Village> GetAllVillages(bool addTextAll = false)
        {
            var c = clsVillageData.GetAllVillages();
            if (addTextAll)
            {
                c.Insert(0, new Village { CityID = -1, VillageID = -1, VillageName = "--الكل--" });
                return c;
            }
            return c;
        }

        public static bool IsExist(int? ID = null, string? VillageName = null)
        {
            return clsVillageData.IsExist(ID, VillageName);
        }
    }
}