using System;
using System.Collections.Generic;

namespace ClassLib
{
    /// <summary>
    /// 用于管理员题目操作的模型
    /// </summary>
    public class ExaQuestModel
    {
        /// <summary>
        /// 题目类型 单选题  多选题  填空题  判断题  简答题  
        /// </summary>
        public string type;

        /// <summary>
        /// 题目难度  简单  普通  困难
        /// </summary>
        public string level;

        /// <summary>
        /// 题号（唯一）
        /// </summary>
        public int num;

        /// <summary>
        /// 题干
        /// </summary>
        public string question;

        /// <summary>
        /// 选项
        /// </summary>
        public string switches;

        /// <summary>
        /// 答案
        /// </summary>
        public string answer;

        /// <summary>
        /// 题目简述
        /// </summary>
        public string summary;

        /// <summary>
        /// 所属章节
        /// </summary>
        public string belongtosection;

        /// <summary>
        /// 所属题库
        /// </summary>
        public string belongtolib;

        /// <summary>
        /// 题目分值
        /// </summary>
        public int score;

        public ExaQuestModel()
        {
        }

        public ExaQuestModel(string Type, string Level, string BelongtoSection, string Quest, string Switches, string Answer, string Summary, string BelongtoLib)
        {
            type = Type;
            summary = Summary;
            level = Level;
            question = Quest;
            switches = Switches;
            answer = Answer;
            belongtosection = BelongtoSection;
            belongtolib = BelongtoLib;
        }

        public string SortAnswer()
        {
            char[] ans = answer.ToCharArray();
            Array.Sort(ans);
            return string.Join("", ans);
        }

        /// <summary>
        /// 选项解构,题目类型有误则返回count=0
        /// </summary>
        public List<string> SwitchesDispatch()
        {
            List<string> s = new List<string>();
            int linecount = 0;
            string n = "";
            if (type.Equals("单选题") || type.Equals("多选题") || type.Equals("判断题"))
            {
                for (int j = 0; j < switches.Length; j++)
                {
                    if (switches[j].Equals('（'))
                    {
                        if (linecount != 0)
                        {
                            s.Add(n);
                            n = "";
                        }
                        linecount++;
                    }
                    n += switches[j];
                }
                s.Add(n);
            }
            return s;
        }
    }
}