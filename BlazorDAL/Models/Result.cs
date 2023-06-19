using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDAL.Models
{
    public class Result
    {

        public int? isSuccess { get; set; }
        public string? msg { get; set; }
        public string? token { get; set; }
        public string? email { get; set; }
        public string? username { get; set; }

        public DateTime? expires { get; set; }
        public int? id { get; set; }
        public string? name { get; set; }
        public string? lastName { get; set; }
        public int? role { get; set; }
    }
    public class Response
    {
        public Result Result { get; set; }
    }
}
