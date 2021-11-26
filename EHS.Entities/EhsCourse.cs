using System;



namespace EHS.Entities
{
    /// <summary>
    /// 课程表
    /// </summary>
    public partial class EhsCourse
    {
        /// <summary>
        /// 课程主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 课程名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 课程类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 课程内容
        /// </summary>
        public string Context { get; set; }
        /// <summary>
        /// 课时
        /// </summary>
        public int Classhour { get; set; }
        /// <summary>
        /// 课程创建时间
        /// </summary>
        public DateTime Createtime { get; set; }
        /// <summary>
        /// 课件地址
        /// </summary>
        public string Coursewarefile { get; set; }

        
    }
    public partial class EhsCourse1
    {
        /// <summary>
        /// 课程主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 课程名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 课程类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 课程内容
        /// </summary>
        public string Context { get; set; }
        /// <summary>
        /// 课时
        /// </summary>
        public int Classhour { get; set; }
        /// <summary>
        /// 课程创建时间
        /// </summary>
        public DateTime Createtime { get; set; }
        /// <summary>
        /// 课件地址
        /// </summary>
        public string Coursewarefile { get; set; }

    }
}
