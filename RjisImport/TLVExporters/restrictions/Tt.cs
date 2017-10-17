using System.Diagnostics;
using TlvSerialise;

namespace RjisImport.TLVExporters.Restrictions
{
    public class Tt : ITlvSerialisable
    {
        public Tt(string line)
        {
            Debug.Assert(line.Length == 13);
            Debug.Assert(line.Substring(1, 2) == "TT");
            CfMarker = RJISParseUtils.GetCurrentFuture(line, 3);
            RestrictionCode = RJISParseUtils.GetRestrictionCode(line, 4);
            SeqNo = RJISParseUtils.GetInt(line, 6, 4);
            OutRet = RJISParseUtils.GetOutReturn(line, 10);
            TocCode = line.Substring(11, 2);
        }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_TT_CF_MKR)] public char CfMarker { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_TT_CODE)] public string RestrictionCode { get; set; }
        [Tlv(TlvTypes.UInt, TlvTags.ID_RESTRICTION_TT_SEQUENCE_NO)] public int SeqNo { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_TT_OUT_RET)] public char OutRet { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_TT_TOC_CODE)] public string TocCode { get; set; }
    }
}
