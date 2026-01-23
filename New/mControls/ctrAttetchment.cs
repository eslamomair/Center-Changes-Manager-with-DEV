using CenterChangesManager.BLL;
using DevExpress.XtraEditors;
using System.Data;
using System.IO;

namespace CenterChanges
{
    public partial class ctrAttachment : DevExpress.XtraEditors.XtraUserControl
    {
        private int ChangeID = -1;
        public ctrAttachment()
        {
            InitializeComponent();
        }

        public void LoadAttachments(int logID)
        {
            if (logID == -1) return;

            ChangeID = logID;

            labelControl1.Text = $"مرفقات المتغير رقم  {logID}";

            DataTable dt = clsChangeAttachment.GetAllByLogID(logID);

            if (dt != null)
            {


                List<clsChangeAttachment> attachmentsList = new List<clsChangeAttachment>();

                foreach (DataRow row in dt.Rows)
                {
                    var item = new clsChangeAttachment
                    {
                        AttachmentID = row["AttachmentID"] != DBNull.Value ? Convert.ToInt32(row["AttachmentID"]) : 0,
                        FileName = row["FileName"].ToString(),
                        FileExtension = row["FileExtension"].ToString(),
                        FileSize = row["FileSize"] != DBNull.Value ? Convert.ToInt32(row["FileSize"]) : 0,
                        UploadDate = row["UploadDate"] != DBNull.Value ? Convert.ToDateTime(row["UploadDate"]) : DateTime.MinValue
                    };
                    attachmentsList.Add(item);

                    gridControl1.DataSource = attachmentsList;

                    gridControl1.RefreshDataSource();
                }
            }

        }



        private void windowsuiButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string tag = e.Button.Properties.Tag.ToString();

            switch (tag)
            {
                case "Add":
                    AddNewAttachment();
                    break;
                case "Open":
                    OpenSelectedAttachment();
                    break;
                case "Delete":
                    DeleteSelectedAttachment();
                    break;
            }
        }

        private void AddNewAttachment()
        {
            if (ChangeID == -1)
            {
                XtraMessageBox.Show("خطا فى رقم المتغير ");
                return;
            }
            using (xtraOpenFileDialog1)
            {
                if (xtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    xtraOpenFileDialog1.Title = $"{ChangeID} اختر ملفا لارفاقه للمتغير رقم ";
                    byte[] fileByte = File.ReadAllBytes(xtraOpenFileDialog1.FileName);

                    FileInfo info = new FileInfo(xtraOpenFileDialog1.FileName);

                    clsChangeAttachment attachment = new clsChangeAttachment();

                    attachment.Log_ID = ChangeID;
                    attachment.FileExtension = info.Extension;
                    attachment.FileSize = (int)info.Length;
                    attachment.FileName = info.Name;
                    attachment.UploadedBy = 1; //-----------------------------

                    if (attachment.Save(fileByte))
                    {
                        LoadAttachments((int)attachment.Log_ID);
                        MessageBox.Show("تم الحفظ بنجاح", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }



            }
        }

        private void OpenSelectedAttachment()
        {
            if (winExplorerView1.FocusedRowHandle < 0) return;

            int ID = (int)winExplorerView1.GetFocusedRowCellValue("AttachmentID");

            clsChangeAttachment attachment = clsChangeAttachment.Find(ID);

            if (attachment != null)
            {
                attachment.OpenFile();
            }
        }

        private void DeleteSelectedAttachment()
        {
            if (winExplorerView1.FocusedRowHandle < 0) return;

            if (MessageBox.Show("هل أنت متأكد من حذف هذا الملف؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                int id = (int)winExplorerView1.GetFocusedRowCellValue("AttachmentID");


                if (clsChangeAttachment.Delete(id))
                {

                    LoadAttachments(ChangeID);


                }
            }
        }
    }
}
