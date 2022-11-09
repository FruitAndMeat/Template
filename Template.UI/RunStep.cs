using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.UI
{
    /// <summary>运行步骤</summary>
    internal enum RunStep
    {
        /// <summary>准备运行</summary>
        RunReady,


        #region 取料位动作
        /// <summary>前往取料位</summary>
        MoveToReclaimer,
        /// <summary>取料位判断料是否存在</summary>
        ReclaimerWait,
        /// <summary>取料位Z轴下降</summary>
        ReclaimerDown,
        /// <summary>取料位抓料</summary>
        ReclaimerGrap,
        /// <summary>取料位Z轴上升</summary>
        ReclaimerUp,
        #endregion

        /// <summary>移动到扫码位</summary>
        MoveToScaner,
        /// <summary>触发扫码</summary>
        TriggerScan,

        #region 加工位 上下
        /// <summary>
        /// 前往加工位
        /// </summary>
        MoveToProcess,

        /// <summary>
        /// 加工位检测
        /// </summary>
        ProcessCheck,

        /// <summary>
        /// 加工位Z轴下降1
        /// </summary>
        ProcessDown1,

        /// <summary>
        /// 加工位放下物体
        /// </summary>
        ProcessPutDown,

        /// <summary>
        /// 加工位Z轴上升1
        /// </summary>
        ProcessUp1,

        /// <summary>
        /// 加工位等待
        /// </summary>
        ProcessWait,

        /// <summary>
        /// 加工位Z轴下降2
        /// </summary>
        ProcessDown2,

        /// <summary>
        /// 加工位抓取物体
        /// </summary>
        ProcessGrab,

        /// <summary>
        /// 加工位Z轴上升2
        /// </summary>
        ProcessUp2,
        #endregion

        /// <summary>去清洗位</summary>
        MoveToClean,
        /// <summary>
        /// 等待清洗
        /// </summary>
        WaitClean,

        #region 出料口
        /// <summary>
        /// 前往出料口
        /// </summary>
        MoveToOutlet,

        /// <summary>
        /// 出料口等待
        /// </summary>
        OutletWait,

        /// <summary>
        /// 出料口Z轴下降
        /// </summary>
        OutletDown,

        /// <summary>
        /// 出料位放下物体
        /// </summary>
        OutletPutDown,

        /// <summary>
        /// 出料位Z轴上升
        /// </summary>
        OutletUp,
        #endregion
    }
}
