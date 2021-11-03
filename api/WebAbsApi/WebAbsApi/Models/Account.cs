using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAbsApi.Models
{
    [Table("ACCOUNT")]
    [Index(nameof(Email), Name = "UQ_EMAIL", IsUnique = true)]
    [Index(nameof(Username), Name = "UQ_USERNAME", IsUnique = true)]
    public partial class Account
    {
        public Account()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        [Column("ACCOUNT_ID")]
        public Guid AccountId { get; set; }
        [Column("ROLE_ID")]
        public Guid RoleId { get; set; }
        [Required]
        [Column("USERNAME")]
        [StringLength(32)]
        public string Username { get; set; }
        [Required]
        [Column("EMAIL")]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [Column("PASSWORD")]
        [StringLength(32)]
        public string Password { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Accounts")]
        public virtual Role Role { get; set; }
        [InverseProperty(nameof(Ticket.Account))]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
