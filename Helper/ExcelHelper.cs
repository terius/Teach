using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;

namespace Helpers
{
    public class ExcelHelper
    {
        //  static HSSFWorkbook hssfworkbook;

        //     static XSSFWorkbook xssfworkbook;


        public static DataTable GetData(string filePath)
        {
            IWorkbook wk = null;
            bool isHss = false;
            try
            {
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    if (filePath.ToLower().EndsWith(".xls"))
                    {
                        wk = new HSSFWorkbook(file);
                        isHss = true;
                    }
                    else
                    {

                        wk = new XSSFWorkbook(file);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            DataTable dt = new DataTable();

            NPOI.SS.UserModel.ISheet sheet = wk.GetSheetAt(0);
            try
            {


                //获取标题
                var row1 = sheet.GetRow(0);//获取第一行即标头  
                int cellCount = row1.LastCellNum; //第一行的列数  
                string excelColName;
                for (int j = 0; j < cellCount; j++)
                {
                    excelColName = row1.GetCell(j).StringCellValue.ToUpper().Trim();
                    // if (!string.IsNullOrEmpty(excelColName))
                    //  {

                    DataColumn column = new DataColumn(excelColName);

                    dt.Columns.Add(column);
                    // }

                    // dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
                }
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                rows.MoveNext();
                while (rows.MoveNext())
                {
                    IRow row = null;
                    if (isHss)
                    {
                        row = (HSSFRow)rows.Current;
                    }
                    else
                    {
                        row = (XSSFRow)rows.Current;
                    }
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < cellCount; i++)
                    {

                        ICell cell = row.GetCell(i);

                        if (cell == null || cell.ToString().ToUpper() == "NULL")
                        {
                            dr[i] = null;
                        }
                        else
                        {
                            if (cell.CellType == CellType.Numeric && DateUtil.IsCellDateFormatted(cell))
                            {
                                dr[i] = cell.DateCellValue;
                            }
                            else if (cell.CellType == CellType.Formula)
                            {
                                dr[i] = cell.NumericCellValue.ToString();
                            }
                            else
                            {
                                dr[i] = cell.ToString().Trim();
                            }
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                wk = null;
                sheet = null;
            }
            return dt;
        }




        /// <summary>
        /// DataTable导出到Excel文件
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">保存位置</param>
        public static void Export(DataTable dtSource, string strFileName, Hashtable Columns = null, string strHeaderText = null)
        {

            using (MemoryStream ms = Export(dtSource, Columns, strHeaderText))
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }

       


        private static readonly int MaxRowCount = 65535;

        /// <summary>
        /// DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        private static MemoryStream Export(DataTable dtSource, Hashtable Columns, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            //#region 右击文件 属性信息
            //{
            //    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            //    dsi.Company = "NPOI";
            //    workbook.DocumentSummaryInformation = dsi;

            //    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            //    si.Author = "文件作者信息"; //填加xls文件作者信息
            //    si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息
            //    si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息
            //    si.Comments = "作者信息"; //填加xls文件作者信息
            //    si.Title = "标题信息"; //填加xls文件标题信息

            //    si.Subject = "主题信息";//填加文件主题信息
            //    si.CreateDateTime = DateTime.Now;
            //    workbook.SummaryInformation = si;
            //}
            //#endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            //int[] arrColWidth = new int[dtSource.Columns.Count];
            //foreach (DataColumn item in dtSource.Columns)
            //{
            //    arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            //}
            //for (int i = 0; i < dtSource.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dtSource.Columns.Count; j++)
            //    {
            //        int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
            //        if (intTemp > arrColWidth[j])
            //        {
            //            arrColWidth[j] = intTemp;
            //        }
            //    }
            //}
            int rowIndex = 0;
            IRow excelRow;
            ICellStyle headStyle = workbook.CreateCellStyle();
            IFont font;
            ICell newCell;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == MaxRowCount || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        rowIndex = 0;
                        sheet = workbook.CreateSheet();
                    }

                    #region 表头及样式

                    if (!string.IsNullOrEmpty(strHeaderText))
                    {
                        excelRow = sheet.CreateRow(0);
                        excelRow.HeightInPoints = 25;
                        excelRow.CreateCell(0).SetCellValue(strHeaderText);

                        headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        excelRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                        // headerRow.Dispose();
                        rowIndex++;
                    }

                    #endregion


                    #region 列头及样式

                    excelRow = sheet.CreateRow(rowIndex);
                    headStyle = workbook.CreateCellStyle();
                    headStyle.Alignment = HorizontalAlignment.Center;
                    font = workbook.CreateFont();
                    font.FontHeightInPoints = 10;
                    font.Boldweight = 700;
                    headStyle.SetFont(font);
                    string columnName;
                    foreach (DataColumn column in dtSource.Columns)
                    {
                        columnName = GetColumnName(column.ColumnName, Columns);
                        excelRow.CreateCell(column.Ordinal).SetCellValue(columnName);
                        excelRow.GetCell(column.Ordinal).CellStyle = headStyle;

                        //设置列宽
                        //  sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                    }
                    // headerRow.Dispose();
                    rowIndex++;

                    #endregion

                    // rowIndex = 2;
                }
                #endregion


                #region 填充内容
                excelRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    newCell = excelRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            if (DateTime.TryParse(drValue, out dateV))
                            {
                                newCell.SetCellValue(dateV.ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                            else
                            {
                                newCell.SetCellValue("");
                            }
                            // newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion

                rowIndex++;
                int maxRowCount = dtSource.Rows.Count;
                maxRowCount = string.IsNullOrEmpty(strHeaderText) ? maxRowCount + 1 : maxRowCount + 2;
                maxRowCount = Math.Min(maxRowCount, 65535);
                if (maxRowCount == rowIndex)
                {
                    for (int i = 0; i < sheet.GetRow(0).PhysicalNumberOfCells; i++)
                    {
                        sheet.AutoSizeColumn(i);
                    }
                }
            }


            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                //  sheet.Dispose();
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                return ms;
            }
        }

        private static string GetColumnName(string columnName, Hashtable columns)
        {
            if (columns == null)
            {
                return columnName;
            }
            return columns.ContainsKey(columnName) ? columns[columnName].ToString() : columnName;
        }

        ///// <summary>
        ///// 用于Web导出
        ///// </summary>
        ///// <param name="dtSource">源DataTable</param>
        ///// <param name="strHeaderText">表头文本</param>
        ///// <param name="strFileName">文件名</param>
        //public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName)
        //{
        //    HttpContext curContext = HttpContext.Current;

        //    // 设置编码和附件格式
        //    curContext.Response.ContentType = "application/vnd.ms-excel";
        //    curContext.Response.ContentEncoding = Encoding.UTF8;
        //    curContext.Response.Charset = "";
        //    curContext.Response.AppendHeader("Content-Disposition",
        //        "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));

        //    curContext.Response.BinaryWrite(Export(dtSource, strHeaderText).GetBuffer());
        //    curContext.Response.End();
        //}

        ///// <summary>读取excel
        ///// 默认第一行为标头
        ///// </summary>
        ///// <param name="strFileName">excel文档路径</param>
        ///// <returns></returns>
        //public static DataTable Import(string strFileName)
        //{
        //    DataTable dt = new DataTable();

        //    HSSFWorkbook hssfworkbook;
        //    using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
        //    {
        //        hssfworkbook = new HSSFWorkbook(file);
        //    }
        //    HSSFSheet sheet = hssfworkbook.GetSheetAt(0);
        //    System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

        //    HSSFRow headerRow = sheet.GetRow(0);
        //    int cellCount = headerRow.LastCellNum;

        //    for (int j = 0; j < cellCount; j++)
        //    {
        //        HSSFCell cell = headerRow.GetCell(j);
        //        dt.Columns.Add(cell.ToString());
        //    }

        //    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
        //    {
        //        HSSFRow row = sheet.GetRow(i);
        //        DataRow dataRow = dt.NewRow();

        //        for (int j = row.FirstCellNum; j < cellCount; j++)
        //        {
        //            if (row.GetCell(j) != null)
        //                dataRow[j] = row.GetCell(j).ToString();
        //        }

        //        dt.Rows.Add(dataRow);
        //    }
        //    return dt;
        //}


    }
}
