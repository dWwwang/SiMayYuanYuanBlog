using SiMayYuanYuanBlog.Models.BlogCommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiMayYuanYuanBlog.DAL.BlogComment
{
    public class CommentSetManager
    {
        private IDataBaseHelper db = DataBaseFactory.GetDataBaseHelperInstance();
        public bool PublishReply(CommentModel comment)
        {
            string sql = "INSERT INTO tbl_blog_comment ('article_id' , 'feature_type' , 'parent_id' , 'comment_content' , 'comment_user_id' , 'comment_user_name' , 'user_id' , 'user_name' , 'ip_address' , 'region_name' , 'starts' , 'create_datetime' , 'isreview') VALUES(@articleId , @featureType ,@parentId ,@content ,@cuserId ,@cuserName ,@uid ,@uName ,@ip ,@region ,@starts ,@ctime ,@review);";

            int row = db.ExecuteQuery(sql,
                comment.article_id,
                comment.feature_type,
                comment.parent_id,
                comment.comment_content,
                comment.comment_user_id,
                comment.comment_user_name,
                comment.user_id,
                comment.user_name,
                comment.ip_address,
                comment.region_name,
                comment.starts,
                comment.create_datetime,
                comment.isreview);

            return row > 0 ? true : false;

        }
    }
}
