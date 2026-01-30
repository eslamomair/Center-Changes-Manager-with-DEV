using CenterChangesManager.BLL.Global;
using DevExpress.Map;
using DevExpress.XtraMap;
using System.Data;

namespace CenterChangesManager.Main.DSHBO
{
    public partial class ctrDashboardChanges : DevExpress.XtraEditors.XtraUserControl
    {

        private enum ChangeTypes
        {
            Legal = 1,
            Lllegal = 2,
            Other = 3
        }

        public ctrDashboardChanges()
        {
            InitializeComponent();


            //  Maps();

        }
        private void Provider_WebRequest(object sender, MapWebRequestEventArgs e)
        {
            // هنا بنحط التوكيـل عشان جوجل يقبلنا
            e.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.159 Safari/537.36";
        }

        private void Maps()
        {


            // داخل الـ Constructor أو Form_Load


            ImageLayer imageLayer = new ImageLayer();
            OpenStreetMapDataProvider provider = new OpenStreetMapDataProvider();

            // 1. إضافة User Agent (ضروري جداً عشان جوجل يقبل الطلب)

            // 2. الرابط الصحيح (لاحظ الأرقام 2 و 3 و 1)
            provider.TileUriTemplate = @"https://mt1.google.com/vt/lyrs=y&x={2}&y={3}&z={1}";
            provider.WebRequest += Provider_WebRequest;
            imageLayer.DataProvider = provider;
            mapControl1.Layers.Add(imageLayer);

            // إحداثيات مصر
            mapControl1.CenterPoint = new GeoPoint(30.0444, 31.2357);
            mapControl1.ZoomLevel = 6;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. قراءة الأرقام من التيكست بوكس
                // تأكد إن الأسماء عندك زي ما هي في الكود (textEditLat, textEditLng)
                double lat = Convert.ToDouble(txtLat.Text);
                double lng = Convert.ToDouble(txtLng.Text);

                // 2. إنشاء نقطة جغرافية
                GeoPoint location = new GeoPoint(lat, lng);

                // 3. توجيه الخريطة للنقطة دي
                mapControl1.CenterPoint = location;

                // 4. تقريب الزوم (عشان تشوف البيت بوضوح)
                mapControl1.ZoomLevel = 19; // رقم 19 بيجيب زوم قريب جداً

                // --- (إضافي) لو عايز تحط دبوس أحمر مكان البحث ---
                AddMarkerAt(location);
            }
            catch
            {
                MessageBox.Show("تأكد من كتابة الأرقام بشكل صحيح");
            }
        }


        private void AddMarkerAt(GeoPoint point)
        {
            // بنشوف لو عندنا طبقة للدبابيس ولا لسه، لو مفيش نعمل واحدة
            VectorItemsLayer markersLayer = mapControl1.Layers["MarkersLayer"] as VectorItemsLayer;

            if (markersLayer == null)
            {
                markersLayer = new VectorItemsLayer();
                markersLayer.Name = "MarkersLayer"; // بنسميها عشان نعرف نجيبها تاني
                MapItemStorage storage = new MapItemStorage();
                markersLayer.Data = storage;
                mapControl1.Layers.Add(markersLayer);
            }

            // تنظيف الدبابيس القديمة (اختياري)
            ((MapItemStorage)markersLayer.Data).Items.Clear();

            // إضافة الدبوس الجديد
            MapPushpin pin = new MapPushpin();
            pin.Location = point;
            pin.Text = "الموقع";
            ((MapItemStorage)markersLayer.Data).Items.Add(pin);
        }

        private void mapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            // 1. تحويل مكان الماوس على الشاشة إلى إحداثيات جغرافية
            // e.Location هو مكان الماوس
            CoordPoint point = mapControl1.ScreenPointToCoordPoint(new MapPoint(e.X, e.Y));

            // 2. تحويل النتيجة لنوع GeoPoint عشان نقرأ خطوط الطول والعرض
            GeoPoint geoPoint = (GeoPoint)point;

            // 3. كتابة الأرقام في التيكست بوكس
            txtLat.Text = geoPoint.Latitude.ToString();
            txtLng.Text = geoPoint.Longitude.ToString();

