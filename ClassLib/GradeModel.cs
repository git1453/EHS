using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLib
{
    /// <summary>
    /// 用于学员的考试模型
    /// </summary>
    public class GradeModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int id;
        /// <summary>
        /// 学员工号
        /// </summary>
        public int worknum;
        /// <summary>
        /// 考试名称
        /// </summary>
        public string examname;

        /// <summary>
        /// 学员姓名
        /// </summary>
        public string name;

        /// <summary>
        /// 考试时间
        /// </summary>
        public DateTime examtime;

        /// <summary>
        /// 考试使用时长
        /// </summary>
        public TimeSpan lasttime;

        /// <summary>
        /// 分数
        /// </summary>
        public int score;

        /// <summary>
        /// 是否合格
        /// </summary>
        public bool qualified;

        /// <summary>
        /// 客观分数
        /// </summary>
        public int Objectivescore;
        /// <summary>
        /// 主观分数
        /// </summary>
        public int Subjectivescore;
        /// <summary>
        /// 考试状态
        /// </summary>
        public string Status;
        /// <summary>
        /// 考试次数
        /// </summary>
        public string times;

        /// <summary>
        /// 答题文件
        /// </summary>
        public string answerpath;

        public GradeModel()
        {
        }

        public GradeModel(string ExamName, string Name, DateTime ExamTime, TimeSpan timeSpan, int Score, bool Qualified)
        {
            examname = ExamName;
            name = Name;
            examtime = ExamTime;
            lasttime = timeSpan;
            score = Score;
            qualified = Qualified;
        }
    }
}