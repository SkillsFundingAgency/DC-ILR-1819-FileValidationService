using System.Collections.Generic;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerLearningDelivery : ILooseLearningDelivery
    {
        public IReadOnlyCollection<ILooseLearningDeliveryFAM> LearningDeliveryFAMs => learningDeliveryFAMField;

        public IReadOnlyCollection<ILooseAppFinRecord> AppFinRecords => appFinRecordField;

        public IReadOnlyCollection<ILooseProviderSpecDeliveryMonitoring> ProviderSpecDeliveryMonitorings => providerSpecDeliveryMonitoringField;
    }
}
