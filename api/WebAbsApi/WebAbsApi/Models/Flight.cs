using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAbsApi.Models
{
    [Table("FLIGHT")]
    [Index(nameof(Flight_Number), Name = "UQ_FLIGHT_NUMBER", IsUnique = true)]
    public partial class Flight
    {
        public Flight()
        {
            FlightSections = new HashSet<FlightSection>();
        }

        [Key]
        [Column("FLIGHT_ID")]
        public Guid Flight_Id { get; set; }

        [Column("AIRLINE_ID")]
        public Guid Airline_Id { get; set; }

        [Column("ORIG_AIRPORT_ID")]
        public Guid Orig_Airport_Id { get; set; }

        [Column("DEST_AIRPORT_ID")]
        public Guid Dest_Airport_Id { get; set; }

        [Required]
        [Column("FLIGHT_NUMBER")]
        [StringLength(10)]
        public string Flight_Number { get; set; }

        [Column("TAKE_OFF", TypeName = "datetime")]
        public DateTime Take_Off { get; set; }

        [ForeignKey(nameof(Airline_Id))]
        [InverseProperty("Flights")]
        public virtual Airline Airline { get; set; }

        [ForeignKey(nameof(Dest_Airport_Id))]
        [InverseProperty(nameof(Airport.FlightDestAirports))]
        public virtual Airport DestAirport { get; set; }

        [ForeignKey(nameof(Orig_Airport_Id))]
        [InverseProperty(nameof(Airport.FlightOrigAirports))]
        public virtual Airport OrigAirport { get; set; }

        [InverseProperty(nameof(FlightSection.Flight))]
        public virtual ICollection<FlightSection> FlightSections { get; set; }
    }
}
