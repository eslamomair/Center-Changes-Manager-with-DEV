using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CenterChangesManager.DAL
{
    public class clsInspectorData
    {
        public static int AddNew(string name, int City_ID, string Phone)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Inspectors (InspectorName, City_ID, Phone) 
                                VALUES (@Name,@City_ID, @Phone);
                                 SELECT CAST(SCOPE_IDENTITY() as int);";
                return connection.ExecuteScalar<int>(query, new { Name = name, City_ID = City_ID, Phone = Phone });
            }
        }

        public static bool Update(int id, string name, int cityid, string phone)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "UPDATE Inspectors SET InspectorName = @Name WHERE InspectorId = @ID";
                return connection.Execute(query, new { Name = name, ID = id, City_ID = cityid, Phone = phone }) > 0;
            }
        }

        public static bool Delete(int id)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                return connection.Execute("DELETE FROM Inspectors WHERE InspectorId = @ID", new { ID = id }) > 0;
            }
        }

        public static DataTable GetAllInspectors()
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                var reader = connection.ExecuteReader("SELECT InspectorId, InspectorName FROM Inspectors");
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }

        public static bool GetInspectorInfoByID(int id, ref string name, ref int cityid, ref string phone)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                var result = connection.QueryFirstOrDefault("SELECT * FROM Inspectors WHERE InspectorId = @ID", new { ID = id });
                if (result != null) { name = result.InspectorName; return true; }
                return false;
            }
        }

        public static DataTable GetAllInspectorsByCityID(int cityId)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                var reader = connection.ExecuteReader(@"
                   select * from Inspectors where City_ID = @City_ID", new { City_ID = cityId });
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }

        public static DataTable GetIspectorAndCity()
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
    SELECT 
        I.InspectorID, 
        I.InspectorName, 
        I.Phone, 
        C.CityName as 'City',
        I.City_ID 
    FROM Inspectors I
    INNER JOIN Cities C ON I.City_ID = C.CityID";
                var reader = connection.ExecuteReader(query);
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }
    }
}