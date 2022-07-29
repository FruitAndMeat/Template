using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLib
{
    public class Variable
    {
        /// <summary>变量名称</summary>
        public string Name { get; set; }
        /// <summary>数据类型</summary>
        public DataType DataType { get; set; }
        /// <summary>地址</summary>
        public string Address { get; set; }
        /// <summary>值</summary>
        public string Value { get; set; }
        /// <summary>时间戳</summary>
        public DateTime TimeStmap { get; set; }
    }

    /// <summary>
    /// 对应PLC的数据类型。
    /// </summary>
    public enum DataType
    {
        /// <summary>位类型</summary>
        Bool,
        /// <summary>字节类型</summary>
        Byte,
        /// <summary>字类型</summary>
        Word,
        /// <summary>双字类型</summary>
        DWord,
        /// <summary>16位有符号整数</summary>
        Int16,
        /// <summary>16位无符号整数</summary>
        UInt16,
        /// <summary>32位有符号整数</summary>
        Int32,
        /// <summary>32位无符号整数</summary>
        UInt32,
        /// <summary>32位单精度浮点数</summary>
        Float,
        /// <summary>64位双精度浮点数</summary>
        Double,
        /// <summary>字符串类型，字符串存储地址的前两个字节是字符串的长度信息</summary>
        String
    }
}
