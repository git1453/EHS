using System;

namespace ClassLib
{
    /// <summary>
    /// 用于管理员课件操作的模型
    /// </summary>
    public class FileModel
    {
        /// <summary>
        /// 课件编号
        /// </summary>
        public int filenum;

        /// <summary>
        /// 文件名
        /// </summary>
        public string filename;

        /// <summary>
        /// 文件类型
        /// </summary>
        public string type;

        /// <summary>
        /// 文件后缀名
        /// </summary>
        public string extension;

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime uploadtime;

        /// <summary>
        /// 课件的类目
        /// </summary>
        public string courseclass;

        /// <summary>
        /// 课件大小
        /// </summary>
        public long capable;

        /// <summary>
        /// 课件储存路径
        /// </summary>
        public string filepath;

        public int Filenum { get; set; }

        public FileModel(string FileName, string Type, DateTime UpLoadTime, string CourseClass, long Capable)
        {
            filename = FileName;
            type = Type;
            uploadtime = UpLoadTime;
            courseclass = CourseClass;
            capable = Capable;
        }
        public FileModel(string FileName, string Type, DateTime UpLoadTime, string CourseClass, int id)
        {
            filename = FileName;
            type = Type;
            uploadtime = UpLoadTime;
            courseclass = CourseClass;
            filenum = id;
        }

        public FileModel()
        {
        }

        public int GetNum()
        {
            return filenum;
        }

        public bool SetNum(int n)
        {
            filenum = n;
            return true;
        }

    }
}