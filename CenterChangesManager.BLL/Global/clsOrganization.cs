using CenterChangesManager.Common;
using CenterChangesManager.DAL.Global;

namespace CenterChangesManager.BLL.Global
{
    public class clsOrganization
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode;
        public Organization Org { get; set; }


        public clsOrganization()
        {
            Org = new Organization();
            this.Org.OrganizationID = 1;
            Mode = enMode.AddNew;
        }

        private clsOrganization(Organization org) : this()
        {
            Org = org;
            Mode = enMode.Update;
        }


        public static clsOrganization GetOrganization()
        {
            Organization Org = clsOrganizationData.GetOrganizationData();

            if (Org != null)
            {
                return new clsOrganization(Org);
            }
            else
                return new clsOrganization();
        }

        public bool Save()
        {
            // بما أن دالة الـ DAL ذكية (SaveOrUpdate)، يمكننا استدعاؤها مباشرة
            if (clsOrganizationData.SaveOrUpdate(Org))
            {
                // بعد الحفظ بنجاح، نتحول دائماً لوضع التحديث
                Mode = enMode.Update;
                return true;
            }

            return false;
        }
    }
}
