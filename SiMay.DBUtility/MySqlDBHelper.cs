using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SiMay.DBUtility.Interface;

namespace SiMay.DBUtility
{
    public class MySqlDBHelper : IDataBaseHelper
    {
        string _sqlConnectionstring = null;

        public MySqlDBHelper(string constr)
        {
            _sqlConnectionstring = constr;
        }

        public int ExecuteQuery(string sql)
        {
            int i = 0;
            using (MySqlConnection _sqlConnection = new MySqlConnection(_sqlConnectionstring))
            {
                _sqlConnection.Open();
                i = new MySqlCommand(sql, _sqlConnection).ExecuteNonQuery();
            }
            return i;
        }

        public int ExecuteQuery(string sql, params object[] pars)
        {
            int i = 0;
            using (MySqlConnection _sqlConnection = new MySqlConnection(_sqlConnectionstring))
            {
                _sqlConnection.Open();
                MySqlParameter[] mySqlParameters = SetParameter(sql, pars);
                var cmd = new MySqlCommand(sql, _sqlConnection);
                cmd.Parameters.AddRange(mySqlParameters);
                i = cmd.ExecuteNonQuery();
            }
            return i;

        }

        public DataSet ExecuteQueryDataSet(string sql)
        {
            DataSet ds = null;
            using (MySqlConnection _sqlConnection = new MySqlConnection(_sqlConnectionstring))
            {
                _sqlConnection.Open();
                MySqlDataAdapter adt = new MySqlDataAdapter(sql, _sqlConnection);

                ds = new DataSet();
                adt.Fill(ds);
            }
            return ds;
        }

        /// <summary>
        /// 查询数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public DataSet ExecuteQueryDataSet(string sql, params object[] pars)
        {
            DataSet ds = null;
            using (MySqlConnection _sqlConnection = new MySqlConnection(_sqlConnectionstring))
            {
                _sqlConnection.Open();
                MySqlParameter[] mySqlParameters = SetParameter(sql, pars);
                var cmd = new MySqlCommand(sql, _sqlConnection);
                cmd.Parameters.AddRange(mySqlParameters);
                MySqlDataAdapter adt = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                adt.Fill(ds);
            }
            return ds;
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="transactions">批量SQL及参数</param>
        /// <returns>是否成功</returns>
        public bool ExecuteSqlTransaction(List<SqlTransaction> transactions)
        {
            bool isSuccessed = true;
            using (MySqlConnection _sqlConnection = new MySqlConnection(_sqlConnectionstring))
            {
                _sqlConnection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = _sqlConnection;
                cmd.Transaction = _sqlConnection.BeginTransaction();

                try
                {
                    foreach (var tran in transactions)
                    {
                        cmd.CommandText = tran.SQL;
                        cmd.Parameters.AddRange(SetParameter(tran.SQL, tran.Parameters.ToArray()));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    cmd.Transaction.Commit();
                }
                catch
                {
                    cmd.Transaction.Rollback();
                    isSuccessed = false;
                }
            }

            return isSuccessed;
        }


        //public int ExecuteCommandTextProc(string sql)
        //{
        //    int i = 0;
        //    using (MySqlConnection _sqlConnection = new MySqlConnection(_sqlConnectionstring))
        //    {
        //        _sqlConnection.Open();
        //        MySqlCommand cmd = new MySqlCommand();
        //        cmd.Connection = _sqlConnection;
        //        cmd.CommandText = sql;
        //        cmd.CommandType = CommandType.;
        //        i = cmd.ExecuteNonQuery();
        //    }
        //    return i;
        //}

        //public int ExecuteCommandTextProc(string sql, params object[] pars)
        //{
        //    var _sqlConnection = new MySqlConnection(_sqlConnectionstring);

        //    _sqlConnection.Open();
        //    MySqlParameter[] mySqlParameters = SetParameter(sql, pars);

        //    MySqlCommand cmd = new MySqlCommand();
        //    cmd.Connection = _sqlConnection;
        //    cmd.CommandText = sql;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.AddRange(mySqlParameters);

        //    int l = cmd.ExecuteNonQuery();

        //    _sqlConnection.Close();

        //    return l;

        //}

        //public DataTable ExecuteCommandTextProcGetValue(string sql)
        //{
        //    var _sqlConnection = new MySqlConnection(_sqlConnectionstring);

        //    _sqlConnection.Open();
        //    MySqlCommand cmd = new MySqlCommand();
        //    cmd.Connection = _sqlConnection;
        //    cmd.CommandText = sql;
        //    cmd.CommandType = CommandType.Text;

        //    MySqlDataAdapter adapter = new MySqlDataAdapter();
        //    adapter.SelectCommand = cmd;

        //    DataTable dt = new DataTable();
        //    adapter.Fill(dt);

        //    _sqlConnection.Close();

        //    return dt;

        //}

        //public DataTable ExecuteCommandTextProcGetValue(string sql, params object[] pars)
        //{
        //    DataTable dt = null;
        //    using (MySqlConnection _sqlConnection = new MySqlConnection(_sqlConnectionstring))
        //    {
        //        _sqlConnection.Open();
        //        MySqlParameter[] mySqlParameters = SetParameter(sql, pars);

        //        MySqlCommand cmd = new MySqlCommand();
        //        cmd.Connection = _sqlConnection;
        //        cmd.CommandText = sql;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddRange(mySqlParameters);

        //        MySqlDataAdapter adapter = new MySqlDataAdapter();
        //        adapter.SelectCommand = cmd;

        //        dt = new DataTable();
        //        adapter.Fill(dt);
        //    }
        //    return dt;
        //}

        private MySqlParameter[] SetParameter(string sql, object[] parameters)
        {
            string key = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_";

            List<string> parameterNames = new List<string>(); //判断参数是否已赋值

            MySqlParameter[] mySqlParameters = new MySqlParameter[parameters.Length];
            StringBuilder sb = new StringBuilder();
            bool isname = false;
            int index = 0;
            for (int i = 0; i < sql.Length; i++)
            {
                char c = sql[i];
                if (c == '@')
                {
                    sb.Append(c);
                    isname = true;
                }
                else if (isname)
                {
                    if (key.Contains(c))
                    {
                        sb.Append(c);
                    }
                    else
                    {
                        isname = false;

                        string parameterName = sb.ToString();
                        if (!parameterNames.Contains(parameterName))
                        {
                            parameterNames.Add(parameterName);
                            mySqlParameters[index] = new MySqlParameter(parameterName, parameters[index]);
                            index++;
                        }
                        sb.Clear();
                    }
                }
            }
            if (sb.Length > 0)
            {
                string parameterName = sb.ToString();
                if (!parameterNames.Contains(parameterName))
                    mySqlParameters[index] = new MySqlParameter(parameterName, parameters[index]);

                sb.Clear();
            }
            return mySqlParameters;
        }
    }

    public class SqlTransaction
    {
        public string SQL { set; get; }

        public List<object> Parameters { get; set; } = new List<object>();
    }
}
