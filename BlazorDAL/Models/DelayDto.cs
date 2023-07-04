using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDAL.Models
{
    public class DelayDto : BaseParameter
    {
        public int delay_id { get; set; }
        public int delay_group_code { get; set; }
        public int delay_reason_code { get; set; }
        public int delay_class_code { get; set; }
        public string delay_group_name { get; set; }
        public string delay_reason_name { get; set; }
        public string delay_class_name { get; set; }
        public int duration { get; set; }
        public int shift_id { get; set; }
        public string accept_by { get; set; }
        public DateTime begin_date { get; set; }
        public DateTime end_date { get; set; }
        public string remark { get; set; }


    }
}
