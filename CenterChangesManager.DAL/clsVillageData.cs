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
                                 VALUES (@Name, @City_ID);
                                 SELECT CAST(SCOPE_IDENTITY() as int);";
                return connection.ExecuteScalar<int>(query, new { Name = villageName, City_ID = cityID });
            }
        }

        public static bool Update(int villageID, string? villageName, int? cityID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Villages 
                                 SET VillageName = @Name, CityId = @CityID 
                                 WHERE VillageID = @ID";
                return connection.Execute(query, new { Name = villageName, CityID = cityID, ID = villageID }) > 0;
            }
        }

        public static bool Delete(int villageID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Villages WHERE VillageID = @ID";
                return connection.Execute(query, new { ID = villageID }) > 0;
            }
        }

        public static bool GetVillageInfoByID(int villageID, ref string? villageName, ref int? cityID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Villages WHERE VillageID = @ID";
                var result = connection.QueryFirstOrDefault(query, new { ID = villageID });
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
                var reader = connection.Query<Village>("SELECT VillageID, VillageName FROM Villages WHERE City_ID = @CityID", new { CityID = cityID });
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
    }
}