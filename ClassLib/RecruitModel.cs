using System;

namespace ClassLib
{
    /// <summary>
    /// 用于员工基础模型
    /// </summary>
    public class RecruitModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string name;

        /// <summary>
        /// 工号
        /// </summary>
        public int worknum;

        /// <summary>
        /// 性别 1男 2女
        /// </summary>
        public int sex;

        /// <summary>
        /// 学历
        /// </summary>
        public string degree;

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime birth;

        /// <summary>
        /// 分公司
        /// </summary>
        public string commpany;

        /// <summary>
        /// 职位
        /// </summary>
        public string occupation;

        /// <summary>
        /// 加入时间
        /// </summary>
        public DateTime jointime;

        /// <summary>
        /// 照片路径
        /// </summary>
        public byte[] photocode;

        /// <summary>
        /// 部门
        /// </summary>
        public string department;

        /// <summary>
        /// 电话
        /// </summary>
        public int phone;

        public string SignPath;

        /// <summary>
        /// 分级部门
        /// </summary>
        public string[] Dep;

        public RecruitModel()
        {

        }
    }
}