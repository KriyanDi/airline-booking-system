﻿namespace AirlineBookingSystem
{
    public class Seat
    {
        public Seat((int rows, char cols) id, bool isBooked)
        {
            Id = id;
            IsBooked = isBooked;
        }

        public (int rows, char cols) Id { get; set; }
        public bool IsBooked { get; set; }

        public override string ToString() => $"ROW: {Id.rows} COL: {Id.cols} BOOKED: {IsBooked}";
    }
}
