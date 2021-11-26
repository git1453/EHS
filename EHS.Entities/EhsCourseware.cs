using System;

namespace EHS.Entities
{
    /// <summary>
    /// 课件表
    /// </summary>
    public partial class EhsCourseware
    {
        /// <summary>
        /// 课件号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 课件名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 扩展名
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// 课件大小
        /// </summary>
        public long Capable { get; set; }

        /// <summary>
        /// 课件类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 课件类目
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Starttime { get; set; }


    }
}
