namespace EHS.Entities
{
    /// <summary>
    /// 课程文件夹课件表
    /// </summary>
    public class EhsCoursefoldercourseware : BaseEntity
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
        /// 文件号
        /// </summary>
        public int Foldeid { get; set; }
        /// <summary>
        /// 课件名
        /// </summary>
        public int Courseware { get; set; }
    }
}
