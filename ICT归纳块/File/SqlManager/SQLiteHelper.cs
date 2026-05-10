using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using UserHelper;

namespace DataBaseManager
{
    public class SQLiteHelper : IDisposable, DataBaseHelper
    {
        private bool _autoCommit;
        public SQLiteConnection _connection;
        private string _connectionString;
        private bool _disposed;
        private bool _transacted;
        private SQLiteTransaction _transaction;
        private object lockSQLite;
        public SQLiteDataAdapter sqlAdapter;
        private readonly object obj1 = new object();

        public SQLiteHelper(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentException("数据库路径为空,connectionString==null");
            }
            if (!File.Exists(connectionString))
            {
                SQLiteConnection.CreateFile(connectionString);
                Thread.Sleep(500);
            }

            _autoCommit = false;
            _disposed = false;
            _transacted = false;
            _transaction = null;
            lockSQLite = RuntimeHelpers.GetObjectValue(new object());
            _connectionString = new SQLiteConnectionStringBuilder
            {
                DataSource = connectionString
            }.ToString();
            _connection = new SQLiteConnection(_connectionString);
            _connection.Commit += Transaction_Commit;
            _connection.RollBack += Transaction_RollBack;
        }

        public void Close()
        {
            if (_connection.State > ConnectionState.Closed)
            {
                if (_transacted && _autoCommit)
                {
                    Commit();
                }
                _connection.Close();
            }
        }

        public void Commit()
        {
            if (_transacted)
            {
                _transaction.Commit();
                _transacted = false;
            }
        }

        public virtual void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        public int ExecuteNonQuery(string commandText)
        {
            int result = 0;
            lock (obj1)
            {
                using (SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _connection))
                {
                    try
                    {
                        Open();
                        SQLiteTransaction sQLiteTransaction = _connection.BeginTransaction();
                        if (sQLiteTransaction != null)
                        {
                            if (sQLiteTransaction.Connection.State == ConnectionState.Connecting || sQLiteTransaction.Connection.State == ConnectionState.Open)
                            {
                                result = sQLiteCommand.ExecuteNonQuery();
                                sQLiteTransaction.Commit();
                            }
                        }
                    }
                    finally
                    {
                        Close();
                    }
                }
            }
            return result;
        }

        public void Open()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        private void IDisposable_Dispose()
        {
            sqlAdapter.Dispose();
        }

        void IDisposable.Dispose()
        {
            this.IDisposable_Dispose();
        }

        private void Transaction_Commit(object sender, CommitEventArgs e) => _transacted = false;

        private void Transaction_RollBack(object sender, EventArgs e) => _transacted = false;

        public int DeleteValues(string tableName, string WhereClause)
        {
            string commandText = (WhereClause.Length == 0) ? $"DELETE FROM {tableName}" : $"DELETE FROM {tableName} WHERE {WhereClause}";
            return ExecuteNonQuery(commandText);
        }

        public int DeleteValues(string tableName, string WhichCol, string operateStr, string condition)
        {
            string commandText = $"DELETE FROM {tableName} WHERE {WhichCol} {operateStr} '{condition}'";
            return ExecuteNonQuery(commandText);
        }

        public int InsertStandardValues(string tableName, string[] colNames, string[] colValues)
        {
            if (colNames.Length != colValues.Length)
            {
                throw new SQLiteException($"{tableName} InsertValues colNames.Length!=colValues.Length");
            }
            string[] values = new string[5] { "INSERT INTO ", tableName, " ('", "Serial_ID", "'" };
            string str = string.Concat(values);
            checked
            {
                int num = colNames.Length - 1;
                for (int i = 0; i <= num; i++)
                {
                    str = $"{str}, '{colNames[i]}'";
                }
                str = $"{str}) VALUES (NULL,'{colValues[0]}'";
                int num2 = colValues.Length - 1;
                for (int j = 1; j <= num2; j++)
                {
                    str = $"{str}, '{colValues[j]}'";
                }
                str += " )";
                return ExecuteNonQuery(str);
            }
        }

        public DataSet SelectValues(string tableName, string Command)
        {
            DataSet dataSet = new DataSet();
            lock (obj1)
            {
                try
                {
                    Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(Command, _connection))
                    using (SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd))
                    {
                        sQLiteDataAdapter.Fill(dataSet, tableName);
                    }
                }
                finally
                {
                    Close();
                }
            }
            return dataSet;
        }

        public int CreateStandardTable(string tableName, string[] colNames, string[] colTypes)
        {
            string text;

            checked
            {
                try
                {
                    text = $"CREATE TABLE IF NOT EXISTS {tableName} ( Serial_ID integer PRIMARY KEY AUTOINCREMENT ";//"( " + colNames[0] + " " + colTypes[0];

                    int num = colNames.Length - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        text = $"{text}, {colNames[i]} {colTypes[i]}";
                    }
                    text += " )  ; ";
                    return ExecuteNonQuery(text);
                }
                catch (Exception ex)
                {
                    DebugHelper.WriteLine(ex);

                    return 0;
                }
            }
        }
    }
}