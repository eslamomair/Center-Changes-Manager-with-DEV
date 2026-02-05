using CenterChangesManager.Common;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Data;


namespace CenterChangesManager.DAL
{
    public class clsUserData
    {
        public static async Task<User?> GetUserByIDAsync(int userId)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<User>(
                    "SELECT * FROM Users WHERE UserID = @UserID", new { UserID = userId });
            }
        }

        public static async Task<User?> GetUserByUsernameAsync(string username)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<User>(
                   "SELECT * FROM Users WHERE UserName = @UserName",
                    new { UserName = username });
            }
        }

        public static int AddNewUser(User user)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                //string query = @"INSERT INTO User (UserName, Password, FullName, Permession, IsActive)
                //             VALUES (@UserName, @Password, @FullName, @Permession, @IsActive);
                //             SELECT CAST(SCOPE_IDENTITY() as int);";
                //return await connection.QuerySingleAsync<int>(query, user);

                int id = Convert.ToInt32(connection.Insert(user));
                return id;
            }
        }

        public static bool UpdateUser(User user)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                //string query = @"UPDATE User SET UserName=@UserName, Password=@Password, 
                //             FullName=@FullName, Permession=@Permession, IsActive=@IsActive 
                //             WHERE UserID=@UserID";
                //return await connection.ExecuteAsync(query, user) > 0;

                return connection.Update(user);
            }
        }

        public static bool DeleteUser(int userId)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                //  return await connection.ExecuteAsync("DELETE FROM User WHERE UserID=@UserID", new { UserID = userId }) > 0;
                return connection.Delete(new User { UserID = userId });
            }
        }

        public static async Task<bool> IsUserExistAsync(string username)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                return await connection.ExecuteScalarAsync<bool>(
                    @"SELECT CASE  WHEN EXISTS (SELECT 1 FROM Users WHERE UserName = @UserName)   THEN CAST(1 AS BIT)  ELSE CAST(0 AS BIT) END", new { UserName = username });
            }
        }

        public static async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                return await connection.QueryAsync<User>("SELECT * FROM Users");
            }
        }

        //انت كنت نسيت بيعمل ايه وكنت هتحذفه .. بيسال هل هناك ادمن ام لا 
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
