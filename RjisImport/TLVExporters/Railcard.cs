using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TlvSerialise;

namespace RjisImport.TLVExporters
{
    class Railcard
    {
        public Railcard(string line)
        {
            RailcardCode = RJISParseUtils.GetRailcardCode(line, 0);
            (EndDate, StartDate, QuoteDate) = RJISParseUtils.GetEndStartQuoteDates(line, 3);
            HolderType = RJISParseUtils.GetAdultChild(line, 27);
            Description = line.Substring(28, 20);
            RestrictedByIssue = RJISParseUtils.GetYNAsBoolean(line, 48);
            RestrictedByArea = RJISParseUtils.GetYNAsBoolean(line, 49);
            RestrictedByTrain = RJISParseUtils.GetYNAsBoolean(line, 50);
            RestrictedByDate = RJISParseUtils.GetYNAsBoolean(line, 51);
            RailcardMasterCode = RJISParseUtils.GetRailcardCode(line, 52);
            MaxPassengers = RJISParseUtils.GetInt(line, 56, 3);
            MinPassengers = RJISParseUtils.GetInt(line, 59, 3);
            MaxHolders = RJISParseUtils.GetInt(line, 62, 3);
            MinHolders = RJISParseUtils.GetInt(line, 65, 3);
            MaxAccAdults = RJISParseUtils.GetInt(line, 68, 3);
            MinAccAdults = RJISParseUtils.GetInt(line, 71, 3);
            MaxAdults = RJISParseUtils.GetInt(line, 74, 3);
            MinAdults = RJISParseUtils.GetInt(line, 77, 3);
            MaxChildren = RJISParseUtils.GetInt(line, 80, 3);
            MinChildren = RJISParseUtils.GetInt(line, 83, 3);
            DiscountPrice = RJISParseUtils.GetInt(line, 94, 8);
            ValidMonths = RJISParseUtils.GetInt(line, 102, 2);
            ValidDays = RJISParseUtils.GetInt(line, 104, 2);
            LastValidDate = RJISParseUtils.GetDate(line, 106);
            CapriTicketCode = RJISParseUtils.GetThreeAlphaNumeric(line, 115);


        }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_CODE)] public string RailcardCode { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_END_DATE)] public DateTime EndDate { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_START_DATE)] public DateTime StartDate { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_QUOTE_DATE)] public DateTime QuoteDate { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_HOLDER_TYPE)] public char HolderType { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_DESCRIPTION)] public string Description { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_RESTRICTED_BY_ISSUE)] public bool RestrictedByIssue { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_RESTRICTED_BY_AREA)] public bool RestrictedByArea { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_RESTRICTED_BY_TRAIN)] public bool RestrictedByTrain { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_RESTRICTED_BY_DATE)] public bool RestrictedByDate { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_MASTER_CODE)] public string RailcardMasterCode { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_DISPLAY_FLAG)] public bool DisplayFlag { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_MAX_PASSENGERS)] public int MaxPassengers { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_MIN_PASSENGERS)] public int MinPassengers { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_MAX_HOLDERS)] public int MaxHolders { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_MIN_HOLDERS)] public int MinHolders { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_MAX_ACC_ADULTS)] public int MaxAccAdults { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_MIN_ACC_ADULTS)] public int MinAccAdults { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_MAX_ADULTS)] public int MaxAdults { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_MIN_ADULTS)] public int MinAdults { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_MAX_CHILDREN)] public int MaxChildren { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_MIN_CHILDREN)] public int MinChildren { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_DISCOUNTED_PRICE)] public int DiscountPrice { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_VAL_PERIOD_DAYS)] public int ValidMonths { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_VAL_PERIOD_MONTHS)] public int ValidDays { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_LAST_VALID_DATE)] public DateTime LastValidDate { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_CAPRI_TICKET_TYPE)] public string CapriTicketCode { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_ADULT_STATUS)] public string AdultStatus { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_CHILD_STATUS)] public string ChildStatus { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RAILCARD_AAA_STATUS)] public string AAAStatus { get; set; }
    }
}
