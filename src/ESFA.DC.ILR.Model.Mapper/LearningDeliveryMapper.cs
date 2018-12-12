using System;
using System.Linq;
using ESFA.DC.ILR.Model.Mapper.Abstract;
using ESFA.DC.ILR.Model.Mapper.Extension;
using ESFA.DC.ILR.Model.Mapper.Interface;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class LearningDeliveryMapper : AbstractModelMapper<Loose.MessageLearnerLearningDelivery, MessageLearnerLearningDelivery>
    {
        private readonly IModelMapper<Loose.MessageLearnerLearningDeliveryAppFinRecord, MessageLearnerLearningDeliveryAppFinRecord> _appFinRecordMapper;
        private readonly IModelMapper<Loose.MessageLearnerLearningDeliveryLearningDeliveryFAM, MessageLearnerLearningDeliveryLearningDeliveryFAM> _learningDeliveryFamMapper;
        private readonly IModelMapper<Loose.MessageLearnerLearningDeliveryLearningDeliveryHE, MessageLearnerLearningDeliveryLearningDeliveryHE> _learningDeliveryHeMapper;
        private readonly IModelMapper<Loose.MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement, MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement> _learningDeliveryWorkPlacementMapper;
        private readonly IModelMapper<Loose.MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring, MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring> _providerSpecDeliveryMonitoringMapper;

        public LearningDeliveryMapper(
            IModelMapper<Loose.MessageLearnerLearningDeliveryAppFinRecord, MessageLearnerLearningDeliveryAppFinRecord> appFinRecordMapper,
            IModelMapper<Loose.MessageLearnerLearningDeliveryLearningDeliveryFAM, MessageLearnerLearningDeliveryLearningDeliveryFAM> learningDeliveryFamMapper,
            IModelMapper<Loose.MessageLearnerLearningDeliveryLearningDeliveryHE, MessageLearnerLearningDeliveryLearningDeliveryHE> learningDeliveryHeMapper,
            IModelMapper<Loose.MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement, MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement> learningDeliveryWorkPlacementMapper,
            IModelMapper<Loose.MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring, MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring> providerSpecDeliveryMonitoringMapper)
        {
            _appFinRecordMapper = appFinRecordMapper;
            _learningDeliveryFamMapper = learningDeliveryFamMapper;
            _learningDeliveryHeMapper = learningDeliveryHeMapper;
            _learningDeliveryWorkPlacementMapper = learningDeliveryWorkPlacementMapper;
            _providerSpecDeliveryMonitoringMapper = providerSpecDeliveryMonitoringMapper;
        }

        protected override MessageLearnerLearningDelivery MapModel(Loose.MessageLearnerLearningDelivery model)
        {
            return new MessageLearnerLearningDelivery()
            {
                AchDate = model.AchDate,
                AchDateSpecified = model.AchDateSpecified,
                AddHours = (int)model.AddHours,
                AddHoursSpecified = model.AddHoursSpecified,
                AimSeqNumber = (int)model.AimSeqNumber,
                AimType = (int)model.AimType,
                AppFinRecord = model.AppFinRecord?.Select(r => _appFinRecordMapper.Map(r)).ToArray(),
                CompStatus = (int)model.CompStatus,
                ConRefNumber = model.ConRefNumber,
                DelLocPostCode = model.DelLocPostCode.Sanitize(),
                EPAOrgID = model.EPAOrgID,
                EmpOutcome = (int)model.EmpOutcome,
                EmpOutcomeSpecified = model.EmpOutcomeSpecified,
                FundModel = (int)model.FundModel,
                FworkCode = (int)model.FworkCode,
                FworkCodeSpecified = model.FworkCodeSpecified,
                LearnActEndDate = model.LearnActEndDate,
                LearnActEndDateSpecified = model.LearnActEndDateSpecified,
                LearnAimRef = model.LearnAimRef,
                LearnPlanEndDate = model.LearnPlanEndDate,
                LearnStartDate = model.LearnStartDate,
                LearningDeliveryFAM = model.LearningDeliveryFAM?.Select(f => _learningDeliveryFamMapper.Map(f)).ToArray(),
                LearningDeliveryHE = _learningDeliveryHeMapper.Map(model.LearningDeliveryHE?.FirstOrDefault()),
                LearningDeliveryWorkPlacement = model.LearningDeliveryWorkPlacement?.Select(wp => _learningDeliveryWorkPlacementMapper.Map(wp)).ToArray(),
                OrigLearnStartDate = model.OrigLearnStartDate,
                OrigLearnStartDateSpecified = model.OrigLearnStartDateSpecified,
                OtherFundAdj = (int)model.OtherFundAdj,
                OtherFundAdjSpecified = model.OtherFundAdjSpecified,
                OutGrade = model.OutGrade,
                Outcome = (int)model.Outcome,
                OutcomeSpecified = model.OutcomeSpecified,
                PartnerUKPRN = (int)model.PartnerUKPRN,
                PartnerUKPRNSpecified = model.PartnerUKPRNSpecified,
                PriorLearnFundAdj = (int)model.PriorLearnFundAdj,
                PriorLearnFundAdjSpecified = model.PriorLearnFundAdjSpecified,
                ProgType = (int)model.ProgType,
                ProgTypeSpecified = model.ProgTypeSpecified,
                ProviderSpecDeliveryMonitoring = model.ProviderSpecDeliveryMonitoring?.Select(m => _providerSpecDeliveryMonitoringMapper.Map(m)).ToArray(),
                PwayCode = (int)model.PwayCode,
                PwayCodeSpecified = model.PwayCodeSpecified,
                SWSupAimId = model.SWSupAimId,
                StdCode = (int)model.StdCode,
                StdCodeSpecified = model.StdCodeSpecified,
                WithdrawReason = (int)model.WithdrawReason,
                WithdrawReasonSpecified = model.WithdrawReasonSpecified,
            };
        }
    }
}
