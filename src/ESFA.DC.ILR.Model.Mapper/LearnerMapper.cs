using System.Linq;
using ESFA.DC.ILR.Model.Mapper.Abstract;
using ESFA.DC.ILR.Model.Mapper.Extension;
using ESFA.DC.ILR.Model.Mapper.Interface;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class LearnerMapper : AbstractModelMapper<Loose.MessageLearner, MessageLearner>
    {
        private readonly IModelMapper<Loose.MessageLearnerContactPreference, MessageLearnerContactPreference> _contactPreferenceMapper;
        private readonly IModelMapper<Loose.MessageLearnerLLDDandHealthProblem, MessageLearnerLLDDandHealthProblem> _llddAndHealthProblemMapper;
        private readonly IModelMapper<Loose.MessageLearnerLearnerEmploymentStatus, MessageLearnerLearnerEmploymentStatus> _learnerEmploymentStatusMapper;
        private readonly IModelMapper<Loose.MessageLearnerLearnerFAM, MessageLearnerLearnerFAM> _learnerFamMapper;
        private readonly IModelMapper<Loose.MessageLearnerLearnerHE, MessageLearnerLearnerHE> _learnerHeMapper;
        private readonly IModelMapper<Loose.MessageLearnerLearningDelivery, MessageLearnerLearningDelivery> _learningDeliveryMapper;
        private readonly IModelMapper<Loose.MessageLearnerProviderSpecLearnerMonitoring, MessageLearnerProviderSpecLearnerMonitoring> _providerSpecLearnerMonitoringMapper;

        public LearnerMapper(
            IModelMapper<Loose.MessageLearnerContactPreference, MessageLearnerContactPreference> contactPreferenceMapper,
            IModelMapper<Loose.MessageLearnerLLDDandHealthProblem, MessageLearnerLLDDandHealthProblem> llddAndHealthProblemMapper,
            IModelMapper<Loose.MessageLearnerLearnerEmploymentStatus, MessageLearnerLearnerEmploymentStatus> learnerEmploymentStatusMapper,
            IModelMapper<Loose.MessageLearnerLearnerFAM, MessageLearnerLearnerFAM> learnerFamMapper,
            IModelMapper<Loose.MessageLearnerLearnerHE, MessageLearnerLearnerHE> learnerHeMapper,
            IModelMapper<Loose.MessageLearnerLearningDelivery, MessageLearnerLearningDelivery> learningDeliveryMapper,
            IModelMapper<Loose.MessageLearnerProviderSpecLearnerMonitoring, MessageLearnerProviderSpecLearnerMonitoring> providerSpecLearnerMonitoringMapper)
        {
            _contactPreferenceMapper = contactPreferenceMapper;
            _llddAndHealthProblemMapper = llddAndHealthProblemMapper;
            _learnerEmploymentStatusMapper = learnerEmploymentStatusMapper;
            _learnerFamMapper = learnerFamMapper;
            _learnerHeMapper = learnerHeMapper;
            _learningDeliveryMapper = learningDeliveryMapper;
            _providerSpecLearnerMonitoringMapper = providerSpecLearnerMonitoringMapper;
        }

        protected override MessageLearner MapModel(Loose.MessageLearner model)
        {
            return new MessageLearner()
            {
                Accom = (int)model.Accom,
                AccomSpecified = model.AccomSpecified,
                AddLine1 = model.AddLine1,
                AddLine2 = model.AddLine2,
                AddLine3 = model.AddLine3,
                AddLine4 = model.AddLine4,
                ALSCost = (int)model.ALSCost,
                ALSCostSpecified = model.ALSCostSpecified,
                CampId = model.CampId,
                ContactPreference = model.ContactPreference?.Select(cp => _contactPreferenceMapper.Map(cp)).ToArray(),
                DateOfBirth = model.DateOfBirth,
                DateOfBirthSpecified = model.DateOfBirthSpecified,
                Email = model.Email,
                EngGrade = model.EngGrade,
                Ethnicity = (int)model.Ethnicity,
                FamilyName = model.FamilyName,
                GivenNames = model.GivenNames,
                LLDDHealthProb = (int)model.LLDDHealthProb,
                LLDDandHealthProblem = model.LLDDandHealthProblem?.Select(p => _llddAndHealthProblemMapper.Map(p)).ToArray(),
                LearnRefNumber = model.LearnRefNumber,
                LearnerEmploymentStatus = model.LearnerEmploymentStatus?.Select(s => _learnerEmploymentStatusMapper.Map(s)).ToArray(),
                LearnerFAM = model.LearnerFAM?.Select(f => _learnerFamMapper.Map(f)).ToArray(),
                LearnerHE = _learnerHeMapper.Map(model.LearnerHE?.FirstOrDefault()),
                LearningDelivery = model.LearningDelivery?.Select(ld => _learningDeliveryMapper.Map(ld)).ToArray(),
                MathGrade = model.MathGrade,
                NINumber = model.NINumber,
                OTJHours = (int)model.OTJHours,
                OTJHoursSpecified = model.OTJHoursSpecified,
                PMUKPRN = (int)model.PMUKPRN,
                PMUKPRNSpecified = model.PMUKPRNSpecified,
                PlanEEPHours = (int)model.PlanEEPHours,
                PlanEEPHoursSpecified = model.PlanEEPHoursSpecified,
                PlanLearnHours = (int)model.PlanLearnHours,
                PlanLearnHoursSpecified = model.PlanLearnHoursSpecified,
                Postcode = model.Postcode.Sanitize(),
                PostcodePrior = model.PostcodePrior.Sanitize(),
                PrevLearnRefNumber = model.PrevLearnRefNumber,
                PrevUKPRN = (int)model.PrevUKPRN,
                PrevUKPRNSpecified = model.PrevUKPRNSpecified,
                PriorAttain = (int)model.PriorAttain,
                PriorAttainSpecified = model.PriorAttainSpecified,
                ProviderSpecLearnerMonitoring = model.ProviderSpecLearnerMonitoring?.Select(m => _providerSpecLearnerMonitoringMapper.Map(m)).ToArray(),
                Sex = model.Sex,
                TelNo = model.TelNo,
                ULN = model.ULN,
            };
        }
    }
}
