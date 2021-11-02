using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAbsApi.Models
{
    [Table("FLIGHT")]
    [Index(nameof(FlightNumber), Name = "UQ_FLIGHT_NUMBER", IsUnique = true)]
    public partial class Flight
    {
        public Flight()
        {
            FlightSections = new HashSet<FlightSection>();
        }

        [Key]
        [Column("FLIGHT_ID")]
        public Guid FlightId { get; set; }
        [Column("AIRLINE_ID")]
        public Guid AirlineId { get; set; }
        [Column("ORIG_AIRPORT_ID")]
        public Guid OrigAirportId { get; set; }
        [Column("DEST_AIRPORT_ID")]
        public Guid DestAirportId { get; set; }
        [Required]
        [Column("FLIGHT_NUMBER")]
        [StringLength(10)]
        public string FlightNumber { get; set; }
        [Column("TAKE_OFF", TypeName = "datetime")]
        public DateTime TakeOff { get; set; }

        [ForeignKey(nameof(AirlineId))]
        [InverseProperty("Flights")]
        public virtual Airline Airline { get; set; }
        [ForeignKey(nameof(DestAirportId))]
        [InverseProperty(nameof(Airport.FlightDestAirports))]
        public virtual Airport DestAirport { get; set; }
        [ForeignKey(nameof(OrigAirportId))]
        [InverseProperty(nameof(Airport.FlightOrigAirports))]
        public virtual Airport OrigAirport { get; set; }
        [InverseProperty(nameof(FlightSection.Flight))]
        public virtual ICollection<FlightSection> FlightSections { get; set; }
    }
}
