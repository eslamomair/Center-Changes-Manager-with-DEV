using Dapper.Contrib.Extensions;

namespace CenterChangesManager.Common
{
    [Table("ReportSettings")]
    public class ReportSettings
    {
        [Key]
        public int ID { get; set; }

        // بيانات الترويسة
        public string GovernorateName { get; set; }
        public string CenterName { get; set; }
        public bool IsSubCenterVisible { get; set; }
        public string SubCenterName { get; set; }
        public string DepartmentName { get; set; }

        // بيانات المخاطبة
        public string RecipientRank { get; set; }
        public string RecipientJobTitle { get; set; }
        public string RecipientEntityName { get; set; }

        // بيانات التذييل
        public string TechName { get; set; }
        public string ManagerName { get; set; }
        public string CenterHeadName { get; set; }

        // تواريخ وحالة
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
