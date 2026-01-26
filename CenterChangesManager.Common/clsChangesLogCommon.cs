using Dapper.Contrib.Extensions;
namespace CenterChangesManager.Common
{
    [Table("ChangesLog")]
    public class ChangesLog
    {
        [Key]
        public int? LogID { get; set; }          // Primary Key
        public int? CityID { get; set; }         // معرف المدينة
        public int? VillageID { get; set; }      // معرف القرية
        public int? Dependency_ID { get; set; }   // معرف التابع
        public string? ChangeNumber { get; set; } // رقم المتغير 
        public decimal? Latitude { get; set; }   // دائرة العرض
        public decimal? Longitude { get; set; }  // خط الطول
        public DateTime? ChangeDate { get; set; } // تاريخ التغير
        public string? Address { get; set; }     // العنوان
        public int? LocationStatusID { get; set; } // معرف حالة الموقع
        public string? OwnerName { get; set; }   // اسم المالك
        public int? ChangeType_ID { get; set; }   // معرف نوع التغير
        public int? Inspector_ID { get; set; }    // معرف المفتش

        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? Note { get; set; }
        public bool? IsActive { get; set; }



        [Write(false)]
        public string? CityName { get; set; }        // عشان يقرأ c.CityName
        [Write(false)]
        public string? VillageName { get; set; }     // عشان يقرأ v.VillageName
        [Write(false)]
        public string? ChangeType { get; set; }      // عشان يقرأ ct.TypeName AS ChangeType
        [Write(false)]
        public string? InspectorName { get; set; }   // عشان يقرأ i.InspectorName
        [Write(false)]
        public string? LocationStatus { get; set; }  // عشان يقرأ ls.StatusName AS LocationStatus
        [Write(false)]
        public string? DependencyName { get; set; }  // عشان يقرأ d.DependencyName

    }
}