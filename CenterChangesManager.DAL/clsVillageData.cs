using CenterChangesManager.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CenterChangesManager.DAL
{
    public class clsVillageData
    {
        public static int AddNew(string villageName, int? cityID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Villages (VillageName, City_ID) 
                                 VALUES (@VillageName, @City_ID);
                                 SELECT CAST(SCOPE_IDENTITY() as int);";
                return connection.ExecuteScalar<int>(query, new { VillageName = villageName, City_ID = cityID });
            }
        }

        public static bool Update(int villageID, string? villageName, int? cityID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Villages 
                                 SET VillageName = @VillageName, City_ID = @City_ID
                                 WHERE VillageID = @VillageID";
                return connection.Execute(query, new { VillageName = villageName, City_ID = cityID, VillageID = villageID }) > 0;
            }
        }

        public static bool Delete(int villageID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Villages WHERE VillageID = @VillageID";
                return connection.Execute(query, new { VillageID = villageID }) > 0;
            }
        }

        public static bool GetVillageInfoByID(int villageID, ref string? villageName, ref int? cityID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Villages WHERE VillageID = @VillageID";
                var result = connection.QueryFirstOrDefault(query, new { VillageID = villageID });
                if (result != null)
                {
                    villageName = result.VillageName;
                    cityID = result.CityId;
                    return true;
                }
                return false;
            }
        }

        public static List<Village> GetAllVillagesByCityID(int cityID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                var reader = connection.Query<Village>("SELECT VillageID, VillageName FROM Villages WHERE City_ID = @City_ID", new { City_ID = cityID });
                return reader.ToList();
            }
        }

        public static List<Village> GetAllVillages()
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                var reader = connection.Query<Village>("SELECT * FROM Villages ");
                return reader.ToList();
            }
        }

        public static bool IsExist(int? vilageId, string? vilageName)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string Query = @" SELECT TOP 1 1  FROM Villages
    WHERE 
        (@VillageID IS NOT NULL ANd VillageID  = @VillageID)
        OR
        (@VillageName IS NOT NULL ANd VillageName = @VillageName);";

                int? Count = connection.ExecuteScalar<int?>(Query, new { VillageID = vilageId, VillageName = vilageName });
                return Count != null;
            }
        }
    }
}