using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Converter
    {
        #region Parse

        #region Dictionary Parse To String
        /// <summary>
        /// Dictionary Parse To String
        /// </summary>
        /// <param name="parameters">Dictionary</param>
        /// <returns>若字典为空则返回null</returns>
        static public string ParseToString(IDictionary<string, string> parameters)
        {
            if (parameters is null && parameters.Count == 0)
            {
                return null;
            }
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            StringBuilder query = new StringBuilder("");
            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.Append(key).Append(":").Append(value).Append(";");
                }
            }
            string content = query.ToString().Substring(0, query.Length - 1);

            return content;
        }
        #endregion

        #region String Parse To Dictionary
        /// <summary>
        /// String Parse To Dictionary
        /// </summary>
        /// <param name="parameter">String</param>
        /// <returns>Dictionary</returns>
        static public Dictionary<string, string> ParseToDictionarySS(string parameter)
        {
            try
            {
                String[] dataArry = parameter.Split(';');
                Dictionary<string, string> dataDic = new Dictionary<string, string>();
                for (int i = 0; i <= dataArry.Length - 1; i++)
                {
                    String dataParm = dataArry[i];
                    int dIndex = dataParm.IndexOf(":");
                    if (dIndex != -1)
                    {
                        String key = dataParm.Substring(0, dIndex);
                        String value = dataParm.Substring(dIndex + 1, dataParm.Length - dIndex - 1);
                        dataDic.Add(key, value);
                    }
                }

                return dataDic;
            }
            catch
            {
                return null;
            }
        }
        #endregion


        #endregion

        #region Parse

        #region Dictionary Parse To String
        /// <summary>
        /// Dictionary Parse To String
        /// </summary>
        /// <param name="parameters">Dictionary</param>
        /// <returns>若字典为空则返回null</returns>
        static public string ParseToString(IDictionary<int, string> parameters)
        {
            if (parameters is null || parameters.Count == 0)
            {
                return null;
            }
            IDictionary<int, string> sortedParams = new SortedDictionary<int, string>(parameters);
            IEnumerator<KeyValuePair<int, string>> dem = sortedParams.GetEnumerator();

            StringBuilder query = new StringBuilder("");
            while (dem.MoveNext())
            {
                int key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(value))
                {
                    query.Append(key).Append(":").Append(value).Append(";");
                }
            }
            string content = query.ToString().Substring(0, query.Length - 1);

            return content;
        }
        #endregion

        #region String Parse To Dictionary
        /// <summary>
        /// String Parse To Dictionary
        /// </summary>
        /// <param name="parameter">String</param>
        /// <returns>Dictionary</returns>
        static public Dictionary<int, string> ParseToDictionaryIS(string parameter)
        {
            try
            {
                String[] dataArry = parameter.Split(';');
                Dictionary<int, string> dataDic = new Dictionary<int, string>();
                for (int i = 0; i <= dataArry.Length - 1; i++)
                {
                    String dataParm = dataArry[i];
                    int dIndex = dataParm.IndexOf(":");
                    if (dIndex != -1)
                    {
                        int key = Convert.ToInt32(dataParm.Substring(0, dIndex));
                        String value = dataParm.Substring(dIndex + 1, dataParm.Length - dIndex - 1);
                        dataDic.Add(key, value);
                    }
                }

                return dataDic;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #endregion

        #region Collect
        /// <summary>
        /// 收集Table
        /// </summary>
        /// <param name="Exaname"></param>
        /// <param name="Libname"></param>
        /// <param name="Exatype"></param>
        /// <param name="section"></param>
        /// <param name="Level"></param>
        /// <param name="Starttime"></param>
        /// <param name="Endtime"></param>
        /// <param name="Limit"></param>
        /// <param name="timeSpan"></param>
        /// <param name="limitcount"></param>
        /// <returns></returns>
        public static Hashtable ExamTable(string Exaname, string Libname, string Exatype, int section, string Level, DateTime Starttime, DateTime Endtime, bool Limit, TimeSpan timeSpan, int limitcount,bool Anhuan)
        {
            Hashtable hashtable = new();
            hashtable.Add("索引", new string[] { "考试名", "题库名", "考试类型", "题库章节", "考试难度", "开始时间", "结束时间", "是否限考", "限考时长", "限考次数","是否安环" });
            hashtable.Add("考试名",Exaname);
            hashtable.Add("题库名", Libname);
            hashtable.Add("考试类型", Exatype);
            hashtable.Add("题库章节", section);
            hashtable.Add("考试难度", Level);
            hashtable.Add("开始时间", Starttime);
            hashtable.Add("结束时间", Endtime);
            hashtable.Add("是否限考", Limit);
            hashtable.Add("限考时长", timeSpan);
            hashtable.Add("限考次数", limitcount);
            hashtable.Add("是否安环", Anhuan);
            return hashtable;
        }

        /// <summary>
        /// 转换为考试
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        public static ExamModel HashTableToExam(Hashtable hashtable)
        {
            string[] s = (string[])hashtable["索引"];
            return new ExamModel(
              hashtable[s[0]] != null ? hashtable[s[0]].ToString() : null,
               hashtable[s[1]] != null ? hashtable[s[1]].ToString() : null,
               hashtable[s[2]] != null ? hashtable[s[2]].ToString() : null,
                Convert.ToInt32(hashtable[s[3]]),
                hashtable[s[4]] != null ? hashtable[s[4]].ToString() : null,
                (DateTime)hashtable[s[5]],
                 (DateTime)hashtable[s[6]],
                  (bool)hashtable[s[7]],
                  (TimeSpan)hashtable[s[8]],
                 Convert.ToInt32(hashtable[s[9]]))
            { Anhuan = (bool)hashtable[s[10]]};
        }
       
        public static Hashtable ExaQuestTable(ExaQuestModel exaQuestModel)
        {
            Hashtable hashtable = new();
            string[] s = new string[] { "题目类型", "难度", "所属章节", "题干", "选项", "答案", "题目简述", "所属题库",  "题目分值" , "编号" };
            hashtable.Add("索引", s);
            hashtable.Add("题目类型", exaQuestModel.type);
            hashtable.Add("难度", exaQuestModel.level);
            hashtable.Add("所属章节", exaQuestModel.belongtosection);
            hashtable.Add("题干", exaQuestModel.question);
            hashtable.Add("选项", exaQuestModel.switches);
            hashtable.Add("答案", exaQuestModel.answer);
            hashtable.Add("题目简述", exaQuestModel.summary);
            hashtable.Add("所属题库", exaQuestModel.belongtolib);
            hashtable.Add("题目分值", exaQuestModel.score);
            hashtable.Add("编号", exaQuestModel.num);
            return hashtable;
        }

        public static ExaQuestModel HashtableToQuest(Hashtable hashtable)
        {
            string[] s = (string[])hashtable["索引"];
            return new ExaQuestModel()
            {
                type = hashtable[s[0]] != null ? hashtable[s[0]].ToString() : null,
                level = hashtable[s[1]] != null ? hashtable[s[1]].ToString() : null,
                belongtosection = hashtable[s[2]] != null ? hashtable[s[2]].ToString() : null,
                question = hashtable[s[3]] != null ? hashtable[s[3]].ToString() : null,
                switches = hashtable[s[4]] !=null ? hashtable[s[4]].ToString():null,
                answer = hashtable[s[5]] !=null? hashtable[s[5]].ToString():null,
                summary = hashtable[s[6]] != null ? hashtable[s[6]].ToString() : null,
                belongtolib = hashtable[s[7]] != null ? hashtable[s[7]].ToString() : null,
                score = Convert.ToInt32(hashtable[s[8]] !=null? hashtable[s[8]].ToString():0),
                num = Convert.ToInt32(hashtable[s[9]]!=null? hashtable[s[9]].ToString():0)
            };
        }



        #endregion

        #region ExaLib

        /// <summary>
        /// Excel读取为List
        /// </summary>
        /// <param name="excelHelper"></param>
        /// <param name="LibName"></param>
        /// <param name="startindex"></param>
        /// <returns></returns>
        public static List<ExaQuestModel> ExcelToList(ExcelHelper excelHelper, string LibName, int startindex)
        {
            List<ExaQuestModel> exaQuests = new();
            for (int i = startindex; i <= excelHelper.RowCount; i++)
            {
                if (excelHelper.ReadGrid(i, 1).Equals("")) { continue; };
                exaQuests.Add(ExcelToQuest(excelHelper, LibName, i));
            }
            return exaQuests;
        }

        /// <summary>
        ///  读取单个试题
        /// </summary>
        /// <param name="excelHelper"></param>
        /// <param name="LibName"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        public static ExaQuestModel ExcelToQuest(ExcelHelper excelHelper, string LibName, int Index)
        {
            return new ExaQuestModel(
                            excelHelper.ReadGrid(Index, 1),
                            excelHelper.ReadGrid(Index, 2),
                            excelHelper.ReadGrid(Index, 3),
                            excelHelper.ReadGrid(Index, 4),
                            excelHelper.ReadGrid(Index, 5),
                            excelHelper.ReadGrid(Index, 6),
                            excelHelper.ReadGrid(Index, 7),
                            LibName);
        }




        /// <summary>
        /// Excel读取为字典
        /// </summary>
        /// <param name="excelHelper"></param>
        /// <param name="LibName"></param>
        /// <param name="startindex"></param>
        /// <returns></returns>
        public static Dictionary<int, ExaQuestModel> ExcelToDic(ExcelHelper excelHelper, string LibName, int startindex)
        {
            Dictionary<int, ExaQuestModel> exaQuests = new();
            for (int i = startindex; i <= excelHelper.RowCount; i++)
            {
                if (excelHelper.ReadGrid(i, 1).Equals("")) { continue; };
                exaQuests.Add(i, ExcelToQuest(excelHelper, LibName, i));

            }
            return exaQuests;
        }

        /// <summary>
        /// 对象写入Excel
        /// </summary>
        /// <param name="excelHelper"></param>
        /// <param name="exaQuestModel"></param>
        /// <param name="RowIndex"></param>
        public static void WriteInExcel(ExcelHelper excelHelper, ExaQuestModel exaQuestModel, int RowIndex)
        {
            excelHelper.WriteGrid(RowIndex, 1, exaQuestModel.type);
            excelHelper.WriteGrid(RowIndex, 2, exaQuestModel.level);
            excelHelper.WriteGrid(RowIndex, 3, exaQuestModel.belongtosection);
            excelHelper.WriteGrid(RowIndex, 4, exaQuestModel.question);
            excelHelper.WriteGrid(RowIndex, 5, exaQuestModel.switches);
            excelHelper.WriteGrid(RowIndex, 6, exaQuestModel.answer);
            excelHelper.WriteGrid(RowIndex, 7, exaQuestModel.summary);
        }
        #endregion

        /// <summary>
        ///  读取单个试题
        /// </summary>
        /// <param name="excelHelper"></param>
        /// <param name="LibName"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        public static ExaQuestModel ExcelToExamQuest(ExcelHelper excelHelper, int Index)
        {
            return new ExaQuestModel(
                            excelHelper.ReadGrid(Index, 1),
                            excelHelper.ReadGrid(Index, 2),
                            excelHelper.ReadGrid(Index, 3),
                            excelHelper.ReadGrid(Index, 4),
                            excelHelper.ReadGrid(Index, 5),
                            excelHelper.ReadGrid(Index, 6),
                            excelHelper.ReadGrid(Index,7),""
                          )
            {score=Convert.ToInt32( excelHelper.ReadGrid(Index,8)) };
        }

        /// <summary>
        /// 考试试题读取为List
        /// </summary>
        /// <param name="excelHelper"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static List<ExaQuestModel>ExcelToExamList(ExcelHelper excelHelper,int startIndex)
        {
            List<ExaQuestModel> exaQuestModels = new();
            for (int i = startIndex; i <= excelHelper.RowCount; i++)
            {
                if (excelHelper.ReadGrid(i, 1).Equals("")) { continue; };
                exaQuestModels.Add( ExcelToExamQuest(excelHelper, i));
            }
            return exaQuestModels;
        }

        /// <summary>
        /// 考试试题读取为字典
        /// </summary>
        /// <param name="excelHelper"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static Dictionary<int,ExaQuestModel> ExcelToExamDic(ExcelHelper excelHelper,int startIndex)
        {
            Dictionary<int, ExaQuestModel> exaQuests = new();
            for (int i = startIndex; i <= excelHelper.RowCount; i++)
            {
                if (excelHelper.ReadGrid(i, 1).Equals("")) { continue; };
                exaQuests.Add(i, ExcelToExamQuest(excelHelper, i));

            }
            return exaQuests;
        }

        /// <summary>
        /// 答案试题读取为字典
        /// </summary>
        /// <param name="excelHelper"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static Dictionary<int, string> ExcelToAnswerDic(ExcelHelper excelHelper, int startIndex)
        {
            Dictionary<int, string> exaQuests = new();
            for (int i = startIndex; i <= excelHelper.RowCount; i++)
            {
                exaQuests.Add(i, excelHelper.ReadGrid(i, 1));
            }
            return exaQuests;
        }
    }
}
