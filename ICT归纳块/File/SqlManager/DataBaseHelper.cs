using System;
using System.Data;

namespace DataBaseManager
{
    /// <summary>
    /// 定义数据库统一接口。统合不同数据库。各数据库继承此类，并重写相应接扣内容。 目前已暂时完成 MySQL SQLite
    /// </summary>
    public interface DataBaseHelper : IDisposable
    {
        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="colNames">列名数组</param>
        /// <param name="colTypes">列类型数组</param>
        int CreateStandardTable(string tableName, string[] colNames, string[] colTypes);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="WhereClause">删除条件</param>
        int DeleteValues(string tableName, string WhereClause);

        /// <summary>
        /// 按条件删除表中的数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="WhichCol">条件列名</param>
        /// <param name="operateStr">条件 &gt; = &gt;=</param>
        /// <param name="condition">条件值</param>
        int DeleteValues(string tableName, string WhichCol, string operateStr, string condition);

        /// <summary>
        /// 向表中插入数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="colNames">列名数组</param>
        /// <param name="colValues">对应列名的数值</param>
        int InsertStandardValues(string tableName, string[] colNames, string[] colValues);


        /// <summary>
        /// commandText 自己写全部命令，无返回值
        /// </summary>
        int ExecuteNonQuery(string commandText);

        DataSet SelectValues(string tableName, string Command);

        void Open();

        void Close();
    }
}