using System;

namespace EHS.Entities
{
    /// <summary>
    /// 考试表
    /// </summary>
    public partial class EhsExam : BaseEntity
    {
        /// <summary>
        /// 考试名称
        /// </summary>
        public string Examname { get; set; }
        /// <summary>
        /// 是否限时
        /// </summary>
        public bool? limittime { get; set; }
        /// <summary>
        /// 考试持续时间
        /// </summary>
        public TimeSpan Lsattime { get; set; }
        /// <summary>
        /// 考试开始日期
        /// </summary>
        public DateTime Starttime { get; set; }
        /// <summary>
        /// 考试结束日期
        /// </summary>
        public DateTime Endtime { get; set; }

        /// <summary>
        /// 考试类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 考试总分
        /// </summary>
        public int Toalscore { get; set; }
        /// <summary>
        /// 合格分数
        /// </summary>
        public int Qualifiedscore { get; set; }
        /// <summary>
        /// 是否人工阅卷
        /// </summary>
        public bool? Artifitial { get; set; }
        /// <summary>
        /// 题库名
        /// </summary>
        public string Libname { get; set; }
        /// <summary>
        /// 所属章节
        /// </summary>
        public int Section { get; set; }

        /// <summary>
        /// 难度等级
        /// </summary>
        public string Levels { get; set; }
        /// <summary>
        /// 考试文件路径
        /// </summary>
        public string Examfile { get; set; }
        /// <summary>
        /// 考试次数限制
        /// </summary>
        public bool? Limittime { get; set; }

        /// <summary>
        /// 限考次数
        /// </summary>
        public int Limitcount { get; set; }


        public bool Anhuan { get; set; }
    }
}
