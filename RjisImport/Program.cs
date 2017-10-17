using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TlvSerialise;

namespace RjisImport
{
    class TlvWriteInfo
    {
        public string Filename { get; set; }
        public ITlvSerialisable Serialisable { get; set; }
    };
    internal class Program
    {
        static TLVExporters.Restrictions.RhList rhList = new TLVExporters.Restrictions.RhList();
        static TLVExporters.Restrictions.SdList sdList = new TLVExporters.Restrictions.SdList();
        static TLVExporters.Restrictions.TtList ttList = new TLVExporters.Restrictions.TtList();
        static TLVExporters.Restrictions.TrList trList = new TLVExporters.Restrictions.TrList();

        private static void Main(string[] args)
        {
            var start = DateTime.Now;
            try
            {
                var filename = "s:\\rjfaf628.rst";
                foreach (var line in File.ReadLines(filename).Where(x => x.Length > 3))
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
                        case "TT":
                            ttList.AddLine(line);
                            break;
                        case "TR":
                            trList.AddLine(line);
                            break;
                        default:
                            break;
                    }
                }

                var tlvWriteList = new List<TlvWriteInfo>
                {
                    new TlvWriteInfo { Filename = "RESTR_RH", Serialisable = rhList },
                    new TlvWriteInfo { Filename = "RESTR_TR", Serialisable = trList },
                    new TlvWriteInfo { Filename = "RESTR_SD", Serialisable = sdList },
                    new TlvWriteInfo { Filename = "RESTR_TT", Serialisable = ttList }
                };

                foreach (var tlvwriteItem in tlvWriteList)
                {
                    using (var fs = new FileStream(tlvwriteItem.Filename, FileMode.Create, FileAccess.Write))
                    {
                        byte[] header = new UTF8Encoding(true).GetBytes("TLtV0100");
                        fs.Write(header, 0, header.Length);
                        tlvwriteItem.Serialisable.Serialise(fs);
                    }
                }
                var totaltime = (DateTime.Now - start).TotalSeconds;
                Console.WriteLine($"total time is {totaltime}");
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
