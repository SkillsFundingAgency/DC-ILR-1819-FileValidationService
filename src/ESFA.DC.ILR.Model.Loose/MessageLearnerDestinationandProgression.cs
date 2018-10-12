﻿using System;
using System.Collections.Generic;
using System.Text;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerDestinationandProgression : ILooseLearnerDestinationAndProgression
    {
        public IReadOnlyCollection<ILooseDPOutcome> DPOutcomes => dPOutcomeField;
    }
}