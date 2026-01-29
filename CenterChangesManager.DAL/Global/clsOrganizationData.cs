using CenterChangesManager.Common;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CenterChangesManager.DAL.Global
{
    public class clsOrganizationData
    {
        public static Organization GetOrganizationData()
        {
            using (IDbConnection db = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                // نستخدم Get من Dapper.Contrib لجلب السجل بناءً على المعرف
                return db.Get<Organization>(1);
            }
        }

        // دالة الحفظ الذكية (تحديث لو موجود / إضافة لو مش موجود)
        public static bool SaveOrUpdate(Organization org)
        {

            try
            {
                using (IDbConnection db = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    org.OrganizationID = 1;
                    var existing = db.Get<Organization>(1);

                    if (existing != null)
                    {
                        return db.Update(org);
                    }
                    else
                    {
                        // إذا فشل الإدخال هنا لأي سبب، سينتقل الكود فوراً لكتلة الـ catch
                        db.Insert(org);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

                return false; // في حالة الفشل، ترجع الدالة false بأمان
            }
        }
    }
}



