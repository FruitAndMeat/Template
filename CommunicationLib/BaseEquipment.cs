﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLib
{
    public abstract class BaseEquipment
    {
        public bool IsConnected { get; set; }


        public abstract void Send();
    }
}
