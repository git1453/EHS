using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MSWord = Microsoft.Office.Interop.Word;
using System.Threading;

namespace ClassLib
{
    public class DocHelper
    {
        #region 地址
        /// <summary>
        /// 有效责任书路径
        /// </summary>
        public const string 教育卡路径=Configuration.教育卡路径;

        /// <summary>
        ///  有效危害告知书路径
        /// </summary>
        public const string 危害告知书路径= Configuration.危害告知书路径;

        public const string 责任书路径 = Configuration.目标路径 +"/"+ Configuration.责任书路径;

        /// <summary>
        /// 临时文件路径
        /// </summary>
        public const string 临时路径 = Configuration.文档临时路径;

        /// <summary>
        /// 目标路径
        /// </summary>
        public const string 目标路径 = Configuration.目标路径;

        #endregion

        #region 常量区
        static MSWord.WdExportOptimizeFor paramExportOptimizeFor = MSWord.WdExportOptimizeFor.wdExportOptimizeForPrint;
        static MSWord.WdExportRange paramExportRange = MSWord.WdExportRange.wdExportAllDocument;     
        static MSWord.WdExportItem paramExportItem = MSWord.WdExportItem.wdExportDocumentContent; 
        static MSWord.WdExportCreateBookmarks paramCreateBookmarks = MSWord.WdExportCreateBookmarks.wdExportCreateWordBookmarks;
        static readonly int paramStartPage = 0;    
        static readonly bool paramOpenAfterExport = false;
        static readonly int paramEndPage = 0;
        static readonly bool paramIncludeDocProps = true;
        static readonly bool paramKeepIRM = true;
        static readonly bool paramDocStructureTags = true;
        static readonly bool paramBitmapMissingFonts = true;
        static readonly bool paramUseISO19005_1 = false;
        static readonly object paramMissing = Type.Missing;
        #endregion

        /// <summary>
        /// 多线程
        /// </summary>
        private static readonly Semaphore semaphore = new(10, 10);

        private MSWord.Application wordApp;

        private MSWord.Document wordDoc=null;

        private object TMP=null;

        private DocHelper() { }

        /// <summary>
        /// 工厂创建解析器
        /// </summary>
        /// <returns></returns>
        public static DocHelper CreateDocHelper()
        {
            semaphore.WaitOne();
            MSWord.Application appMain = new MSWord.Application();
            if (appMain == null)
            {
                return null;
            }
            appMain.Visible = false;
            appMain.DisplayAlerts = MSWord.WdAlertLevel.wdAlertsNone;
            DocHelper eh = new()
            {
                wordApp = appMain
            };
            return eh;
        }

    
        #nullable enable
       /// <summary>
       /// 创建副本并打开 
       /// </summary>
       /// <param name="basepath">源路径</param>
       /// <param name="TmpPath">临时文件路径（可空）</param>
       /// <returns></returns>
        public bool OpenDocument(string basepath,string? TmpPath)
        {
            object path;
            if (Path.IsPathRooted(basepath))
            {
                path = basepath;
            }
            else
            {
                path = Path.GetFullPath(Path.Combine(basepath));
            }
            if (!File.Exists((string)path))
            {
                return false;
            }
            FileInfo file = new(path.ToString());
            if (TmpPath == null)
            {
                file.CopyTo(Path.GetFullPath(临时路径));
                TMP = Path.GetFullPath(Path.Combine(临时路径));
            }
            else
            {
                if (Path.IsPathRooted(TmpPath))
                {
                    file.CopyTo(TmpPath);
                    TMP = TmpPath;
                }
                else
                {
                    TMP = Path.GetFullPath(TmpPath);
                    file.CopyTo(TMP.ToString());
                }
            }

            wordDoc = wordApp.Documents.Open(
                    ref TMP, paramMissing,  paramMissing,
                    paramMissing,  paramMissing, paramMissing,
                    paramMissing,  paramMissing, paramMissing,
                    paramMissing,  paramMissing, paramMissing,
                    paramMissing,  paramMissing, paramMissing,
                    paramMissing);
            return true;
        }

        /// <summary>
        /// 关闭文件
        /// </summary>
        public void Close()
        {
            //文件保存
            object Nothing = Missing.Value;
            if(wordDoc!=null)
                wordDoc.Close();
            wordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
            if (TMP != null)
            {
                new FileInfo(TMP.ToString()).Delete();
            }
            semaphore.Release();
        }

