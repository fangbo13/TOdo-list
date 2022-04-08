using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoAppAPI.Models
{
    public class Result
    {
        public bool Success { get; set; }

        public string ResultCode { get; set; }

        public string ResultMsg { get; set; }

        public object ResultData { get; set; }
    }
}