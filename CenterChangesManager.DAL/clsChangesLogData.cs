using CenterChangesManager.Common;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CenterChangesManager.DAL
{
    public class clsChangesLogData
    {


        // ========== إضافة سجل جديد ==========
        public static int AddNewChangesLog(ChangesLog log)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                try
                {
                    // دالة Insert بترجع long، بنحولها لـ int
                    return (int)connection.Insert(log);
                }
                catch (Exception ex)
                {

                    return -1; // فشل الإضافة
                }
            }
        }


        // ========== تحديث سجل موجود ==========
        public static bool UpdateChangesLog(ChangesLog log)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                try
                {
                    // دالة Update بتحدث كل الحقول بناءً على الـ Key (LogID)
                    return connection.Update(log);
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        // ========== حذف ناعم (Soft Delete) ==========
        public static bool DeleteChangesLog(int? logID, string? deletedBy)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    UPDATE ChangesLog 
                    SET 
                        IsActive = 0,
                        LastModifieBy = @DeletedBy,
                        LastModifiedData = GETDATE()
                    WHERE 
                        LogID = @LogID";

                try
                {
                    int rowsAffected = connection.Execute(query, new { LogID = logID, DeletedBy = string.IsNullOrEmpty(deletedBy) ? null : deletedBy });
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        // ========== حذف نهائي ==========
        public static bool PermanentDeleteChangesLog(int? logID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM ChangesLog WHERE LogID = @LogID";
                try
                {
                    int rowsAffected = connection.Execute(query, new { LogID = logID });
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }

        // ========== البحث بـ ID ==========
        // ملاحظة: Dapper يفضل إرجاع كائن (Object) بدلاً من ref parameters
        // ولكن تم الحفاظ على التوقيع (Signature) كما هو لعدم كسر الكود القديم
        public static CenterChangesManager.Common.ChangesLog? GetChangesLogByID(int? logID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                // هي لوحدها بتعمل SELECT * FROM ChangesLog WHERE LogID = @id
                return connection.Get<CenterChangesManager.Common.ChangesLog>(logID);
            }
        }

        public static CenterChangesManager.Common.ChangesLog? GetChangesLogByChangeNumber(string? changeNumber)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                // هنا نحتاج SQL لأننا لا نبحث بالـ ID
                string query = "SELECT * FROM ChangesLog WHERE ChangeNumber = @ChangeNumber";

                try
                {
                    // Dapper العادي هيملأ الاوبجكت لوحده لأن الأسماء متطابقة
                    return connection.QueryFirstOrDefault<ChangesLog>(query, new { ChangeNumber = changeNumber });
                }
                catch (Exception ex)
                {

                    return null;
                }
            }
        }

        // ========== جلب جميع السجلات النشطة ==========
        public static DataTable GetAllChangesLog()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                // استخدمنا LEFT JOIN مع الجداول التي قد تكون فارغة
                string query = @"
        SELECT 
            cl.LogID, cl.ChangeNumber, cl.ChangeDate,
            cl.CityID, c.CityName, 
            cl.Village_ID, v.VillageName, 
            cl.Dependency_ID AS Dependency_ID, d.DependencyName,
            cl.Latitude, cl.Longitude, cl.OwnerName,
            ct.TypeName AS ChangeType, 
            i.InspectorName,
            ls.StatusName AS LocationStatus
        FROM ChangesLog cl
        INNER JOIN Cities c ON cl.CityID = c.CityID              -- المدينة إجبارية (INNER)
        INNER JOIN ChangeTypes ct ON cl.ChangeType_ID = ct.TypeID -- النوع إجباري (INNER)
        INNER JOIN Inspectors i ON cl.Inspector_ID = i.Inspector_ID -- المفتش إجباري (INNER)
        LEFT JOIN Villages v ON cl.Village_ID = v.Village_ID       -- القرية اختيارية (LEFT)
        LEFT JOIN Dependencies d ON cl.Dependency_ID = d.Dependency_ID -- التبعية اختيارية (LEFT)
        LEFT JOIN LocationStatuses ls ON cl.LocationStatusID = ls.StatusID -- الحالة اختيارية (LEFT)
        WHERE cl.IsActive = 1
        ORDER BY cl.ChangeDate DESC";

                try
                {
                    var reader = connection.ExecuteReader(query);
                    dt.Load(reader);
                }
                catch (Exception ex)
                {
                    // يفضل تسجيل الخطأ هنا
                }
            }
            return dt;
        }




        //باستخدام الليست 
        public static List<ChangesLog> GetListAllChangesLog()
        {
            List<ChangesLog> Log = new List<ChangesLog>();
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                // استخدمنا LEFT JOIN مع الجداول التي قد تكون فارغة
                string query = @"
        SELECT 
            cl.LogID, cl.ChangeNumber, cl.ChangeDate,
            cl.CityID, c.CityName, 
            cl.VillageID, v.VillageName, 
            cl.Dependency_ID AS Dependency_ID, d.DependencyName,
            cl.Latitude, cl.Longitude, cl.OwnerName,
            ct.TypeName AS ChangeType, 
            i.InspectorName,
            ls.StatusName AS LocationStatus ,cl.Note
        FROM ChangesLog cl
        INNER JOIN Cities c ON cl.CityID = c.CityID              -- المدينة إجبارية (INNER)
        INNER JOIN ChangeTypes ct ON cl.ChangeType_ID = ct.TypeID -- النوع إجباري (INNER)
        INNER JOIN Inspectors i ON cl.Inspector_ID = i.InspectorID -- المفتش إجباري (INNER)
        LEFT JOIN Villages v ON cl.VillageID = v.VillageID       -- القرية اختيارية (LEFT)
        LEFT JOIN Dependencies d ON cl.Dependency_ID = d.DependencyID -- التبعية اختيارية (LEFT)
        LEFT JOIN LocationStatuses ls ON cl.LocationStatusID = ls.StatusID -- الحالة اختيارية (LEFT)
        WHERE cl.IsActive = 1
        ORDER BY cl.ChangeDate DESC";

                try
                {
                    Log = connection.Query<ChangesLog>(query).ToList();

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return Log;
        }




        // ========== البحث برقم التغيير ==========
        public static DataTable SearchByChangeNumber(string? changeNumber)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT 
                        cl.LogID, cl.ChangeNumber, cl.ChangeDate,
                        c.CityName, v.VillageName, d.DependencyName, cl.OwnerName
                    FROM ChangesLog cl
                    INNER JOIN Cities c ON cl.City_ID = c.CityID
                    INNER JOIN Villages v ON cl.VillageID = v.VillageID
                    INNER JOIN Dependencies d ON cl.Dependency_ID = d.Dependency_ID
                    WHERE cl.IsActive = 1 
                      AND cl.ChangeNumber LIKE '%' + @ChangeNumber + '%'";

                try
                {
                    var reader = connection.ExecuteReader(query, new { ChangeNumber = changeNumber });
                    dt.Load(reader);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return dt;
        }

        // ========== تحقق من وجود رقم تغيير ==========
        public static bool IsChangeNumberExists(string? changeNumber, int? excludeLogID = -1)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT COUNT(1) 
                    FROM ChangesLog 
                    WHERE ChangeNumber = @ChangeNumber 
                    AND LogID != @ExcludeLogID";

                try
                {
                    int count = connection.ExecuteScalar<int>(query, new { ChangeNumber = changeNumber, ExcludeLogID = excludeLogID });
                    return count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        public static bool Exists(int logId, string change)
        {
            if (logId <= 0 && string.IsNullOrWhiteSpace(change))
                return false;

            const string query = @"
        SELECT COUNT(1)
        FROM ChangesLog
        WHERE (@LogID > 0 AND LogID = @LogID)
           OR (@Change <> '' AND ChangeNumber = @Change)
    ";

            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@LogID", logId);
                cmd.Parameters.AddWithValue("@Change", change ?? "");

                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }




        //--------------- New Solution 2025-12-9 ---------------

        public static DataTable GetChangesLogByFilter(DateTime? startDate, DateTime? endDate, int? cityID, int? changeTypeID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                // لاحظ استخدام 1=1 لتسهيل إضافة الشروط ديناميكياً
                // واستخدام IS NULL في جملة الـ WHERE يجعل الفلتر اختياريًا
                string query = @"
            SELECT 
                cl.LogID, 
                cl.ChangeNumber, 
                cl.ChangeDate,
                cl.CityID, c.CityName, 
                cl.VillageID, v.VillageName, 
                cl.Dependency_ID AS Dependency_ID, d.DependencyName,
                cl.Latitude, cl.Longitude, 
                cl.OwnerName,
                ct.TypeName AS ChangeType, 
                i.InspectorName,
                ls.StatusName AS LocationStatus
            FROM ChangesLog cl
            INNER JOIN Cities c ON cl.CityID = c.CityID
            INNER JOIN ChangeTypes ct ON cl.ChangeType_ID = ct.TypeID
            INNER JOIN Inspectors i ON cl.Inspector_ID = i.Inspector_ID
            LEFT JOIN Villages v ON cl.VillageID = v.VillageID
            LEFT JOIN Dependencies d ON cl.Dependency_ID = d.Dependency_ID
            LEFT JOIN LocationStatuses ls ON cl.LocationStatusID = ls.StatusID
            WHERE cl.IsActive = 1
            AND (@StartDate IS NULL OR cl.ChangeDate >= @StartDate)
            AND (@EndDate IS NULL OR cl.ChangeDate <= @EndDate)
            AND (@CityID IS NULL OR cl.CityID = @CityID)
            AND (@ChangeType_ID IS NULL OR cl.ChangeType_ID = @ChangeType_ID)
            ORDER BY cl.ChangeDate DESC";

                try
                {
                    var parameters = new
                    {
                        StartDate = startDate,
                        EndDate = endDate,
                        CityID = cityID,
                        ChangeTypeID = changeTypeID
                    };

                    var reader = connection.ExecuteReader(query, parameters);
                    dt.Load(reader);
                }
                catch (Exception ex)
                {
                    // يفضل تسجيل الخطأ هنا في ملف Log
                    Console.WriteLine("Error in GetChangesLogByFilter: " + ex.Message);
                }
            }
            return dt;
        }
    }
}
