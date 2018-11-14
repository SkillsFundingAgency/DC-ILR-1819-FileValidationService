using System;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerDestinationandProgressionDPOutcome : ILooseDPOutcome
    {
        public long? OutCodeNullable => outCodeFieldSpecified ? outCodeField : default(long?);

        public DateTime? OutStartDateNullable => outStartDateFieldSpecified ? outStartDateField : default(DateTime?);

        public DateTime? OutCollDateNullable => outCollDateFieldSpecified ? outCollDateField : default(DateTime?);

        public DateTime? OutEndDateNullable => outEndDateFieldSpecified ? outEndDateField : default(DateTime?);
    }
}
