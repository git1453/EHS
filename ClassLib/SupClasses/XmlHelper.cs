using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace ClassLib
{
    public abstract class XmlHelper
    {
        public static readonly string[] PROPERTY = { "Department", "belong", "name", "UpDateTime", "likes", "Content", "Reply", "Info","replyid" };

        protected readonly string PATH;

        protected XmlDocument XML;

        public XmlHelper(string path)
        {
            if (Path.IsPathRooted(path))
            {
                PATH = path;
            }
            else
            {
                PATH = Path.GetFullPath(path);
            }
            if (new FileInfo(PATH).Exists)
            {
                XML = new XmlDocument();
                XML.Load(PATH);
            }
            else
            {
                XML = null;
                PATH = null;
            }
        }


    }
}
