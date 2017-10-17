using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TlvSerialise;

namespace RjisImport.TLVExporters.Restrictions
{
    [TlvSerialiseFile("RESTR_SD")]
    public class SdList : ITlvSerialisable
    {
        [Tlv(TlvTypes.UInt, TlvTags.ID_RESTRICTION_SD_NUMERO_VERSION)] public int Version { get; set; } = 0;
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_SD_IAP)] public string Iap { get; set; } = "ParkeonTVM";
        [Tlv(TlvTypes.Array, TlvTags.ID_RESTRICTION_SD_DESC)] public List<Sd> List { get; set; }
        public SdList()
        {
            List = new List<Sd>();
        }
        public void AddLine(string line)
        {
            List.Add(new Sd(line));
        }
    }

    [TlvSerialiseFile("RESTR_RH")]
    public class RhList : ITlvSerialisable
    {
        [Tlv(TlvTypes.UInt, TlvTags.ID_RESTRICTION_RH_NUMERO_VERSION)] public int Version { get; set; } = 0;
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_RH_IAP)] public string Iap { get; set; } = "ParkeonTVM";
        [Tlv(TlvTypes.Array, TlvTags.ID_RESTRICTION_RH_DESC)] public List<Rh> List { get; set; }

        public RhList()
        {
            List = new List<Rh>();
        }
        public void AddLine(string line)
        {
            List.Add(new Rh(line));
        }
    }

    [TlvSerialiseFile("RESTR_TT")]
    public class TtList : ITlvSerialisable
    {
        [Tlv(TlvTypes.UInt, TlvTags.ID_RESTRICTION_TT_NUMERO_VERSION)] public int Version { get; set; } = 0;
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_TT_IAP)] public string Iap { get; set; } = "ParkeonTVM";
        [Tlv(TlvTypes.Array, TlvTags.ID_RESTRICTION_TT_DESC)] public List<Tt> List { get; set; }

        public TtList()
        {
            List = new List<Tt>();
        }
        public void AddLine(string line)
        {
            List.Add(new Tt(line));
        }

    }

    [TlvSerialiseFile("RESTR_TR")]
    public class TrList : ITlvSerialisable
    {
        [Tlv(TlvTypes.UInt, TlvTags.ID_RESTRICTION_TR_NUMERO_VERSION)] public int Version { get; set; } = 0;
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_TR_IAP)] public string Iap { get; set; } = "ParkeonTVM";
        [Tlv(TlvTypes.Array, TlvTags.ID_RESTRICTION_TR_DESC)] public List<Tr> List { get; set; }

        public TrList()
        {
            List = new List<Tr>();
        }
        public void AddLine(string line)
        {
            List.Add(new Tr(line));
        }
    }
}
