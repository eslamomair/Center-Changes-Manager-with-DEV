using CenterChangesManager.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CenterChangesManager.DAL
{
    public class clsCityData
    {

        public static int AddNew(string cityName)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                // جملة SQL: بتضيف وترجع آخر ID اتعمله إنشاء
                string query = @"INSERT INTO Cities (CityName) 
                                 VALUES (@Name);
                                 SELECT CAST(SCOPE_IDENTITY() as int);";

                // Dapper ExecuteScalar: بتنفذ وبترجع أول قيمة (اللي هي الـ ID)
                // لاحظ إننا بعتنا Parameters بشكل شيك جداً (Anonymous Object)
                return connection.ExecuteScalar<int>(query, new { Name = cityName });
            }
        }

        public static bool Update(int? cityID, string? cityName)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Cities 
                                 SET CityName = @Name 
                                 WHERE CityID = @ID";

                // Execute: بترجع عدد الصفوف المتأثرة
                int rowsAffected = connection.Execute(query, new { Name = cityName, ID = cityID });
                return rowsAffected > 0;
            }
        }

        public static bool GetCityInfoByID(int? cityID, ref string? cityName)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Cities WHERE CityID = @ID";

                // QueryFirstOrDefault: هات أول صف أو null
                var result = connection.QueryFirstOrDefault(query, new { ID = cityID });

                if (result != null)
                {
                    cityName = result.CityName;
                    return true;
                }
                return false;
            }
        }

        // داخل ملف clsCityData.cs
        public static List<Cites?> GetAllCities()
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                var cites = connection.Query<Cites?>("SELECT CityID, CityName FROM Cities");
                return cites.ToList();
            }
        }

        public static List<Cites?> GetAllGetCityByID(int? ID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT CityID, CityName FROM Cities WHERE CityID = @ID";
                var subCites = connection.Query<Cites?>(query, new { ID = ID });

                return subCites.ToList();
            }
        }

        // داخل ملف clsCity.cs
        public static bool Delete(int cityID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                // لاحظ: بسبب تفعيل ON DELETE CASCADE في قاعدة البيانات (لو فعلتها)، 
                // حذف المدينة سيحذف القرى والتوابع تلقائياً.
                string query = "DELETE FROM Cities WHERE CityId = @ID";

                // Execute بترجع عدد الصفوف المحذوفة، لو أكبر من 0 يبقى نجح
                return connection.Execute(query, new { ID = cityID }) > 0;
            }
        }
    }
}

