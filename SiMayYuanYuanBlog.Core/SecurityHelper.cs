using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiMayYuanYuanBlog.Core
{
    public class SecurityHelper
    {
        public static string MD5_32(string s)
        {
            string str = "";
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] @byte = md5.ComputeHash(Encoding.UTF8.GetBytes(s));
            for (int i = 0; i < @byte.Length; i++)
                str = str + @byte[i].ToString("X");
            return str;
        }
    }
}
