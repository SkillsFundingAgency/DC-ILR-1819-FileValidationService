﻿using ESFA.DC.ILR.Model.Mapper.Abstract;
using ESFA.DC.ILR.Model.Mapper.Extension;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class LearningDeliveryFAMMapper : AbstractModelMapper<Loose.MessageLearnerLearningDeliveryLearningDeliveryFAM, MessageLearnerLearningDeliveryLearningDeliveryFAM>
    {
        protected override MessageLearnerLearningDeliveryLearningDeliveryFAM MapModel(Loose.MessageLearnerLearningDeliveryLearningDeliveryFAM model)
        {
            return new MessageLearnerLearningDeliveryLearningDeliveryFAM()
            {
                LearnDelFAMCode = model.LearnDelFAMCode.Sanitize(),
                LearnDelFAMDateFrom = model.LearnDelFAMDateFrom,
                LearnDelFAMDateFromSpecified = model.LearnDelFAMDateFromSpecified,
                LearnDelFAMDateTo = model.LearnDelFAMDateTo,
                LearnDelFAMDateToSpecified = model.LearnDelFAMDateToSpecified,
                LearnDelFAMType = model.LearnDelFAMType.Sanitize(),
            };
        }
    }
}
