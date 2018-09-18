using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiMayYuanYuanBlog.Models.AccountModels;

namespace SiMayYuanYuanBlog.DAL.Account
{
    public class AccountInfoManager
    {
        private IDataBaseHelper db = DataBaseFactory.GetDataBaseHelperInstance();

        /// <summary>
        /// 获取账户信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public AccountInfoModel GetAccount(string username)
        {
            string sql = "SELECT * FROM tbl_account WHERE user_name=@uname LIMIT 1;";
            DataSet ds = db.ExecuteQueryDataSet(sql, username);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return SiMay.Common.ModelHelper<AccountInfoModel>.ConvertToModelEntity(ds.Tables[0]);
            }
            else
                return null;
        }

        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ModtifyPersonInfoModel GetPersonInfo(int id)
        {
            string sql = "SELECT account_id , sex , region , profession , icon_urladdress , blog_title , blog_describe , blog_guest_msg FROM tbl_account WHERE account_id=@id LIMIT 1;";
            DataSet ds = db.ExecuteQueryDataSet(sql, id);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return SiMay.Common.ModelHelper<ModtifyPersonInfoModel>.ConvertToModelEntity(ds.Tables[0]);
            }
            else
                return null;

        }

        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="modtifyInfo"></param>
        /// <returns></returns>
        public bool ModifyPersonInfo(ModtifyPersonInfoModel modtifyInfo)
        {
            string sql = "UPDATE tbl_account SET sex=@sex , region=@region , profession=@profession , icon_urladdress=@icon , blog_title=@btitle , blog_describe=@describe , blog_guest_msg=@guestMsg WHERE account_id=@id LIMIT 1;";
            int row = db.ExecuteQuery(sql,
                modtifyInfo.sex,
                modtifyInfo.region,
                modtifyInfo.profession,
                modtifyInfo.icon_urladdress,
                modtifyInfo.blog_title,
                modtifyInfo.blog_describe,
                modtifyInfo.blog_guest_msg,
                modtifyInfo.account_id);

            return row > 0 ? true : false;
        }
    }
}
