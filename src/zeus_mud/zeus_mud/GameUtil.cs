using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace zeus_mud
{
    class ValidateResult
    {
        public ValidateResult(bool result, string reason)
        {
            Result = result;
            FailedReason = reason;
        }

        public bool Result { get; set; }
        public string FailedReason { get; set; }
    }

    class GameUtil
    {
        //======================================================================
        // ● 检查资料合法性
        //======================================================================

        /// <summary>
        /// 检查邮箱
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static ValidateResult checkEmail(string email)
        {
            email.Trim();
            if (email.Length == 0)
            {
                return new ValidateResult(false, "你先把邮箱填了吧");
            }
            if (email.IndexOf(" ") > -1)
            {
                return new ValidateResult(false, "邮箱不能含有空格");
            }
            Regex regex = new Regex("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
            return new ValidateResult(regex.Match(email).Success, "邮箱地址不合法。");
        }

        /// <summary>
        /// 检查密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static ValidateResult checkPassword(string password)
        {
            if (password.Length == 0)
            {
                return new ValidateResult(false, "你先把密码填了吧");
            }
            if (password.IndexOf(" ") > -1)
            {
                return new ValidateResult(false, "密码不能含有空格");
            }
            Regex regex = new Regex("^[a-zA-Z0-9_@#]{3,24}$");
            return new ValidateResult(regex.Match(password).Success, "密码必须由3-24个大小写字母、下划线、数字组成。");
        }

        /// <summary>
        /// 检查昵称
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns></returns>
        public static ValidateResult checkNickname(string nickname)
        {
            nickname.Trim();
            if (nickname.Length == 0)
            {
                return new ValidateResult(false, "你先把昵称填了吧");
            }
            if (nickname.IndexOf(" ") > -1)
            {
                return new ValidateResult(false, "昵称不能含有空格");
            }
            return new ValidateResult(true, "合法昵称");
        }


        public static string toMD5(string str)
        {
            string password = "";

            MD5 md5 = MD5.Create();

            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符
                password = password + s[i].ToString("X");
            }

            return password;
        }

    }
}
