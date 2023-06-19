using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDAL.Models
{
    public class EvtAlarmParams : BaseParameter
    {
        public string? machine_name { get; set; }
        public string? user_name { get; set; }
        public string? log_description { get; set; }
        public string? log_method { get; set; }
        public string? Property { get; set; }
        public object? FilterValue { get; set; } = string.Empty;

    }
}
