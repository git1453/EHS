using System;
using System.Collections.Generic;

namespace ClassLib
{
    /// <summary>
    /// 用于学员学习进度模型
    /// </summary>
    public class LearnModel:BaseModel
    {
        public int id;
        /// <summary>
        /// 人员工号
        /// </summary>
        public int eid;

        /// <summary>
        /// 课程名
        /// </summary>
        public string course;

        /// <summary>
        /// 课程编号
        /// </summary>
        public int coursenum;

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime updatetime;

        /// <summary>
        /// 已学课件
        /// </summary>
        public List<int> learnedwares;

        /// <summary>
        /// 总课件数
        /// </summary>
        public int allwares;

        public void AddLearn(int FileNum)
        {
            if (learnedwares == null)
            {
                learnedwares = new();
                learnedwares.Add(FileNum);
                allwares = 1;
                updatetime = DateTime.Now;
            }
            else if(!learnedwares.Contains(FileNum))
            {
                learnedwares.Add(FileNum);
                allwares ++;
                updatetime = DateTime.Now;
            }
            else
            {
                updatetime = DateTime.Now;
            }
        }

        public void Replace(LearnModel learn)
        {
            if (learnedwares == null)
                learnedwares = new();
            foreach(int i in learn.learnedwares)
            {
                if (!learnedwares.Contains(i))
                {
                    learnedwares.Add(i);
                }
            }
            allwares = learn.allwares;
            updatetime = learn.updatetime;
            coursenum = learn.coursenum;
            course = learn.course;
            eid = learn.eid;
            id = learn.id;
        }
    }
}