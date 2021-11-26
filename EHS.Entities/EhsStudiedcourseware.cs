namespace EHS.Entities
{
    /// <summary>
    /// 课程的已学课件记录表
    /// </summary>
    public class EhsStudiedcourseware : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id;
        /// <summary>
        /// 工号
        /// </summary>
        public int Badge;
        /// <summary>
        /// 课件号
        /// </summary>
        public int Courseid;
        /// <summary>
        /// 已学课件号
        /// </summary>
        public int Coursewareid;
    }
}
