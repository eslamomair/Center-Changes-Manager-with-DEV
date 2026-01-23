using CenterChangesManager.Common;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CenterChangesManager.DAL
{
    public class clsAdminOTPData
    {


        public static async Task<int?> AddNewData(AdminOTPVerificationCommon otp)
        {
            using var connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            const string sql = @"
       INSERT INTO AdminOTPVerification (
        AdminUserID, Purpose, OTP, IsUsed, AttemptCount
    )
    VALUES (
        @AdminUserID, @Purpose, @OTP, @IsUsed, @AttemptCount
    );
    SELECT CAST(SCOPE_IDENTITY() AS int);";

            return await connection.QueryFirstOrDefaultAsync<int?>(sql, otp);
        }

        public static async Task<AdminOTPVerificationCommon?> GetActiveOTPByAdminAsync(int adminUserID)
        {
            using var connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            const string sql = @"
            SELECT TOP 1 * 
            FROM AdminOTPVerification
            WHERE AdminUserID = @AdminUserID
              AND IsUsed = 0 
              AND ExpiryTime > GETDATE()
            ORDER BY CreatedAt DESC;";

            return await connection.QueryFirstOrDefaultAsync<AdminOTPVerificationCommon>(
                sql, new { AdminUserID = adminUserID });
        }

        public static async Task<bool> MarkAsUsedAsync(int? iD)
        {
            using var connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            const string sql = "UPDATE AdminOTPVerification SET IsUsed = 1 WHERE ID = @ID;";
            var rows = await connection.ExecuteAsync(sql, new { ID = iD });
            return rows > 0;
        }

        public static async Task<bool> IncrementAttemptCountAsync(int? iD)
        {
            using var connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            const string sql = "UPDATE AdminOTPVerification SET AttemptCount = AttemptCount + 1 WHERE ID = @ID;";
            var rows = await connection.ExecuteAsync(sql, new { ID = iD });
            return rows > 0;
        }


        public static async Task<int?> GetAttemptCountAsync(int? id)
        {
            using var connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            const string sql = "SELECT AttemptCount FROM AdminOTPVerification WHERE ID = @ID;";

            // بيرجع القيمة أو null لو الـ ID مش موجود
            return await connection.QueryFirstOrDefaultAsync<int?>(sql, new { ID = id });
        }
    }
}
