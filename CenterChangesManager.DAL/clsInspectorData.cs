using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CenterChangesManager.DAL
{
    public class clsInspectorData
    {
        public static int AddNew(string name, int City_ID, string Phone, int? Village_ID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Inspectors (InspectorName, City_ID, Phone,Village_ID) 
                                VALUES (@Name,@City_ID, @Phone,@Village_ID);
                                 SELECT CAST(SCOPE_IDENTITY() as int);";
                return connection.ExecuteScalar<int>(query, new { Name = name, City_ID = City_ID, Phone = Phone, Village_ID = Village_ID });
            }
        }

        public static bool Update(int id, string name, int cityid, string phone, int? Village_ID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "UPDATE Inspectors SET InspectorName = @Name,Phone = @Phone,Village_ID=@Village_ID WHERE InspectorId = @ID";
                return connection.Execute(query, new { Name = name, ID = id, City_ID = cityid, Phone = phone, Village_ID = Village_ID }) > 0;
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

        public static bool GetInspectorInfoByID(int id, ref string name, ref int cityid, ref string phone, ref int Village_ID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                var result = connection.QueryFirstOrDefault("SELECT * FROM Inspectors WHERE InspectorId = @ID", new { ID = id });
                if (result != null)
                {
                    // هنا التصحيح: ملء جميع البيانات
                    name = result.InspectorName;

                    // تأكد أن أسماء الأعمدة (City_ID, Phone) مطابقة لما في الداتابيز
                    cityid = result.City_ID;
                    phone = result.Phone;
                    Village_ID = result.Village_ID;
                    return true;
                }
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


        // ارجاع جميع الموظفين الخاصين بالمدينه 
        public static DataTable GetVillageInspectorsByCity(int cityID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string Query = @"
           SELECT i.InspectorID, i.InspectorName, i.Phone, i.City_ID, i.Village_ID FROM Inspectors i WHERE 
        i.Village_ID IS NOT NULL AND i.City_ID = @City_ID;";
                var Reader = connection.ExecuteReader(Query, new { City_ID = cityID });

                DataTable dt = new DataTable();
                dt.Load(Reader);
                return dt;
            }
        }
    }
}