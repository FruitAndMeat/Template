using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Models
{
    public class AxisInfo {
        public int ID { get; set; }
        #region 1区
        /// <summary>使能</summary>
        public bool Enable { get; set; }
        /// <summary>错误</summary>
        public bool Error { get; set; }
        /// <summary>原点已回归</summary>
        public bool Homed { get; set; }
        /// <summary>动作完成</summary>
        public bool Done { get; set; }
        /// <summary>正限位</summary>
        public bool MaxLimited { get; set; }
        /// <summary>负限位</summary>
        public bool MinLimited { get; set; }
        #endregion

        #region 3区
        /// <summary>当前速度</summary>
        public double CurrentSpeed { get; set; }
        /// <summary>当前位置</summary>
        public double CurrentPostion { get; set; }

        /// <summary>错误码</summary>
        public uint ErrorId { get; set; }
        #endregion

        /// <summary>
        /// 目的位置
        /// </summary>
        public double DestPostion { get; set; }

    }

   
}
