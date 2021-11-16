using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAbsApi.Models
{
    [Table("FLIGHT_SECTION")]
    [Index(nameof(Flight_Id), nameof(Seatclass_Id), Name = "UQ_FLIGHT_SEATCLASS", IsUnique = true)]
    public partial class FlightSection
    {
        public FlightSection()
        {
            Seats = new HashSet<Seat>();
        }

        [Key]
        [Column("FLIGHT_SECTION_ID")]
        public Guid Flight_Section_Id { get; set; }
        [Column("FLIGHT_ID")]
        public Guid Flight_Id { get; set; }
        [Column("SEATCLASS_ID")]
        public Guid Seatclass_Id { get; set; }
        [Column("ROWS")]
        public int Rows { get; set; }
        [Column("COLS")]
        public int Cols { get; set; }

        [ForeignKey(nameof(Flight_Id))]
        [InverseProperty("FlightSections")]
        public virtual Flight Flight { get; set; }
        [ForeignKey(nameof(Seatclass_Id))]
        [InverseProperty("FlightSections")]
        public virtual Seatclass Seatclass { get; set; }
        [InverseProperty(nameof(Seat.FlightSection))]
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
