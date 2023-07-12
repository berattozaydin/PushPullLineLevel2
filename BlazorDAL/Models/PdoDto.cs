using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDAL.Models
{
    public class PdoDto
    {
        public DateTime? WEI_DATI { get; set; }
        public int? OUT_DIA { get; set; }
        public int? IN_DIA { get; set; }
        public int ID { get; set; }
        public DateTime PRD_DATI { get; set; }
        public int SHIFT_ID { get; set; }
        public int? PRD_WIDTH { get; set; }
        public short? PRD_THICK { get; set; }
        public int? PRD_WEIGHT { get; set; }
        public int? CALC_WEIGHT { get; set; }
        public int? SCRAP_WEIGHT { get; set; }
        public int? PRD_LENGTH { get; set; }
        public string EX_COIL_ID { get; set; }
        public string? CREW { get; set; }
        public string? EN_COIL_ID { get; set; }
        public float? OIL_AMOUNT { get; set; }
       
    }
}
