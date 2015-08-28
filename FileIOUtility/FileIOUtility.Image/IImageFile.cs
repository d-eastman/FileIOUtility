using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FileIOUtility.Image
{
    public interface IImageFile
    {
        System.Drawing.Image ToImage(string filenameOrUrl);

        void OverwriteTo(string filename, System.Drawing.Image image);

        void OverwriteTo(string filename, System.Drawing.Image image, System.Drawing.Imaging.ImageFormat imageFormat);
    }
}
