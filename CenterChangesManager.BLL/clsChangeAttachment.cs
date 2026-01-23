using CenterChangesManager.DAL;
using System.Data;

namespace CenterChangesManager.BLL
{
    public class clsChangeAttachment
    {

        // ==========================================
        // Enums
        // ==========================================
        public enum enMode { AddNew = 0, Update = 1 }

        // ==========================================
        // Properties
        // ==========================================
        public int? AttachmentID { get; set; }
        public int? Log_ID { get; set; }
        public string? FileName { get; set; }
        public string? FileExtension { get; set; }
        public int? FileSize { get; set; }
        public int? UploadedBy { get; set; }
        public DateTime? UploadDate { get; set; }

        public enMode Mode { get; set; }

        // Property محسوب - تنسيق حجم الملف
        public string FileSizeFormatted
        {
            get
            {
                if (FileSize < 1024)
                    return $"{FileSize} بايت";
                else if (FileSize < 1024 * 1024)
                    return $"{FileSize / 1024.0:F2} كيلوبايت";
                else if (FileSize < 1024 * 1024 * 1024)
                    return $"{FileSize / (1024.0 * 1024.0):F2} ميجابايت";
                else
                    return $"{FileSize / (1024.0 * 1024.0 * 1024.0):F2} جيجابايت";
            }
        }

        // Property محسوب - أيقونة حسب نوع الملف
        public string? FileIcon
        {
            get
            {
                string? ext = FileExtension.ToLower();

                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif" || ext == ".bmp")
                    return "🖼️";
                else if (ext == ".pdf")
                    return "📄";
                else if (ext == ".doc" || ext == ".docx")
                    return "📝";
                else if (ext == ".xls" || ext == ".xlsx")
                    return "📊";
                else if (ext == ".zip" || ext == ".rar")
                    return "📦";
                else
                    return "📎";
            }
        }

