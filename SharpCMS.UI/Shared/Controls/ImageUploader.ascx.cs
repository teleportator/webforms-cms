using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using SharpCMS.UI.Images;

namespace SharpCMS.UI.Shared.Controls
{
    public partial class ImageUploader : System.Web.UI.UserControl
    {
        #region Fields
        private int _imageWidth = 1024;
        private int _imageHeight = 1024;
        #endregion

        #region Members
        public int ImageWidth
        {
            get { return _imageWidth; }
            set { _imageWidth = value; }
        }

        public int ImageHeight
        {
            get { return _imageHeight; }
            set { _imageHeight = value; }
        }

        public string DefaultImagePath { get; set; }

        public string UploadFolderPath { get; set; }

        public string CurrentImagePath
        {
            get { return (string)ViewState["UploadImagePath"]; }
            set { ViewState["UploadImagePath"] = value; }
        }

        private string InitImagePath
        {
            get { return (string)ViewState["InitImagePath"]; }
            set { ViewState["InitImagePath"] = value; }
        }
        #endregion

        #region Methods
        protected void Page_Load(object sender, EventArgs e)
        {
            imgLogoPreview.ImageUrl = CurrentImagePath == "" ? DefaultImagePath : CurrentImagePath;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fupImageUploader.HasFile)
            {
                try
                {
                    string fileExtention = Path.GetExtension(fupImageUploader.PostedFile.FileName).ToLower();
                    if (fileExtention == ".jpg" || fileExtention == ".jpeg")
                    {
                        string fileName = "img" + DateTime.Now.Ticks.ToString() + fileExtention;
                        string fileUrl = UploadFolderPath + "/" + fileName;
                        fupImageUploader.PostedFile.SaveAs(Server.MapPath(fileUrl));
                        System.Drawing.Bitmap image = new System.Drawing.Bitmap(fupImageUploader.PostedFile.InputStream);
                        image = image.Resize(_imageWidth, _imageHeight);
                        image.SaveJpeg(Server.MapPath(fileUrl), 90);

                        ReplaceCurrentImagePath(UploadFolderPath + "/" + fileName);
                        imgLogoPreview.ImageUrl = CurrentImagePath;
                    }
                }
                catch (Exception ex) {  }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ReplaceCurrentImagePath(String.Empty);
            imgLogoPreview.ImageUrl = DefaultImagePath;
        }

        private void ReplaceCurrentImagePath(string currentImagePath)
        {
            if (InitImagePath != null)
            {
                if (CurrentImagePath != String.Empty)
                {
                    File.Delete(Server.MapPath(CurrentImagePath));
                }
            }
            else
            {
                InitImagePath = CurrentImagePath;
            }
            CurrentImagePath = currentImagePath;
        }

        public void DeleteInitImage()
        {
            if ((InitImagePath != null) && (InitImagePath != String.Empty))
            {
                File.Delete(Server.MapPath(InitImagePath));
            }
        }
        #endregion
    }
}