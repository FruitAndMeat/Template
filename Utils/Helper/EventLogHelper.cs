using System;
using System.Diagnostics;

namespace Utils
{
    // <summary>
    /// <para>　</para>
    /// 　常用工具类——系统日志类
    /// <para>　---------------------------------------------------</para>
    /// <para>　WriteEventLog：写入系统日志(２个方法重载)</para>
    /// <para>　DelEventName：删除日志事件源分类</para>
    /// </summary>
    public class EventLogHelper
    {
        #region 写入系统日志
        /// <summary>写入系统日志</summary>
        /// <param name="EventName">事件源名称</param>
        /// <param name="LogStr">日志内容</param>
        public static void WriteEventLog(string EventName, string LogStr)
        {
            try
            {
                if (!EventLog.SourceExists(EventName))
                {
                    EventLog.CreateEventSource(EventName, EventName);
                }
                EventLog.WriteEntry(EventName, LogStr);
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 写入系统日志
        /// </summary>
        /// <param name="EventName">事件源名称</param>
        /// <param name="LogType">日志类型</param>
        /// <param name="LogStr">日志内容</param>
        public static void WriteEventLog(string EventName, string LogStr, EventLogEntryType LogType)
        {
            try
            {
                if (!EventLog.SourceExists(EventName))
                {
                    EventLog.CreateEventSource(EventName, EventName);
                }
                EventLog.WriteEntry(EventName, LogStr, LogType);
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region 删除日志事件源分类
        /// <summary>
        /// 删除日志事件源分类
        /// </summary>
        /// <param name="EventName">事件源名</param>
        /// <returns></returns>
        public static bool DelEventName(string EventName)
        {
            bool flag = false;
            try
            {
                if (EventLog.SourceExists(EventName))
                {
                    EventLog.DeleteEventSource(EventName, ".");
                    flag = true;
                }
            }
            catch (Exception)
            {
            }
            return flag;
        }
        #endregion
    }
}
