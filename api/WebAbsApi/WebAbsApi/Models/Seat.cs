using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAbsApi.Models
{
    [Table("SEAT")]
    public partial class Seat
    {
        public Seat()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        [Column("SEAT_ID")]
        public Guid SeatId { get; set; }
        [Column("FLIGHT_SECTION_ID")]
        public Guid FlightSectionId { get; set; }
        [Column("BOOKED")]
        public bool Booked { get; set; }
        [Column("ROW")]
        public int Row { get; set; }
        [Required]
        [Column("COL")]
        [StringLength(1)]
        public string Col { get; set; }

        [ForeignKey(nameof(FlightSectionId))]
        [InverseProperty("Seats")]
        public virtual FlightSection FlightSection { get; set; }
        [InverseProperty(nameof(Ticket.Seat))]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
