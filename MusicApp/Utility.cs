using MusicApp.Data;
using MusicApp.Exceptions;
using System.Drawing;
using System.IO;
using System.Net;

namespace MusicApp
{
    class Utility
    {
        /// <summary>
        /// Download an image from the internet.
        /// </summary>
        /// <param name="src">Image source URL</param>
        /// <returns></returns>
        public static Image DownloadImage(string src)
        {
            if (src == string.Empty)
            {
                return null;
            }
            try
            {
                using (var wc = new WebClient())
                {
                    using (var imgStream = new MemoryStream(wc.DownloadData(src)))
                    {
                        using (var image = Image.FromStream(imgStream))
                        {
                            return new Bitmap(image);
                        }
                    }
                }
            }
            catch (WebException)
            {
                throw new InternetAccessException("No internet connection.");
            }
        }

        /// <summary>
        /// Saves a given image on the disk in the given location.
        /// </summary>
        public static void SaveImage(Image toSave)
        {
            if(!Directory.Exists(Constants.ImageDir))
            {
                Directory.CreateDirectory(Constants.ImageDir);
            }
            string[] parts = toSave.Tag.ToString().Split(',');
            string imagePath = Constants.ImageDir + parts[0] + "/";
            if(!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }

            parts[1] = parts[1].TrimStart();

            toSave.Save(imagePath + parts[1] + ".jpg");
            toSave.Dispose();
        }
    }
}
