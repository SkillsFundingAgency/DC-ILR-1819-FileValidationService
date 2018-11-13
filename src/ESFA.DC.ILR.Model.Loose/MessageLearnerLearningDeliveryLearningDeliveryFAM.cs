using System;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerLearningDeliveryLearningDeliveryFAM : ILooseLearningDeliveryFAM
    {
        public DateTime? LearnDelFAMDateFromNullable => LearnDelFAMDateFromSpecified ? LearnDelFAMDateFrom : default(DateTime?);

        public DateTime? LearnDelFAMDateToNullable => LearnDelFAMDateToSpecified ? LearnDelFAMDateTo : default(DateTime?);
    }
}
