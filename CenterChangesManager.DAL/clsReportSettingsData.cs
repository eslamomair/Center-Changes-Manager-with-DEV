using CenterChangesManager.Common;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CenterChangesManager.DAL
{
    public class clsReportSettingsData
    {

        public static ReportSettings? GetActiveSettings()
        {
            using (IDbConnection db = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                // نجلب آخر إعدادات تم تفعيلها (IsActive = 1)
                string sql = @"
                SELECT TOP 1 * FROM ReportSettings 
                WHERE IsActive = 1 
                ORDER BY ID DESC";

                return db.Query<ReportSettings>(sql).FirstOrDefault();
            }
        }


        public static int AddNew(ReportSettings Info)
        {
            using (IDbConnection db = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                db.Open();
                using (IDbTransaction Transaction = db.BeginTransaction())
                {
                    try
                    {
                        string Query = @" 
   INSERT INTO ReportSettings (GovernorateName, CenterName, IsSubCenterVisible, SubCenterName, DepartmentName, RecipientRank, RecipientJobTitle, RecipientEntityName, TechName, ManagerName, CenterHeadName, CreatedAt, UpdatedAt, IsActive)
VALUES (@GovernorateName, @CenterName, @IsSubCenterVisible, @SubCenterName, @DepartmentName, @RecipientRank, @RecipientJobTitle, @RecipientEntityName, @TechName, @ManagerName, @CenterHeadName, @CreatedAt, @UpdatedAt, @IsActive); 
 SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        db.Execute("Update ReportSettings set IsActive = 0", transaction: Transaction);
                        int id = db.QuerySingle<int>(Query, Info, transaction: Transaction);
                        Transaction.Commit();
                        return id;
                    }
                    catch (Exception)
                    {
                        Transaction.Rollback();
                        return -1;
                    }

                }



            }
        }


        public static bool Update(ReportSettings Info)
        {
            using (IDbConnection db = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                return db.Update(Info);
            }
        }
    }
}
