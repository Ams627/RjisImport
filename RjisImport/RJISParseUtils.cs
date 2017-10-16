using System;
using System.Collections.Generic;
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

        public static string GetDays(string line, int pos)
        {
            if (line.Substring(pos, 7).Any(x => x != 'Y' && x != 'N'))
            {
                throw new Exception($"Invalid day string: must contain only Y or N - found {line.Substring(pos, 7)}");
            }
            return line.Substring(pos, 7);
        }
    }
}
