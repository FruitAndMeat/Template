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
        /// <summary>点位ID </summary>
        [SqlSugar.SugarColumn(IsPrimaryKey =true)]
        public int Id { get; set; }
        /// <summary>点位名称</summary>
        [SqlSugar.SugarColumn(IsNullable =false)]
        public string PointName { get; set; }
        /// <summary>点位X轴坐标值</summary>
        [SqlSugar.SugarColumn(IsNullable = false)]
        public double XAxisPostion { get; set; }
        /// <summary>点位Y轴坐标值</summary>
        [SqlSugar.SugarColumn(IsNullable = false)]
        public double YAxisPostion { get; set; }
        /// <summary>点位Z轴坐标值</summary>
        [SqlSugar.SugarColumn(IsNullable = false)]
        public double ZAxisPostion { get; set; }

        //加减速时间，运动速度
    }
}
