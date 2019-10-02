using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace HelperRepository
{
    public class HelperConfiguration
    {
        //public string ConnectionString => ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        //public string Database => ConfigurationManager.AppSettings["Database"].ToString();

        public string ConnectionString { get; set; }

        public string Database { get; set; }
    }
}
