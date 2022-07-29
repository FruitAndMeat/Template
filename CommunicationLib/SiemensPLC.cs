using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Net;

namespace CommunicationLib
{
    public class SiemensPLC
    {

        public bool IsConnected => _PLC?.IsConnected ?? false;
        private Plc _PLC;

        public SiemensPLC(CpuType CpuType,string ip, short rack, short slot)
        {
            _PLC = new Plc(CpuType, ip, rack, slot);
        }

        public async Task ConnectAsync()
        {
            if (_PLC!=null)
            {
              await  _PLC.OpenAsync();
            }
        }

        public void Close()
        {
            _PLC?.Close();
        }
    }
}
