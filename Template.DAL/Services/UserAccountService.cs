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
        /// 检查是否有该用户名
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> CheckUserNameAsync(UserAccount user) {
            try {
                return await SqlSugarHelper.sqliteDb.Queryable<UserAccount>()
                  .AnyAsync(t => t.Name == user.Name);
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
        public async Task<UserAccount> GetUserAsync(UserAccount user) {
            try {
                return await SqlSugarHelper.sqliteDb.Queryable<UserAccount>()
                  .FirstAsync(t => t.Name == user.Name && t.Password==user.Password);
            }
            catch (Exception ex) {

                LogHelper.LogError(ex);
                return null;
            }
        }
    }
}
