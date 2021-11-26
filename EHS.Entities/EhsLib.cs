using System;

namespace EHS.Entities
{
    /// <summary>
    /// 试题表
    /// </summary>
    public partial class EhsLib : BaseEntity
    {
        /// <summary>
        /// 题库名
        /// </summary>
        public string Libname { get; set; }
        /// <summary>
        /// 试题类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 试题数量
        /// </summary>
        public int Questcount { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Createtime { get; set; }
        /// <summary>
        /// 题库摘要
        /// </summary>
        public string Libsummary { get; set; }
        /// <summary>
        /// 作用范围
        /// </summary>
        public string Usage { get; set; }
        /// <summary>
        /// 章节数章节名
        /// </summary>
        public string Sectioncount { get; set; } 

        /// <summary>
        /// 题库路径
        /// </summary>
        public string Questionpath { get; set; }

    }
}
