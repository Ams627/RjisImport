using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RjisImport
{
    static class RJISParseUtils
    {
        public static char GetCurrentFuture(string line, int pos)
        {
            char c = line[pos];
            if (c != 'C' && c != 'F')
            {
                throw new Exception($"Current/Future marker must be 'C' or 'F' - found '{c}'");
            }
            return c;
        }
        public static char GetPositiveNegative(string line, int pos)
        {
            char c = line[pos];
            if (c != 'P' && c != 'N')
            {
                throw new Exception($"Positive/Negative marker must be 'C' or 'F' - found '{c}'");
            }
            return c;
        }
        public static char GetOutReturn(string line, int pos)
        {
            char c = line[pos];
            if (c != 'O' && c != 'R')
            {
                throw new Exception($"Outward/Return marker must be 'O' or 'R' - found '{c}'");
            }
            return c;
        }

        public static char GetArriveDepartVia(string line, int pos)
        {
            char c = line[pos];
            if (c != 'A' && c != 'D' && c != 'V')
            {
                throw new Exception($"Arrive/Depart/Via marker must be 'A', 'D' or 'V' - found '{c}'");
            }
            return c;
        }

        public static char GetActualOrRunningTime(string line, int pos)
        {
            char c = line[pos];
            if (c != 'A' && c != 'T')
            {
                throw new Exception($"Actual/Running marker must be 'A' or 'T' - found '{c}'");
            }
            return c;
        }



        public static bool GetYNAsBoolean(string line, int pos)
        {
            char c = line[pos];
            if (c != 'Y' && c != 'N')
            {
                throw new Exception($"Yes/No marker must be 'Y' or 'N' - found '{c}'");
            }
            return c == 'Y';
        }
        public static string GetRestrictionCode(string line, int pos)
        {
            char c1 = line[pos];
            char c2 = line[pos + 1];
            if (!char.IsLetterOrDigit(c1) || !char.IsLetterOrDigit(c2))
            {
                throw new Exception($"Invalid restriction code must be two alphanumerics - found '{"" + c1 + c2}'");
            }
            return "" + c1 + c2;
        }

        public static string GetCrsCode(string line, int pos)
        {
            string crs = line.Substring(pos, 3);
            if (!crs.All(x=>char.IsUpper(x) || x == ' '))
            {
                throw new Exception($"Invalid CRS code: must be three letters or three spaces - found '{crs}'");
            }
            return crs;
        }

        public static DateTime GetMMDD(string line, int pos)
        {
            if (!(line.Substring(pos, 4).All(char.IsDigit)))
            {
                throw new Exception($"Invalid date - found {line.Substring(pos, 4)}");
            }
            var y = 1970;
            var m = 10 * (line[pos] - '0') + line[pos + 1] - '0';
            var d = 10 * (line[pos + 2] - '0') + line[pos + 3] - '0';
            return new DateTime(y, m, d);
        }

        public static DateTime GetHHMM(string line, int pos)
        {
            if (!(line.Substring(pos, 4).All(char.IsDigit)))
            {
                throw new Exception($"Invalid time - found {line.Substring(pos, 4)}");
            }
            var h = 10 * (line[pos] - '0') + line[pos + 1] - '0';
            var m = 10 * (line[pos + 2] - '0') + line[pos + 3] - '0';
            if (h > 23 || m > 59)
            {
                throw new Exception($"Invalid time - found {line.Substring(pos, 4)}");
            }
            return new DateTime(1970, 1, 1, h, m, 0);
        }

        /// <summary>
        /// Return end start quote dates as a tuple.
        /// </summary>
        /// <param name="line">RJIS file input line</param>
        /// <param name="pos">position on line of first character of end date</param>
        /// <returns>A 3-tuple holding all three parsed dates as DateTimes</returns>
        public static (DateTime, DateTime, DateTime) GetEndStartQuoteDates(string line, int pos)
        {
            bool res = DateTime.TryParseExact(line.Substring(pos, 8), "ddmmyyyy", CultureInfo.InvariantCulture,  DateTimeStyles.None, out var endDate);
            if (!res)
            {
                throw new Exception($"Invalid end date string: found {line.Substring(pos, 8)}");
            }
            res = DateTime.TryParseExact(line.Substring(pos, 8), "ddmmyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var startDate);
            if (!res)
            {
                throw new Exception($"Invalid start date string: found {line.Substring(pos + 8, 8)}");
            }
            res = DateTime.TryParseExact(line.Substring(pos, 8), "ddmmyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var quoteDate);
            if (!res)
            {
                throw new Exception($"Invalid quote date string: found {line.Substring(pos + 16, 8)}");
            }
            return (endDate, startDate, quoteDate);
        }

        public static string GetDays(string line, int pos)
        {
            if (line.Substring(pos, 7).Any(x => x != 'Y' && x != 'N'))
            {
                throw new Exception($"Invalid day string: must contain only Y or N - found {line.Substring(pos, 7)}");
            }
            return line.Substring(pos, 7);
        }
        public static int GetInt(string line, int pos, int length)
        {
            int result = 0;
            foreach (var c in line.Substring(pos, length))
            {
                if (!char.IsDigit(c))
                {
                    throw new Exception($"Invalid character in integer - found {c}");
                }
                result = 10 * result + c - '0';
            }
            return result;
        }

    }
}
