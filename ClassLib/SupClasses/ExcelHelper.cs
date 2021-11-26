using Microsoft.Office.Interop.Excel;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ClassLib
{
    /// <summary>
    /// 导入试题时对EXCEL文件的操作对象
    /// </summary>
    public class ExcelHelper
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        private string m_target = null;
        private bool m_isCreateMode = false;
        private readonly object MISSING_VALUE = System.Reflection.Missing.Value;

        private Application m_AppMain = null;
        private Workbook m_Workbook = null;
        private Worksheet m_Worksheet = null;

        private static readonly Semaphore semaphore = new(5,5);

        
        private ExcelHelper() { }

        /// <summary>
        /// 工厂创建解析器
        /// </summary>
        /// <returns></returns>
        public static ExcelHelper CreateExcelHelper()
        {
            /// 信号量
            semaphore.WaitOne();

            Application appMain = new();
            if (appMain == null)
            {
                semaphore.Release();
                return null;
            }
            appMain.DisplayAlerts = false;
            appMain.AlertBeforeOverwriting = false;
            ExcelHelper eh = new ExcelHelper
            {
                m_AppMain = appMain
            };
            return eh;
        }

        /// <summary>
        /// 创建Excel，并进入打开状态
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public bool CreateExcel(string strPath)
        {
            m_target = strPath;
            m_isCreateMode = true;
            m_Workbook = m_AppMain.Workbooks.Add(MISSING_VALUE);
            return true;
        }

        /// <summary>
        /// 打开Excel
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public bool OpenExcel(string strPath)
        {
            m_isCreateMode = true;
            m_Workbook = m_AppMain.Workbooks.Open(strPath);
            if (m_Workbook == null)
            {
                return false;
            }
            m_target = strPath;
            return true;
        }
        /// <summary>
        /// 页数
        /// </summary>
        public int PageCount { get { return m_Workbook.Sheets.Count; } }
        /// <summary>
        /// 行数
        /// </summary>
        public int RowCount { get { return m_Worksheet.UsedRange.Cells.Rows.Count; } }
        /// <summary>
        /// 列数
        /// </summary>
        public int ColCount { get { return m_Worksheet.UsedRange.Cells.Columns.Count; } }

        /// <summary>
        /// 选择某页
        /// </summary>
        /// <param name="page"></param>
        public void SelectPage(int page)
        {
            if (page <= PageCount)
            {
                m_Worksheet = (Worksheet)m_Workbook.Worksheets.get_Item(page);
            }
            else
            {
                m_Worksheet = (Worksheet)m_Workbook.Worksheets.get_Item(PageCount);
                for (int i = PageCount; i < page; i++)
                {
                    m_Workbook.Worksheets.Add(After: m_Worksheet);
                    m_Worksheet = (Worksheet)m_Workbook.Worksheets.get_Item(i + 1);
                }
                m_Worksheet = (Worksheet)m_Workbook.Worksheets.get_Item(page);
            }


        }

        /// <summary>
        /// 单元格判空
        /// </summary>
        /// <param name="nRow"></param>
        /// <param name="nCol"></param>
        /// <returns></returns>
        public bool CellExsit(int nRow,int nCol)
        {
            if ( (Range)m_Worksheet.Cells[nRow, nCol] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取单元格的跨行
        /// </summary>
        /// <param name="nRow"></param>
        /// <param name="nCol"></param>
        /// <returns></returns>
        public int RowSpan(int nRow,int nCol)
        {
            return ((Range)m_Worksheet.Cells[nRow, nCol]).MergeArea.Rows.Count;
        }
        /// <summary>
        /// 获取单元格的跨列
        /// </summary>
        /// <param name="nRow"></param>
        /// <param name="nCol"></param>
        /// <returns></returns>
        public int ColSpan(int nRow, int nCol)
        {
            return ((Range)m_Worksheet.Cells[nRow, nCol]).MergeArea.Columns.Count;
        }
        /// <summary>
        /// 读某行某列的内容
        /// </summary>
        /// <param name="nRow"></param>
        /// <param name="nCol"></param>
        /// <returns></returns>
        public string ReadGrid(int nRow, int nCol)
        {
            Range range = (Range)m_Worksheet.Cells[nRow, nCol];
            return (bool)range.MergeCells?((Range)m_Worksheet.Cells[ range.MergeArea.Row,range.MergeArea.Column]).Text.ToString():(range.Text.ToString());
        }


        /// <summary>
        /// 写某行某列的内容
        /// </summary>
        /// <param name="nRow">单元格行</param>
        /// <param name="nCol">单元格列</param>
        /// <param name="value">值</param>
        public void WriteGrid(int nRow, int nCol, string value)
        {
            m_Worksheet.Cells[nRow, nCol] = value;
        }

        /// <summary>
        /// 删除一行
        /// </summary>
        /// <param name="index">索引</param>
        public void DeleteRow(int index)
        {
            ((Range)m_Worksheet.Rows[index,MISSING_VALUE]).Delete();
        }

        /// <summary>
        /// 删除一列
        /// </summary>
        /// <param name="index">索引</param>
        public void DeleteCol(int index)
        {
            ((Range)m_Worksheet.Cells[RowCount,index]).Delete();
        }

        /// <summary>
        /// 完全关闭
        /// </summary>
        public void Release()
        {
            m_Workbook.Close();
            m_AppMain.Quit();
            Kill(m_AppMain);

        }

        /// <summary>
        /// 先保存
        /// </summary>
        public void Save()
        {
            if (m_isCreateMode)
            {
                m_Workbook.SaveAs(m_target);
            }
        }

        /// <summary>
        /// 单独关闭文本，配合QuitApp使用
        /// </summary>
        public void CloseBook()
        {
            m_Workbook.Close();
            m_Workbook = null;
        }

        /// <summary>
        /// 最终关闭进程
        /// </summary>
        public void QuitApp()
        {
            m_AppMain.Quit();
            Kill(m_AppMain);
          
        }

        /// <summary>
        /// 保证进程关闭 
        /// </summary>
        /// <param name="excel"></param>
        public void Kill(Application excel)
        {
            IntPtr t = new(excel.Hwnd);//得到这个句柄，具体作用是得到这块内存入口 

             _ = GetWindowThreadProcessId(t, out int k);   //得到本进程唯一标志k
            Process p = Process.GetProcessById(k);   //得到对进程k的引用
            //p.CloseMainWindow();
            _ = Marshal.ReleaseComObject(o:m_AppMain);
         /*   p.Kill();  */   //关闭进程k
            semaphore.Release();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }


    }


}