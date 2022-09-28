using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.DAL;
using Template.Models;
using Utils;

namespace Template.BLL
{
    public class UserManage
    {
        public string CheckUser(string userName,string password) {
            //封装对象
            UserAccount objuser=new UserAccount() {
                Name=userName,
                Password=password
            };
            if (new UserAccountService().GetUser(objuser)!=null) {
                LogHelper.LogInfo($"用户[{objuser.Name}]登录");
                return "登录成功";
            }
            else {
                return "登录失败";
            }
        }
    }
}