            // 4. (إضافي) وضع دبوس مكان الضغطة عشان تبقى شايف المكان
            AddMarkerAt(geoPoint);
            //LoadChartData();
        }


        private void LoadChartData()
        {
            try
            {
                // هات البيانات من الكلاس بتاعك
                // تأكد إنك غيرت clsYourClassName لاسم الكلاس الحقيقي عندك
                DataTable dt = clsServes.GetCountWithName();

                //// === كاشف الأخطاء (مهم جداً) ===
                //// السطر ده هيطلعلك رسالة يقولك جبنا كام صف
                //MessageBox.Show("عدد الصفوف الموجودة: " + dt.Rows.Count.ToString());

                //if (dt.Rows.Count == 0)
                //{
                //    MessageBox.Show("البيانات فارغة! تأكد من جملة الاستعلام SQL وإن في بيانات IsActive=1");
                //    return;
                //}
                // ==============================

                chartControl1.DataSource = null;
                chartControl1.Series.Clear();
                chartControl1.DataSource = dt;

                DevExpress.XtraCharts.Series series = new DevExpress.XtraCharts.Series("المتغيرات", DevExpress.XtraCharts.ViewType.Bar);

                // تأكد أن الأسماء هنا تطابق أسماء الأعمدة في جملة الـ SQL بالحرف
                series.ArgumentDataMember = "Names";
                series.ValueDataMembers.AddRange(new string[] { "Total" });

                chartControl1.Series.Add(series);

                // إظهار القيم فوق الأعمدة
                series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                // 1. إعداد الـ Diagram
                DevExpress.XtraCharts.XYDiagram diagram = (DevExpress.XtraCharts.XYDiagram)chartControl1.Diagram;

                //if (diagram != null)
                //{
                //    diagram.Rotated = true; // العواميد بالعرض

                //    // === تنظيف الخلفية تماماً (إزالة الخطوط الشبكية) ===
                //    diagram.AxisX.GridLines.Visible = false; // إخفاء الخطوط الأفقية
                //    diagram.AxisY.GridLines.Visible = false; // إخفاء الخطوط الرأسية (المزعجة في الصورة)
                //    diagram.DefaultPane.BorderVisible = false; // إخفاء البرواز المحيط بالرسم
                //    diagram.DefaultPane.BackColor = System.Drawing.Color.Transparent; // خلفية شفافة

                //    // === تنظيف المحاور (الأرقام والأسماء) ===
                //    // إخفاء الخط الرئيسي للمحور س وص
                //    diagram.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True; // سيب الأسماء ظاهرة
                //    diagram.AxisY.Visibility = DevExpress.Utils.DefaultBoolean.False; // إخفاء الأرقام اللي تحت (0, 0.3, 0.6...) ملهاش لازمة لأننا كاتبين الرقم على العمود

                //    diagram.AxisX.Tickmarks.MinorVisible = false; // إخفاء الشرط الصغيرة
                //    diagram.AxisX.Tickmarks.Visible = false;      // إخفاء الشرط الكبيرة
                //}

                // 2. تجميل الأعمدة (البارات)
                // ... بعد إضافة الـ Series ...

                // تحويل الـ View لنوع Bar عشان نقدر نعدل خصائصه
                // 1. تعريف الـ View
                DevExpress.XtraCharts.SideBySideBarSeriesView view = (DevExpress.XtraCharts.SideBySideBarSeriesView)series.View;

                // 2. تنظيف الإعدادات (امسح أي كود قديم هنا)
                view.Border.Visibility = DevExpress.Utils.DefaultBoolean.False; // إخفاء الحدود السوداء
                view.BarWidth = 0.6; // عرض العمود

                // 3. التلوين (Gradient) - ده الكود الصحيح لعمل تدريج لوني بدون أخطاء
                view.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Gradient; // تفعيل التدريج

                // تخصيص اتجاه التدريج (اختياري)
                DevExpress.XtraCharts.RectangleGradientFillOptions options = view.FillStyle.Options as DevExpress.XtraCharts.RectangleGradientFillOptions;
                if (options != null)
                {
                    // يخلي اللون يبدأ غامق وينتهي فاتح بزاوية
                    options.GradientMode = DevExpress.XtraCharts.RectangleGradientMode.TopLeftToBottomRight;
                }

                // 4. تفعيل تنوع الألوان لكل عمود
                view.ColorEach = true;

                // 5. السحر كله هنا (الباليت الحديثة)
                // "WXI" هو الستايل الجديد اللي بيعمل حواف دائرية وشكل ناعم أوتوماتيك
                // لو WXI مش عاجبك، جرب "Office 2019 Colorful"
                // ... بعد إضافة السلسلة chartControl1.Series.Add(series);

                // 1. استخدام اسم باليت صحيح (حل مشكلة الخطأ)
                chartControl1.PaletteName = "Nature Colors";

                // 2. إخفاء مفتاح الخريطة (عشان نوفر مساحة زي الصورة)
                chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

                // 3. الوصول لخصائص العرض

                // 4. تفعيل الجريدينت (التدرج اللوني)
                view.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Gradient;

                // 5. ضبط اتجاه التدرج ليكون "لامع" وشيك
                if (options != null)
                {
                    // التدرج من أعلى اليسار لأسفل اليمين (بيدي إحساس 3D خفيف)
                    options.GradientMode = DevExpress.XtraCharts.RectangleGradientMode.TopLeftToBottomRight;

                    // خدعة مهمة: نخلي اللون التاني "شفاف" أو أبيض عشان التدرج يبقى مع نفسه وميكونش غامق
                    // (لو سبتها فاضية أحياناً بتدي لون باهت)
                    // view.ColorEach = true; // دي بتخلي كل عمود لون، سيبها شغالة
                }

                // 6. لمسات جمالية
                view.BarWidth = 0.6; // عرض العمود
                view.Border.Visibility = DevExpress.Utils.DefaultBoolean.False; // إخفاء البرواز الأسود
                view.ColorEach = true; // تفعيل تعدد الألوان

            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }

        private async void LoadCountsAsync()
        {
            try
            {

                var counts = await Task.Run(() => clsServes.LoadCount());

                if (counts != null)
                {

                    tileITotal.Elements[1].Text = counts.Total.ToString();
                    tileIlegal.Elements[1].Text = counts.Legal.ToString();
                    tileIillegal.Elements[1].Text = counts.Illegal.ToString();
                    tileIOther.Elements[1].Text = counts.Other.ToString();
                }
            }
            catch
            {

            }
        }

        public void LoadControl()
        {

            Maps();
            LoadCountsAsync();
            LoadChartData();
        }
    }
}

