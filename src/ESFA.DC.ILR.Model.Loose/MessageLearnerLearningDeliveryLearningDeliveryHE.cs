using System;
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
    }
}
