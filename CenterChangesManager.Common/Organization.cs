using Dapper.Contrib.Extensions;
namespace CenterChangesManager.Common
{
    [Table("OrganizationSettings")]
    public class Organization
    {
        // المعرف الوحيد للسجل، ونستخدم ExplicitKey لأننا سنعطيه القيمة (1) يدوياً
        [ExplicitKey]
        public int OrganizationID { get; set; }

        // اسم الجهة الكبرى (مثلاً: محافظة الدقهلية)
        public string OrgName { get; set; }

        // اسم الإدارة التابع لها البرنامج (مثلاً: رءاسه مركز)
        public string DeptName { get; set; }

        // اسم القسم الفرعي داخل الإدارة (مثلاً: وحده محليه تابعه للرئاسه)
        public string? SubDeptName { get; set; }

        // العنوان التفصيلي للمقر ليظهر في مراسلات البرنامج
        public string? FullAddress { get; set; }

        // رقم التليفون الخاص بالتواصل مع الإدارة
        public string? PhoneNumber { get; set; }

        // البريد الإلكتروني الرسمي لاستقبال المراسلات الرقمية
        public string? EmailAddress { get; set; }

        // مصفوفة بايتات لتخزين صورة الشعار (يتم تحويلها من PictureEdit في الواجهة)
        public byte[] OrgLogo { get; set; }

        // نص طويل لوصف مهام الإدارة أو نبذة تعريفية عنها
        public string? AboutDept { get; set; }

    }
}