        /// <summary>
        /// 保存绝对地址和相对地址都可以
        /// </summary>
        /// <param name="purppath"></param>
        public void SaveDocument(string purppath)
        {
            if (!Path.IsPathRooted(purppath))
            {
                purppath = Path.GetFullPath( purppath );
            }

            //文件保存
            wordDoc.ExportAsFixedFormat(purppath,
                          MSWord.WdExportFormat.wdExportFormatPDF, paramOpenAfterExport,
                          paramExportOptimizeFor, paramExportRange, paramStartPage,
                          paramEndPage, paramExportItem, paramIncludeDocProps,
                          paramKeepIRM, paramCreateBookmarks, paramDocStructureTags,
                          paramBitmapMissingFonts, paramUseISO19005_1,
                          paramMissing); //文件关闭

            wordDoc.Save();
        }

        /// <summary>
        /// 填入人员信息
        /// </summary>
        /// <param name="recruit"></param>
        public void ChangeContent(RecruitModel recruit,string 安环考试路径,string 入职课程文件路径,string 考试文件路径)
        {
            //工号
                wordDoc.Tables[1].Cell(2, 3).Range.Text = recruit.worknum.ToString();
            //姓名
            if (recruit.name != null)
                wordDoc.Tables[1].Cell(2, 5).Range.Text = recruit.name;
            //性别
            if (recruit.sex.Equals(1))
                wordDoc.Tables[1].Cell(2, 7).Range.Text = "男";
            else
                wordDoc.Tables[1].Cell(2, 7).Range.Text = "女";
            //部门
            if (recruit.department != null)
                wordDoc.Tables[1].Cell(3, 3).Range.Text = recruit.department;
            //年龄
            int age = DateTime.Now.Year - recruit.birth.Year;
            if (DateTime.Now.Month < recruit.birth.Month)
            {
                age -= 1;
            }
            else if (DateTime.Now.Month == recruit.birth.Month && DateTime.Now.Day < recruit.birth.Day)
            {
                age -= 1;
            }
            wordDoc.Tables[1].Cell(3, 5).Range.Text = age.ToString();
            //学历
            if (recruit.degree != null)
                wordDoc.Tables[1].Cell(3, 7).Range.Text = recruit.degree;
            //职位
            if (recruit.occupation != null)
                wordDoc.Tables[1].Cell(4, 3).Range.Text = recruit.occupation;
            //进厂日期
            wordDoc.Tables[1].Cell(4, 5).Range.Text = recruit.jointime.ToString("yyyy.MM.dd");
            //电话
            wordDoc.Tables[1].Cell(4, 7).Range.Text = recruit.phone.ToString();
            int i = 1;
            object Link = false;
            object SaveWith = true;
            FileInfo[] files= new DirectoryInfo(Path.GetFullPath(Path.Combine(入职课程文件路径))).GetFiles("*.txt");
            DateTime Insertfile=DateTime.MinValue;
            if (files.Length != 0 && files != null)
            {
                foreach(FileInfo f in files)
                {
                    if (Path.GetFileNameWithoutExtension(f.Name).Equals(recruit.worknum.ToString()))
                    {
                        Insertfile= f.CreationTime;
                    }
                }
            }
            if (Insertfile != DateTime.MinValue)
            {
                string s = Insertfile.ToString("yyyy年MM月dd日HH时") + "至" + DateTime.Now.ToString("yyyy年MM月dd日HH时");
                wordDoc.Tables[1].Cell(6, 3).Range.Text = s;
                //wordDoc.Tables[1].Cell(10, 3).Range.Text = s;
                //wordDoc.Tables[1].Cell(14, 3).Range.Text = s;
            }   
            
            if (recruit.photocode != null)
            {
                string file = Path.GetFullPath( Path.Combine(目标路径, recruit.name + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpeg"));
                File.WriteAllBytes(file, recruit.photocode);
                wordDoc.InlineShapes.AddPicture(file, ref Link, ref SaveWith, wordDoc.Tables[1].Cell(2, 8).Range);
                wordDoc.InlineShapes[i].Width = 70;
                wordDoc.InlineShapes[i].Height = 80;
                i++;
                new FileInfo(file).Delete();
            }

            FileInfo[] fileInfos = new DirectoryInfo(Path.GetFullPath(Path.Combine(考试文件路径 ,安环考试路径, recruit.name))).GetFiles("*.jpeg");
                string PhotoPath="";
            if (fileInfos.Length != 0 && fileInfos != null)
            {
                int k = new Random().Next(0, fileInfos.Length);
                PhotoPath = fileInfos[k].FullName;
            }
            if (PhotoPath != "")
            {
                wordDoc.InlineShapes.AddPicture(PhotoPath, ref Link, ref SaveWith, wordDoc.Tables[1].Cell(2, 9).Range);
                wordDoc.InlineShapes[i].Width = 70;
                wordDoc.InlineShapes[i].Height = 70;
                i++;
            }



         
                
            //签字
            if (recruit.SignPath != null)
            {
                wordDoc.InlineShapes.AddPicture(recruit.SignPath, ref Link, ref SaveWith, wordDoc.Tables[1].Cell(7, 4).Range);
                wordDoc.InlineShapes[i].Width = 60;
                wordDoc.InlineShapes[i].Height = 30;
                i++;

                //wordDoc.InlineShapes.AddPicture(recruit.SignPath, ref Link, ref SaveWith, wordDoc.Tables[1].Cell(11, 4).Range);
                //wordDoc.InlineShapes[i].Width = 60;
                //wordDoc.InlineShapes[i].Height = 30;
                //i++;

                //wordDoc.InlineShapes.AddPicture(recruit.SignPath, ref Link, ref SaveWith, wordDoc.Tables[1].Cell(15, 4).Range);
                //wordDoc.InlineShapes[i].Width = 60;
                //wordDoc.InlineShapes[i].Height = 30;
                

            }
        }

        /// <summary>
        /// 填入危害告知信息
        /// </summary>
        /// <param name="danger"></param>
        public void ChangeContent(Occupation danger)
        {
            if (danger.岗位名称 != null)
                wordDoc.Tables[1].Cell(2, 1).Range.Text = danger.岗位名称;
            if (danger.职业危害 != null)
            {
                List<string> pros = new();
                int cell = 2;
                foreach (DangerInfo info in danger.职业危害)
                {
                    if (cell > 2)
                    {
                        wordDoc.Tables[1].Rows.Add();
                    }
                    wordDoc.Tables[1].Cell(cell, 2).Range.Text = info.危害;
                    wordDoc.Tables[1].Cell(cell, 3).Range.Text = info.危害因素;
                    wordDoc.Tables[1].Cell(cell, 4).Range.Text = info.禁忌症;
                    wordDoc.Tables[1].Cell(cell, 5).Range.Text = info.防护措施;
                    pros.Add(info.防护措施);
                    cell++;
                }
                if (cell > 3)
                {
                    wordDoc.Tables[1].Cell(2, 1).Merge(wordDoc.Tables[1].Cell(cell - 1, 1));
                }
                if (pros.Count >= 2)
                {
                    for (int i = pros.Count - 2; i >= 0; i--)
                    {
                        if (ToStandard(pros[i].Trim()).Equals(ToStandard(pros[i + 1].Trim())))
                        {
                            wordDoc.Tables[1].Cell(i + 2, 5).Merge(wordDoc.Tables[1].Cell(i + 3, 5));
                            wordDoc.Tables[1].Cell(i + 2, 5).Range.Text = pros[i];
                        }
                    }
                }
            };
        
        }
        public static string ToStandard(string str)
        {
            string ret = string.Empty;
            foreach (char c in str)
            {
                if (c!.Equals(' ') && c!.Equals('\n'))
                {
                    ret += c;
                }
            }
            return ret;
        }


        /// <summary>
        /// 插入表格内容
        /// </summary>
        /// <param name="table"></param>
        /// <param name="CellRow"></param>
        /// <param name="CellCol"></param>
        /// <param name="value"></param>
        public void Insert(int table,int CellRow,int CellCol,string str)
        {
            wordDoc.Tables[table].Cell(CellRow, CellCol).Range.Text = str;
        }
        public void AddDangerTime(string SignPath)
        {
            MSWord.Range range = wordDoc.Paragraphs.Last.Range;
            if (SignPath != null)
            {
                object Link = false;
                object SaveWith = true;
                wordDoc.InlineShapes.AddPicture(SignPath, ref Link, ref SaveWith, wordDoc.Range(wordDoc.Paragraphs.Last.Previous(1).Range.End - 1, wordDoc.Paragraphs.Last.Previous(1).Range.End));
                wordDoc.InlineShapes[1].Width = 60;
                wordDoc.InlineShapes[1].Height = 30;
            }
            range.Font.Name = "宋体";
            range.Font.Size = 12;
            range.Text = DateTime.Now.ToString("yyyy年MM月dd日") + "                    " + DateTime.Now.ToString("yyyy年MM月dd日");
        }
        public void AddResponseTime(string SignPath)
        {


            MSWord.Range range1 = Searchstr("{当前年}");
            if (range1 != null)
            {
                range1.Text = DateTime.Now.Year.ToString();
            }
            MSWord.Range range2 = Searchstr("{当前年月日}");
            if (range2 != null)
            {
                range2.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            }
            MSWord.Range range3 = Searchstr("{当前年最后月日}");
            if (range3 != null)
            {
                range3.Text = DateTime.Now.Year.ToString() + "年12月31日";
            }


            MSWord.Range prev = wordDoc.Paragraphs.Last.Range;
            prev.Font.Name = "仿宋";
            prev.Font.Size = 14;
            prev.Text = "责任人签字：             上级管理者：           ";

            if (SignPath != null)
            {
                object Link = false;
                object SaveWith = true;
                wordDoc.InlineShapes.AddPicture(SignPath, ref Link, ref SaveWith, wordDoc.Range(prev.Start + 6, prev.Start + 15));
                wordDoc.InlineShapes[1].Width = 60;
                wordDoc.InlineShapes[1].Height = 30;
            }
            wordDoc.Paragraphs.Add();
            MSWord.Range range = wordDoc.Paragraphs.Last.Range;
            range.Font.Name = "仿宋";
            range.Font.Size = 14;
            range.Text = "签订日期：" + DateTime.Now.ToString("yyyy年MM月dd日") + " 签订日期：" + DateTime.Now.ToString("yyyy年MM月dd日");
        }
        public MSWord.Range Searchstr(string str)
        {
            int StartIndex;
            for (int P=1;P<=wordDoc.Paragraphs.Count;P++)
            {
                string Text = wordDoc.Paragraphs[P].Range.Text;
                for(int i = 0; i < Text.Length - str.Length; i++)
                {
                    if (Text[i].Equals(str[0]))
                    {
                        StartIndex = i;
                        int swif = 1;
                        while (Text[i + swif].Equals(str[swif]))
                        {
                            swif++;
                            if (swif == str.Length)
                            {
                                return wordDoc.Range(wordDoc.Paragraphs[P].Range.Start + StartIndex, wordDoc.Paragraphs[P].Range.Start + StartIndex + swif);
                            }
                        }
                    }
                }
            }
            return null;
        }


        /// <summary>
        /// Doc转换pdf
        /// </summary>
        /// <param name="源路径"></param>
        /// <param name="目标路径"></param>
        /// <param name="转换格式"></param>
        /// <returns></returns>
        static public bool Doc转Pdf(string 源路径, string 目标路径, MSWord.WdExportFormat 转换格式)
        {
            semaphore.WaitOne();
            bool result;
            MSWord.Application wordApplication = new MSWord.Application();
            MSWord.Document? wordDocument = null;
            try
            {
                object paramSourceDocPath = Path.GetFullPath( 源路径 );
                string paramExportFilePath = Path.GetFullPath( 目标路径 );

                MSWord.WdExportFormat paramExportFormat = 转换格式;

                wordDocument = wordApplication.Documents.Open(
                        ref paramSourceDocPath,  paramMissing, paramMissing,
                         paramMissing,  paramMissing,  paramMissing,
                        paramMissing,  paramMissing,  paramMissing,
                        paramMissing, paramMissing,  paramMissing,
                        paramMissing, paramMissing,  paramMissing,
                        paramMissing);

                if (wordDocument != null)
                    wordDocument.ExportAsFixedFormat(paramExportFilePath,
                            paramExportFormat, paramOpenAfterExport,
                            paramExportOptimizeFor, paramExportRange, paramStartPage,
                            paramEndPage, paramExportItem, paramIncludeDocProps,
                            paramKeepIRM, paramCreateBookmarks, paramDocStructureTags,
                            paramBitmapMissingFonts, paramUseISO19005_1,
                            paramMissing);
                result = true;
               
            }
            finally
            {
                if (wordDocument != null)
                {
                    wordDocument.Close( paramMissing,  paramMissing, paramMissing);
                }
                wordApplication.Quit();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                semaphore.Release();
            }
            
            return result;
        }

    }
}


