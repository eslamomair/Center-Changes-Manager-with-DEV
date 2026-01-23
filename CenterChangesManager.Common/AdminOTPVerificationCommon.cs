namespace CenterChangesManager.Common
{
    public class AdminOTPVerificationCommon
    {

        public int? ID { get; set; } // Primary Key
        public int? AdminUserID { get; set; } // Foreign Key to Admin User
        public string? Purpose { get; set; } = "RequestNewUserCreation"; // e.g., "RequestNewUserCreation"
        public string? OTP { get; set; } = string.Empty; // One-Time Password
        public DateTime? ExpiryTime { get; set; } = null;// لوقت الذي ينتهي بعده صلاحية الرمز
        public bool? IsUsed { get; set; } // Indicates if OTP has been used
        public DateTime? CreatedAt { get; set; } = null;// Creation Timestamp
        public byte? AttemptCount { get; set; } // Number of verification attempts
    }
}
