using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAbsApi.Models
{
    [Keyless]
    public partial class AvailFlight
    {
        [Column("FLIGHT_ID")]
        public Guid FlightId { get; set; }
        [Required]
        [Column("SEATCLASS")]
        [StringLength(25)]
        public string Seatclass { get; set; }
    }
}
