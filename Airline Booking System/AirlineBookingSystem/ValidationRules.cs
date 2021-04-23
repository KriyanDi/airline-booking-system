using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static AirportOperation AirportName(string airportName)
        {
            if (airportName != null)
            {
                if (airportName.HasLengthThree())
                {
                    if (airportName.HasOnlyCapitalLetters())
                    {
                        return AirportOperation.Succeded;
                    }
                    else
                    {
                        return AirportOperation.InvalidNameFormatFailure;
                    }
                }
                else
                {
                    return AirportOperation.InvalidNameLenghtFailure;
                }
            }
            else
            {
                return AirportOperation.InvalidNameNullFailure;
            }
        }
        public static AirlineOperation AirlineName(string airlineName)
        {
            if (airlineName != null)
            {
                if (airlineName.HasLengthMoreThanOneAndLessThanSix())
                {
                    if (airlineName.HasOnlyCapitalLettersAndNumbers())
                    {
                        return AirlineOperation.Succeded;
                    }
                    else
                    {
                        return AirlineOperation.InvalidNameFormatFailure;
                    }
                }
                else
                {
                    return AirlineOperation.InvalidNameLenghtFailure;
                }
            }
            else
            {
                return AirlineOperation.InvalidNameNullFailure;
            }
        }
        public static bool SeatsRowsNumber(int rowNumber)
        {
            if (MIN_ROWS <= rowNumber && rowNumber <= MAX_ROWS)
            {
                return true;
            }
            else
            {
                throw new ArgumentException($"Seat row should be number between {MIN_ROWS} and {MAX_ROWS}.");
            }
        }
        public static bool SeatsColsLetter(char colLetter)
        {
            if (MIN_COLS_LETTER <= colLetter && colLetter <= MAX_COLS_LETTER)
            {
                return true;
            }
            else
            {
                throw new ArgumentException($"Seat column should be char between {MIN_COLS_LETTER} and {MAX_COLS_LETTER}.");
            }
        }
        public static bool SeatsColsNumber(int colNumber)
        {
            if (MIN_COLS < colNumber && colNumber <= MAX_COLS)
            {
                return true;
            }
            else
            {
                throw new ArgumentException($"Seat column should be char between {MIN_COLS} and {MIN_COLS}.");
            }
        }
        public static bool SeatsRowsCols(int rows, char cols) => SeatsRowsNumber(rows) && SeatsColsLetter(cols);
        public static bool SeatsRowsCols(int rows, int cols) => SeatsRowsNumber(rows) && SeatsColsNumber(cols);
        #endregion
    }
}
