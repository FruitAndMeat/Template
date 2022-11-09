using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.DAL;
using Template.Models;
using Utils;

namespace Template.UI
{
    public class Argument
    {
        /// <summary>用户信息</summary>
        public static UserAccount User { get; set; }

        /// <summary>机构执行PLC</summary>
        public static MotionService MotionPLC { get; set; }

        /// <summary>点位配置文件路径 </summary>
        private static string AxisPointFilePath { get { return $"{AppDomain.CurrentDomain.BaseDirectory}AxisPoint.json"; }}

        /// <summary>系统是否为自动模式。</summary>
        public  static bool AutoMode { get; set; }

        private static List<AxisPoint> points;
        /// <summary>点位集合</summary>
        public  static List<AxisPoint> Points {
            get {
                //if (points == null) {
                    points = JsonConvert.DeserializeObject<List<AxisPoint>>(FileHelper.ReadFile(AxisPointFilePath));
                //}
                return points; }
            set { points = value; 
                FileHelper.WriteFile(AxisPointFilePath, JsonConvert.SerializeObject(value,new JsonSerializerSettings() { 
                StringEscapeHandling=StringEscapeHandling.EscapeNonAscii
                }));
            }
        }

        internal    static RunStep CurrentRunStep { get; set; }

    }
}
