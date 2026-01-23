using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
namespace CenterChangesManager.DAL
{
    public class clsChangeTypeData
    {

        public static int AddChangeType(string changeName)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string sql = "INSERT INTO ChangeTypes (TypeName) VALUES (@ChangeName); SELECT CAST(SCOPE_IDENTITY() as int)";
                int newId = conn.QuerySingle<int>(sql, new { TypeName = changeName });
                return newId;
            }
        }

        public static bool UpdateChangeType(int TypeId, string TypeNam)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string sql = "UPDATE ChangeTypes SET TypeName = @TypeName WHERE TypeID = @TypeID";
                int rowsAffected = conn.Execute(sql, new { TypeName = TypeNam, TypeID = TypeId });
                return rowsAffected > 0;
            }
        }

        public static bool DeleteChangeType(int TypeID)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string sql = "DELETE FROM ChangeTypes WHERE TypeID = @TypeID";
                int rowsAffected = conn.Execute(sql, new { TypeID = TypeID });
                return rowsAffected > 0;
            }
        }

        public static DataTable GetAllChangeType()
        {
            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                var result = connection.Query("SELECT TypeID, TypeName FROM ChangeTypes");

                DataTable dt = new DataTable();
                dt.Columns.Add("TypeID", typeof(int));
                dt.Columns.Add("TypeName", typeof(string));

                foreach (var row in result)
                {
                    dt.Rows.Add(row.TypeID, row.TypeName);
                }

                return dt;
            }
        }

        public static bool FindChangeType(int TypeID, ref string name)
        {


            using (IDbConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))

            {
                string sql = "select * FROM ChangeTypes WHERE TypeID = @TypeID";
                var Result = conn.QueryFirstOrDefault(sql, new { TypeID = TypeID, TypeName = name });

                if (Result != null)
                {
                    name = Result.TypeName; return true;
                }
                return false;
            }
        }
    }
}