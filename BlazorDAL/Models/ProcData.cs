using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDAL.Models
{
    public class ProcDataDto
    {
        public int ID { get; set; }
        public int LINE_SPEED { get; set; }
        public short T1_ACID_COND { get; set; }
        public int T1_TEMP { get; set; }
        public int T2_TEMP { get; set; }
        public int T3_TEMP { get; set; }
        public short RINSE_COND { get; set; }
        public int RINSE_TEMP { get; set; }
        public int POR_TEN { get; set; }
        public int TR_TEN { get; set; }

    }
}
