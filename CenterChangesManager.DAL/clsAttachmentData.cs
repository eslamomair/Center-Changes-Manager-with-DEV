using Microsoft.Data.SqlClient;
using System.Data;

namespace CenterChangesManager.DAL
{

    public static class clsChangeAttachmentData
    {
        // ==========================================
        // 1. إضافة مرفق جديد
        // ==========================================
        public static int AddNewAttachment(
            int? logID,
            string? fileName,
            string? fileExtension,
            byte[]? fileData,
            int? uploadedBy)
        {
            int newID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    INSERT INTO ChangeAttachments 
                    (Log_ID, FileName, FileExtension, FileData, FileSize, UploadedBy, UploadDate)
                    VALUES 
                    (@LogID, @FileName, @FileExtension, @FileData, @FileSize, @UploadedBy, GETDATE());
                    
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LogID", logID);
                    command.Parameters.AddWithValue("@FileName", fileName);
                    command.Parameters.AddWithValue("@FileExtension", fileExtension);
                    command.Parameters.AddWithValue("@FileData", fileData);
                    command.Parameters.AddWithValue("@FileSize", fileData.Length);
                    command.Parameters.AddWithValue("@UploadedBy", uploadedBy);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            newID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        // يمكن استخدام Logger هنا
                        System.Diagnostics.Debug.WriteLine($"Error in AddNewAttachment: {ex.Message}");
                    }
                }
            }

            return newID;
        }

        // ==========================================
        // 2. استرجاع محتوى الملف (Binary Data)
        // ==========================================
        public static byte[]? GetAttachmentFileData(int? attachmentID)
        {
            byte[]? fileData = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT FileData 
                    FROM ChangeAttachments 
                    WHERE AttachmentID = @AttachmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AttachmentID", attachmentID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            fileData = (byte[])result;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error in GetAttachmentFileData: {ex.Message}");
                    }
                }
            }

            return fileData;
        }

        // ==========================================
        // 3. جلب معلومات مرفق معين (بدون الملف نفسه)
        // ==========================================
        public static bool GetAttachmentInfoByID(
            int? attachmentID,
            ref int? logID,
            ref string? fileName,
            ref string? fileExtension,
            ref int? fileSize,
            ref int? uploadedBy,
            ref DateTime? uploadDate)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT 
                        Log_ID, FileName, FileExtension, 
                        FileSize, UploadedBy, UploadDate
                    FROM ChangeAttachments
                    WHERE AttachmentID = @AttachmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AttachmentID", attachmentID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                logID = reader["Log_ID"] != DBNull.Value ? (int)reader["Log_ID"] : -1;
                                fileName = reader["FileName"] != DBNull.Value ? (string)reader["FileName"] : "";
                                fileExtension = reader["FileExtension"] != DBNull.Value ? (string)reader["FileExtension"] : "";
                                fileSize = reader["FileSize"] != DBNull.Value ? (int)reader["FileSize"] : 0;
                                uploadedBy = (int)reader["UploadedBy"];
                                uploadDate = (DateTime)reader["UploadDate"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error in GetAttachmentInfoByID: {ex.Message}");
                    }
                }
            }

            return isFound;
        }

        // ==========================================
        // 4. حذف مرفق نهائياً
        // ==========================================
        public static bool DeleteAttachment(int? attachmentID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM ChangeAttachments WHERE AttachmentID = @AttachmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AttachmentID", attachmentID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error in DeleteAttachment: {ex.Message}");
                    }
                }
            }

            return (rowsAffected > 0);
        }

        // ==========================================
        // 5. جلب جميع مرفقات سجل معين
        // ==========================================
        public static DataTable GetAllAttachmentsByLogID(int? logID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT 
                        ca.AttachmentID,
                        ca.FileName,
                        ca.FileExtension,
                        ca.FileSize,
                        ca.UploadDate,
                        u.UserName AS UploadedBy
                    FROM ChangeAttachments ca
                    INNER JOIN Users u ON ca.UploadedBy = u.UserID
                    WHERE ca.Log_ID = @LogID
                    ORDER BY ca.UploadDate DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LogID", logID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error in GetAllAttachmentsByLogID: {ex.Message}");
                    }
                }
            }

            return dt;
        }

        // ==========================================
        // 6. عدد المرفقات لسجل معين
        // ==========================================
        public static int? GetAttachmentsCountByLogID(int? logID)
        {
            int? count = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT COUNT(*) 
                    FROM ChangeAttachments 
                    WHERE Log_ID = @LogID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LogID", logID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int totalCount))
                        {
                            count = totalCount;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error in GetAttachmentsCountByLogID: {ex.Message}");
                    }
                }
            }

            return count;
        }

        // ==========================================
        // 7. إجمالي حجم المرفقات لسجل معين
        // ==========================================
        public static long? GetTotalAttachmentsSizeByLogID(int? logID)
        {
            long? totalSize = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT ISNULL(SUM(FileSize), 0) 
                    FROM ChangeAttachments 
                    WHERE Log_ID = @LogID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LogID", logID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            totalSize = Convert.ToInt64(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error in GetTotalAttachmentsSizeByLogID: {ex.Message}");
                    }
                }
            }

            return totalSize;
        }

        // ==========================================
        // 8. التحقق من وجود مرفق
        // ==========================================
        public static bool IsAttachmentExist(int? attachmentID)
        {
            bool isExist = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT 1 
                    FROM ChangeAttachments 
                    WHERE AttachmentID = @AttachmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AttachmentID", attachmentID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        isExist = (result != null);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error in IsAttachmentExist: {ex.Message}");
                    }
                }
            }

            return isExist;
        }

        // ==========================================
        // 9. حذف جميع مرفقات سجل معين
        // ==========================================
        public static bool DeleteAllAttachmentsByLogID(int? logID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM ChangeAttachments WHERE Log_ID = @LogID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LogID", logID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error in DeleteAllAttachmentsByLogID: {ex.Message}");
                    }
                }
            }

            return (rowsAffected > 0);
        }

        // ==========================================
        // 10. جلب جميع المرفقات (للإدارة)
        // ==========================================
        public static DataTable GetAllAttachments()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT 
                        ca.AttachmentID,
                        ca.Log_ID,
                        cl.ChangeNumber,
                        ca.FileName,
                        ca.FileExtension,
                        ca.FileSize,
                        ca.UploadDate,
                        u.UserName AS UploadedBy
                    FROM ChangeAttachments ca
                    INNER JOIN ChangesLog cl ON ca.Log_ID = cl.LogID
                    INNER JOIN Users u ON ca.UploadedBy = u.UserID
                    ORDER BY ca.UploadDate DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error in GetAllAttachments: {ex.Message}");
                    }
                }
            }

            return dt;
        }
    }
}

