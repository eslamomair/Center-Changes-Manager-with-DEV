using CenterChangesManager.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CenterChangesManager.DAL
{
    public class clsChangesLogData
    {


        // ========== إضافة سجل جديد ==========
        public static int AddNewChangesLog(
     int? cityID,
     int? villageID,
     int? dependencyID,
     string? changeNumber,
     decimal? latitude,
     decimal? longitude,
     DateTime? changeDate,
     string? address,
     int? locationStatusID,
     string? ownerName,
     int? changeTypeID,
     int? inspectorID,
     string? note,
     int? createdBy)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                // 1. جملة الاستعلام (لاحظ أن الأسماء بعد @ يجب أن تطابق أسماء الباراميترات بالأسفل)
                string query = @"
            INSERT INTO ChangesLog (
                CityID, Village_ID, Dependency_ID, ChangeNumber, 
                Latitude, Longitude, ChangeDate, Address, 
                LocationStatusID, OwnerName, ChangeType_ID, Inspector_ID, 
                Note, CreatedBy, CreatedDate, IsActive
            )
            VALUES (
                @CityID, @Village_ID, @Dependency_ID, @ChangeNumber, 
                @Latitude, @Longitude, @ChangeDate, @Address, 
                @LocationStatusID, @OwnerName, @ChangeType_ID, @Inspector_ID, 
                @Note, @CreatedBy, GETDATE(), 1
            );
            
            -- لاسترجاع رقم الـ ID الجديد الذي تم إنشاؤه
            SELECT CAST(SCOPE_IDENTITY() as int);";

                // 2. تجهيز الباراميترات (هنا نعالج مشكلة الـ -1)
                var parameters = new
                {
                    CityID = cityID,
                    // السطر التالي يعني: لو القيمة -1 اجعلها null (من نوع int?) وإلا ضع القيمة كما هي
                    VillageID = (villageID == -1) ? (int?)null : villageID,
                    Dependency_ID = (dependencyID == -1) ? (int?)null : dependencyID,

                    ChangeNumber = changeNumber,
                    Latitude = latitude,
                    Longitude = longitude,
                    ChangeDate = changeDate,
                    Address = address,

                    // معالجة حالة الموقع أيضاً إذا كانت اختيارية
                    LocationStatusID = (locationStatusID == -1) ? (int?)null : locationStatusID,

                    OwnerName = ownerName,
                    ChangeType_ID = changeTypeID,
                    Inspector_ID = inspectorID,
                    Note = note,
                    CreatedBy = createdBy
                };

                // 3. التنفيذ
                // QuerySingle<int> تعني: نفذ الأمر وأعد لي القيمة الأولى (التي هي الـ ID الجديد) كرقم صحيح
                return connection.QuerySingle<int>(query, parameters);
            }
        }


        // ========== تحديث سجل موجود ==========
        public static bool UpdateChangesLog(
            int? logID, int? cityID, int? villageID, int? dependencyID, string? changeNumber,
            decimal? latitude, decimal? longitude, DateTime? changeDate, string? address,
            int? locationStatusID, string? ownerName, int? changeTypeID, int? inspectorID,
            string? Note, int? modifiedBy)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                   UPDATE dbo.ChangesLog
SET
    Dependency_ID = @Dependency_ID,
    CityID = @CityID,
    VillageID = @VillageID,
    ChangeNumber = @ChangeNumber,
    Latitude = @Latitude,
    Longitude = @Longitude,
    ChangeDate = @ChangeDate,
    Address = @Address,
    LocationStatusID = @LocationStatusID,
    OwnerName = @OwnerName,
    ChangeType_ID = @ChangeType_ID,
    Inspector_ID = @Inspector_ID,
    Note = @Note,
    LastModifieBy = @ModifiedBy,
    LastModifiedData = GETDATE()
