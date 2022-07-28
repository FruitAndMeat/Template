using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLib
{
    public class Variable
    {
        public string Name { get; set; }
        public DataType DataType { get; set; }
        public string Address { get; set; }
        public string value { get; set; }
    }

    public enum DataType
    {
        Bool,
        Byte,
        Word,
        DWord,
        Int16,
        UInt16,
        Int32,
        UInt32,
        Float,
        Double
    }
}
