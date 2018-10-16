using System;
using System.Collections.Generic;
using System.Text;

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
    }   
}
