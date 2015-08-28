using FileIOUtility.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace FileIOUtility.Image
{
    public class ImageFile : FileBase, IFile, IImageFile
    {
        public static readonly ImageFile Instance = new ImageFile();

        private ImageFile()
        {
            //Clients cannot instantiate this class directly
        }

        public System.Drawing.Image ToImage(string filenameOrUrl)
        {
            try
            {
                using (FileStream fs = new FileStream(filenameOrUrl, FileMode.Open, FileAccess.Read))
                {
                    return System.Drawing.Image.FromStream(fs);
                }
            }
            catch(ArgumentException aex)
            {
                if (aex.Message == "URI formats are not supported.")
                {
                    return GetImageFromUrl(filenameOrUrl);
                }
                else
                {
                    throw;
                }
            }
        }

        private System.Drawing.Image GetImageFromUrl(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (Stream stream = httpWebReponse.GetResponseStream())
            {
                return System.Drawing.Image.FromStream(stream);
            }
        }

        public void OverwriteTo(string filename, System.Drawing.Image image)
        {
            image.Save(filename);
        }

        public void OverwriteTo(string filename, System.Drawing.Image image, System.Drawing.Imaging.ImageFormat imageFormat)
        {
            image.Save(filename, imageFormat);
        }
    }
}
