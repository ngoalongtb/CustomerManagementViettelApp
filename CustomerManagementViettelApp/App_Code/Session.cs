﻿using CustomerManagementViettelApp.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementViettelApp.App_Code
{
    public class Session
    {
        public static TaiKhoan LoginAccount { get; set; }
        public static TaiKhoan TaiKhoanQLDV { get; set; }

        public static HopDong HopDong { get; set; }
    }
}
