using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TlvSerialise;

namespace RjisImport
{
    internal class Program
    {
        static TLVExporters.Restrictions.RhList rhList = new TLVExporters.Restrictions.RhList();
        static TLVExporters.Restrictions.SdList sdList = new TLVExporters.Restrictions.SdList();

        private static void Main(string[] args)
        {
            try
            {
                var filename = "s:\\rjfaf628.rst";
                foreach (var line in File.ReadLines(filename).Where(x=>x.Length > 3))
                {
                    var iad = line[0];
                    var recordType = line.Substring(1, 2);
                    switch (recordType)
                    {
                        case "RH":
                            rhList.AddLine(line);
                            break;
                        case "SD":
                            sdList.AddLine(line);
                            break;
                        default:
                            break;
                    }
                }
                var rhTlvFilename = "RESTR_RH";
                using (var fs = new FileStream(rhTlvFilename, FileMode.Create, FileAccess.Write))
                {
                    byte[] header = new UTF8Encoding(true).GetBytes("TLtV0100");
                    fs.Write(header, 0, header.Length);
                    rhList.Serialise(fs);
                }

                var sdTlvFilename = "RESTR_SD";
                using (var fs = new FileStream(sdTlvFilename, FileMode.Create, FileAccess.Write))
                {
                    byte[] header = new UTF8Encoding(true).GetBytes("TLtV0100");
                    fs.Write(header, 0, header.Length);
                    sdList.Serialise(fs);
                }
            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }
        }
    }
}
