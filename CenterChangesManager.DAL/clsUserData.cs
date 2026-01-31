using CenterChangesManager.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;


namespace CenterChangesManager.DAL
{
    public class clsUserData
    {
        public static async Task<clsUsers> GetUserByIDAsync(int userId)
        {
            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<clsUsers>(
                    "SELECT * FROM Users WHERE UserID = @UserID", new { UserID = userId });
            }
        }

        public static async Task<clsUsers> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<clsUsers>(
                    "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password",
                    new { UserName = username, Password = password });
            }
        }

        public static async Task<int> AddNewUserAsync(clsUsers user)
        {
            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Users (UserName, Password, FullName, Permession, IsActive)
                             VALUES (@UserName, @Password, @FullName, @Permession, @IsActive);
                             SELECT CAST(SCOPE_IDENTITY() as int);";
                return await connection.QuerySingleAsync<int>(query, user);
            }
        }

        public static async Task<bool> UpdateUserAsync(clsUsers user)
        {
            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Users SET UserName=@UserName, Password=@Password, 
                             FullName=@FullName, Permession=@Permession, IsActive=@IsActive 
                             WHERE UserID=@UserID";
                return await connection.ExecuteAsync(query, user) > 0;
            }
        }

        public static async Task<bool> DeleteUserAsync(int userId)
        {
            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                return await connection.ExecuteAsync("DELETE FROM Users WHERE UserID=@UserID", new { UserID = userId }) > 0;
            }
        }

        public static async Task<bool> IsUserExistAsync(string username)
        {
            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                return await connection.ExecuteScalarAsync<bool>(
                    "SELECT COUNT(1) FROM Users WHERE UserName = @UserName", new { UserName = username });
            }
        }

        public static async Task<IEnumerable<clsUsers>> GetAllUsersAsync()
        {
            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                return await connection.QueryAsync<clsUsers>("SELECT * FROM Users");
            }
        }

        public static async Task<bool> IsAnyUserExists()
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string Query = @"SELECT CASE 
       WHEN EXISTS (SELECT 1 FROM Users)
       THEN CAST(1 AS BIT)
       ELSE CAST(0 AS BIT)
       END;     ";

                return await connection.ExecuteScalarAsync<bool>(Query);
            }
        }
    }
}
