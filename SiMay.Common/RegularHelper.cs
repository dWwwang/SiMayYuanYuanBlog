using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiMay.Common
{
    public class RegularCheck
    {
        public RegularCheck()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 精度小数点后2为整数,验证货币
        /// </summary>
        /// <returns></returns>
        public static bool CheckMoney(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"^\d+(\.\d\d?)?$");
        }

        /// <summary>
        /// 验证手机号码
        /// </summary>
        /// <returns></returns>
        public static bool CheckMobile(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"^13[0-9]{1}[0-9]{8}|^15[9]{1}[0-9]{8}");
        }

        /// <summary>
        /// 验证邮箱
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckEmail(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }

        /// <summary>
        /// 验证身份证号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckIDcard(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"\d{15}|\d{18}");
        }

        /// <summary>
        /// 验证中国邮政编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckPostcode(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"[1-9]\d{5}(?!\d)");
        }

        /// <summary>
        /// 验证英文26个字母（大小写）
        /// </summary>
        /// <returns></returns>
        public static bool CheckLetters(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"^[A-Za-z]+$");
        }

        /// <summary>
        /// 验证大写字母
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckCapitalLetters(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"^[A-Z]+$");
        }

        /// <summary>
        /// 验证小写字母
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckSmallLetters(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"^[a-z]+$");
        }

        /// <summary>
        /// 验证只有数字跟字母
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckNumAndLetters(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"^[A-Za-z0-9]+$");
        }

        /// <summary>
        /// 验证中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckZhongWen(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }


        public static bool CheckNum(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"^-?[0-9]\d*$");
        }
    }
}
