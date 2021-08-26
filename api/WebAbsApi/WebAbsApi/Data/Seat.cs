﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAbsApi.Data
{
    public class Seat
    {
        public int Id { get; set; }
        public string Row { get; set; }
        public string Column { get; set; }
        public bool IsBooked { get; set; }

        [ForeignKey(nameof(FlightSection))]
        public int FlightSectionId { get; set; }
        public FlightSection FlightSection { get; set; }

    }
}