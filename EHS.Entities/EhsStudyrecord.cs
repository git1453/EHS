using System;

namespace EHS.Entities
{
    /// <summary>
    /// 学习记录表
    /// </summary>
    public partial class EhsStudyrecord
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public int Badge { get; set; }
        /// <summary>
        /// 课程号
        /// </summary>

        public int Courseid { get; set; }

        /// <summary>
        /// 总课件数
        /// </summary>
        public int Totalcoureseware { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime Updatetime { get; set; }
    }
}
