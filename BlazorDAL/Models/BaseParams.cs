using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDAL.Models
{
    public class Order
    {
        public const int Desc = -1;
        public const int Asc = 1;
    }

    public class BaseParameter : IBaseParam
    {
        public int? Page { get; set; } = 1;
        public int? First { get; set; } = 0;
        public int? Rows { get; set; } = 20;
        public int TotalRecords { get; set; } = 20;
        public virtual int? SortOrder { get; set; } = 1;
        public virtual string? SortField { get; set; }
        public virtual string? Filter { get; set; }
    }
    public interface IBaseParam
    {
        public int? Page { get; set; }
        public int? First { get; set; }
        public int? Rows { get; set; }
        public int TotalRecords { get; set; }
        public string? SortField { get; set; }
        public int? SortOrder { get; set; }
        public string? Filter { get; set; }
    }
}
