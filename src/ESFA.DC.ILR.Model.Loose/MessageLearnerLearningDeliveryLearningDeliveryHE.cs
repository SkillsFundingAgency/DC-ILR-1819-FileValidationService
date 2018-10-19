using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerLearningDeliveryLearningDeliveryHE : ILooseLearningDeliveryHE
    {
        public long? TYPEYRNullable => tYPEYRFieldSpecified ? tYPEYRField : default(long?);

        public long? MODESTUDNullable => mODESTUDFieldSpecified ? mODESTUDField : default(long?);

        public long? FUNDLEVNullable => fUNDLEVFieldSpecified ? fUNDLEVField : default(long?);

        public long? FUNDCOMPNullable => fUNDCOMPFieldSpecified ? fUNDCOMPField : default(long?);

        public long? YEARSTUNullable => yEARSTUFieldSpecified ? yEARSTUField : default(long?);

        public long? MSTUFEENullable => mSTUFEEFieldSpecified ? mSTUFEEField : default(long?);

        public long? SPECFEENullable => sPECFEEFieldSpecified ? sPECFEEField : default(long?);

        public long? SOC2000Nullable => sOC2000FieldSpecified ? sOC2000Field : default(long?);

        public long? SECNullable => sECFieldSpecified ? sECField : default(long?);

        public long? NETFEENullable => nETFEEFieldSpecified ? nETFEEField : default(long?);

        public long? GROSSFEENullable => gROSSFEEFieldSpecified ? gROSSFEEField : default(long?);

        public long? ELQNullable => eLQFieldSpecified ? eLQField : default(long?);

        public decimal? STULOADNullable => sTULOADFieldSpecified ? sTULOADField : default(decimal?);

        public decimal? PCOLABNullable => pCOLABFieldSpecified ? pCOLABField : default(decimal?);

        public decimal? PCFLDCSNullable => pCFLDCSFieldSpecified ? pCFLDCSField : default(decimal?);

        public decimal? PCSLDCSNullable => pCSLDCSFieldSpecified ? pCSLDCSField : default(decimal?);

        public decimal? PCTLDCSNullable => pCTLDCSFieldSpecified ? pCTLDCSField : default(decimal?);
    }
}
