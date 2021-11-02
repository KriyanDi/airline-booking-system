using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAbsApi.Models
{
    [Table("TICKET")]
    public partial class Ticket
    {
        [Key]
        [Column("TICKET_ID")]
        public Guid TicketId { get; set; }
        [Column("ACCOUNT_ID")]
        public Guid AccountId { get; set; }
        [Column("FLIGHT_SECTION_ID")]
        public Guid FlightSectionId { get; set; }
        [Column("SEAT_ID")]
        public Guid SeatId { get; set; }
        [Column("PRICE", TypeName = "money")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("Tickets")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(SeatId))]
        [InverseProperty("Tickets")]
        public virtual Seat Seat { get; set; }
    }
}
