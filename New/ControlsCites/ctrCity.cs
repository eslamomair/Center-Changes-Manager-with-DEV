using CenterChangesManager.BLL;
using DevExpress.XtraEditors;

namespace CenterChanges.ControlsCites
{
    public partial class ctrCity : DevExpress.XtraEditors.XtraUserControl
    {
        public ctrCity()
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                return;
            }

            try
            {
                InitializeDefaultState();
            }
            catch
            {
                // ولا كأن حاجة حصلت.. كمل رسم الشاشة فاضية
            }

            // InitializeDefaultState();
            layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never; // القرى
            layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never; // التوابع
            layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never; // زر الحفظ العام
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(0, 0, 650, 400);
            ucCity.SelectedValueChanged += (s, e) =>
            {


                FillVillage(ucCity.SelectedId);
            };
            ucDependencies.IsChkVisible = false;

            //  عند تغيير اختيار القرية -> قم بملء التوابع
            ucVillage.SelectedValueChanged += (s, e) => FillDependencies(ucVillage.SelectedId);
        }

        public void InitializeDefaultState()
        {
            // أ. ملء البيانات الأساسية (المدن فقط حالياً)
            FillCityCard();

            // ب. ضبط كنترول المدينة على وضع "الإضافة" (Textbox)
            // ده هيظهر التكيست، ويخفي الكومبو، ويظهر زر الحفظ الصغير الخاص بيه أوتوماتيك حسب كودك في ctrItemAll
            ucCity.IscmbVisible = false;



        }



        #region

        private void FillCityCard()
        {

            ucCity.FillCombo(clsCity.GetAllCities(false), "CityID", "CityName");
        }

        private void FillVillage(int CityID)
        {
            ucVillage.FillCombo(clsVillage.GetAllVillagesByCityID(CityID), "VillageID", "VillageName");
        }

        private void FillDependencies(int VillageID)
        {
            ucDependencies.FillCombo(clsDependency.GetAllDependenciesByVillageID(VillageID), "Dependency_ID", "DependencyName");
        }
        #endregion



        private void ucCity_isSelectedCHK(object sender, bool isChecked)
        {
            ucCity.IscmbVisible = isChecked;

            if (isChecked)
            {
                // إظهار كنترول القرية
                layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                // ✅ تحديد وضع القرية = إضافة (TextBox)
                ucVillage.IscmbVisible = false;

                // ملء بيانات القرى
                FillCityCard();
                FillVillage(ucCity.SelectedId);
            }
            else
            {
                layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void ucVillage_isSelectedCHK(object sender, bool isChecked)
        {

            ucVillage.IscmbVisible = isChecked;


            if (isChecked)
            {
                layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                // ✅ تحديد وضع التوابع = إضافة (TextBox)
                ucDependencies.IscmbVisible = false;
                FillVillage(ucCity.SelectedId);
                FillDependencies(ucVillage.SelectedId);
            }
            else
            {
                layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void ucDependencies_isSelectedCHK(object sender, bool isChecked)
        {
            // ucDependencies.IscmbVisible = isChecked;
            ucDependencies.IsChkVisible = false;

            //if (isChecked)
            //{
            //    layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //}
            //else
            //{
            //    layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //}
        }

        private void btnSaveAllUC_Click(object sender, EventArgs e)
        {
            if (btnSaveAllUC.Visible && ucCity.Visible && ucVillage.Visible && ucDependencies.Visible)
            {
                clsDependency dependency = new clsDependency();


            }
        }

        private void ucCity_OnSaveClick(object sender, EventArgs e)
        {
            string? CurrentCity = ucCity.ItemTextValue.Trim();
            if (string.IsNullOrEmpty(CurrentCity))
            {
                XtraMessageBox.Show("لا يمكن حفظ بيانات فارغه ");

                return;
            }


            if (clsCity.IsExists(CityName: CurrentCity))
            {

                XtraMessageBox.Show("اسم المدينه مسجل من قبل  ");

                return;
            }

            clsCity city = new clsCity();

            city.DataCity.CityName = CurrentCity;

            if (city.Save())
            {
                XtraMessageBox.Show($"{city.DataCity.CityName.ToString()}  تم حفظ المدينه بنجاح ");
                FillCityCard();
            }
            else
                XtraMessageBox.Show("تعذر الحفظ بيانات المدينة ");



        }

        private void ucVillage_OnSaveClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ucVillage.ItemTextValue))
            {
                XtraMessageBox.Show("لا يمكن حفظ بيانات فارغه ");
                return;
            }

            int? cityId = ucCity.SelectedId;
            if (!cityId.HasValue || cityId <= 0)
            {
                XtraMessageBox.Show("من فضلك اختر المدينة أولاً", "تنبيه",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (clsVillage.IsExist(VillageName: ucVillage.ItemTextValue.Trim()))
            {
                XtraMessageBox.Show("اسم القريه مسجل من قبل  ");

                return;
            }


            clsVillage village = new clsVillage();

            village.DataVillage.VillageName = ucVillage.ItemTextValue.Trim();
            village.DataVillage.CityID = cityId;

            if (village.Save())
            {
                XtraMessageBox.Show($"{village.DataVillage.VillageName.ToString()}  تم حفظ المدينه  ");
                FillVillage((int)cityId);
            }
            else
            {
                XtraMessageBox.Show("تعذر الحفظ بيانات القريه ");
            }

        }

        private void ucDependencies_OnSaveClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ucDependencies.ItemTextValue))
            {
                XtraMessageBox.Show("لا يمكن حفظ بيانات فارغه ");
                return;
            }

            //   للتأكد من اختيار القرية
            int villageId = ucVillage.SelectedId;
            if (villageId <= 0)
            {
                XtraMessageBox.Show("من فضلك اختر القرية أولاً", "تنبيه",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsDependency.IsExist(name: ucVillage.ItemTextValue.Trim()))
            {
                XtraMessageBox.Show("اسم التابع مسجل من قبل  ");

                return;
            }

            clsDependency Dep = new clsDependency();

            Dep.DataDependency.DependencyName = ucDependencies.ItemTextValue;
            Dep.DataDependency.Village_ID = villageId;



            if (Dep.Save())
            {
                XtraMessageBox.Show($"{Dep.DataDependency.DependencyName.ToString()}  تم حفظ التابع ");
                FillDependencies(ucVillage.SelectedId);
            }
            else
            {
                XtraMessageBox.Show("تعذر الحفظ بيانات التابع ");
            }
        }





        private void ucCity_OnEditButtonClick(object sender, EventArgs e)
        {
            int? Id = ucCity.SelectedId;

            if (Id <= 0)
            {
                return;
            }

            string CurrentName = ucCity.SelectedDisplayText.Trim();

            string newCityName = DevExpress.XtraEditors.XtraInputBox.Show("ادخل الاسم الصحيح", "تعديل اسم المدينه", CurrentName);
            if (!string.IsNullOrEmpty(newCityName) && newCityName != CurrentName)
            {

                if (clsCity.IsExists(CityName: newCityName))
                {

                    XtraMessageBox.Show("اسم المدينه مسجل من قبل  ");

                    return;
                }

                clsCity? City = clsCity.Find(Id);
                if (City == null)
                {
                    XtraMessageBox.Show("تعذر تعديل الاسم ", "خطا فى النظام", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                City.DataCity.CityName = newCityName.Trim();

                if (City.Save())
                {
                    XtraMessageBox.Show("تم تعديل اسم المدينه بنجاح");
                    FillCityCard();
                }
                else
                {
                    XtraMessageBox.Show("فشل تعديل اسم المدينه ");
                }


            }
        }

        private void ucVillage_OnEditButtonClick(object sender, EventArgs e)
        {
            int Id = ucVillage.SelectedId;
            int? CityId = ucCity.SelectedId;

            if (!CityId.HasValue || CityId <= 0)
            {
                XtraMessageBox.Show("من فضلك اختر المدينة أولاً", "تنبيه",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string CurrentText = ucVillage.SelectedDisplayText;

            string newVillage = DevExpress.XtraEditors.XtraInputBox.Show("ادخل اسم القريه الصحيح ", "تعديل اسم القريه ", CurrentText).Trim();


            if (!string.IsNullOrEmpty(newVillage) && CurrentText != newVillage)
            {
                clsVillage village = clsVillage.Find(Id);

                if (village == null)
                {
                    XtraMessageBox.Show("تعذر تعديل الاسم ", "خطا فى النظام", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                if (clsVillage.IsExist(VillageName: newVillage))
                {
                    XtraMessageBox.Show("اسم القريه مسجل من قبل  ");

                    return;
                }

                village.DataVillage.VillageName = newVillage.Trim();
                village.DataVillage.CityID = CityId;
                if (village.Save())
                {
                    XtraMessageBox.Show("تم تعديل اسم القرية بنجاح");
                    FillVillage(ucCity.SelectedId);
                }
                else
                {
                    XtraMessageBox.Show("فشل تعديل اسم القرية ");
                }



            }

        }

        private void ucDependencies_OnEditButtonClick(object sender, EventArgs e)
        {
            int Id = ucDependencies.SelectedId;
            int VillageId = ucVillage.SelectedId;



            if (VillageId <= 0)
            {
                XtraMessageBox.Show("من فضلك اختر القرية أولاً", "تنبيه",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            string CurrentText = ucDependencies.SelectedDisplayText;

            string NewDependencies = DevExpress.XtraEditors.XtraInputBox.Show("ادخل اسم التابع الصحيح ", "تعديل اسم القريه ", CurrentText).Trim();



            if (!string.IsNullOrEmpty(NewDependencies) && CurrentText != NewDependencies)
            {
                clsDependency Depe = clsDependency.Find(Id);

                if (Depe == null)
                {
                    XtraMessageBox.Show("تعذر تعديل الاسم ", "خطا فى النظام", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }


                if (clsDependency.IsExist(name: NewDependencies))
                {
                    XtraMessageBox.Show("اسم التابع مسجل من قبل  ");

                    return;
                }


                if (clsDependency.IsExist(NewDependencies))
                {
                    XtraMessageBox.Show("اسم التابع موجود من قبل ", "تنبيه",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Depe.DataDependency.DependencyName = NewDependencies.Trim();
                Depe.DataDependency.Village_ID = VillageId;
                if (Depe.Save())
                {
                    XtraMessageBox.Show("تم تعديل اسم التابع بنجاح");
                    FillDependencies(VillageId);
                }
                else
                {
                    XtraMessageBox.Show("فشل تعديل اسم التابع ");
                }

            }
        }

        private void ucCity_OnDeleteButtonClick(object sender, EventArgs e)
        {
            int Id = ucCity.SelectedId;
            string SelectedCity = ucCity.SelectedDisplayText;
            if (Id <= 0)
            {
                return;
            }

            if (XtraMessageBox.Show($"هل ترغب في حذف المدينه , {SelectedCity} , سيتم حذف التوابع الخاصه بالمدينه ايضا ، هل انت متاكد من عمليه الحذف", "تاكيد الحذف ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsCity.Delete(Id))
                {
                    XtraMessageBox.Show("تم الحذف بنجاح ");
                    FillCityCard();
                }
                else
                {
                    XtraMessageBox.Show("تعذر عمليه الحذف ");
                }
            }
        }

        private void ucVillage_OnDeleteButtonClick(object sender, EventArgs e)
        {
            int cityId = ucCity.SelectedId;
            int Id = ucVillage.SelectedId;
            string SelectedVillage = ucVillage.SelectedDisplayText;
            if (Id <= 0)
            {
                return;
            }

            if (XtraMessageBox.Show($"هل ترغب في حذف القرية , {SelectedVillage} , سيتم حذف التوابع الخاصه بالقرية ايضا ، هل انت متاكد من عمليه الحذف", "تاكيد الحذف ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsVillage.Delete(Id))
                {
                    XtraMessageBox.Show("تم الحذف بنجاح ");
                    FillVillage(cityId);
                }
                else
                {
                    XtraMessageBox.Show("تعذر عمليه الحذف ");
                }
            }
        }

        private void ucDependencies_OnDeleteButtonClick(object sender, EventArgs e)
        {
            int VillageID = ucVillage.SelectedId;
            int Id = ucDependencies.SelectedId;
            string SelectedVillage = ucDependencies.SelectedDisplayText;
            if (Id <= 0)
            {
                return;
            }

            if (XtraMessageBox.Show($"هل ترغب في حذف التابع , {SelectedVillage} ,  هل انت متاكد من عمليه الحذف", "تاكيد الحذف ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsDependency.Delete(Id))
                {
                    XtraMessageBox.Show("تم الحذف بنجاح ");
                    FillDependencies(VillageID);
                }
                else
                {
                    XtraMessageBox.Show("تعذر عمليه الحذف ");
                }
            }



        }
    }
}