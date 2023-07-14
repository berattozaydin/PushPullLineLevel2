using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace BlazorDAL
{
    public class Record<T> : INotifyPropertyChanged where T : new()
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                MarkColumnModified(propertyName);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [Ignore]
        [JsonIgnore]
        public List<string> ModifiedColumns { get; set; } = new List<string>();

        //[Ignore]
        //[JsonIgnore]
        //public Dictionary<string, bool> ModifiedColumns { get; set; } = new Dictionary<string, bool>();

        protected void MarkColumnModified([CallerMemberName] string column_name = null)
        {
            //if (ModifiedColumns != null)
            //    ModifiedColumns[column_name] = true;

            if (!ModifiedColumns.Exists(item => item == column_name))
            {
                ModifiedColumns.Add(column_name);
            }
        }

        private void OnLoaded()
        {

            if (ModifiedColumns == null)
            {
                ModifiedColumns = new List<string>();
            }
            else
            {
                ModifiedColumns.Clear();
            }
        }
    }

    //CINARCELIK_MODELS LEVEL2

    [TableName("dbo.pdi")]
    [PrimaryKey("id", AutoIncrement = true)]
    [ExplicitColumns]
    public class PDI : Record<PDI>
    {
        [ResultColumn(IncludeInAutoSelect.Yes)]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private int _ID;

        [Column]
        public int? IN_DIA
        {
            get { return _IN_DIA; }
            set { _IN_DIA = value; OnPropertyChanged(); }
        }
        private int? _IN_DIA;

        [Column]
        public int? OUT_DIA
        {
            get { return _OUT_DIA; }
            set { _OUT_DIA = value; OnPropertyChanged(); }
        }
        private int? _OUT_DIA;

        [Column]
        public int? OIL_CODE
        {
            get { return _OIL_CODE; }
            set { _OIL_CODE = value; OnPropertyChanged(); }
        }
        private int? _OIL_CODE;

        [Column]
        public int? OIL_WEIGHT
        {
            get { return _OIL_WEIGHT; }
            set { _OIL_WEIGHT = value; OnPropertyChanged(); }
        }
        private int? _OIL_WEIGHT;

        [Column]
        public int? OIL_TYPE
        {
            get { return _OIL_TYPE; }
            set { _OIL_TYPE = value; OnPropertyChanged(); }
        }
        private int? _OIL_TYPE;

        [Column]
        public short? THICKNESS
        {
            get { return _THICKNESS; }
            set { _THICKNESS = value; OnPropertyChanged(); }
        }
        private short? _THICKNESS;

        [Column]
        public int? WIDTH
        {
            get { return _WIDTH; }
            set { _WIDTH = value; OnPropertyChanged(); }
        }
        private int? _WIDTH;

        [Column("length")]
        public int? LENGTH
        {
            get { return _LENGTH; }
            set { _LENGTH = value; OnPropertyChanged(); }
        }
        private int? _LENGTH;

        [Column]
        public string EN_COIL_ID
        {
            get { return _EN_COIL_ID; }
            set { _EN_COIL_ID = value; OnPropertyChanged(); }
        }
        private string _EN_COIL_ID;

        [Column]
        public string? REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; OnPropertyChanged(); }
        }
        private string? _REMARK;

        [Column]
        public string? PRD_TYPE
        {
            get { return _PRD_TYPE; }
            set { _PRD_TYPE = value; OnPropertyChanged(); }
        }
        private string? _PRD_TYPE;

        [Column]
        public string? EXPO_DOM
        {
            get { return _EXPO_DOM; }
            set { _EXPO_DOM = value; OnPropertyChanged(); }
        }
        private string? _EXPO_DOM;

        [Column]
        public string? SPECIAL_INSTRUCTION
        {
            get { return _SPECIAL_INSTRUCTION; }
            set { _SPECIAL_INSTRUCTION = value; OnPropertyChanged(); }
        }
        private string? _SPECIAL_INSTRUCTION;
    }
    [TableName("dbo.pdo")]
    [PrimaryKey("id", AutoIncrement = true)]
    [ExplicitColumns]
    public class PDO : Record<PDO>
    {
        [Column]
        public DateTime? WEI_DATI
        {
            get { return _WEI_DATI; }
            set { _WEI_DATI = value; OnPropertyChanged(); }
        }
        private DateTime? _WEI_DATI;

        [Column]
        public int? OUT_DIA
        {
            get { return _OUT_DIA; }
            set { _OUT_DIA = value; OnPropertyChanged(); }
        }
        private int? _OUT_DIA;

        [Column]
        public int? IN_DIA
        {
            get { return _IN_DIA; }
            set { _IN_DIA = value; OnPropertyChanged(); }
        }
        private int? _IN_DIA;

        [ResultColumn(IncludeInAutoSelect.Yes)]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private int _ID;

        [Column]
        public DateTime PRD_DATI
        {
            get { return _PRD_DATI; }
            set { _PRD_DATI = value; OnPropertyChanged(); }
        }
        private DateTime _PRD_DATI;

        [Column]
        public int SHIFT_ID
        {
            get { return _SHIFT_ID; }
            set { _SHIFT_ID = value; OnPropertyChanged(); }
        }
        private int _SHIFT_ID;

        [Column]
        public int? PRD_WIDTH
        {
            get { return _PRD_WIDTH; }
            set { _PRD_WIDTH = value; OnPropertyChanged(); }
        }
        private int? _PRD_WIDTH;

        [Column]
        public short? PRD_THICK
        {
            get { return _PRD_THICK; }
            set { _PRD_THICK = value; OnPropertyChanged(); }
        }
        private short? _PRD_THICK;

        [Column]
        public int? PRD_WEIGHT
        {
            get { return _PRD_WEIGHT; }
            set { _PRD_WEIGHT = value; OnPropertyChanged(); }
        }
        private int? _PRD_WEIGHT;

        [Column]
        public int? CALC_WEIGHT
        {
            get { return _CALC_WEIGHT; }
            set { _CALC_WEIGHT = value; OnPropertyChanged(); }
        }
        private int? _CALC_WEIGHT;

        [Column]
        public int? SCRAP_WEIGHT
        {
            get { return _SCRAP_WEIGHT; }
            set { _SCRAP_WEIGHT = value; OnPropertyChanged(); }
        }
        private int? _SCRAP_WEIGHT;

        [Column]
        public int? PRD_LENGTH
        {
            get { return _PRD_LENGTH; }
            set { _PRD_LENGTH = value; OnPropertyChanged(); }
        }
        private int? _PRD_LENGTH;

        [Column]
        public string EX_COIL_ID
        {
            get { return _EX_COIL_ID; }
            set { _EX_COIL_ID = value; OnPropertyChanged(); }
        }
        private string _EX_COIL_ID;

        [Column]
        public string? CREW
        {
            get { return _CREW; }
            set { _CREW = value; OnPropertyChanged(); }
        }
        private string? _CREW;

        [Column]
        public string? EN_COIL_ID
        {
            get { return _EN_COIL_ID; }
            set { _EN_COIL_ID = value; OnPropertyChanged(); }
        }
        private string? _EN_COIL_ID;

        [Column]
        public float? OIL_AMOUNT
        {
            get { return _OIL_AMOUNT; }
            set { _OIL_AMOUNT = value; OnPropertyChanged(); }
        }
        private float? _OIL_AMOUNT;
    }

    [TableName("dbo.ctrpos")]
    [PrimaryKey("id", AutoIncrement = true)]
    [ExplicitColumns]
    public class CTRPOS : Record<CTRPOS>
    {
        [ResultColumn(IncludeInAutoSelect.Yes)]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private int _ID;

        [Column]
        public int ZONE_ID
        {
            get { return _ZONE_ID; }
            set { _ZONE_ID = value; OnPropertyChanged(); }
        }
        private int _ZONE_ID;

        [Column]
        public int DISTANCE
        {
            get { return _DISTANCE; }
            set { _DISTANCE = value; OnPropertyChanged(); }
        }
        private int _DISTANCE;

        [Column]
        public string ZONE_NAME
        {
            get { return _ZONE_NAME; }
            set { _ZONE_NAME = value; OnPropertyChanged(); }
        }
        private string _ZONE_NAME;

    }
    [TableName("dbo.delay_class")]
    [PrimaryKey("id", AutoIncrement = true)]
    [ExplicitColumns]
    public class DELAY_CLASS : Record<DELAY_CLASS>
    {
        [Column]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private int _ID;

        [Column]
        public int CODE
        {
            get { return _CODE; }
            set { _CODE = value; OnPropertyChanged(); }
        }
        private int _CODE;

        [Column]
        public string? NAME
        {
            get { return _NAME; }
            set { _NAME = value; OnPropertyChanged(); }
        }
        private string? _NAME;

        [Column]
        public string? DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set { _DESCRIPTION = value; OnPropertyChanged(); }
        }
        private string? _DESCRIPTION;

        [Column]
        public string DESCRIPTION_TR
        {
            get { return _DESCRIPTION_TR; }
            set { _DESCRIPTION_TR = value; OnPropertyChanged(); }
        }
        private string _DESCRIPTION_TR;


    }
    [TableName("delay_data")]
    [PrimaryKey("id", AutoIncrement = true)]
    [ExplicitColumns]
    public class DELAY_DATA : Record<DELAY_DATA>
    {
        [Column]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private int _ID;

        [Column]
        public DateTime BEGIN_TIME
        {
            get { return _BEGIN_TIME; }
            set { _BEGIN_TIME = value; OnPropertyChanged(); }
        }
        private DateTime _BEGIN_TIME;

        [Column]
        public DateTime END_TIME
        {
            get { return _END_TIME; }
            set { _END_TIME = value; OnPropertyChanged(); }
        }
        private DateTime _END_TIME;

        [Column]
        public DateTime DURATION
        {
            get { return _DURATION; }
            set { _DURATION = value; OnPropertyChanged(); }
        }
        private DateTime _DURATION;

        [Column]
        public int DELAY_REASON_CODE
        {
            get { return _DELAY_REASON_CODE; }
            set { _DELAY_REASON_CODE = value; OnPropertyChanged(); }
        }
        private int _DELAY_REASON_CODE;

        [Column]
        public int DELAY_GROUP_CODE
        {
            get { return _DELAY_GROUP_CODE; }
            set { _DELAY_GROUP_CODE = value; OnPropertyChanged(); }
        }
        private int _DELAY_GROUP_CODE;

        [Column]
        public int DELAY_CLASS_CODE
        {
            get { return _DELAY_CLASS_CODE; }
            set { _DELAY_CLASS_CODE = value; OnPropertyChanged(); }
        }
        private int _DELAY_CLASS_CODE;

        [Column]
        public int SHIFT_ID
        {
            get { return _SHIFT_ID; }
            set { _SHIFT_ID = value; OnPropertyChanged(); }
        }
        private int _SHIFT_ID;

        [Column]
        public bool WAS_SENT
        {
            get { return _WAS_SENT; }
            set { _WAS_SENT = value; OnPropertyChanged(); }
        }
        private bool _WAS_SENT;

        [Column]
        public bool IS_AUTO
        {
            get { return _IS_AUTO; }
            set { _IS_AUTO = value; OnPropertyChanged(); }
        }
        private bool _IS_AUTO;

        [Column]
        public string? ACCEPTED_BY
        {
            get { return _ACCEPTED_BY; }
            set { _ACCEPTED_BY = value; OnPropertyChanged(); }
        }
        private string? _ACCEPTED_BY;

        [Column]
        public string? DELAY_REASON_NAME
        {
            get { return _DELAY_REASON_NAME; }
            set { _DELAY_REASON_NAME = value; OnPropertyChanged(); }
        }
        private string? _DELAY_REASON_NAME;

        [Column]
        public string? REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; OnPropertyChanged(); }
        }
        private string? _REMARK;

        [Column]
        public string? DELAY_GROUP_NAME
        {
            get { return _DELAY_GROUP_NAME; }
            set { _DELAY_GROUP_NAME = value; OnPropertyChanged(); }
        }
        private string? _DELAY_GROUP_NAME;

        [Column]
        public string? CREW
        {
            get { return _CREW; }
            set { _CREW = value; OnPropertyChanged(); }
        }
        private string? _CREW;

        [Column]
        public string? DELAY_CLASS_NAME
        {
            get { return _DELAY_CLASS_NAME; }
            set { _DELAY_CLASS_NAME = value; OnPropertyChanged(); }
        }
        private string? _DELAY_CLASS_NAME;
    }

    [TableName("delay_group")]
    [PrimaryKey("id",AutoIncrement =true)]
    [ExplicitColumns]
    public class DELAY_GROUP : Record<DELAY_GROUP>
    {
        [Column]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private int _ID;

        [Column]
        public int CODE
        {
            get { return _CODE; }
            set { _CODE = value; OnPropertyChanged(); }
        }
        private int _CODE;

        [Column]
        public int DELAY_CLASS_CODE
        {
            get { return _DELAY_CLASS_CODE; }
            set { _DELAY_CLASS_CODE = value; OnPropertyChanged(); }
        }
        private int _DELAY_CLASS_CODE;

        [Column]
        public string? NAME
        {
            get { return _NAME; }
            set { _NAME = value; OnPropertyChanged(); }
        }
        private string? _NAME;

        [Column]
        public string? DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set { _DESCRIPTION = value; OnPropertyChanged(); }
        }
        private string? _DESCRIPTION;

        [Column]
        public string DESCRIPTION_TR
        {
            get { return _DESCRIPTION_TR; }
            set { _DESCRIPTION_TR = value; OnPropertyChanged(); }
        }
        private string _DESCRIPTION_TR;

    }

    [TableName("evtalm")]
    [PrimaryKey("id", AutoIncrement = true)]
    [ExplicitColumns]
    public class EVTALM : Record<EVTALM>
    {

        [ResultColumn(IncludeInAutoSelect.Yes)]
        public long ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private long _ID;

        [Column]
        public int LINE_NUMBER
        {
            get { return _LINE_NUMBER; }
            set { _LINE_NUMBER = value; OnPropertyChanged(); }
        }
        private int _LINE_NUMBER;

        [Column]
        public int SEVERITY
        {
            get { return _SEVERITY; }
            set { _SEVERITY = value; OnPropertyChanged(); }
        }
        private int _SEVERITY;

        [Column]
        public int KIND
        {
            get { return _KIND; }
            set { _KIND = value; OnPropertyChanged(); }
        }
        private int _KIND;

        [Column]
        public DateTime DATI
        {
            get { return _DATI; }
            set { _DATI = value; OnPropertyChanged(); }
        }
        private DateTime _DATI;

        [Column]
        public string? USER_NAME
        {
            get { return _USER_NAME; }
            set { _USER_NAME = value; OnPropertyChanged(); }
        }
        private string? _USER_NAME;

        [Column]
        public string? METHOD_NAME
        {
            get { return _METHOD_NAME; }
            set { _METHOD_NAME = value; OnPropertyChanged(); }
        }
        private string? _METHOD_NAME;

        [Column]
        public string? CLASS_NAME
        {
            get { return _CLASS_NAME; }
            set { _CLASS_NAME = value; OnPropertyChanged(); }
        }
        private string? _CLASS_NAME;

        [Column]
        public string? USER_MSG
        {
            get { return _USER_MSG; }
            set { _USER_MSG = value; OnPropertyChanged(); }
        }
        private string? _USER_MSG;

        [Column]
        public string? SYS_MSG
        {
            get { return _SYS_MSG; }
            set { _SYS_MSG = value; OnPropertyChanged(); }
        }
        private string? _SYS_MSG;

    }


    [TableName("dbo.gmc_data")]
    [ExplicitColumns]
    public class GMC_DATA : Record<GMC_DATA>
    {

        [Column]
        public int? IN_DIA
        {
            get { return _IN_DIA; }
            set { _IN_DIA = value; OnPropertyChanged(); }
        }
        private int? _IN_DIA;

        [Column]
        public int? OUT_DIA
        {
            get { return _OUT_DIA; }
            set { _OUT_DIA = value; OnPropertyChanged(); }
        }
        private int? _OUT_DIA;

        [Column]
        public int? WIDTH
        {
            get { return _WIDTH; }
            set { _WIDTH = value; OnPropertyChanged(); }
        }
        private int? _WIDTH;

        [ResultColumn(IncludeInAutoSelect.Yes)]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private int _ID;

        [Column]
        public int? COIL_LENGTH
        {
            get { return _COIL_LENGTH; }
            set { _COIL_LENGTH = value; OnPropertyChanged(); }
        }
        private int? _COIL_LENGTH;

        [Column]
        public short? THICKNESS
        {
            get { return _THICKNESS; }
            set { _THICKNESS = value; OnPropertyChanged(); }
        }
        private short? _THICKNESS;

        [Column]
        public DateTime? POR_CHARGE_DATI
        {
            get { return _POR_CHARGE_DATI; }
            set { _POR_CHARGE_DATI = value; OnPropertyChanged(); }
        }
        private DateTime? _POR_CHARGE_DATI;

        [Column]
        public string? SPECIAL_INSTRUCTION
        {
            get { return _SPECIAL_INSTRUCTION; }
            set { _SPECIAL_INSTRUCTION = value; OnPropertyChanged(); }
        }
        private string? _SPECIAL_INSTRUCTION;

        [Column]
        public string? EN_COIL_ID
        {
            get { return _EN_COIL_ID; }
            set { _EN_COIL_ID = value; OnPropertyChanged(); }
        }
        private string? _EN_COIL_ID;

        [Column]
        public string? GRADE
        {
            get { return _GRADE; }
            set { _GRADE = value; OnPropertyChanged(); }
        }
        private string? _GRADE;

        [Column]
        public string? PRD_TYPE
        {
            get { return _PRD_TYPE; }
            set { _PRD_TYPE = value; OnPropertyChanged(); }
        }
        private string? _PRD_TYPE;

    }
    [TableName("dbo.mnt_data")]
    [ExplicitColumns]
    public class MNT_DATA : Record<MNT_DATA>
    {

        [Column]
        public DateTime? REPLACE_DATI
        {
            get { return _REPLACE_DATI; }
            set { _REPLACE_DATI = value; OnPropertyChanged(); }
        }
        private DateTime? _REPLACE_DATI;

        [Column]
        public bool? WARNING_LEVEL
        {
            get { return _WARNING_LEVEL; }
            set { _WARNING_LEVEL = value; OnPropertyChanged(); }
        }
        private bool? _WARNING_LEVEL;

        [Column]
        public DateTime? INSTALL_DATI
        {
            get { return _INSTALL_DATI; }
            set { _INSTALL_DATI = value; OnPropertyChanged(); }
        }
        private DateTime? _INSTALL_DATI;

        [Column]
        public int? ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private int? _ID;

        [Column]
        public int? LIFE
        {
            get { return _LIFE; }
            set { _LIFE = value; OnPropertyChanged(); }
        }
        private int? _LIFE;

        [Column]
        public int? CURRENT_LIFE
        {
            get { return _CURRENT_LIFE; }
            set { _CURRENT_LIFE = value; OnPropertyChanged(); }
        }
        private int? _CURRENT_LIFE;

        [Column]
        public int? WARNING_LIMIT
        {
            get { return _WARNING_LIMIT; }
            set { _WARNING_LIMIT = value; OnPropertyChanged(); }
        }
        private int? _WARNING_LIMIT;

        [Column]
        public int? RATE
        {
            get { return _RATE; }
            set { _RATE = value; OnPropertyChanged(); }
        }
        private int? _RATE;

        [Column]
        public string? EQUIPMENT_NAME
        {
            get { return _EQUIPMENT_NAME; }
            set { _EQUIPMENT_NAME = value; OnPropertyChanged(); }
        }
        private string? _EQUIPMENT_NAME;

        [Column]
        public string? UNIT
        {
            get { return _UNIT; }
            set { _UNIT = value; OnPropertyChanged(); }
        }
        private string? _UNIT;

        [Column]
        public string? REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; OnPropertyChanged(); }
        }
        private string? _REMARK;

    }
    [TableName("dbo.proc_data")]
    [ExplicitColumns]
    public class PROC_DATA : Record<PROC_DATA>
    {

        [ResultColumn(IncludeInAutoSelect.Yes)]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private int _ID;

        [Column]
        public int LINE_SPEED
        {
            get { return _LINE_SPEED; }
            set { _LINE_SPEED = value; OnPropertyChanged(); }
        }
        private int _LINE_SPEED;

        [Column]
        public short T1_ACID_COND
        {
            get { return _T1_ACID_COND; }
            set { _T1_ACID_COND = value; OnPropertyChanged(); }
        }
        private short _T1_ACID_COND;

        [Column]
        public int T1_TEMP
        {
            get { return _T1_TEMP; }
            set { _T1_TEMP = value; OnPropertyChanged(); }
        }
        private int _T1_TEMP;

        [Column]
        public int T2_TEMP
        {
            get { return _T2_TEMP; }
            set { _T2_TEMP = value; OnPropertyChanged(); }
        }
        private int _T2_TEMP;

        [Column]
        public int T3_TEMP
        {
            get { return _T3_TEMP; }
            set { _T3_TEMP = value; OnPropertyChanged(); }
        }
        private int _T3_TEMP;

        [Column]
        public short RINSE_COND
        {
            get { return _RINSE_COND; }
            set { _RINSE_COND = value; OnPropertyChanged(); }
        }
        private short _RINSE_COND;

        [Column]
        public int RINSE_TEMP
        {
            get { return _RINSE_TEMP; }
            set { _RINSE_TEMP = value; OnPropertyChanged(); }
        }
        private int _RINSE_TEMP;

        [Column]
        public int POR_TEN
        {
            get { return _POR_TEN; }
            set { _POR_TEN = value; OnPropertyChanged(); }
        }
        private int _POR_TEN;

        [Column]
        public int TR_TEN
        {
            get { return _TR_TEN; }
            set { _TR_TEN = value; OnPropertyChanged(); }
        }
        private int _TR_TEN;

    }
    [TableName("dbo.qcs_coil_data_pdi")]
    [ExplicitColumns]
    public class QCS_COIL_DATA_PDI : Record<QCS_COIL_DATA_PDI>
    {

        [Column]
        public object? SAMPLE_DATA
        {
            get { return _SAMPLE_DATA; }
            set { _SAMPLE_DATA = value; OnPropertyChanged(); }
        }
        private object? _SAMPLE_DATA;

        [Column]
        public DateTime DATI
        {
            get { return _DATI; }
            set { _DATI = value; OnPropertyChanged(); }
        }
        private DateTime _DATI;

        [Column]
        public bool? HIST_FLAG
        {
            get { return _HIST_FLAG; }
            set { _HIST_FLAG = value; OnPropertyChanged(); }
        }
        private bool? _HIST_FLAG;

        [ResultColumn(IncludeInAutoSelect.Yes)]
        public long ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private long _ID;

        [Column]
        public int SAMPLE_DISTANCE
        {
            get { return _SAMPLE_DISTANCE; }
            set { _SAMPLE_DISTANCE = value; OnPropertyChanged(); }
        }
        private int _SAMPLE_DISTANCE;

        [Column]
        public int SAMPLE_NUMBER
        {
            get { return _SAMPLE_NUMBER; }
            set { _SAMPLE_NUMBER = value; OnPropertyChanged(); }
        }
        private int _SAMPLE_NUMBER;

        [Column]
        public int DATA_SIZE
        {
            get { return _DATA_SIZE; }
            set { _DATA_SIZE = value; OnPropertyChanged(); }
        }
        private int _DATA_SIZE;

        [Column]
        public short? MIN_VALUE
        {
            get { return _MIN_VALUE; }
            set { _MIN_VALUE = value; OnPropertyChanged(); }
        }
        private short? _MIN_VALUE;

        [Column]
        public short? MAX_VALUE
        {
            get { return _MAX_VALUE; }
            set { _MAX_VALUE = value; OnPropertyChanged(); }
        }
        private short? _MAX_VALUE;

        [Column]
        public short? AVG_VALUE
        {
            get { return _AVG_VALUE; }
            set { _AVG_VALUE = value; OnPropertyChanged(); }
        }
        private short? _AVG_VALUE;

        [Column]
        public short? STDDEV_VALUE
        {
            get { return _STDDEV_VALUE; }
            set { _STDDEV_VALUE = value; OnPropertyChanged(); }
        }
        private short? _STDDEV_VALUE;

        [Column]
        public short? MIN_TOLE
        {
            get { return _MIN_TOLE; }
            set { _MIN_TOLE = value; OnPropertyChanged(); }
        }
        private short? _MIN_TOLE;

        [Column]
        public short? MAX_TOLE
        {
            get { return _MAX_TOLE; }
            set { _MAX_TOLE = value; OnPropertyChanged(); }
        }
        private short? _MAX_TOLE;

        [Column]
        public bool? PERF_FLAG
        {
            get { return _PERF_FLAG; }
            set { _PERF_FLAG = value; OnPropertyChanged(); }
        }
        private bool? _PERF_FLAG;

        [Column]
        public string VARIABLE_NAME
        {
            get { return _VARIABLE_NAME; }
            set { _VARIABLE_NAME = value; OnPropertyChanged(); }
        }
        private string _VARIABLE_NAME;

        [Column]
        public string COIL_ID
        {
            get { return _COIL_ID; }
            set { _COIL_ID = value; OnPropertyChanged(); }
        }
        private string _COIL_ID;

    }
    [TableName("dbo.qcs_coil_data_pdo")]
    [ExplicitColumns]
    public class QCS_COIL_DATA_PDO : Record<QCS_COIL_DATA_PDO>
    {

        [Column]
        public object? SAMPLE_DATA
        {
            get { return _SAMPLE_DATA; }
            set { _SAMPLE_DATA = value; OnPropertyChanged(); }
        }
        private object? _SAMPLE_DATA;

        [Column]
        public DateTime DATI
        {
            get { return _DATI; }
            set { _DATI = value; OnPropertyChanged(); }
        }
        private DateTime _DATI;

        [Column]
        public bool? HIST_FLAG
        {
            get { return _HIST_FLAG; }
            set { _HIST_FLAG = value; OnPropertyChanged(); }
        }
        private bool? _HIST_FLAG;

        [ResultColumn(IncludeInAutoSelect.Yes)]
        public long ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private long _ID;

        [Column]
        public int SAMPLE_DISTANCE
        {
            get { return _SAMPLE_DISTANCE; }
            set { _SAMPLE_DISTANCE = value; OnPropertyChanged(); }
        }
        private int _SAMPLE_DISTANCE;

        [Column]
        public int SAMPLE_NUMBER
        {
            get { return _SAMPLE_NUMBER; }
            set { _SAMPLE_NUMBER = value; OnPropertyChanged(); }
        }
        private int _SAMPLE_NUMBER;

        [Column]
        public int DATA_SIZE
        {
            get { return _DATA_SIZE; }
            set { _DATA_SIZE = value; OnPropertyChanged(); }
        }
        private int _DATA_SIZE;

        [Column]
        public short? MIN_VALUE
        {
            get { return _MIN_VALUE; }
            set { _MIN_VALUE = value; OnPropertyChanged(); }
        }
        private short? _MIN_VALUE;

        [Column]
        public short? MAX_VALUE
        {
            get { return _MAX_VALUE; }
            set { _MAX_VALUE = value; OnPropertyChanged(); }
        }
        private short? _MAX_VALUE;

        [Column]
        public short? AVG_VALUE
        {
            get { return _AVG_VALUE; }
            set { _AVG_VALUE = value; OnPropertyChanged(); }
        }
        private short? _AVG_VALUE;

        [Column]
        public short? STDDEV_VALUE
        {
            get { return _STDDEV_VALUE; }
            set { _STDDEV_VALUE = value; OnPropertyChanged(); }
        }
        private short? _STDDEV_VALUE;

        [Column]
        public short? MIN_TOLE
        {
            get { return _MIN_TOLE; }
            set { _MIN_TOLE = value; OnPropertyChanged(); }
        }
        private short? _MIN_TOLE;

        [Column]
        public short? MAX_TOLE
        {
            get { return _MAX_TOLE; }
            set { _MAX_TOLE = value; OnPropertyChanged(); }
        }
        private short? _MAX_TOLE;

        [Column]
        public bool? PERF_FLAG
        {
            get { return _PERF_FLAG; }
            set { _PERF_FLAG = value; OnPropertyChanged(); }
        }
        private bool? _PERF_FLAG;

        [Column]
        public string VARIABLE_NAME
        {
            get { return _VARIABLE_NAME; }
            set { _VARIABLE_NAME = value; OnPropertyChanged(); }
        }
        private string _VARIABLE_NAME;

        [Column]
        public string COIL_ID
        {
            get { return _COIL_ID; }
            set { _COIL_ID = value; OnPropertyChanged(); }
        }
        private string _COIL_ID;

    }
    [TableName("dbo.qcs_coil_data_temp")]
    [ExplicitColumns]
    public class QCS_COIL_DATA_TEMP : Record<QCS_COIL_DATA_TEMP>
    {

        [Column]
        public object? SAMPLE_DATA
        {
            get { return _SAMPLE_DATA; }
            set { _SAMPLE_DATA = value; OnPropertyChanged(); }
        }
        private object? _SAMPLE_DATA;

        [Column]
        public DateTime DATI
        {
            get { return _DATI; }
            set { _DATI = value; OnPropertyChanged(); }
        }
        private DateTime _DATI;

        [Column]
        public bool? HIST_FLAG
        {
            get { return _HIST_FLAG; }
            set { _HIST_FLAG = value; OnPropertyChanged(); }
        }
        private bool? _HIST_FLAG;

        [ResultColumn(IncludeInAutoSelect.Yes)]
        public long ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private long _ID;

        [Column]
        public int SAMPLE_DISTANCE
        {
            get { return _SAMPLE_DISTANCE; }
            set { _SAMPLE_DISTANCE = value; OnPropertyChanged(); }
        }
        private int _SAMPLE_DISTANCE;

        [Column]
        public int SAMPLE_NUMBER
        {
            get { return _SAMPLE_NUMBER; }
            set { _SAMPLE_NUMBER = value; OnPropertyChanged(); }
        }
        private int _SAMPLE_NUMBER;

        [Column]
        public int DATA_SIZE
        {
            get { return _DATA_SIZE; }
            set { _DATA_SIZE = value; OnPropertyChanged(); }
        }
        private int _DATA_SIZE;

        [Column]
        public short? MIN_VALUE
        {
            get { return _MIN_VALUE; }
            set { _MIN_VALUE = value; OnPropertyChanged(); }
        }
        private short? _MIN_VALUE;

        [Column]
        public short? MAX_VALUE
        {
            get { return _MAX_VALUE; }
            set { _MAX_VALUE = value; OnPropertyChanged(); }
        }
        private short? _MAX_VALUE;

        [Column]
        public short? AVG_VALUE
        {
            get { return _AVG_VALUE; }
            set { _AVG_VALUE = value; OnPropertyChanged(); }
        }
        private short? _AVG_VALUE;

        [Column]
        public short? STDDEV_VALUE
        {
            get { return _STDDEV_VALUE; }
            set { _STDDEV_VALUE = value; OnPropertyChanged(); }
        }
        private short? _STDDEV_VALUE;

        [Column]
        public short? MIN_TOLE
        {
            get { return _MIN_TOLE; }
            set { _MIN_TOLE = value; OnPropertyChanged(); }
        }
        private short? _MIN_TOLE;

        [Column]
        public short? MAX_TOLE
        {
            get { return _MAX_TOLE; }
            set { _MAX_TOLE = value; OnPropertyChanged(); }
        }
        private short? _MAX_TOLE;

        [Column]
        public bool? PERF_FLAG
        {
            get { return _PERF_FLAG; }
            set { _PERF_FLAG = value; OnPropertyChanged(); }
        }
        private bool? _PERF_FLAG;

        [Column]
        public string VARIABLE_NAME
        {
            get { return _VARIABLE_NAME; }
            set { _VARIABLE_NAME = value; OnPropertyChanged(); }
        }
        private string _VARIABLE_NAME;

        [Column]
        public string COIL_ID
        {
            get { return _COIL_ID; }
            set { _COIL_ID = value; OnPropertyChanged(); }
        }
        private string _COIL_ID;

    }
    [TableName("dbo.temp_delay")]
    [ExplicitColumns]
    public class TEMP_DELAY : Record<TEMP_DELAY>
    {

        [Column]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private int _ID;

        [Column]
        public DateTime? BEGIN_TIME
        {
            get { return _BEGIN_TIME; }
            set { _BEGIN_TIME = value; OnPropertyChanged(); }
        }
        private DateTime? _BEGIN_TIME;

        [Column]
        public int? SHIFT_ID
        {
            get { return _SHIFT_ID; }
            set { _SHIFT_ID = value; OnPropertyChanged(); }
        }
        private int? _SHIFT_ID;

        [Column]
        public int? DELAY_REASON_CODE
        {
            get { return _DELAY_REASON_CODE; }
            set { _DELAY_REASON_CODE = value; OnPropertyChanged(); }
        }
        private int? _DELAY_REASON_CODE;

        [Column]
        public int? DELAY_CLASS_CODE
        {
            get { return _DELAY_CLASS_CODE; }
            set { _DELAY_CLASS_CODE = value; OnPropertyChanged(); }
        }
        private int? _DELAY_CLASS_CODE;

        [Column]
        public bool? DELAY_STARTED
        {
            get { return _DELAY_STARTED; }
            set { _DELAY_STARTED = value; OnPropertyChanged(); }
        }
        private bool? _DELAY_STARTED;

        [Column]
        public bool? IS_DONE
        {
            get { return _IS_DONE; }
            set { _IS_DONE = value; OnPropertyChanged(); }
        }
        private bool? _IS_DONE;

        [Column]
        public DateTime? END_TIME
        {
            get { return _END_TIME; }
            set { _END_TIME = value; OnPropertyChanged(); }
        }
        private DateTime? _END_TIME;

        [Column]
        public int? DELAY_GROUP_CODE
        {
            get { return _DELAY_GROUP_CODE; }
            set { _DELAY_GROUP_CODE = value; OnPropertyChanged(); }
        }
        private int? _DELAY_GROUP_CODE;

        [Column]
        public string? DELAY_REASON_NAME
        {
            get { return _DELAY_REASON_NAME; }
            set { _DELAY_REASON_NAME = value; OnPropertyChanged(); }
        }
        private string? _DELAY_REASON_NAME;

        [Column]
        public string? DELAY_CLASS_NAME
        {
            get { return _DELAY_CLASS_NAME; }
            set { _DELAY_CLASS_NAME = value; OnPropertyChanged(); }
        }
        private string? _DELAY_CLASS_NAME;

        [Column]
        public string? DELAY_GROUP_NAME
        {
            get { return _DELAY_GROUP_NAME; }
            set { _DELAY_GROUP_NAME = value; OnPropertyChanged(); }
        }
        private string? _DELAY_GROUP_NAME;

        [Column]
        public string? REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; OnPropertyChanged(); }
        }
        private string? _REMARK;

    }
    [TableName("dbo.trk")]
    [ExplicitColumns]
    public class TRK : Record<TRK>
    {

        [ResultColumn(IncludeInAutoSelect.Yes)]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private int _ID;

        [Column]
        public int ZONE_ID
        {
            get { return _ZONE_ID; }
            set { _ZONE_ID = value; OnPropertyChanged(); }
        }
        private int _ZONE_ID;

        [Column]
        public int COLOR_IDX
        {
            get { return _COLOR_IDX; }
            set { _COLOR_IDX = value; OnPropertyChanged(); }
        }
        private int _COLOR_IDX;

        [Column]
        public int COLOR_IDX2
        {
            get { return _COLOR_IDX2; }
            set { _COLOR_IDX2 = value; OnPropertyChanged(); }
        }
        private int _COLOR_IDX2;

        [Column]
        public string ZONE_NAME
        {
            get { return _ZONE_NAME; }
            set { _ZONE_NAME = value; OnPropertyChanged(); }
        }
        private string _ZONE_NAME;

        [Column]
        public string? COIL_ID
        {
            get { return _COIL_ID; }
            set { _COIL_ID = value; OnPropertyChanged(); }
        }
        private string? _COIL_ID;

    }
    [TableName("dbo.trk_data")]
    [ExplicitColumns]
    public class TRK_DATA : Record<TRK_DATA>
    {

        [Column]
        public int COIL_STATUS
        {
            get { return _COIL_STATUS; }
            set { _COIL_STATUS = value; OnPropertyChanged(); }
        }
        private int _COIL_STATUS;

        [ResultColumn(IncludeInAutoSelect.Yes)]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private int _ID;

        [Column]
        public short THICKNESS
        {
            get { return _THICKNESS; }
            set { _THICKNESS = value; OnPropertyChanged(); }
        }
        private short _THICKNESS;

        [Column]
        public int WIDTH
        {
            get { return _WIDTH; }
            set { _WIDTH = value; OnPropertyChanged(); }
        }
        private int _WIDTH;

        [Column]
        public int? COIL_LENGTH
        {
            get { return _COIL_LENGTH; }
            set { _COIL_LENGTH = value; OnPropertyChanged(); }
        }
        private int? _COIL_LENGTH;

        [Column]
        public int? CUTLEN1
        {
            get { return _CUTLEN1; }
            set { _CUTLEN1 = value; OnPropertyChanged(); }
        }
        private int? _CUTLEN1;

        [Column]
        public int? CUTLEN2
        {
            get { return _CUTLEN2; }
            set { _CUTLEN2 = value; OnPropertyChanged(); }
        }
        private int? _CUTLEN2;

        [Column]
        public int? CUTLEN3
        {
            get { return _CUTLEN3; }
            set { _CUTLEN3 = value; OnPropertyChanged(); }
        }
        private int? _CUTLEN3;

        [Column]
        public int? CUTLEN4
        {
            get { return _CUTLEN4; }
            set { _CUTLEN4 = value; OnPropertyChanged(); }
        }
        private int? _CUTLEN4;

        [Column]
        public int? OILING
        {
            get { return _OILING; }
            set { _OILING = value; OnPropertyChanged(); }
        }
        private int? _OILING;

        [Column]
        public int? OIL_TYPE
        {
            get { return _OIL_TYPE; }
            set { _OIL_TYPE = value; OnPropertyChanged(); }
        }
        private int? _OIL_TYPE;

        [Column]
        public int? OIL_WEI
        {
            get { return _OIL_WEI; }
            set { _OIL_WEI = value; OnPropertyChanged(); }
        }
        private int? _OIL_WEI;

        [Column]
        public string COIL_ID
        {
            get { return _COIL_ID; }
            set { _COIL_ID = value; OnPropertyChanged(); }
        }
        private string _COIL_ID;

    }

    [TableName("dbo.user_data")]
    [PrimaryKey("id", AutoIncrement = true)]
    [ExplicitColumns]
    public class USER_DATA : Record<USER_DATA>
    {

        [Column]
        public bool IS_ACTIVE
        {
            get { return _IS_ACTIVE; }
            set { _IS_ACTIVE = value; OnPropertyChanged(); }
        }
        private bool _IS_ACTIVE;

        [Column]
        public DateTime CREATE_DATI
        {
            get { return _CREATE_DATI; }
            set { _CREATE_DATI = value; OnPropertyChanged(); }
        }
        private DateTime _CREATE_DATI;

        [Column]
        public DateTime? UPDATE_DATI
        {
            get { return _UPDATE_DATI; }
            set { _UPDATE_DATI = value; OnPropertyChanged(); }
        }
        private DateTime? _UPDATE_DATI;

        [ResultColumn(IncludeInAutoSelect.Yes)]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private int _ID;

        [Column]
        public string USER_ROLE
        {
            get { return _USER_ROLE; }
            set { _USER_ROLE = value; OnPropertyChanged(); }
        }
        private string _USER_ROLE;

        [Column]
        public string? TEAM
        {
            get { return _TEAM; }
            set { _TEAM = value; OnPropertyChanged(); }
        }
        private string? _TEAM;

        [Column]
        public string? PASSWORD
        {
            get { return _PASSWORD; }
            set { _PASSWORD = value; OnPropertyChanged(); }
        }
        private string? _PASSWORD;

        [Column]
        public string USER_NAME
        {
            get { return _USER_NAME; }
            set { _USER_NAME = value; OnPropertyChanged(); }
        }
        private string _USER_NAME;

        [Column]
        public string FIRST_NAME
        {
            get { return _FIRST_NAME; }
            set { _FIRST_NAME = value; OnPropertyChanged(); }
        }
        private string _FIRST_NAME;

        [Column]
        public string LAST_NAME
        {
            get { return _LAST_NAME; }
            set { _LAST_NAME = value; OnPropertyChanged(); }
        }
        private string _LAST_NAME;

    }

    [TableName("dbo.leveler_setting")]
    [ExplicitColumns]
    [PrimaryKey("id")]
    public class LEVELER_SETTING : Record<LEVELER_SETTING>
    {

        [ResultColumn(IncludeInAutoSelect.Yes)]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }
        private int _ID;

        [Column]
        public short THICKNESS
        {
            get { return _THICKNESS; }
            set { _THICKNESS = value; OnPropertyChanged(); }
        }
        private short _THICKNESS;

        [Column]
        public short INTERMESH1
        {
            get { return _INTERMESH1; }
            set { _INTERMESH1 = value; OnPropertyChanged(); }
        }
        private short _INTERMESH1;

        [Column]
        public short INTERMESH2
        {
            get { return _INTERMESH2; }
            set { _INTERMESH2 = value; OnPropertyChanged(); }
        }
        private short _INTERMESH2;

        [Column]
        public short ANTICROSSBOW
        {
            get { return _ANTICROSSBOW; }
            set { _ANTICROSSBOW = value; OnPropertyChanged(); }
        }
        private short _ANTICROSSBOW;

        [Column]
        public short ANTICOILSET
        {
            get { return _ANTICOILSET; }
            set { _ANTICOILSET = value; OnPropertyChanged(); }
        }
        private short _ANTICOILSET;

    }
}