WHERE LogID = @LogID;";

                var parameters = new
                {
                    LogID = logID,
                    CityID = cityID,
                    VillageID = villageID,
                    DependencyID = dependencyID,
                    ChangeNumber = changeNumber,
                    Latitude = latitude,
                    Longitude = longitude,
                    ChangeDate = changeDate,
                    Address = address,
                    LocationStatusID = locationStatusID,
                    OwnerName = ownerName,
                    ChangeTypeID = changeTypeID,
                    InspectorID = inspectorID,
                    Note = Note,
                    ModifiedBy = modifiedBy
                };

                try
                {
                    int rowsAffected = connection.Execute(query, parameters);
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
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
                        LastModifiedBy = @DeletedBy,
                        LastModifiedDate = GETDATE()
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
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        // ========== البحث بـ ID ==========
        // ملاحظة: Dapper يفضل إرجاع كائن (Object) بدلاً من ref parameters
        // ولكن تم الحفاظ على التوقيع (Signature) كما هو لعدم كسر الكود القديم
        public static bool GetChangesLogByID(
            int? logID, ref int? cityID, ref int? villageID, ref int? dependencyID,
            ref string? changeNumber, ref decimal? latitude, ref decimal? longitude,
            ref DateTime? changeDate, ref string? address, ref int? locationStatusID,
            ref string? ownerName, ref int? changeTypeID, ref int? inspectorID,
            ref string? Note, ref bool? isActive)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT 
                        CityID, VillageID, Dependency_ID, ChangeNumber,
                        Latitude, Longitude, ChangeDate, Address,
                        LocationStatusID, OwnerName, ChangeType_ID,
                        Inspector_ID, Note, IsActive
                    FROM ChangesLog 
                    WHERE LogID = @LogID";

                try
                {
                    // جلب النتيجة كـ dynamic object
                    var result = connection.QueryFirstOrDefault(query, new { LogID = logID });

                    if (result != null)
                    {
                        cityID = result.CityID;
                        villageID = result.VillageID ?? -1;
                        dependencyID = result.Dependency_ID ?? -1;
                        changeNumber = result.ChangeNumber;
                        latitude = result.Latitude;
                        longitude = result.Longitude;
                        changeDate = result.ChangeDate;
                        address = result.Address ?? "";
                        locationStatusID = result.LocationStatusID;
                        ownerName = result.OwnerName;
                        changeTypeID = result.ChangeType_ID;
                        inspectorID = result.Inspector_ID;
                        Note = result.Note ?? "";
                        isActive = result.IsActive;
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                return false;
            }
        }

        public static bool GetChangesLogByChangeNumber(ref int? logID, ref int? cityID, ref int? villageID,
            ref int? dependencyID,
             string? changeNumber, ref decimal? latitude, ref decimal? longitude,
            ref DateTime? changeDate, ref string? address, ref int? locationStatusID,
            ref string? ownerName, ref int? changeTypeID, ref int? inspectorID,
            ref string? incomingDocs, ref bool? isActive)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT 
                       LogID, City_ID, Village_ID, Dependency_ID, ChangeNumber,
                        Latitude, Longitude, ChangeDate, Address,
                        LocationStatusID, OwnerName, ChangeType_ID,
                        Inspector_ID, Note, IsActive
                    FROM ChangesLog 
                    WHERE ChangeNumber = @ChangeNumber";
                try
                {
                    // جلب النتيجة كـ dynamic object
                    var result = connection.QueryFirstOrDefault(query, new { ChangeNumber = changeNumber });
                    if (result != null)
                    {
                        logID = result.LogID;
                        cityID = result.City_ID;
                        villageID = result.Village_ID;
                        dependencyID = result.Dependency_ID;
                        changeNumber = result.ChangeNumber;
                        latitude = result.Latitude;
                        longitude = result.Longitude;
                        changeDate = result.ChangeDate;
                        address = result.Address ?? "";
                        locationStatusID = result.LocationStatusID;
                        ownerName = result.OwnerName;
                        changeTypeID = result.ChangeType_ID;
                        inspectorID = result.Inspector_ID;
                        incomingDocs = result.IncomingDocs ?? "";
                        isActive = result.IsActive;
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                return false;
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
            ls.StatusName AS LocationStatus
        FROM ChangesLog cl
        INNER JOIN Cities c ON cl.CityID = c.CityID              -- المدينة إجبارية (INNER)
        INNER JOIN ChangeTypes ct ON cl.ChangeType_ID = ct.TypeID -- النوع إجباري (INNER)
        INNER JOIN Inspectors i ON cl.Inspector_ID = i.Inspector_ID -- المفتش إجباري (INNER)
        LEFT JOIN Villages v ON cl.VillageID = v.VillageID       -- القرية اختيارية (LEFT)
        LEFT JOIN Dependencies d ON cl.Dependency_ID = d.Dependency_ID -- التبعية اختيارية (LEFT)
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
