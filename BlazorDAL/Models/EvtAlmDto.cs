using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDAL.Models
{
    public class EvtAlmDto : BaseParameter
    {
        public int? event_alarm_id { get; set; }
        public string? machine_name { get; set; }
        public string? user_name { get; set; }
        public string? log_description { get; set; }
        public string? log_method { get; set; }
        public DateTime? dati { get; set; }
    }
}
