//using System.Data;

//using Telerik.Reporting;
//using Telerik.Reporting.Processing;


//namespace CenterChangesManager.BLL.Global
//{
//    public class clsExportService
//    {


//        public static async Task<bool> ExportDashboardToPdf(string filePath, string total, string legal, string illegal,
//            string other, DataTable dtDetailedData, string LogoImage, string cityName = "ميت غمر ")
//        {
//            // بنستخدم Task.Run عشان العملية تتم في الخلفية والبرنامج ميهنجش
//            return await Task.Run(() =>
//            {
//                try
//                {
//                    // 1. تحديد مسار ملف التقرير (تأكد أن الفولدر والملف موجودين في الـ Debug)
//                    string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "DashboardReport.trdp");

//                    if (!File.Exists(reportPath))
//                    {
//                        throw new FileNotFoundException("لم يتم العثور على ملف التقرير في المسار: " + reportPath);
//                    }

//                    // 2. فك حزمة التقرير (Unpackage)
//                    var reportPackager = new ReportPackager();
//                    Telerik.Reporting.Report report;

//                    using (var fileStream = File.OpenRead(reportPath))
//                    using (var memoryStream = new MemoryStream())
//                    {
//                        fileStream.CopyTo(memoryStream);
//                        memoryStream.Position = 0; // ✅ ارجع للبداية

//                        report = (Telerik.Reporting.Report)reportPackager.UnpackageDocument(memoryStream);
//                    }

//                    if (!string.IsNullOrEmpty(LogoImage) && report.ReportParameters["Pb"] != null)
//                    {
//                        byte[] imageBytes = Convert.FromBase64String(LogoImage);
//                        report.ReportParameters["Pb"].Value = imageBytes;
//                    }


//                    // 3. ربط الأرقام (Parameters) - تأكد من مطابقة الأسماء للمصمم
//                    if (report.ReportParameters["TotalCount"] != null) report.ReportParameters["TotalCount"].Value = total;
//                    if (report.ReportParameters["LegalCount"] != null) report.ReportParameters["LegalCount"].Value = legal;
//                    if (report.ReportParameters["IllegalCount"] != null) report.ReportParameters["IllegalCount"].Value = illegal;
//                    if (report.ReportParameters["OtherCount"] != null) report.ReportParameters["OtherCount"].Value = other;
//                    if (report.ReportParameters["MasterCity"] != null) report.ReportParameters["MasterCity"].Value = cityName;

//                    // 4. البحث عن الجدول وربطه بالبيانات (حل مشكلة الجدول الفاضي)
//                    // ملاحظة: لازم تروح للمصمم وتسمي الجدول table1 في الـ Properties
//                    var table = report.Items.Find("table1", true).FirstOrDefault() as Telerik.Reporting.Table;
//                    if (table != null)
//                    {
//                        table.DataSource = dtDetailedData;
//                    }

//                    // 5. إعداد عملية التحويل (Rendering)
//                    var instanceReportSource = new InstanceReportSource { ReportDocument = report };
//                    var reportProcessor = new ReportProcessor();

//                    // تحويل التقرير إلى PDF
//                    RenderingResult result = reportProcessor.RenderReport("PDF", instanceReportSource, null);

//                    if (result.HasErrors)
//                    {
//                        throw new Exception("خطأ في معالجة التقرير: " + result.Errors[0].Message);
//                    }

//                    // 6. حفظ الملف النهائي على الجهاز
//                    File.WriteAllBytes(filePath, result.DocumentBytes);

//                    return true;
//                }
//                catch (Exception ex)
//                {
//                    File.AppendAllText(
//     Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Errors.log"),
//     $"{DateTime.Now}: {ex.Message}\n{ex.StackTrace}\n\n"
// );

//                    return false;
//                }
//            });
//        }
//    }


//}
