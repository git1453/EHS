

namespace EHS.Entities
{
    /// <summary>
    /// 职业危害告知表
    /// </summary>
    public partial class EhsOccupationalhazard
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 事业部
        /// </summary>
        public string Businessdivision { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Postion { get; set; }
        /// <summary>
        /// 职业病危害因素
        /// </summary>
        public string Factor { get; set; }
        /// <summary>
        /// 职业禁忌证
        /// </summary>
        public string Contraindications { get; set; }
        /// <summary>
        /// 可能导致的职业病危害
        /// </summary>
        public string Harm { get; set; }
        /// <summary>
        /// 职业病防护措施
        /// </summary>
        public string Protect { get; set; }
    }
}
