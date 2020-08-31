using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCropSquareBuck
{
    public class Utility
    {
        public static string GetParentDirectoryOrCurrent(string preProcessDst)
        {
            if (preProcessDst == Directory.GetDirectoryRoot(preProcessDst))
                return preProcessDst;
            var path = Directory.GetParent(preProcessDst).FullName;
            return path;
        }
    }
}
