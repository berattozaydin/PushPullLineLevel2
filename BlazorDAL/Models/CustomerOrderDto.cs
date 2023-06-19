using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDAL.Models
{
    public class CustomerOrderDto : BaseParameter
    {
        public string CustomerOrderId { get; set; }
        public int CustomerId { get; set; }
        public int CustomerOrderStatusId { get; set; }
        public string OrderNumber { get; set; }
        public string? Name { get; set; }
        public string? Remark { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public string? CustomerOrderStatusName { get; set; }
        public string? CustomerOrderCustomerName { get; set; }

    }
}
