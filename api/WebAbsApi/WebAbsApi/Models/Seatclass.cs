using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAbsApi.Models
{
    [Table("SEATCLASS")]
    [Index(nameof(Type), Name = "UQ_SEATCLASS_TYPE", IsUnique = true)]
    public partial class Seatclass
    {
        public Seatclass()
        {
            FlightSections = new HashSet<FlightSection>();
        }

        [Key]
        [Column("SEATCLASS_ID")]
        public Guid SeatclassId { get; set; }
        [Required]
        [Column("TYPE")]
        [StringLength(25)]
        public string Type { get; set; }

        [InverseProperty(nameof(FlightSection.Seatclass))]
        public virtual ICollection<FlightSection> FlightSections { get; set; }
    }
}
