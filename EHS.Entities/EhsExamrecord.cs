using System;

namespace EHS.Entities
{
    /// <summary>
    /// 考试记录表
    /// </summary>
    public partial class EhsExamrecord : BaseEntity
    {

        

        /// <summary>
        /// 考试记录的主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 考试名称
        /// </summary>
        public string Examname { get; set; }
        /// <summary>
        /// 学员工号
        /// </summary>
        public int Badge { get; set; }
        /// <summary>
        /// 学员姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 开始考试时间
        /// </summary>
        public DateTime Examtime { get; set; }

        /// <summary>
        /// 考试使用时长
        /// </summary>
        public TimeSpan? Lasttime { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// 是否合格
        /// </summary>
        public bool Qualified { get; set; }
        /// <summary>
        /// 客观分数
        /// </summary>
        public int Objectivescore { get; set; }
        /// <summary>
        /// 主观分数
        /// </summary>
        public int Subjectivescore { get; set; }
        /// <summary>
        /// 考试状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 答题文件路径
        /// </summary>
        public string Answerpath { get; set; }
    }
}
