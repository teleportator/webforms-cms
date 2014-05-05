using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;

namespace SharpCMS.UI.Mvc.Infrastructure
{
	public static class BitmapExtentions
	{
		/// <summary>
		/// Resize the image to the specified width and height limits.
		/// </summary>
		public static Bitmap Resize(this Bitmap image, int maxWidth, int maxHeight)
		{
			int maximumWidth = (maxWidth > 0) ? maxWidth : image.Width;
			int maximumHeight = (maxHeight > 0) ? maxHeight : image.Height;
			double scaleWidth = (double)maximumWidth / (double)image.Width;
			double scaleHeight = (double)maximumHeight / (double)image.Height;
			double scale = (scaleHeight < scaleWidth) ? scaleHeight : scaleWidth;
			scale = (scale > 1) ? 1 : scale;

			var newWidth = (int)(Math.Round(scale * image.Width));
			var newHeight = (int)(Math.Round(scale * image.Height));

			var b = new Bitmap(newWidth, newHeight);

			using (var g = Graphics.FromImage(b))
			{
				g.CompositingQuality = CompositingQuality.HighSpeed;
				g.SmoothingMode = SmoothingMode.HighSpeed;
				g.InterpolationMode = InterpolationMode.HighQualityBicubic;

				g.DrawImage(image, new Rectangle(0, 0, newWidth, newHeight));
				g.Save();
			}

			return b;
		}

		/// <summary> 
		/// Saves an image as a jpeg image, with the given quality 
		/// </summary> 
		public static void SaveJpeg(this Bitmap image, string path, int quality)
		{
			if ((quality < 0) || (quality > 100))
			{
				string error = string.Format("Jpeg image quality must be between 0 and 100, with 100 being the highest quality.  A value of {0} was specified.", quality);
				throw new ArgumentOutOfRangeException(error);
			}

			var qualityParam = new EncoderParameter(Encoder.Quality, quality);
			ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

			var encoderParams = new EncoderParameters(1);
			encoderParams.Param[0] = qualityParam;
			image.Save(path, jpegCodec, encoderParams);
			encoderParams.Dispose();
		}

		/// <summary> 
		/// Returns the image codec with the given mime type 
		/// </summary> 
		public static ImageCodecInfo GetEncoderInfo(string mimeType)
		{
			ImageCodecInfo[] codec = ImageCodecInfo.GetImageEncoders();
			return codec.FirstOrDefault(t => t.MimeType == mimeType);
		}
	}
}