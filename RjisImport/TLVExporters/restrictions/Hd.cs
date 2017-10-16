using System;
using TlvSerialise;

namespace RjisImport.TLVExporters.Restrictions
{
    public class Hd : ITlvSerialisable
    {
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_HD_CF_MKR)] public char CfMarker { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_HD_CODE)] public string RestrictionCode { get; set; }
        [Tlv(TlvTypes.Date, TlvTags.ID_RESTRICTION_HD_DATE_FROM)] public DateTime DateFrom { get; set; }
        [Tlv(TlvTypes.Date, TlvTags.ID_RESTRICTION_HD_DATE_TO)] public DateTime DateTo { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_HD_DAYS)] public string Days { get; set; }
    }
}