        // ==========================================
        // Constructors
        // ==========================================
        public clsChangeAttachment()
        {
            this.AttachmentID = -1;
            this.Log_ID = -1;
            this.FileName = "";
            this.FileExtension = "";
            this.FileSize = 0;
            this.UploadedBy = -1;
            this.UploadDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsChangeAttachment(int? attachmentID, int? logID, string? fileName,
            string? fileExtension, int? fileSize, int? uploadedBy, DateTime? uploadDate)
        {
            this.AttachmentID = attachmentID;
            this.Log_ID = logID;
            this.FileName = fileName;
            this.FileExtension = fileExtension;
            this.FileSize = fileSize;
            this.UploadedBy = uploadedBy;
            this.UploadDate = uploadDate;

            Mode = enMode.Update;
        }

        // ==========================================
        // Private Methods
        // ==========================================
        private bool _AddNew(byte[] fileData)
        {
            this.AttachmentID = clsChangeAttachmentData.AddNewAttachment(
                this.Log_ID,
                this.FileName,
                this.FileExtension,
                fileData,
                this.UploadedBy);

            return (this.AttachmentID != -1);
        }

        // ==========================================
        // Public Methods - Save
        // ==========================================

        /// <summary>
        /// حفظ المرفق - يستقبل البيانات كـ Byte Array
        /// </summary>
        public bool Save(byte[] fileData)
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew(fileData))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                default:
                    return false;
            }
        }

        /// <summary>
        /// حفظ المرفق من مسار ملف - دالة مساعدة
        /// </summary>
        /// 
        [Obsolete("Use Save(byte[] fileData) instead. Compression should be handled in UI layer.")]
        public bool SaveFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return false;

            byte[] fileData = File.ReadAllBytes(filePath);

            // تعيين الاسم والامتداد تلقائياً
            this.FileName = Path.GetFileName(filePath);
            this.FileExtension = Path.GetExtension(filePath);
            this.FileSize = fileData.Length;

            return Save(fileData);
        }

        // ==========================================
        // Public Methods - Find
        // ==========================================

        /// <summary>
        /// البحث عن مرفق بالـ ID - يجلب المعلومات فقط (بدون الملف)
        /// </summary>
        public static clsChangeAttachment Find(int? attachmentID)
        {
            int? logID = -1;
            string? fileName = "";
            string? fileExtension = "";
            int? fileSize = 0;
            int? uploadedBy = -1;
            DateTime? uploadDate = DateTime.Now;

            if (clsChangeAttachmentData.GetAttachmentInfoByID(
                attachmentID,
                ref logID,
                ref fileName,
                ref fileExtension,
                ref fileSize,
                ref uploadedBy,
                ref uploadDate))
            {
                return new clsChangeAttachment(
                    attachmentID,
                    logID,
                    fileName,
                    fileExtension,
                    fileSize,
                    uploadedBy,
                    uploadDate);
            }

            return null;
        }

        // ==========================================
        // Public Methods - Download
        // ==========================================

        /// <summary>
        /// تحميل محتوى الملف - يجلب البيانات الثنائية
        /// </summary>
        public byte[]? DownloadFileData()
        {
            return clsChangeAttachmentData.GetAttachmentFileData(this.AttachmentID);
        }

        /// <summary>
        /// حفظ الملف في مكان آخر (Save As)
        /// </summary>
        public bool SaveToFile(string destinationPath)
        {
            byte[] fileData = DownloadFileData();

            if (fileData == null || fileData.Length == 0)
                return false;

            try
            {
                File.WriteAllBytes(destinationPath, fileData);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// فتح الملف مباشرة (يحفظه مؤقتاً ويفتحه)
        /// </summary>
        public bool OpenFile()
        {
            byte[] fileData = DownloadFileData();

            if (fileData == null || fileData.Length == 0)
                return false;

            try
            {
                // حفظ مؤقت
                string tempPath = Path.Combine(Path.GetTempPath(), this.FileName);
                File.WriteAllBytes(tempPath, fileData);

                // فتح
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = tempPath,
                    UseShellExecute = true
                });

                return true;
            }
            catch
            {
                return false;
            }
        }

        // ==========================================
        // Public Methods - Delete
        // ==========================================

        /// <summary>
        /// حذف المرفق نهائياً
        /// </summary>
        public bool Delete()
        {
            return clsChangeAttachmentData.DeleteAttachment(this.AttachmentID);
        }

        /// <summary>
        /// حذف مرفق بالـ ID - Static Method
        /// </summary>
        public static bool Delete(int attachmentID)
        {
            return clsChangeAttachmentData.DeleteAttachment(attachmentID);
        }

        // ==========================================
        // Public Methods - Exist
        // ==========================================

        /// <summary>
        /// التحقق من وجود المرفق
        /// </summary>
        public static bool IsExist(int attachmentID)
        {
            return clsChangeAttachmentData.IsAttachmentExist(attachmentID);
        }

        // ==========================================
        // Static Methods - Lists & Statistics
        // ==========================================

        /// <summary>
        /// جلب جميع مرفقات سجل معين
        /// </summary>
        public static DataTable GetAllByLogID(int logID)
        {
            return clsChangeAttachmentData.GetAllAttachmentsByLogID(logID);
        }

        /// <summary>
        /// عدد مرفقات سجل معين
        /// </summary>
        public static int? GetCountByLogID(int? logID)
        {
            return clsChangeAttachmentData.GetAttachmentsCountByLogID(logID);
        }

        /// <summary>
        /// إجمالي حجم مرفقات سجل معين
        /// </summary>
        public static long? GetTotalSizeByLogID(int? logID)
        {
            return clsChangeAttachmentData.GetTotalAttachmentsSizeByLogID(logID);
        }

        /// <summary>
        /// إجمالي حجم مرفقات سجل معين (منسق)
        /// </summary>
        public static string? GetTotalSizeFormattedByLogID(int? logID)
        {
            long? totalSize = GetTotalSizeByLogID(logID);

            if (totalSize < 1024)
                return $"{totalSize} بايت";
            else if (totalSize < 1024 * 1024)
                return $"{totalSize / 1024.0:F2} كيلوبايت";
            else if (totalSize < 1024 * 1024 * 1024)
                return $"{totalSize / (1024.0 * 1024.0):F2} ميجابايت";
            else
                return $"{totalSize / (1024.0 * 1024.0 * 1024.0):F2} جيجابايت";
        }

        /// <summary>
        /// حذف جميع مرفقات سجل معين
        /// </summary>
        public static bool DeleteAllByLogID(int logID)
        {
            return clsChangeAttachmentData.DeleteAllAttachmentsByLogID(logID);
        }

        /// <summary>
        /// جلب جميع المرفقات (للإدارة)
        /// </summary>
        public static DataTable GetAll()
        {
            return clsChangeAttachmentData.GetAllAttachments();
        }
    }
}