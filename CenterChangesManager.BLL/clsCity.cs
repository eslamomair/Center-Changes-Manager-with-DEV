
using CenterChangesManager.Common;
using CenterChangesManager.DAL;

namespace CenterChangesManager.BLL
{
    public class clsCity
    {
        public enum enMode
        {
            AddNew = 1, Update = 2
        }
        public enMode Mode;


        public Cites DataCity { get; set; }

        public clsCity()
        {
            DataCity = new Cites();
            this.DataCity.CityID = -1;
            this.DataCity.CityName = string.Empty;
            Mode = enMode.AddNew;
        }

        private clsCity(int? cityID, string? cityName)
        {
            DataCity = new Cites();
            this.DataCity.CityID = cityID;
            this.DataCity.CityName = cityName;
            Mode = enMode.Update;
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update; // بعد الحفظ يتحول لتعديل
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        private bool _AddNew()
        {
            // بنبعت الاسم للداتا بيز، وبترجعلنا الـ ID الجديد
            this.DataCity.CityID = clsCityData.AddNew(this.DataCity.CityName);
            return (this.DataCity.CityID != -1);
        }

        private bool _Update()
        {
            // لسه هنعملها في الـ DAL
            return clsCityData.Update(this.DataCity.CityID, this.DataCity.CityName);
        }

        // دالة لجلب مدينة بالـ ID (مصنع اوبجيكت)
        public static clsCity? Find(int? cityID)
        {
            string cityName = "";
            if (clsCityData.GetCityInfoByID(cityID, ref cityName))
            {
                // لو لقيناها بنرجع اوبجيكت جاهز
                return new clsCity(cityID, cityName);
            }
            else
            {
                return null;
            }
        }

        public static List<Cites?> GetAllCities(bool AddAll = false)
        {
            var C = clsCityData.GetAllCities();

            if (AddAll)
            {
                C.Insert(0, new Cites { CityID = -1, CityName = "--الكل--" });
                return C;
            }
            else
                return C;
        }

        public static List<Cites> GetCityByID(int? ID, bool AddAll = false)
        {
            var C = clsCityData.GetAllGetCityByID(ID);
            if (AddAll)
            {
                C.Insert(0, new Cites { CityID = -1, CityName = "--الكل--" });

            }

            return C;
        }

        // دالة static لأننا لا نحتاج لإنشاء كائن مدينة لنحذفه، فقط نحتاج الـ ID
        public static bool Delete(int cityID)
        {
            return clsCityData.Delete(cityID);
        }


        public static bool IsExists(string? CityName = null, int? CityId = null)
        {
            return clsCityData.IsExist(CityName, CityId);
        }
    }
}

