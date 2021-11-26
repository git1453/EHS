using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHS.Entities
{
    public static class configure
    {
        /// <summary>
        /// EhsCoursearrange的权限
        /// </summary>
        public static string[] Authority1 = new string[] { "完全公开", "指定人员" };
        /// <summary>
        /// EhsExamarrange的权限
        /// </summary>
        public static string[] Authority2 = new string[] { "完全公开", "需要密码", "部门公开", "指定用户公开" };
    }
    public abstract class BaseEntity { }
}
