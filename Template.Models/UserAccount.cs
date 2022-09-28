using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Models.Enum;

namespace Template.Models
{
    /// <summary>
    /// 账户类
    /// </summary>
    public class UserAccount
    {
        /// <summary>
        /// 账户名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 账户密码，MD5加密生成
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 权限等级
        /// </summary>
        public Rank Rank { get; set; }

    }
}
