using System;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseLearningDeliveryFAM
    {
        string LearnDelFAMType { get; }

        string LearnDelFAMCode { get; }

        DateTime? LearnDelFAMDateFromNullable { get; }

        DateTime? LearnDelFAMDateToNullable { get; }
    }
}
