using System;
using System.Collections.Generic;

namespace ClassLib
{
    /// <summary>
    /// 用于管理员考试操作的模型
    /// </summary>
    public class ExamModel
    {
        /// <summary>
        ///考试名称
        /// </summary>
        public string examname;

        /// <summary>
        /// 持续时间
        /// </summary>
        public TimeSpan lasttime;

        /// <summary>
        /// 是否限时
        /// </summary>
        public bool limittime;

        /// <summary>
        /// 考试开放时间
        /// </summary>
        public DateTime starttime;

        /// <summary>
        /// 考试关闭时间
        /// </summary>
        public DateTime endtime;

        /// <summary>
        /// 考试类目
        /// </summary>
        public string type;

        /// <summary>
        /// 总分
        /// </summary>
        public int totalscore;

        /// <summary>
        /// 及格分
        /// </summary>
        public int qualifiedscore;

        /// <summary>
        ///是否人工阅卷
        /// </summary>
        public bool artifitial;

        /// <summary>
        /// 试卷目录
        /// </summary>
        public string examfile;// ?

        /// <summary>
        /// 考试状态（开启/关闭）
        /// </summary>
        public bool status;

        /// <summary>
        /// 题库名
        /// </summary>
        public string libname;//

        /// <summary>
        /// 试卷难度
        /// </summary>
        public string level;//difficulties

        /// <summary>
        /// 所属章节
        /// </summary>
        public int section;

        /// <summary>
        /// 【行号】【分值】
        /// </summary>
        public Dictionary<int, int> questions;

        /// <summary>
        /// 权限设置 {完全公开} {部门公开} {指定用户公开} {需要密码}
        /// </summary>
        public string authority;

        /// <summary>
        /// 授权许可考试的工号
        /// </summary>
        public List<int> badge;

        /// <summary>
        /// 授权的部门
        /// </summary>
        public List<string> department;

        /// <summary>
        /// 所需的密码
        /// </summary>
        public string password;

        /// <summary>
        /// 限考次数
        /// </summary>
        public int limitcount;

        /// <summary>
        /// 安环教育考试
        /// </summary>
        public bool Anhuan;

        public ExamModel(string Exaname, string Libname, string Exatype, int Section, string Level, DateTime Starttime, DateTime Endtime, bool Limit, TimeSpan timeSpan, int Limitcount)
        {
            examname = Exaname;
            libname = Libname;
            type = Exatype;
            section = Section;
            level = Level;
            starttime = Starttime;
            endtime = Endtime;
            limittime = Limit;
            lasttime = timeSpan;
            limitcount = Limitcount;
        }

        public ExamModel()
        {
        }
    }
}