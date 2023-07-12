using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDAL.Models
{
    public class PdiDto
    {
        public int ID { get; set; }
        public int? IN_DIA { get; set; }
        public int? OUT_DIA { get; set; }
        public int? OIL_CODE { get; set; }
        public int? OIL_WEIGHT { get; set; }
        public int? OIL_TYPE { get; set; }
        public short? THICKNESS { get; set; }
        public int? WIDTH { get; set; }
        public int? LENGTH { get; set; }
        public string EN_COIL_ID { get; set; }
        public string? REMARK { get; set; }
        public string? PRD_TYPE { get; set; }
        public string? EXPO_DOM { get; set; }
        public string? SPECIAL_INSTRUCTION { get; set; }
    }
}
