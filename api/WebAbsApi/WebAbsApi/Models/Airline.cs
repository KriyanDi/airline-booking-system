using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAbsApi.Models
{
    [Table("AIRLINE")]
    [Index(nameof(Name), Name = "UQ_AIRLINE_NAME", IsUnique = true)]
    public partial class Airline
    {
        public Airline()
        {
            Flights = new HashSet<Flight>();
        }

        [Key]
        [Column("AIRLINE_ID")]
        public Guid Airline_Id { get; set; }

        [Required]
        [Column("NAME")]
        [StringLength(5)]
        public string Name { get; set; }

        [InverseProperty(nameof(Flight.Airline))]
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
