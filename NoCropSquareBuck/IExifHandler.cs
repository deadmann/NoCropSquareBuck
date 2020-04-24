using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace NoCropSquareBuck
{
    public interface IExifHandler
    {
        List<PropertyItem> Read(Stream str);
        void Write(Stream str, List<PropertyItem> properties);

        List<PropertyItem> Read(Image img);
        void Write(Image img, List<PropertyItem> properties);
    }
}