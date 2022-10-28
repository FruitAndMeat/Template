using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using S7.Net;

namespace CommunicationLib
{
    public class SiemensPLC
    {
        #region Field&Property
        public bool IsConnected => _PLC?.IsConnected ?? false;
        //public List<Variable> Variables { get; set; } = new List<Variable>();

        
        private List<bool> bools = new List<bool>();

        private Plc _PLC;
        #endregion

        #region Initial And Connect、DisConnect Function
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="CpuType">CPU类型，如S71200,S71500,S7200</param>
        /// <param name="ip">PLC的IP地址</param>
        /// <param name="rack">PLC的导轨号</param>
        /// <param name="slot">PLC的插槽号</param>
        public void  Initial(CpuType CpuType,string ip, short rack, short slot)
        {
            _PLC = new Plc(CpuType, ip, rack, slot);
            //Variables = new List<Variable>();
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void UnInit()
        {
            (_PLC as IDisposable)?.Dispose();
            _PLC = null;
        }

        /// <summary>
        /// 异步连接方法
        /// </summary>
        /// <returns>连接的Task</returns>
        public async Task ConnectAsync(CancellationToken cancellationToken)
        {
            if (_PLC!=null)
            {
              await  _PLC.OpenAsync();
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            _PLC?.Close();
        }
        #endregion

        #region Read Variable Function
        public short ReadBool(string Address, ref bool value)
        {
            
            return 0;
        }

        #endregion

        #region InitialVariableList
       public void InitialList()
        {
            
        }

        #endregion
    }
}
