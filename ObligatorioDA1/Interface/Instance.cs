﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;


namespace Interface
{
    internal class Instance
    {
        public static ClientLogic InstanceClientLogic { get; } = new ClientLogic();



    }
}
