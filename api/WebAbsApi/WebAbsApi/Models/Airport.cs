using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAbsApi.Models
{
    [Table("AIRPORT")]
    [Index(nameof(Name), Name = "UQ_AIRPORT_NAME", IsUnique = true)]
    public partial class Airport
    {
        public Airport()
        {
            FlightDestAirports = new HashSet<Flight>();
            FlightOrigAirports = new HashSet<Flight>();
        }

        [Key]
        [Column("AIRPORT_ID")]
        public Guid AirportId { get; set; }

        [Required]
        [Column("NAME")]
        [StringLength(3)]
        public string Name { get; set; }

        [InverseProperty(nameof(Flight.DestAirport))]
        public virtual ICollection<Flight> FlightDestAirports { get; set; }
        [InverseProperty(nameof(Flight.OrigAirport))]
        public virtual ICollection<Flight> FlightOrigAirports { get; set; }
    }
}
