using SiMayYuanYuanBlog.Models.DynamicallyModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiMayYuanYuanBlog.DAL.Dynamically
{
    public class DynamicallySetManager
    {
        private IDataBaseHelper db = DataBaseFactory.GetDataBaseHelperInstance();

        public bool PublishDynamically(DynamicallyModel dynamically)
        {
            string sql = "INSERT INTO tbl_blog_dynamically ('acc_id' , 'article_id' , 'sys_type' , 'content' , 'visits' , 'starts' , 'create_datetime' , 'modify_datetime' , 'islock' , 'lock_describe') VALUES(@accid , @articleid , @stype , @content , @visits , @starts , @createtime , @modifytime , @islock , @lockdescribe)";
            int row = db.ExecuteQuery(sql,
                dynamically.acc_id,
                dynamically.article_id,
                dynamically.sys_type,
                dynamically.content,
                dynamically.visits,
                dynamically.starts,
                dynamically.create_datetime,
                dynamically.modify_datetime,
                dynamically.islock,
                dynamically.lock_describe);

            return row > 0 ? true : false;
        }

        public List<DynamicallyModel> GetDynamicallys(int accountId, int lastarticle, int count)
        {
            string sql = "SELECT * FROM (SELECT * FROM tbl_blog_dynamically WHERE acc_id=@accid ORDER BY id DESC) AS data" + (lastarticle == -1 ? "" : " WHERE id < " + lastarticle) + " LIMIT @count;";
            DataSet ds = db.ExecuteQueryDataSet(sql, accountId, count);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                List<DynamicallyModel> dynamicallyModels = SiMayYuanYuanBlog.Core.UtilityHelper.GetModelEntity<DynamicallyModel>(dt);


                return dynamicallyModels;
            }
            else
                return new List<DynamicallyModel>();
        }
    }
}
