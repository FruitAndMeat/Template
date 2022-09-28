using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Models.Enum
{
    /// <summary>
    /// 用户权限
    /// </summary>
    public enum Rank
    {
        /// <summary>
        /// 操作员
        /// </summary>
        Operator,
        /// <summary>
        /// 调试员
        /// </summary>
        Adjustor,
        /// <summary>
        /// 工程师
        /// </summary>
        Engineer,
        /// <summary>
        /// 管理员
        /// </summary>
        Admin
    }
}
