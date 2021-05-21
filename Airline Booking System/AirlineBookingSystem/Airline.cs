using System.ComponentModel.DataAnnotations;

namespace AirlineBookingSystem
{
    public class Airline
    {
        private static int _counter = 0;

        public Airline(string airlineName)
        {
            Id = _counter++;
            Name = airlineName;
            if(!ValidateObject.TryValidate(this)) throw new ValidationException("Invalid Airline");
        }

        public int Id { get; set; }

        [RegularExpression(@"^[A-Z0-9]{1,5}$", ErrorMessage = "Error: Airline name should be with more than zero and less than six alphanumeric capital symbols long.")]
        public string Name { get; set; }
        public override string ToString() => $"{Name}";
    }
}