using System;
using System.Diagnostics;
using TlvSerialise;

namespace RjisImport.TLVExporters.Restrictions
{
    public class Sd : ITlvSerialisable
    {
        public Sd(string line)
        {
            Debug.Assert(line.Length == 28);
            Debug.Assert(line.Substring(1, 2) == "SD");
            CfMarker = RJISParseUtils.GetCurrentFuture(line, 3);
            RestrictionCode = RJISParseUtils.GetRestrictionCode(line, 4);
            TrainUID = line.Substring(6, 6);
            OutRet = RJISParseUtils.GetOutReturn(line, 12);
            DateFrom = RJISParseUtils.GetMMDD(line, 13);
            DateTo = RJISParseUtils.GetMMDD(line, 17);
            Days = RJISParseUtils.GetDays(line, 21);
        }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_SD_CF_MKR)] public char CfMarker { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_SD_CODE)] public string RestrictionCode { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_SD_TRAIN_NO)] public string TrainUID { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_SD_OUT_RET)] public char OutRet { get; set; }
        [Tlv(TlvTypes.Date, TlvTags.ID_RESTRICTION_SD_DATE_FROM)] public DateTime DateFrom  { get; set; }
        [Tlv(TlvTypes.Date, TlvTags.ID_RESTRICTION_SD_DATE_TO)] public DateTime DateTo { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_SD_DAYS)] public string Days { get; set; }
    }
}
