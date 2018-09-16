using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiMayYuanYuanBlog.Models.AccountModels
{
    public class LoginResultModel
    {
        public int account_id { get; set; }

        public string user_name { get; set; }

        public bool islock { get; set; }

        public string lock_describe { get; set; }
    }
}
