using CenterChangesManager.DAL;
using System.Data;

namespace CenterChangesManager.BLL
{
    public class clsChangeType
    {
        public enum enChangeType
        {
            AddNew = 1,
            Update = 2
        }
        public enChangeType Mode;

        public int ChangeTypeID { get; set; }
        public string ChangeTypeName { get; set; }

        public clsChangeType()
        {
            ChangeTypeID = 0;
            ChangeTypeName = string.Empty;
            Mode = enChangeType.AddNew;
        }

        public clsChangeType(int changeTypeID, string changeTypeName)
        {
            ChangeTypeID = changeTypeID;
            ChangeTypeName = changeTypeName;
            Mode = enChangeType.Update;
        }

        private bool _ADDChangeType()
        {
            int newId = DAL.clsChangeTypeData.AddChangeType(this.ChangeTypeName);
            if (newId > 0)
            {
                this.ChangeTypeID = newId;
                return true;
            }
            return false;
        }

        private bool _UpdateChangeType()
        {
            return DAL.clsChangeTypeData.UpdateChangeType(this.ChangeTypeID, this.ChangeTypeName);


        }

        public static bool DELETEChangeType(int ID)
        {
            return DAL.clsChangeTypeData.DeleteChangeType(ID);

        }

        public static DataTable GetAllChangeType()
        {
            return DAL.clsChangeTypeData.GetAllChangeType();
        }

        public static clsChangeType Find(int ID)
        {
            string Name = string.Empty;

            if (clsChangeTypeData.FindChangeType(ID, ref Name))
            {
                return new clsChangeType(ID, Name);
            }
            else
                return null;
        }

        public bool SaveChangeType()
        {
            switch (this.Mode)
            {
                case enChangeType.AddNew:
                    if (_ADDChangeType())
                    {
                        Mode = enChangeType.Update;
                        return true;
                    }
                    return false;
                case enChangeType.Update:
                    return _UpdateChangeType();
                default:
                    throw new InvalidOperationException("Invalid Mode");
            }
        }
    }
}

