namespace EHS.Entities
{
    /// <summary>
    /// 课程安排
    /// </summary>
    public class EhsCoursearrange : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 课程主键
        /// </summary>
        public int Courseid { get; set; }
        /// <summary>
        /// 课程权限 完全公开和指定人员
        /// </summary>
        public string Authority { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public int Badge { get; set; }
    }
}
