using CenterChangesManager.Common;
using CenterChangesManager.DAL;

namespace CenterChangesManager.BLL
{
    public class clsDependency
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public Dependency DataDependency { get; set; }

        public clsDependency()
        {
            DataDependency = new Dependency();
            this.DataDependency.DependencyID = -1;
            this.DataDependency.DependencyName = "";
            this.DataDependency.Village_ID = -1;
            this.Mode = enMode.AddNew;
        }

        private clsDependency(int id, string name, int villageId)
        {
            DataDependency = new Dependency();
            this.DataDependency.DependencyID = id;
            this.DataDependency.DependencyName = name;
            this.DataDependency.Village_ID = villageId;
            this.Mode = enMode.Update;
        }

        public static clsDependency Find(int id)
        {
            string name = "";
            int villageId = -1;
            if (clsDependencyData.GetDependencyInfoByID(id, ref name, ref villageId))
                return new clsDependency(id, name, villageId);
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
            this.DataDependency.DependencyID = clsDependencyData.AddNew(this.DataDependency.DependencyName, this.DataDependency.Village_ID);
            return (this.DataDependency.DependencyID != -1);
        }

        private bool _Update()
        {
            return clsDependencyData.Update(this.DataDependency.DependencyID, this.DataDependency.DependencyName, this.DataDependency.Village_ID);
        }

        public static bool Delete(int id)
        {
            return clsDependencyData.Delete(id);
        }

        public static List<Dependency> GetAllDependenciesByVillageID(int villageID, bool AddTextAll = false)
        {
            var D = clsDependencyData.GetAllDependenciesByVillageID(villageID);

            if (AddTextAll)
            {
                D.Insert(0, new Dependency { DependencyID = -1, DependencyName = "--الكل--", Village_ID = -1 });
            }
            return D;
        }

        public static bool IsExist(string? name = null, int? ID = null)
        {
            return clsDependencyData.IsExist(name, ID);
        }
    }
}