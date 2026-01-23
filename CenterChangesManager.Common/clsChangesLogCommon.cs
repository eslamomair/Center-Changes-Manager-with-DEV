namespace CenterChangesManager.Common
{
    public class ChangesLog
    {
        public int? LogID { get; set; }          // Primary Key
        public int? CityID { get; set; }         // معرف المدينة
        public int? VillageID { get; set; }      // معرف القرية
        public int? DependencyID { get; set; }   // معرف التابع
        public string? ChangeNumber { get; set; } // رقم المتغير 
        public decimal? Latitude { get; set; }   // دائرة العرض
        public decimal? Longitude { get; set; }  // خط الطول
        public DateTime? ChangeDate { get; set; } // تاريخ التغير
        public string? Address { get; set; }     // العنوان
        public int? LocationStatusID { get; set; } // معرف حالة الموقع
        public string? OwnerName { get; set; }   // اسم المالك
        public int? ChangeTypeID { get; set; }   // معرف نوع التغير
        public int? InspectorID { get; set; }    // معرف المفتش

        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? Note { get; set; }
        public bool? IsActive { get; set; }

        public string? CityName { get; set; }        // عشان يقرأ c.CityName
        public string? VillageName { get; set; }     // عشان يقرأ v.VillageName
        public string? ChangeType { get; set; }      // عشان يقرأ ct.TypeName AS ChangeType
        public string? InspectorName { get; set; }   // عشان يقرأ i.InspectorName
        public string? LocationStatus { get; set; }  // عشان يقرأ ls.StatusName AS LocationStatus
        public string? DependencyName { get; set; }  // عشان يقرأ d.DependencyName

    }
}