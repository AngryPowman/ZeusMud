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
        static ValidateResult checkEmail(string email)
        {
            Regex regex = new Regex("w+([-+.]w+)*@w+([-.]w+)*.w+([-.]w+)*");
            return new ValidateResult(regex.Match(email).Success, "邮箱地址不合法。");
        }

        static ValidateResult checkPassword(string password)
        {
            Regex regex = new Regex("^[a-zA-Z][a-zA-Z0-9_@#]{3,32}$");
            return new ValidateResult(regex.Match(password).Success, "密码必须由3-32个大小写字母、下划线、数字组成。");
        }
    }
}
