using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public  class IniFileHelper
    {
        //声明Ini文件的写操作函数 WritePrivateProfileString()
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        //声明Ini文件的读操作函数 GetPrivateProfileString()
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retval, int size, string filepath);
        
        /// <summary>写入Ini的方法</summary>
        /// <param name="section">配置节点名称</param>
        /// <param name="key">键名</param>
        /// <param name="value">返回键值</param>
        /// <param name="path">路径</param>
        public void INIWrite(string section,string key,string value,string path)
        {
            WritePrivateProfileString(section, key, value, path);
        }

        /// <summary>从Ini文件根据键名读取值</summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public string INIRead(string section,string key,string path)
        {
            //每次从Ini文件读取多少字节
            System.Text.StringBuilder temp = new System.Text.StringBuilder(255);
            GetPrivateProfileString(section, key, "", temp, 255, path);
            return temp.ToString();
        }
        
    }
}
