using ClassLib;
using System;
using System.Collections.Generic;

namespace ClassLib
{
    /// <summary>
    /// 用于管理员课程管理的模型
    /// </summary>
    public class CourseModel:BaseModel
    {
        /// <summary>
        /// 课程简介文件
        /// </summary>
        public string coursefile;

        /// <summary>
        /// 课程名
        /// </summary>
        public string coursename;

        /// <summary>
        /// 课程编号 数据库主键
        /// </summary>
        public int coursenum;
        /// <summary>
        /// 课程创建时间
        /// </summary>
        public DateTime creatime;
        /// <summary>
        /// 课程类别
        /// </summary>
        public string coursetype;

        /// <summary>
        /// 课时数
        /// </summary>
        public int coursecount;

        /// <summary>
        /// 课件文件夹
        /// </summary>
        public List<CourseDirectory> directories;

        /// <summary>
        /// 课程描述
        /// </summary>
        public string coursesummery;
        /// <summary>
        /// 课程权限
        /// </summary>
        public string authority;
        /// <summary>
        /// 学员工号列表
        /// </summary>
        public List<int> participants;

        /// <summary>
        /// 获取指定文件夹中的课件编号
        /// </summary>
        /// <param name="FileDirectory"></param>
        /// <returns></returns>
        public List<int> GetRequiredFiles(string FileDirectory)
        {
            List<int> RequiredFiles = null;
            foreach (CourseDirectory dir in directories)
            {
                if (dir.directoryname.Equals(FileDirectory))
                {
                    foreach (int i in dir.coursefiles)
                    {
                        RequiredFiles.Add(i);
                    }
                    return RequiredFiles;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取某课程全部的课件编号
        /// </summary>
        /// <returns></returns>
        public List<int> GetFiles()
        {
            List<int> AllFiles = new();
            foreach (var dir in directories)
            {
                foreach (var f in dir.coursefiles)
                {
                    AllFiles.Add(f);
                }
            }
            return AllFiles;
        }

        public int GetMaximun()
        {
            int x = 0;
            directories.ForEach(a => x += a.coursefiles.Count);
            return x;
        }
    }
}

/// <summary>
/// 课程文件结构 （文件夹名  课件号集合）
/// </summary>
public class CourseDirectory
{
    public string directoryname;
    public List<int> coursefiles;
    public List<FileModel> fileModels;
}