using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDAL.Models
{
    public class AccountDto
    {
        public int? Id { get; set; }

        public int? CustomerId { get; set; }

        public string? Username { get; set; } = null!;

        public string? Password { get; set; } = null!;

        public short? Role { get; set; }

        public string? Name { get; set; } = null!;

        public string? LastName { get; set; } = null!;

        public DateTime? CreateDati { get; set; }

        public DateTime? UpdateDati { get; set; }

        public bool? IsActive { get; set; }

        public string? Email { get; set; } = null!;

        public string? PhoneNumber { get; set; } = null!;

        /*public virtual Customer? Customer { get; set; }

        public virtual Role? RoleNavigation { get; set; } = null!;*/
    }
}
