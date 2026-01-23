//using iText.Kernel.Pdf;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Drawing.Imaging;

//namespace CenterChangesManager.BLL.Global
//{
//    public static class clsImageHelper
//    {

//        public static byte[] CompressPDF(string filePath)
//        {
//            try
//            {
//                using (MemoryStream ms = new MemoryStream())
//                {
//                    // 1. إعداد القارئ والكاتب
//                    PdfReader reader = new PdfReader(filePath);

//                    // 2. تفعيل وضع الضغط الكامل (Full Compression) لتقليل حجم البيانات الوصفية والخطوط
//                    WriterProperties props = new WriterProperties().SetFullCompressionMode(true);
//                    PdfWriter writer = new PdfWriter(ms, props);

//                    // 3. معالجة المستند
//                    using (PdfDocument pdfDoc = new PdfDocument(reader, writer))
//                    {
//                        // iText 9 يقوم بعملية التحسين (Optimization) تلقائياً عند إغلاق الـ PdfDocument
//                    }

//                    return ms.ToArray();
//                }
//            }
//            catch
//            {
//                // في حالة وجود حماية على الملف أو خطأ، نحفظ النسخة الأصلية دون ضغط
//                return File.ReadAllBytes(filePath);
//            }
//        }







//        public static byte[] CompressImage(string filePath, int quality = 60, int maxWidth = 1200)
//        {
//            using (Image originalImage = Image.FromFile(filePath))
//            {
//                // 1. حساب الأبعاد الجديدة مع الحفاظ على النسبة
//                int newWidth = originalImage.Width;
//                int newHeight = originalImage.Height;

//                if (originalImage.Width > maxWidth)
//                {
//                    float ratio = (float)originalImage.Width / originalImage.Height;
//                    newWidth = maxWidth;
//                    newHeight = (int)(maxWidth / ratio);
//                }

//                // 2. التحقق من الصور الصغيرة جداً
//                newWidth = Math.Max(100, newWidth);
//                newHeight = Math.Max(100, newHeight);

//                // 3. إنشاء الصورة المضغوطة
//                using (Bitmap compressedImage = new Bitmap(newWidth, newHeight))
//                using (Graphics graphics = Graphics.FromImage(compressedImage))
//                {
//                    // إعدادات الجودة العالية أثناء التحجيم
//                    graphics.CompositingQuality = CompositingQuality.HighQuality;
//                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
//                    graphics.SmoothingMode = SmoothingMode.HighQuality;
//                    graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);

//                    // 4. ضغط الصورة مع تحديد الجودة
//                    using (MemoryStream ms = new MemoryStream())
//                    {
//                        EncoderParameters encoderParams = new EncoderParameters(1);
//                        encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, (long)quality);

//                        compressedImage.Save(
//                            ms,
//                            GetEncoder(ImageFormat.Jpeg),
//                            encoderParams
//                        );

//                        return ms.ToArray();
//                    }
//                }
//            }
//        }


//        // دالة مساعدة لجلب الكودك الخاص بالـ JPEG
//        private static ImageCodecInfo GetEncoder(ImageFormat format)
//        {
//            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
//            foreach (ImageCodecInfo codec in codecs)
//            {
//                if (codec.FormatID == format.Guid) return codec;
//            }
//            return null;
//        }
//    }
//}
