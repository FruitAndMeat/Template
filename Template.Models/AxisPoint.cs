using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Models
{
    /// <summary>
    /// 运行点位
    /// </summary>
    public class AxisPoint
    {
        
        private int _ID;
        /// <summary>点位ID </summary>
        [SqlSugar.SugarColumn(IsPrimaryKey = true)]
        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }


        
        private string _PointName;
        /// <summary>点位名称</summary>
        [SqlSugar.SugarColumn(IsNullable = false)]
        public string PointName {
            get { return _PointName; }
            set { _PointName = value; }
        }


        

        private double _XAxisPostion;
        /// <summary>点位X轴坐标值</summary>
        [SqlSugar.SugarColumn(IsNullable = false)]
        public double XAxisPostion {
            get { return _XAxisPostion; }
            set { _XAxisPostion = value; }
        }


        
        private double _YAxisPostion;
        /// <summary>点位Y轴坐标值</summary>
        [SqlSugar.SugarColumn(IsNullable = false)]
        public double YAxisPostion {
            get { return _YAxisPostion; }
            set { _YAxisPostion = value; }
        }


        
        private double _ZAxisPostion;
        /// <summary>点位Z轴坐标值</summary>
        [SqlSugar.SugarColumn(IsNullable = false)]
        public double ZAxisPostion {
            get { return _ZAxisPostion; }
            set { _ZAxisPostion = value; }
        }


        //加减速时间，运动速度
    }
}
