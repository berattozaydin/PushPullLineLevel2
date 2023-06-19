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

    [TableName("CustomerOrder")]
    [PrimaryKey("CustomerOrderId", AutoIncrement = false)]
    [ExplicitColumns]
    public class CustomerOrder : Record<CustomerOrder>
    {
        [Column]
        public string CustomerOrderId
        {
            get { return _CustomerOrderId; }
            set { _CustomerOrderId = value; OnPropertyChanged(); }
        }
        string _CustomerOrderId;

        [Column]
        public int CustomerId
        {
            get { return _CustomerId; }
            set { _CustomerId = value; OnPropertyChanged(); }
        }
        int _CustomerId;

        [Column]
        public int CustomerOrderStatusId
        {
            get { return _CustomerOrderStatusId; }
            set { _CustomerOrderStatusId = value; OnPropertyChanged(); }
        }
        int _CustomerOrderStatusId;

        [Column]
        public string OrderNumber
        {
            get { return _OrderNumber; }
            set { _OrderNumber = value; OnPropertyChanged(); }
        }
        string _OrderNumber;

        [Column]
        public string? Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged(); }
        }
        string? _Name;

        [Column]
        public string? Remark
        {
            get { return _Remark; }
            set { _Remark = value; OnPropertyChanged(); }
        }
        string? _Remark;

        [Column]
        public DateTime? CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; OnPropertyChanged(); }
        }
        DateTime? _CreatedDate;

        [Column]
        public DateTime? UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; OnPropertyChanged(); }
        }
        DateTime? _UpdatedDate;
    }
    [TableName("CustomerOrderStatus")]
    [PrimaryKey("CustomerOrderStatusId", AutoIncrement = false)]
    [ExplicitColumns]
    public class CustomerOrderStatus : Record<CustomerOrderStatus>
    {
        [Column]
        public int CustomerOrderStatusId
        {
            get { return _CustomerOrderStatusId; }
            set { _CustomerOrderStatusId = value; OnPropertyChanged(); }
        }
        int _CustomerOrderStatusId;

        [Column]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged(); }
        }
        string _Name;
    }

    [TableName("Customer")]
    [PrimaryKey("CustomerId", AutoIncrement = true)]
    [ExplicitColumns]
    public class Customer : Record<Customer>
    {
        [Column]
        public int CustomerId
        {
            get { return _CustomerId; }
            set { _CustomerId = value; OnPropertyChanged(); }
        }
        int _CustomerId;

        [Column]
        public string? CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; OnPropertyChanged(); }
        }
        string? _CompanyName;

        [Column]
        public string? CompanyFullName
        {
            get { return _CompanyFullName; }
            set { _CompanyFullName = value; OnPropertyChanged(); }
        }
        string? _CompanyFullName;

        [Column]
        public string? TaxNumber
        {
            get { return _TaxNumber; }
            set { _TaxNumber = value; OnPropertyChanged(); }
        }
        string? _TaxNumber;

        [Column]
        public string? TaxAdministration
        {
            get { return _TaxAdministration; }
            set { _TaxAdministration = value; OnPropertyChanged(); }
        }
        string? _TaxAdministration;

        [Column]
        public string? Remark
        {
            get { return _Remark; }
            set { _Remark = value; OnPropertyChanged(); }
        }
        string? _Remark;

        [Column]
        public int? CurrencyType
        {
            get { return _CurrencyType; }
            set { _CurrencyType = value; OnPropertyChanged(); }
        }
        int? _CurrencyType;

        [Column]
        public int? PartitionType
        {
            get { return _PartitionType; }
            set { _PartitionType = value; OnPropertyChanged(); }
        }
        int? _PartitionType;

        [Column]
        public int? Status
        {
            get { return _Status; }
            set { _Status = value; OnPropertyChanged(); }
        }
        int? _Status;

        [Column]
        public int? Maturity
        {
            get { return _Maturity; }
            set { _Maturity = value; OnPropertyChanged(); }
        }
        int? _Maturity;

        [Column]
        public string? CompanyCode
        {
            get { return _CompanyCode; }
            set { _CompanyCode = value; OnPropertyChanged(); }
        }
        string? _CompanyCode;

    }
    [TableName("Account")]
    [PrimaryKey("Id", AutoIncrement = true)]
    [ExplicitColumns]
    public class Account : Record<Account>
    {
        [Column]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; OnPropertyChanged(); }
        }
        int _Id;

        [Column]
        public int? CustomerId
        {
            get { return _CustomerId; }
            set { _CustomerId = value; OnPropertyChanged(); }
        }
        int? _CustomerId;

        [Column]
        public string? Username
        {
            get { return _Username; }
            set { _Username = value; OnPropertyChanged(); }
        }
        string? _Username;

        [Column]
        public string? Password
        {
            get { return _Password; }
            set { _Password = value; OnPropertyChanged(); }
        }
        string? _Password;

        [Column]
        public int? Role
        {
            get { return _Role; }
            set { _Role = value; OnPropertyChanged(); }
        }
        int? _Role;

        [Column]
        public string? Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged(); }
        }
        string? _Name;

        [Column]
        public string? LastName
        {
            get { return _LastName; }
            set { _LastName = value; OnPropertyChanged(); }
        }
        string? _LastName;

        [Column]
        public DateTime? CreateDati
        {
            get { return _CreateDati; }
            set { _CreateDati = value; OnPropertyChanged(); }
        }
        DateTime? _CreateDati;

        [Column]
        public DateTime? UpdateDati
        {
            get { return _UpdateDati; }
            set { _UpdateDati = value; OnPropertyChanged(); }
        }
        DateTime? _UpdateDati;

        [Column]
        public int? IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; OnPropertyChanged(); }
        }
        int? _IsActive;

        [Column]
        public string? Email
        {
            get { return _Email; }
            set { _Email = value; OnPropertyChanged(); }
        }
        string? _Email;

        [Column]
        public int? PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; OnPropertyChanged(); }
        }
        int? _PhoneNumber;


    }
    [TableName("event_alarm")]
    [PrimaryKey("event_alarm_id", AutoIncrement = true)]
    [ExplicitColumns]
    public class event_alarm : Record<event_alarm>
    {
        [Column]
        public int event_alarm_id
        {
            get { return _event_alarm_id; }
            set { _event_alarm_id = value; OnPropertyChanged(); }
        }
        int _event_alarm_id;

        [Column]
        public string machine_name
        {
            get { return _machine_name; }
            set { _machine_name = value; OnPropertyChanged(); }
        }
        string _machine_name;

        [Column]
        public string user_name
        {
            get { return _user_name; }
            set { _user_name = value; OnPropertyChanged(); }
        }
        string _user_name;

        [Column]
        public string? log_description
        {
            get { return _log_description; }
            set { _log_description = value; OnPropertyChanged(); }
        }
        string? _log_description;

        [Column]
        public string? log_method
        {
            get { return _log_method; }
            set
            {
                _log_method = value;
                OnPropertyChanged();
            }
        }
        string? _log_method;

        [Column]
        public DateTime dati
        {
            get { return _dati; }
            set
            {
                _dati = value;
                OnPropertyChanged();
            }
        }
        DateTime _dati;
    }
}
