namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseLearningDeliveryHE
    {
        string NUMHUS { get; }
        string SSN { get; }
        string QUALENT3 { get; }
        string UCASAPPID { get; }
        string DOMICILE { get; }
        string HEPostCode { get; }

        long? TYPEYRNullable { get; }
        long? MODESTUDNullable { get; }
        long? FUNDLEVNullable { get; }
        long? FUNDCOMPNullable { get; }
        long? YEARSTUNullable { get; }
        long? MSTUFEENullable { get; }
        long? SPECFEENullable { get; }
        long? SOC2000Nullable { get; }
        long? SECNullable { get; }
        long? NETFEENullable { get; }
        long? GROSSFEENullable { get; }
        long? ELQNullable { get;  }

        decimal? STULOADNullable { get; }
        decimal? PCOLABNullable { get; }
        decimal? PCFLDCSNullable { get; }
        decimal? PCSLDCSNullable { get; }
        decimal? PCTLDCSNullable { get; }
    }   
}
