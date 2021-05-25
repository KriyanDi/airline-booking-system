using System.ComponentModel.DataAnnotations;

namespace AirlineBookingSystem
{
    public class Airport
    {
        private static int _counter = 0;

        public Airport(string airportName)
        {
            Id = _counter++;
            Name = airportName;
            if (!ValidateObject.TryValidate(this)) throw new ValidationException("Invalid Airport");
        }

        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Error: Airport name should be exact three capital letters long.")]
        public string Name { get; set; }
        public override string ToString() => $"[{Name}]";
    }
}