using CenterChangesManager.Common;
using CenterChangesManager.DAL;

namespace CenterChangesManager.BLL
{



    public class clsAdminOTP
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode;

        public AdminOTPVerificationCommon AdminDate { get; set; }

        public clsAdminOTP()
        {
            AdminDate = new AdminOTPVerificationCommon
            {
                ID = null,
                AdminUserID = null,
                Purpose = "RequestNewUserCreation",
                OTP = string.Empty,
                ExpiryTime = DateTime.Now.AddMinutes(3),
                IsUsed = false,
                CreatedAt = DateTime.Now,
                AttemptCount = 0,
            };
            Mode = enMode.AddNew;
        }

        private clsAdminOTP(AdminOTPVerificationCommon adminDate)
        {
            AdminDate = new AdminOTPVerificationCommon
            {
                ID = adminDate.ID,
                AdminUserID = adminDate.AdminUserID,
                Purpose = adminDate.Purpose,
                OTP = adminDate.OTP,
                ExpiryTime = adminDate.ExpiryTime,
                IsUsed = adminDate.IsUsed,
                CreatedAt = adminDate.CreatedAt,
                AttemptCount = adminDate.AttemptCount,
            };
            Mode = enMode.Update;
        }

        // 1. حفظ سجل OTP جديد في قاعدة البيانات
        public async Task<bool> AddNew()
        {

            this.AdminDate.ID = await clsAdminOTPData.AddNewData(this.AdminDate);
            return this.AdminDate.ID != null;
        }


        // 2. جلب رمز OTP نشط (لم يُستخدم و لم ينتهِ وقته) خاص بالمسؤول الحالي
        public static async Task<clsAdminOTP> GetActiveOTPByAdminAsync(int adminUserId)
        {
            if (await clsAdminOTPData.GetActiveOTPByAdminAsync(adminUserId) != null)
            {
                return new clsAdminOTP(await clsAdminOTPData.GetActiveOTPByAdminAsync(adminUserId));
            }
            else
                return null;
        }

        // 3. تعديل السجل ليصبح "مستخدمًا" بعد التحقق الناجح
        public static async Task<bool> MarkAsUsedAsync(int? id)
        {
            return await clsAdminOTPData.MarkAsUsedAsync(id);

        }

        // 4. زيادة عدد محاولات الإدخال الخاطئة لهذا السجل
        public static async Task<bool> IncrementAttemptCountAsync(int? id)
        {
            return await clsAdminOTPData.IncrementAttemptCountAsync(id);
        }

        // 5. جلب عدد محاولات الإدخال الخاطئة لهذا السجل
        public static async Task<int?> GetAttemptCountAsync(int? id)
        {
            return await clsAdminOTPData.GetAttemptCountAsync(id);
        }


        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (await AddNew())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    return false;

            }
            return false;
        }
    }
}
