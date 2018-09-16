using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiMayYuanYuanBlog.Models.AccountModels
{
    public class AccountInfoModel
    {
        public int account_id { get; set; }

        public string user_name { get; set; }

        public string password { get; set; }

        public bool sex { get; set; }

        public byte auth_level { get; set; }

        public string region { get; set; }

        public string profession { get; set; }

        public string icon_urladdress { get; set; }

        public string blog_title { get; set; }

        public string blog_describe { get; set; }

        public string blog_guest_msg { get; set; }

        public string mobile { get; set; }

        public DateTime register_datetime { get; set; }

        public bool islock { get; set; }

        public string lock_describe { get; set; }
    }
}
