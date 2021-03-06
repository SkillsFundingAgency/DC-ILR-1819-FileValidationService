﻿using ESFA.DC.ILR.Model.Mapper.Abstract;
using ESFA.DC.ILR.Model.Mapper.Extension;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class LearnerFAMMapper : AbstractModelMapper<Loose.MessageLearnerLearnerFAM, MessageLearnerLearnerFAM>
    {
        protected override MessageLearnerLearnerFAM MapModel(Loose.MessageLearnerLearnerFAM model)
        {
            return new MessageLearnerLearnerFAM()
            {
                LearnFAMCode = (int)model.LearnFAMCode,
                LearnFAMType = model.LearnFAMType.Sanitize(),
            };
        }
    }
}
