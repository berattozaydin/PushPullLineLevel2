using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDAL.Models
{
    public class DelayDto : BaseParameter
    {
        public int ID { get; set; }
        public DateTime BEGIN_TIME { get; set; }
        public DateTime END_TIME { get; set; }
        public DateTime DURATION { get; set; }
        public int DELAY_REASON_CODE { get; set; }
        public int DELAY_GROUP_CODE { get; set; }
        public int DELAY_CLASS_CODE { get; set; }
        public int SHIFT_ID { get; set; }
        public bool WAS_SENT { get; set; }
        public bool IS_AUTO { get; set; }
        public string? ACCEPTED_BY { get; set; }
        public string? DELAY_REASON_NAME { get; set; }
        public string? REMARK { get; set; }
        public string? DELAY_GROUP_NAME { get; set; }
        public string? CREW { get; set; }
        public string? DELAY_CLASS_NAME { get; set; }
    }
}
