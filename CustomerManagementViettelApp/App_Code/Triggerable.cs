﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementViettelApp.App_Code
{
    public interface Triggerable
    {
        void Trigger();

        void Trigger(string screen);
    }
}
