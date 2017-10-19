using TlvSerialise;
using System;
using System.Diagnostics;

namespace RjisImport.TLVExporters.Restrictions
{
    public class Tr : ITlvSerialisable
    {
        public Tr(string line)
        {
            Debug.Assert(line.Length == 26);
            Debug.Assert(line.Substring(1, 2) == "TR");
            CfMarker = RJISParseUtils.GetCurrentFuture(line, 3);
            RestrictionCode = RJISParseUtils.GetRestrictionCode(line, 4);
            SeqNo = RJISParseUtils.GetInt(line, 6, 4);
            OutRet = RJISParseUtils.GetOutReturn(line, 10);
            TimeFrom = RJISParseUtils.GetHHMM(line, 11);
            TimeTo = RJISParseUtils.GetHHMM(line, 15);
            ArriveDepart = RJISParseUtils.GetArriveDepartVia(line, 19);
            LocationCrs = RJISParseUtils.GetCrsCode(line, 20);
            RestrictionType = RJISParseUtils.GetActualOrRunningTime(line, 23);
            TrainType = line[24];
            MinFareFlag = RJISParseUtils.GetYNAsBoolean(line, 25);


            Key = CfMarker + RestrictionCode + SeqNo + OutRet;
        }


        public string Key { get;  private set; }
        public bool IsDeleted { get; set; } = false;

        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_TR_CF_MKR)] public char CfMarker { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_TR_CODE)] public string RestrictionCode { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_TR_SEQUENCE_NO)] public int SeqNo { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_TR_OUT_RET)] public char OutRet { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_TR_TIME_FROM)] public DateTime TimeFrom { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_TR_TIME_TO)] public DateTime TimeTo { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_TR_ARR_DEP_VIA)] public char ArriveDepart { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_TR_LOCATION)] public string LocationCrs { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_TR_RSTR_TYPE)] public char RestrictionType { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_TR_TRAIN_TYPE)] public char TrainType { get; set; }
        [Tlv(TlvTypes.BoolToZeroOne, TlvTags.ID_RESTRICTION_TR_MIN_FARE_FLAG)] public bool MinFareFlag { get; set; }

    }
}
