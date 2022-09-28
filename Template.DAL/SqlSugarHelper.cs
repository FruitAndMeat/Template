using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using Template.Models;

namespace Template.DAL
{
    /// <summary>sqlsugar配置类</summary>
    public static class SqlSugarHelper
    {


        /// <summary>
        /// sqlite数据库用。
        /// </summary>
        public static SqlSugarScope sqliteDb=new SqlSugarScope(new ConnectionConfig() {
            ConnectionString =$"Data Source={AppDomain.CurrentDomain.BaseDirectory }Data.db;Version=3;",
            DbType=DbType.Sqlite,
            IsAutoCloseConnection=true,
        }, db => {
            db.Aop.OnLogExecuting = (sql, pars) => {
                Console.WriteLine(sql);
            };
        });

        public static void CrateTable() {
            sqliteDb.DbMaintenance.CreateDatabase();
            sqliteDb.CodeFirst.InitTables<UserAccount>();
        }
    }
}
