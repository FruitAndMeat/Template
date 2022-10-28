using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Models
{
    /// <summary>
    /// 布尔变量类
    /// </summary>
    public class Variable
    {
        private bool _value;
        /// <summary>
        /// 变量当前值
        /// </summary>
        public bool Value {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>上升沿</summary>
        public bool Posedge { get;private set; }
        /// <summary>下降沿 </summary>
        public bool Negedge { get;private set; }
    }
}
