using System.Diagnostics;
using TlvSerialise;

namespace RjisImport.TLVExporters.Restrictions
{
    public class Rh : ITlvSerialisable
    {
        public Rh(string line)
        {
            Debug.Assert(line.Length == 139);
            Debug.Assert(line.Substring(1, 2) == "RH");
            CfMarker = RJISParseUtils.GetCurrentFuture(line, 3);
            RestrictionCode = RJISParseUtils.GetRestrictionCode(line, 4);
            Description = line.Substring(6, 30);
            DescOut = line.Substring(36, 50);
            DescReturn = line.Substring(86, 50);
            TypeOut = RJISParseUtils.GetPositiveNegative(line, 136);
            TypeRtn = RJISParseUtils.GetPositiveNegative(line, 137);
            ChangeInd = RJISParseUtils.GetYNAsBoolean(line, 138);
        }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_RH_CF_MKR)] public char CfMarker { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_RH_CODE)] public string RestrictionCode { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_RH_DESCRIPTION)] public string Description { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_RH_DESC_OUT)] public string DescOut { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_RH_DESC_RTN)] public string DescReturn { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_RH_TYPE_OUT)] public char TypeOut { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_RH_TYPE_RTN)] public char TypeRtn { get; set; }
        [Tlv(TlvTypes.BoolToZeroOne, TlvTags.ID_RESTRICTION_RH_CHANGE_IND)] public bool ChangeInd { get; set; }

    }
}
