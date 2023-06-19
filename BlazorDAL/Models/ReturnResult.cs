using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDAL.Models
{
    public class ReturnResult : ReturnResult<object>
    {
        public ReturnResult<object> GetBase()
        {
            return this;
        }
    }
    public class ReturnResult<T>
    {
        public int IsSuccess { get; set; } = 0;
        public string? Msg { get; set; }
        public int StatusCode { get; set; }
        public T result { get; set; }


    }
}
