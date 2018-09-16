using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiMayYuanYuanBlog.Models.AccountModels
{
    public class ModtifyPersonInfoModel
    {
        public int account_id { get; set; }

        public bool sex { get; set; }

        public string region { get; set; }

        public string profession { get; set; }

        public string icon_urladdress { get; set; }

        public string blog_title { get; set; }

        public string blog_describe { get; set; }

        public string blog_guest_msg { get; set; }
    }
}
