﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMaintain.DataAccess;
using EasyMaintain.DataAccess.Models;

namespace EntityDBGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            DataProvidor dp = new DataProvidor();
            dp.AddEngineType(1, "Test");
        }
    }
}