using System;
using System.Collections.Generic;
using System.Linq;
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
        public static ValidateResult checkEmail(string email)
        {
            email.Trim();
            if (email.Length == 0)
            {
                return new ValidateResult(false, "你先把邮箱填了吧");
            }
            if (email.IndexOf(" ") > 0)
            {
                return new ValidateResult(false, "邮箱不能含有空格");
            }
            Regex regex = new Regex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
            return new ValidateResult(regex.Match(email).Success, "邮箱地址不合法。");
        }

        public static ValidateResult checkPassword(string password)
        {
            if (password.Length == 0)
            {
                return new ValidateResult(false, "你先把密码填了吧");
            }
            if (password.IndexOf(" ") > 0)
            {
                return new ValidateResult(false, "密码不能含有空格");
            }
            Regex regex = new Regex("^[a-zA-Z][a-zA-Z0-9_@#]{3,32}$");
            return new ValidateResult(regex.Match(password).Success, "密码必须由3-32个大小写字母、下划线、数字组成。");
        }

        public static ValidateResult checkNickname(string nickname)
        {
            nickname.Trim();
            if (nickname.Length == 0)
            {
                return new ValidateResult(false, "你先把昵称填了吧");
            }
            if (nickname.IndexOf(" ") > 0)
            {
                return new ValidateResult(false, "昵称不能含有空格");
            }
            return new ValidateResult(true, "合法昵称");
        }
    }
}
