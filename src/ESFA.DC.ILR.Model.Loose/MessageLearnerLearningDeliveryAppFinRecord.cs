using System;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerLearningDeliveryAppFinRecord : ILooseAppFinRecord
    {
        public long? AFinCodeNullable => aFinCodeFieldSpecified ? aFinCodeField : default(long?);

        public DateTime? AFinDateNullable => aFinDateFieldSpecified ? aFinDateField : default(DateTime?);

        public long? AFinAmountNullable => aFinAmountFieldSpecified ? aFinAmountField : default(long?);
    }
}
