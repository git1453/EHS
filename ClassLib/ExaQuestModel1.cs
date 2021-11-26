using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLib
{
    public class DangerInfoModel
    {
        /// <summary>
        /// 记录编号
        /// </summary>
        public int id;
        /// <summary>
        /// 部门
        /// </summary>
        public string department;

        /// <summary>
        /// 事业部
        /// </summary>
        public string region;

        /// <summary>
        /// 职业
        /// </summary>
        public string occupation;

        /// <summary>
        /// 危害因素
        /// </summary>
        public string cause;

        /// <summary>
        /// 症状
        /// </summary>
        public List<string> symptom;

        /// <summary>
        /// 危害
        /// </summary>
        public string effect;

        /// <summary>
        /// 保护措施
        /// </summary>
        public List<string> protection;
    }
}
