using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAbsApi.Models
{
    [Table("ROLE")]
    [Index(nameof(Type), Name = "UQ_ROLE_TYPE", IsUnique = true)]
    public partial class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        [Column("ROLE_ID")]
        public Guid RoleId { get; set; }
        [Required]
        [Column("TYPE")]
        [StringLength(16)]
        public string Type { get; set; }

        [InverseProperty(nameof(Account.Role))]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
