using Autofac;
using ESFA.DC.ILR.FileValidationService.Rules;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Modules
{
    public class ValidatorModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ContactPreferenceValidator>().As<IValidator<ILooseContactPreference>>();
            containerBuilder.RegisterType<LearnerFamValidator>().As<IValidator<ILooseLearnerFAM>>();
            containerBuilder.RegisterType<ProviderSpecLearnerMonitoringValidator>().As<IValidator<ILooseProviderSpecLearnerMonitoring>>();
            containerBuilder.RegisterType<EmploymentStatusMonitoringValidator>().As<IValidator<ILooseEmploymentStatusMonitoring>>();
            containerBuilder.RegisterType<LearnerEmploymentStatusValidator>().As<IValidator<ILooseLearnerEmploymentStatus>>();
            containerBuilder.RegisterType<LearnerHEFinancialSupportValidator>().As<IValidator<ILooseLearnerHEFinancialSupport>>();
            containerBuilder.RegisterType<LearnerHEValidator>().As<IValidator<ILooseLearnerHE>>();
            containerBuilder.RegisterType<LLDDAndHealthProblemValidator>().As<IValidator<ILooseLLDDAndHealthProblem>>();
            containerBuilder.RegisterType<LearnerValidator>().As<IValidator<ILooseLearner>>();
            containerBuilder.RegisterType<DPOutcomeValidator>().As<IValidator<ILooseDPOutcome>>();
            containerBuilder.RegisterType<LearnerDestinationAndProgressionValidator>().As<IValidator<ILooseLearnerDestinationAndProgression>>();
            containerBuilder.RegisterType<LearningDeliveryFAMValidator>().As<IValidator<ILooseLearningDeliveryFAM>>();
            containerBuilder.RegisterType<AppFinRecordValidator>().As<IValidator<ILooseAppFinRecord>>();
            containerBuilder.RegisterType<ProviderSpecDeliveryMonitoringValidator>().As<IValidator<ILooseProviderSpecDeliveryMonitoring>>();
            containerBuilder.RegisterType<LearningDeliveryHEValidator>().As<IValidator<ILooseLearningDeliveryHE>>();
            containerBuilder.RegisterType<LearningDeliveryWorkPlacementValidator>().As<IValidator<ILooseLearningDeliveryWorkPlacement>>();
            containerBuilder.RegisterType<LearningDeliveryValidator>().As<IValidator<ILooseLearningDelivery>>();
        }
    }
}
