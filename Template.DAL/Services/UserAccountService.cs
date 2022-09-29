using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Template.Models;
using Utils;

namespace Template.DAL
{
    public class UserAccountService
    {
        /// <summary>
        /// 根据用户名检查是否有该用户。
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CheckUserName(UserAccount user) {
            try {
                bool result= SqlSugarHelper.sqliteDb.Queryable<UserAccount>()
                  .Any(t => t.Name == user.Name);
                return result;
            }
            catch (Exception ex) {
                LogHelper.LogError(ex);
                return false;
            }
        }
        /// <summary>
        /// 检查数据库该用户名密码是否正确。
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserAccount GetUser(UserAccount user) {
            try {
                return SqlSugarHelper.sqliteDb.Queryable<UserAccount>()
                  .First(t => t.Name == user.Name && t.Password==user.Password);
            }
            catch (Exception ex) {

                LogHelper.LogError(ex);
                return null;
            }
        }
    }
}
