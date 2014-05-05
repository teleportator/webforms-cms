using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace SharpCMS.UI.Images
{
    public static class BitmapExtentions
    {
        /// <summary>
        /// Resize the image to the specified width and height limits.
        /// </summary>
        public static Bitmap Resize(this Bitmap image, int maxWidth, int maxHeight)
        {
            Bitmap b = null;
            
            int _maxWidth = (maxWidth > 0) ? maxWidth : image.Width;
            int _maxHeight = (maxHeight > 0) ? maxHeight : image.Height;
            double _scaleWidth = (double)_maxWidth / (double)image.Width;
            double _scaleHeight = (double)_maxHeight / (double)image.Height;
            double _scale = (_scaleHeight < _scaleWidth) ? _scaleHeight : _scaleWidth;
            _scale = (_scale > 1) ? 1 : _scale;

            int _newWidth = (int)(Math.Round(_scale * image.Width));
            int _newHeight = (int)(Math.Round(_scale * image.Height));

            b = new System.Drawing.Bitmap(_newWidth, _newHeight);

            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(b))
            {
                g.CompositingQuality = CompositingQuality.HighSpeed;
                g.SmoothingMode = SmoothingMode.HighSpeed;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(image, new Rectangle(0, 0, _newWidth, _newHeight));
                g.Save();
            }

            return b;
        }

        /// <summary> 
        /// Saves an image as a jpeg image, with the given quality 
        /// </summary> 
        public static void SaveJpeg(this Bitmap image, string path, int quality)
        {
            //ensure the quality is within the correct range
            if ((quality < 0) || (quality > 100))
            {
                //create the error message
                string error = string.Format("Jpeg image quality must be between 0 and 100, with 100 being the highest quality.  A value of {0} was specified.", quality);
                //throw a helpful exception
                throw new ArgumentOutOfRangeException(error);
            }

            //create an encoder parameter for the image quality
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            //get the jpeg codec
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

            //create a collection of all parameters that we will pass to the encoder
            EncoderParameters encoderParams = new EncoderParameters(1);
            //set the quality parameter for the codec
            encoderParams.Param[0] = qualityParam;
            //save the image using the codec and the parameters
            image.Save(path, jpegCodec, encoderParams);
            encoderParams.Dispose();
        }

        /// <summary> 
        /// Returns the image codec with the given mime type 
        /// </summary> 
        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codec = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < codec.Length; i++)
            {
                if (codec[i].MimeType == mimeType)
                    return codec[i];
            }
            return null;
        } 
    }
}