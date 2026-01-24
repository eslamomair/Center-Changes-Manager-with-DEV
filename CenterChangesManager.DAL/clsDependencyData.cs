using CenterChangesManager.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CenterChangesManager.DAL
{
    public class clsDependencyData
    {
        public static int AddNew(string depName, int villageID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Dependencies (DependencyName, Village_ID) 
                                 VALUES (@Name, @Village_ID);
                                 SELECT CAST(SCOPE_IDENTITY() as int);";
                return connection.ExecuteScalar<int>(query, new { Name = depName, Village_ID = villageID });
            }
        }

        public static bool Update(int depID, string depName, int villageID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Dependencies 
                                 SET DependencyName = @Name, Village_ID = @Village_ID
                                 WHERE DependencyID = @ID";
                return connection.Execute(query, new { Name = depName, DependencyID = villageID, ID = depID }) > 0;
            }
        }

        public static bool Delete(int depID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Dependencies WHERE DependencyID = @ID";
                return connection.Execute(query, new { ID = depID }) > 0;
            }
        }

        public static List<Dependency> GetAllDependenciesByVillageID(int villageID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                var reader = connection.Query<Dependency>("SELECT DependencyID, DependencyName FROM Dependencies WHERE Village_ID = @Village_ID", new { Village_ID = villageID });

                return reader.ToList();
            }
        }

        public static bool GetDependencyInfoByID(int depID, ref string depName, ref int villageID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                var result = connection.QueryFirstOrDefault("SELECT * FROM Dependencies WHERE DependencyID = @ID", new { ID = depID });
                if (result != null)
                {
                    depName = result.DependencyName;
                    villageID = result.VillageId;
                    return true;
                }
                return false;
            }
        }


        public static bool IsExist(string? DepName = null, int? DepID = null)
        {

            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string Query = @"SELECT TOP 1 1 FROM Dependencies WHERE
                        (@DependencyID IS NOT NULL AND DependencyID = @DependencyID) OR
                        (@DependencyName IS NOT NULL AND DependencyName = @DependencyName);";


                int? count = connection.ExecuteScalar<int?>(Query,
                    new { DependencyName = DepName, DependencyID = DepID });

                return count != null;
            }
        }
    }
}