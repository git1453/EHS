using System;

namespace EHS.Entities
{
    /// <summary>
    /// 课程文件夹表
    /// </summary>
    public class EhsCoursefolder
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 课程号
        /// </summary>
        public int Courseid { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public String Foldername { get; set; }


    }
}
