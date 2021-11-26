using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Configuration
    {
        #region 路径区

        public const string 缓存路径 = @"wwwroot/src/Caches";

        public const string 配置文件目录 = @"wwwroot/src/Configuration";

        public const string 课件目录 = @"wwwroot/src/CourseWares";

        public const string 临时路径 = @"wwwroot/tmp";

        public const string 考试文件路径 = @"wwwroot/src/ExamFiles";

        public const string 题库文件路径 = @"wwwroot/src/ExaLibs";

        public const string Src文档 = @"/src/Docu";

        public const string Src课件 = @"/src/CourseWares";

        public const string 教育卡路径 = 目标路径 + "/三级安全教育卡.docx";

        public const string 危害告知书路径 = 目标路径 + "/职业病危害告知书.docx";

        public const string 责任书路径 = "一线员工责任书.docx";

        public const string 文档临时路径 = 目标路径 + "/tmp.docx";

        public const string 目标路径 = @"wwwroot/src/Docu";

        public const string 入职课程文件路径 = @"wwwroot/src/FCourse";

        public const string 入职配置文件路径 = 入职课程文件路径 + "/Configure.txt";

        public const string 危害配置文件1 = @"职业病危害告知书.xlsx";

        public const string 危害配置文件2 = @"2021年职业健康岗前、离岗体检方案.xlsx";

        #endregion
    }
}
