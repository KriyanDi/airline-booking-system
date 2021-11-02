using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAbsApi.Models
{
    [Keyless]
    public partial class FlightsInformation
    {
        [Column("FLIGHT_ID")]
        public Guid FlightId { get; set; }
        [Required]
        [Column("FLIGHT_NUMBER")]
        [StringLength(10)]
        public string FlightNumber { get; set; }
        [Required]
        [Column("AIRLINE")]
        [StringLength(5)]
        public string Airline { get; set; }
        [Column("ORIG")]
        [StringLength(3)]
        public string Orig { get; set; }
        [Column("DEST")]
        [StringLength(3)]
        public string Dest { get; set; }
        [Column("TAKE_OFF", TypeName = "datetime")]
        public DateTime TakeOff { get; set; }
        [Required]
        [Column("SEATCLASS")]
        [StringLength(25)]
        public string Seatclass { get; set; }
        [Column("BOOKED_SEATS")]
        public int? BookedSeats { get; set; }
        [Column("FREE_SEATS")]
        public int? FreeSeats { get; set; }
    }
}
