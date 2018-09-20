using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiMay.DBUtility.Interface
{
    public interface IDataBaseHelper
    {
        /// <summary>
        /// 执行SQL，并返回影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteQuery(string sql);

        int ExecuteQuery(string sql, params object[] pars);

        /// <summary>
        /// 执行SQL,并返回相应数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataSet ExecuteQueryDataSet(string sql);

        DataSet ExecuteQueryDataSet(string sql, params object[] pars);
    }
}
