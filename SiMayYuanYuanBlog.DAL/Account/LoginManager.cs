using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiMay.DBUtility.Factory;
using SiMay.DBUtility.Interface;
using SiMayYuanYuanBlog.Models.AccountModels;

namespace SiMayYuanYuanBlog.DAL.Account
{
    public class LoginManager
    {
        private IDataBaseHelper db = DataBaseFactory.GetDataBaseHelperInstance();

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public LoginResultModel Login(string username,string password)
        {
            string sql = "SELECT account_id, user_name , islock , lockdescribe FROM tbl_account WHERE user_name=@uname AND password=@pwd LIMIT 1;";
            DataSet ds = db.ExecuteQueryDataSet(sql, username, password);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                return SiMay.Common.ModelHelper<LoginResultModel>.ConvertToModelEntity(dt);
            }
            else
                return new LoginResultModel();
        }

        /// <summary>
        /// 注册账户
        /// </summary>
        /// <param name="accountInfo"></param>
        /// <returns></returns>
        public bool RegisterAccount(AccountInfoModel accountInfo)
        {
            string sql = "INSERT INTO tbl_account ('user_name','password','sex','auth_level','region','profession','icon_urladdress','blog_title','blog_describe','blog_guest_msg','mobile','register_datetime','islock','lock_describe') VALUES(@uname,@pwd,@sex,@auth,@region,@profession,@icon,@title,@describe,@guestmsg,@mobile,@regdate,@islock,@lockdescribe)";

            int row = db.ExecuteQuery(sql,
                accountInfo.user_name,
                accountInfo.password,
                accountInfo.sex,
                accountInfo.auth_level,
                accountInfo.region,
                accountInfo.profession,
                accountInfo.icon_urladdress,
                accountInfo.blog_title,
                accountInfo.blog_describe,
                accountInfo.blog_guest_msg,
                accountInfo.mobile,
                accountInfo.register_datetime,
                accountInfo.islock,
                accountInfo.lock_describe);

            return row > 0 ? true : false;
        }
    }
}
