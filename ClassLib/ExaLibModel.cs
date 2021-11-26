using System;
using System.Collections.Generic;

namespace ClassLib
{
    /// <summary>
    /// 用于管理员题库操作的模型
    /// </summary>
    public class ExaLibModel
    {
        /// <summary>
        /// 题库名
        /// </summary>
        public string libname;

        /// <summary>
        /// 题库类目
        /// </summary>
        public string type;

        /// <summary>
        /// 试题数
        /// </summary>
        public int questcount;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createtime;

        /// <summary>
        /// 题库简述
        /// </summary>
        public string libsummary;

        /// <summary>
        /// 作用范围  考试/训练 Exam/Train
        /// </summary>
        public string usage;

        /// <summary>
        /// 章节，章节名字典
        /// </summary>
        public Dictionary<int, string> sections;

        /// <summary>
        /// 题目集
        /// </summary>
        public List<ExaQuestModel> exaquests;

        /// <summary>
        /// 路径
        /// </summary>
        public string libfilelpath;

        public ExaLibModel(string name, string type, DateTime time, string usage, string sum)
        {
            this.libname = name;
            this.type = type;
            this.createtime = time;
            this.usage = usage;
            this.libsummary = sum;
        }
        public ExaLibModel() { }
    }
}