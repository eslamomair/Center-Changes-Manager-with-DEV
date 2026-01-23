using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CenterChangesManager.DAL
{
    public class clsLocationStatusesData
    {
        // ========== جلب كل الحالات ==========
        public static DataTable GetAllStatuses()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT StatusID, StatusName FROM LocationStatuses ORDER BY StatusName";

                var reader = connection.ExecuteReader(query);
                dt.Load(reader);
            }
            return dt;
        }

        // ========== جلب حالة بالـ ID ==========
        public static dynamic GetStatusByID(int statusID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT StatusID, StatusName FROM LocationStatuses WHERE StatusID = @ID";

                return connection.QueryFirstOrDefault(query, new { ID = statusID });
            }
        }

        // ========== إضافة حالة جديدة ==========
        public static int AddNewStatus(string statusName)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    INSERT INTO LocationStatuses (StatusName)
                    VALUES (@Name);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                return connection.QuerySingle<int>(query, new { Name = statusName });
            }
        }

        // ========== تحديث حالة ==========
        public static bool UpdateStatus(int statusID, string statusName)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE LocationStatuses SET StatusName = @Name WHERE StatusID = @ID";

                int rows = connection.Execute(query, new { Name = statusName, ID = statusID });
                return rows > 0;
            }
        }

        // ========== حذف حالة ==========
        public static bool DeleteStatus(int statusID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"DELETE FROM LocationStatuses WHERE StatusID = @ID";

                int rows = connection.Execute(query, new { ID = statusID });
                return rows > 0;
            }
        }
    }
}
