using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDAL.Models
{
    public class EvtAlarmParams : BaseParameter
    {
        public int SEVERITY { get; set; }
        public int KIND { get; set; }
        public DateTime DATI { get; set; }
        public string? USER_NAME { get; set; }
        public string? METHOD_NAME { get; set; }
        public string? CLASS_NAME { get; set; }
        public string? USER_MSG { get; set; }
        public string? SYS_MSG { get; set; }
        public string? Property { get; set; }
        public object? FilterValue { get; set; } = string.Empty;

    }
}
