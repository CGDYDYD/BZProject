using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using UserHelper;

namespace BoTech
{
    public class EPPlusHelper
    {
        /// <summary>
        /// DataSet 转Excel 并保存本地
        /// </summary>
        /// <param name="sourceSet">DataSet 表集</param>
        /// <param name="filePath">保存地址</param>
        public static bool DataSetToExcel(DataSet sourceSet, string filePath)
        {
            try
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
                {
                    for (int k = 0; k < sourceSet.Tables.Count; k++)
                    {
                        string tableName = sourceSet.Tables[k].TableName;
                        if (tableName.Length == 0)
                        {
                            tableName = k.ToString();
                        }

                        ExcelWorksheet ws = package.Workbook.Worksheets.Add(tableName);
                        for (int i = 0; i < sourceSet.Tables[k].Columns.Count; i++)
                        {
                            ws.Cells[1, i + 1].Value = sourceSet.Tables[k].Columns[i].ColumnName;
                            for (int j = 0; j < sourceSet.Tables[k].Rows.Count; j++)
                            {
                                ws.Cells[j + 2, i + 1].Value = sourceSet.Tables[k].Rows[j][i].ToString();
                            }
                        }
                        package.Save();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
                return false;
            }
        }

        /// <summary>
        /// 读取指定地址Excel文件，并返回DataTable 数据
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public static DataTable ExcelToDataTable(string filePath)
        {
            try
            {
                DataTable dt = new DataTable();
                using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
                {
                    if (package.Workbook.Worksheets.Count >= 1)
                    {
                        ExcelWorksheet ws = package.Workbook.Worksheets[1];
                        dt.TableName = package.Workbook.Worksheets[1].Name;
                        int maxColumnNum = ws.Dimension.End.Column;
                        int maxRowNum = ws.Dimension.End.Row;
                        int realColumn = 0;
                        for (int i = 0; i < maxColumnNum; i++)
                        {
                            string temStr = ws.Cells[1, i + 1].Value.ToString();
                            if (temStr != "ColumnEnded")
                            {
                                realColumn++;
                                DataColumn dc = new DataColumn(temStr, typeof(string));
                                dt.Columns.Add(dc);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = 0; i < maxRowNum - 1; i++)
                        {
                            string temStr = "";
                            dt.Rows.Add(dt.NewRow());
                            for (int j = 0; j < realColumn; j++)
                            {
                                if (ws.Cells[i + 2, j + 1].Value != null)
                                {
                                    temStr = ws.Cells[i + 2, j + 1].Value.ToString();
                                    if (temStr != "RowEnded")
                                    {
                                        dt.Rows[i][j] = temStr;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    dt.Rows[i][j] = "";
                                }
                            }
                            if (temStr == "RowEnded")
                            {
                                dt.Rows.RemoveAt(dt.Rows.Count - 1);
                                break;
                            }
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
                return null;
            }
        }
    }
}