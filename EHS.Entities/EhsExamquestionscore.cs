

namespace EHS.Entities
{
    /// <summary>
    /// 考试的试题及分数表
    /// </summary>
    public partial class EhsExamquestionscore
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 考试名称
        /// </summary>
        public string Examname { get; set; }
        /// <summary>
        /// 试题号
        /// </summary>
        public int Questionid { get; set; }
        /// <summary>
        /// 试题分数
        /// </summary>
        public int Questionscore { get; set; }
    }
}
