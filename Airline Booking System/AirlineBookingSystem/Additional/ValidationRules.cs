using AirlineBookingSystem.Additional;
using System;

namespace AirlineBookingSystem
{
    public static class  ValidationRules
    {
        #region Fields
        public const int MAX_ROWS = 100;
        public const int MIN_ROWS = 1;
        public const int MAX_COLS = 10;
        public const int MIN_COLS = 1;
        public const char MAX_COLS_LETTER = 'J';
        public const char MIN_COLS_LETTER = 'A';
        #endregion

        #region Methods
        public static ValidationOperation AirportName(string airportName)
        {
            if (airportName != null)
            {
                if (airportName.HasLengthThree())
                {
                    if (airportName.HasOnlyCapitalLetters())
                    {
                        return ValidationOperation.Succeded;
                    }
                    else
                    {
                        Console.WriteLine("Error: Airport should contain only capital letters.");

                        return ValidationOperation.InvalidNameFormatFailure;
                    }
                }
                else
                {
                    Console.WriteLine("Error: Airport should be exact three letters long.");

                    return ValidationOperation.InvalidNameLenghtFailure;
                }
            }
            else
            {
                Console.WriteLine("Error: Airport can not be null.");

                return ValidationOperation.InvalidNameNullFailure;
            }
        }
        public static ValidationOperation AirlineName(string airlineName)
        {
            if (airlineName != null)
            {
                if (airlineName.HasLengthMoreThanOneAndLessThanSix())
                {
                    if (airlineName.HasOnlyCapitalLettersAndNumbers())
                    {
                        return ValidationOperation.Succeded;
                    }
                    else
                    {
                        Console.WriteLine("Error: Airline should contain only capital letters and numbers.");

                        return ValidationOperation.InvalidNameFormatFailure;
                    }
                }
                else
                {
                    Console.WriteLine("Error: Airline should be exact three symbols long.");

                    return ValidationOperation.InvalidNameLenghtFailure;
                }
            }
            else
            {
                Console.WriteLine("Error: Airline can not be null.");

                return ValidationOperation.InvalidNameNullFailure;
            }
        }
        public static ValidationOperation SeatsRowsNumber(int rowNumber)
        {
            if (MIN_ROWS <= rowNumber && rowNumber <= MAX_ROWS)
            {
                return ValidationOperation.Succeded;
            }
            else
            {
                Console.WriteLine($"Error: Seat rows should be between {MIN_ROWS} and {MAX_ROWS}");

                return ValidationOperation.InvalidSeatRowsFailure;
            }
        }
        public static ValidationOperation SeatsColsLetter(char colLetter)
        {
            if (MIN_COLS_LETTER <= colLetter && colLetter <= MAX_COLS_LETTER)
            {
                return ValidationOperation.Succeded;
            }
            else
            {
                Console.WriteLine($"Error: Seat cols should be between {MIN_COLS_LETTER} and {MAX_COLS_LETTER}");

                return ValidationOperation.InvalidSeatColsFailure;
            }
        }
        public static ValidationOperation SeatsColsNumber(int colNumber)
        {
            if (MIN_COLS < colNumber && colNumber <= MAX_COLS)
            {
                return ValidationOperation.Succeded;
            }
            else
            {
                Console.WriteLine($"Error: Seat cols should be number between {MIN_COLS} and {MAX_COLS}.");

                return ValidationOperation.InvalidSeatColsFailure;
            }
        }
        public static ValidationOperation SeatsRowsCols((int rows, char cols) seats)
        {
            if (SeatsRowsNumber(seats.rows) == ValidationOperation.Succeded)
            {
                if (SeatsColsLetter(seats.cols) == ValidationOperation.Succeded)
                {
                    return ValidationOperation.Succeded;
                }
                else
                {
                    return ValidationOperation.InvalidSeatColsFailure;
                }
            }
            else
            {
                return ValidationOperation.InvalidSeatRowsFailure;
            }
        }
        public static ValidationOperation SeatsRowsCols(int rows, int cols)
        { 
            if (SeatsRowsNumber(rows) == ValidationOperation.Succeded)
            {
                if (SeatsColsNumber(cols) == ValidationOperation.Succeded)
                {
                    return ValidationOperation.Succeded;
                }
                else
                {
                    return ValidationOperation.InvalidSeatColsFailure;
                }
            }
            else
            {
                return ValidationOperation.InvalidSeatRowsFailure;
            }
        }
        public static ValidationOperation FlightNumber(string flightNumber)
        {
            if(flightNumber.HasOnlyNumbers())
            {
                return ValidationOperation.Succeded;
            }
            else
            {
                Console.WriteLine("Error: Flight number should contain only numbers.");

                return ValidationOperation.InvalidFlightNumberContainsNotOnlyNumbersFailure;
            }
        }
        #endregion
    }
}
