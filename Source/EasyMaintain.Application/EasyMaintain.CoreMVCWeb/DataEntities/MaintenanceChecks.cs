﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMaintain.CoreWebMVC.DataEntities
{
    public class MaintenanceChecks
    {

        public int MaintenanceCheckID { get; set; }
        public string Description { get; set; }
        public bool status { get; set; }

    }
}
