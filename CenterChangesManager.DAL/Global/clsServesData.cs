using Dapper;
using Microsoft.Data.SqlClient;

using System.Data;


namespace CenterChangesManager.DAL.Global
{
    public class clsServesData
    {


        public static int GetActiveChangesCount()
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT COUNT(*) FROM ChangesLog WHERE IsActive = 1";

                return connection.ExecuteScalar<int>(query);

            }
        }


        public static int GetActiveChangesCountByType(int changeTypeID)
        {
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM ChangesLog WHERE IsActive = 1 AND ChangeType_ID = @TypeID";
                return connection.ExecuteScalar<int>(query, new { TypeID = changeTypeID });
            }
        }

        public static DataTable GetCountWithName()
        {
            DataTable dt = new DataTable();
            using (IDbConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 
    c.CityName AS 'Names',
    'مدينة' AS 'TypeInfo',
    COUNT(cl.LogID) AS 'CityOnly', -- بما إنها مدينة فكل اللي فيها يتبع المدينة
    0 AS 'VillageOnly',              -- المدينة ليس لها قرية
    0 AS 'Dep',                     -- المدينة ليس لها توابع
    COUNT(cl.LogID) AS 'Total'
FROM ChangesLog cl
INNER JOIN Cities c ON cl.CityID = c.CityID
WHERE cl.Village_ID IS NULL AND cl.IsActive = 1
GROUP BY c.CityName

UNION ALL

/* الجزء الثاني: القرى */
SELECT 
    v.VillageName AS 'Names',
    'قرية' AS 'TypeInfo',
    0 AS 'VillageOnly',              -- هذا السطر يخص قرية وليس مدينة مباشرة
    -- متغيرات القرية فقط (التي ليس لها تابع)
    SUM(CASE WHEN cl.Dependency_ID IS NULL THEN 1 ELSE 0 END) AS 'VillageOnly',
    -- عدد التوابع فقط (التي لها Dependency_ID)
    SUM(CASE WHEN cl.Dependency_ID IS NOT NULL THEN 1 ELSE 0 END) AS 'Dep',
    -- الإجمالي (القرية + توابعها)
    COUNT(cl.LogID) AS 'Total'
FROM ChangesLog cl
INNER JOIN Villages v ON cl.Village_ID = v.Village_ID
WHERE cl.IsActive = 1
GROUP BY v.VillageName

ORDER BY 'TypeInfo','Names';";


                try
                {
                    // Dapper: ExecuteReader is the best way to fill a DataTable
                    using (var reader = connection.ExecuteReader(query))
                    {
                        dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    // تعامل مع الخطأ هنا
                    // Console.WriteLine(ex.Message);
                }
            }

            return dt;
        }
    }
}
