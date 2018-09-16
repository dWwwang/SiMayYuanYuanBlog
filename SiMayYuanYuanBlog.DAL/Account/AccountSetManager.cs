using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiMayYuanYuanBlog.DAL.Account
{
    public class AccountSetManager
    {
        private IDataBaseHelper db = DataBaseFactory.GetDataBaseHelperInstance();
        /// <summary>
        /// 设置权限等级
        /// </summary>
        /// <param name="id"></param>
        /// <param name="auth"></param>
        /// <returns></returns>
        public bool SetAuthLevel(int id, byte auth)
        {
            string sql = "UPDATE tbl_account SET auth_level=@auth WHERE account_id=@id LIMIT 1;";
            int row = db.ExecuteQuery(sql, auth, id);

            return row > 0 ? true : false;
        }

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool SetPassWord(int id, string pwd)
        {
            string sql = "UPDATE tbl_account SET password=@pwd WHERE account_id=@id LIMIT 1;";
            int row = db.ExecuteQuery(sql, pwd, id);

            return row > 0 ? true : false;
        }

        /// <summary>
        /// 设置冻结
        /// </summary>
        /// <param name="id"></param>
        /// <param name="islock"></param>
        /// <param name="describe"></param>
        /// <returns></returns>
        public bool SetLock(int id, bool islock, string describe)
        {
            string sql = "UPDATE tbl_account SET islock=@islock , lock_describe=@describe WHERE account_id=@id LIMIT 1;";
            int row = db.ExecuteQuery(sql, islock, describe, id);

            return row > 0 ? true : false;
        }

        /// <summary>
        /// 设置电话号码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public bool SetMobileNumber(int id, string mobile)
        {
            string sql = "UPDATE tbl_account SET lock_describe=@mobile WHERE account_id=@id LIMIT 1;";
            int row = db.ExecuteQuery(sql, mobile, id);

            return row > 0 ? true : false;
        }

        /// <summary>
        /// 根据手机号码修改密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="mobile"></param>
        /// <param name="destpassword"></param>
        /// <returns></returns>
        public bool SetPassWordByMobile(string username, string mobile, string destpassword)
        {
            string sql = "UPDATE tbl_account SET password=@pwd WHERE user_name=@uname AND mobile=@mobile LIMIT 1;";
            int row = db.ExecuteQuery(sql, destpassword, username, mobile);

            return row > 0 ? true : false;
        }

        /// <summary>+
        /// 设置留言信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SetGuestMessage(int id, string msg)
        {
            string sql = "UPDATE tbl_account SET blog_guest_msg=@msg WHERE account_id=@id LIMIT 1;";
            int row = db.ExecuteQuery(sql, msg, id);

            return row > 0 ? true : false;
        }
    }
}
