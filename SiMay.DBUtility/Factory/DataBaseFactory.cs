﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiMay.DBUtility.Interface;

namespace SiMay.DBUtility.Factory
{
    public class DataBaseFactory
    {
        public static string SQLConnectionString { get; private set; } = ConfigurationSettings.AppSettings["SqlConnection"].ToString();

        public static IDataBaseHelper GetDataBaseHelperInstance()
        {
            return new MySqlDBHelper(SQLConnectionString);
        }
    }
}
