using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiMay.DBUtility.Factory;
using SiMay.DBUtility.Interface;
using SiMayYuanYuanBlog.Models.DynamicallyModels;

namespace SiMayYuanYuanBlog.DAL.Dynamically
{
    public class DynamicallyInfoManager
    {
        private IDataBaseHelper db = DataBaseFactory.GetDataBaseHelperInstance();

        public bool ModifyDynamically(int accountId, int dynamicId, string content)
        {
            string sql = "UPDATE tbl_blog_dynamically SET content=@content WHERE acc_id=@aid AND id=@dyId LIMIT 1;";

            int row = db.ExecuteQuery(sql, content, accountId, dynamicId);

            return row > 0 ? true : false;
        }

        public bool DeleteDynamically(int accountId, int dynamicId)
        {
            string sql = "DELETE FROM tbl_blog_dynamically WHERE acc_id=@aid AND id=@dyId LIMIT 1;";

            int row = db.ExecuteQuery(sql, accountId, dynamicId);

            return row > 0 ? true : false;
        }

        public bool VisitsAdd(int accountId, int dynamicId, int num)
        {
            string sql = "UPDATE tbl_blog_dynamically SET visits=visits + @num WHERE acc_id=@aid AND id=@dyId LIMIT 1;";
            int row = db.ExecuteQuery(sql, num, accountId, dynamicId);

            return row > 0 ? true : false;
        }

        public bool StartsAdd(int accountId, int dynamicId, int num)
        {
            string sql = "UPDATE tbl_blog_dynamically SET starts=starts + @num WHERE acc_id=@aid AND id=@dyId LIMIT 1;";
            int row = db.ExecuteQuery(sql, num, accountId, dynamicId);

            return row > 0 ? true : false;
        }
    }
}
