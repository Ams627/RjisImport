using TlvSerialise;
namespace RjisImport.TLVExporters.Restrictions
{
    public class Ec : ITlvSerialisable
    {
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_EC_CF_MKR)] public char CfMarker { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_EC_CODE)] public char ExceptionCode { get; set; }
        [Tlv(TlvTypes.String, TlvTags.ID_RESTRICTION_EC_DESCRIPTION)] public string Description { get; set; }
    }
}
