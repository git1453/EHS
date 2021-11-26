

namespace EHS.Entities
{
    /// <summary>
    /// 考试安排表
    /// </summary>
    public partial class EhsExamarrange : BaseEntity
    {
        /// <summary>
        /// 考试主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 考试考试主键
        /// </summary>
        public string Examname { get; set; }
        /// <summary>
        /// 权限设置 分为“完全公开”“部门公开”“需要密码”“指定用户公开”
        /// </summary>
        public string Authority { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public int Badge { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

    }
}
