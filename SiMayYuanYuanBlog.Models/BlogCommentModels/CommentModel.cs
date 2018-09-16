using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiMayYuanYuanBlog.Models.BlogCommentModels
{
    public class CommentModel
    {
        public int id { get; set; }

        public int article_id { get; set; }

        public byte feature_type { get; set; }

        public int parent_id { get; set; }

        public string comment_content { get; set; }

        public int comment_user_id { get; set; }

        public string comment_user_name { get; set; }

        public int user_id { get; set; }

        public string user_name { get; set; }

        public string ip_address { get; set; }

        public string region_name { get; set; }

        public int starts { get; set; }

        public DateTime create_datetime { get; set; }

        public bool isreview { get; set; }
    }
}
