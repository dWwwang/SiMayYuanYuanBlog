using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiMayYuanYuanBlog.Models.DynamicallyModels
{
    public class DynamicallyModel
    {
        public int id { get; set; }

        public int acc_id { get; set; }

        public int article_id { get; set; }

        public byte sys_type { get; set; }

        public string content { get; set; }

        public int visits { get; set; }

        public int starts { get; set; }

        public DateTime create_datetime { get; set; }

        public DateTime modify_datetime { get; set; }

        public bool islock { get; set; }

        public string lock_describe { get; set; }
    }
}
