using ESFA.DC.ILR.Model.Mapper.Interface;
using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class LearnerMapperTests : AbstractMapperTests<Model.Loose.MessageLearner, MessageLearner>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_Accom()
        {
            TestMapperProperty(NewMapper(), m => m.Accom, TestIntSizedLong, m => m.Accom, TestInt);
        }

        [Fact]
        public void Map_AccomSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.AccomSpecified, TestBool, m => m.AccomSpecified, TestBool);
        }

        [Fact]
        public void Map_AddLine1()
        {
            TestMapperProperty(NewMapper(), m => m.AddLine1, TestString, m => m.AddLine1, TestString);
        }

        [Fact]
        public void Map_AddLine2()
        {
            TestMapperProperty(NewMapper(), m => m.AddLine2, TestString, m => m.AddLine2, TestString);
        }

        [Fact]
        public void Map_AddLine3()
        {
            TestMapperProperty(NewMapper(), m => m.AddLine3, TestString, m => m.AddLine3, TestString);
        }

        [Fact]
        public void Map_AddLine4()
        {
            TestMapperProperty(NewMapper(), m => m.AddLine4, TestString, m => m.AddLine4, TestString);
        }

        [Fact]
        public void Map_ALSCost()
        {
            TestMapperProperty(NewMapper(), m => m.ALSCost, TestIntSizedLong, m => m.ALSCost, TestInt);
        }

        [Fact]
        public void Map_ALSCostSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.ALSCostSpecified, TestBool, m => m.ALSCostSpecified, TestBool);
        }

        [Fact]
        public void Map_CampId()
        {
            TestMapperProperty(NewMapper(), m => m.CampId, TestString, m => m.CampId, TestString);
        }

        [Fact]
        public void Map_ContactPreference()
        {

            var inputCollection = NewArrayContaining<Loose.MessageLearnerContactPreference>();
            var outputCollection = NewArrayContaining<MessageLearnerContactPreference>();

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(propertyMapper);

            TestMapperCollectionProperty(mapper, m => m.ContactPreference, inputCollection, m => m.ContactPreference, outputCollection);
        }

        [Fact]
        public void Map_DateOfBirth()
        {
            TestMapperProperty(NewMapper(), m => m.DateOfBirth, TestDateTime, m => m.DateOfBirth, TestDateTime);
        }

        [Fact]
        public void Map_DateOfBirthSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.DateOfBirthSpecified, TestBool, m => m.DateOfBirthSpecified, TestBool);
        }

        [Fact]
        public void Map_Email()
        {
            TestMapperProperty(NewMapper(), m => m.Email, TestString, m => m.Email, TestString);
        }

        [Fact]
        public void Map_EngGrade()
        {
            TestMapperProperty(NewMapper(), m => m.EngGrade, TestString, m => m.EngGrade, TestString);
        }

        [Fact]
        public void Map_Ethnicity()
        {
            TestMapperProperty(NewMapper(), m => m.Ethnicity, TestIntSizedLong, m => m.Ethnicity, TestInt);
        }

        [Fact]
        public void Map_FamilyName()
        {
            TestMapperProperty(NewMapper(), m => m.FamilyName, TestString, m => m.FamilyName, TestString);
        }

        [Fact]
        public void Map_GivenNames()
        {
            TestMapperProperty(NewMapper(), m => m.GivenNames, TestString, m => m.GivenNames, TestString);
        }

        [Fact]
        public void Map_LLDDHealthProb()
        {
            TestMapperProperty(NewMapper(), m => m.LLDDHealthProb, TestIntSizedLong, m => m.LLDDHealthProb, TestInt);
        }
        
        [Fact]
        public void Map_LLDDandHealthProblem()
        {
            var inputCollection = NewArrayContaining<Loose.MessageLearnerLLDDandHealthProblem>();
            var outputCollection = NewArrayContaining<MessageLearnerLLDDandHealthProblem>();

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(llddAndHealthProblemMapper: propertyMapper);

            TestMapperCollectionProperty(mapper, m => m.LLDDandHealthProblem, inputCollection, m => m.LLDDandHealthProblem, outputCollection);
        }

        [Fact]
        public void Map_LearnRefNumber()
        {
            TestMapperProperty(NewMapper(), m => m.LearnRefNumber, TestString, m => m.LearnRefNumber, TestString);
        }

        [Fact]
        public void Map_LearnerEmploymentStatus()
        {
            var inputCollection = NewArrayContaining<Loose.MessageLearnerLearnerEmploymentStatus>();
            var outputCollection = NewArrayContaining<MessageLearnerLearnerEmploymentStatus>();

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(learnerEmploymentStatusMapper: propertyMapper);

            TestMapperCollectionProperty(mapper, m => m.LearnerEmploymentStatus, inputCollection, m => m.LearnerEmploymentStatus, outputCollection);
        }

        [Fact]
        public void Map_LearnerFAM()
        {
            var inputCollection = NewArrayContaining<Loose.MessageLearnerLearnerFAM>();
            var outputCollection = NewArrayContaining<MessageLearnerLearnerFAM>();

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(learnerFamMapper: propertyMapper);

            TestMapperCollectionProperty(mapper, m => m.LearnerFAM, inputCollection, m => m.LearnerFAM, outputCollection);
        }

        [Fact]
        public void Map_LearnerHE()
        {
            var outputItem = new MessageLearnerLearnerHE();

            var inputCollection = NewArrayContaining<Loose.MessageLearnerLearnerHE>(1);
            var outputCollection = new[] { outputItem };

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(learnerHeMapper: propertyMapper);

            TestMapperEntityProperty(mapper, m => m.LearnerHE, inputCollection, m => m.LearnerHE, outputItem);
        }

        [Fact]
        public void Map_LearnerDelivery()
        {
            var inputCollection = NewArrayContaining<Loose.MessageLearnerLearningDelivery>();
            var outputCollection = NewArrayContaining<MessageLearnerLearningDelivery>();

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(learningDeliveryMapper: propertyMapper);

            TestMapperCollectionProperty(mapper, m => m.LearningDelivery, inputCollection, m => m.LearningDelivery, outputCollection);
        }

        [Fact]
        public void Map_MathGrade()
        {
            TestMapperProperty(NewMapper(), m => m.MathGrade, TestString, m => m.MathGrade, TestString);
        }

        [Fact]
        public void Map_NINumber()
        {
            TestMapperProperty(NewMapper(), m => m.NINumber, TestString, m => m.NINumber, TestString);
        }

        [Fact]
        public void Map_OTJHours()
        {
            TestMapperProperty(NewMapper(), m => m.OTJHours, TestIntSizedLong, m => m.OTJHours, TestInt);
        }

        [Fact]
        public void Map_OTJHoursSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.OTJHoursSpecified, TestBool, m => m.OTJHoursSpecified, TestBool);
        }

        [Fact]
        public void Map_PMUKPRN()
        {
            TestMapperProperty(NewMapper(), m => m.PMUKPRN, TestIntSizedLong, m => m.PMUKPRN, TestInt);
        }

        [Fact]
        public void Map_PMUKPRNSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.PMUKPRNSpecified, TestBool, m => m.PMUKPRNSpecified, TestBool);
        }

        [Fact]
        public void Map_PlanEEPHours()
        {
            TestMapperProperty(NewMapper(), m => m.PlanEEPHours, TestIntSizedLong, m => m.PlanEEPHours, TestInt);
        }

        [Fact]
        public void Map_PlanEEPHoursSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.PlanEEPHoursSpecified, TestBool, m => m.PlanEEPHoursSpecified, TestBool);
        }

        [Fact]
        public void Map_PlanLearnHours()
        {
            TestMapperProperty(NewMapper(), m => m.PlanLearnHours, TestIntSizedLong, m => m.PlanLearnHours, TestInt);
        }

        [Fact]
        public void Map_PlanLearnHoursSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.PlanLearnHoursSpecified, TestBool, m => m.PlanLearnHoursSpecified, TestBool);
        }

        [Fact]
        public void Map_Postcode()
        {
            TestMapperProperty(NewMapper(), m => m.Postcode, TestString, m => m.Postcode, TestString);
            TestMapperProperty(NewMapper(), m => m.Postcode, TestStringTrailingWhiteSpace, m => m.Postcode, TestString);
        }

        [Fact]
        public void Map_PostcodePrior()
        {
            TestMapperProperty(NewMapper(), m => m.PostcodePrior, TestString, m => m.PostcodePrior, TestString);
            TestMapperProperty(NewMapper(), m => m.PostcodePrior, TestStringTrailingWhiteSpace, m => m.PostcodePrior, TestString);
        }

        [Fact]
        public void Map_PrevLearnRefNumber()
        {
            TestMapperProperty(NewMapper(), m => m.PrevLearnRefNumber, TestString, m => m.PrevLearnRefNumber, TestString);
        }

        [Fact]
        public void Map_PrevUKPRN()
        {
            TestMapperProperty(NewMapper(), m => m.PrevUKPRN, TestIntSizedLong, m => m.PrevUKPRN, TestInt);
        }

        [Fact]
        public void Map_PrevUKPRNSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.PrevUKPRNSpecified, TestBool, m => m.PrevUKPRNSpecified, TestBool);
        }

        [Fact]
        public void Map_PriorAttain()
        {
            TestMapperProperty(NewMapper(), m => m.PriorAttain, TestIntSizedLong, m => m.PriorAttain, TestInt);
        }

        [Fact]
        public void Map_PriorAttainSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.PriorAttainSpecified, TestBool, m => m.PriorAttainSpecified, TestBool);
        }

        [Fact]
        public void Map_ProviderSpecLearnerMonitoring()
        {
            var inputCollection = NewArrayContaining<Loose.MessageLearnerProviderSpecLearnerMonitoring>();
            var outputCollection = NewArrayContaining<MessageLearnerProviderSpecLearnerMonitoring>();

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(providerSpecLearnerMonitoringMapper: propertyMapper);

            TestMapperCollectionProperty(mapper, m => m.ProviderSpecLearnerMonitoring, inputCollection, m => m.ProviderSpecLearnerMonitoring, outputCollection);
        }

        [Fact]
        public void Map_Sex()
        {
            TestMapperProperty(NewMapper(), m => m.Sex, TestString, m => m.Sex, TestString);
        }

        [Fact]
        public void Map_TelNo()
        {
            TestMapperProperty(NewMapper(), m => m.TelNo, TestString, m => m.TelNo, TestString);
        }

        [Fact]
        public void Map_ULN()
        {
            TestMapperProperty(NewMapper(), m => m.ULN, TestLong, m => m.ULN, TestLong);
        }
        
        private LearnerMapper NewMapper(
            IModelMapper<Loose.MessageLearnerContactPreference, MessageLearnerContactPreference> contactPreferenceMapper = null,
            IModelMapper<Loose.MessageLearnerLLDDandHealthProblem, MessageLearnerLLDDandHealthProblem> llddAndHealthProblemMapper = null,
            IModelMapper<Loose.MessageLearnerLearnerEmploymentStatus, MessageLearnerLearnerEmploymentStatus> learnerEmploymentStatusMapper = null,
            IModelMapper<Loose.MessageLearnerLearnerFAM, MessageLearnerLearnerFAM> learnerFamMapper = null,
            IModelMapper<Loose.MessageLearnerLearnerHE, MessageLearnerLearnerHE> learnerHeMapper = null,
            IModelMapper<Loose.MessageLearnerLearningDelivery, MessageLearnerLearningDelivery> learningDeliveryMapper = null,
            IModelMapper<Loose.MessageLearnerProviderSpecLearnerMonitoring, MessageLearnerProviderSpecLearnerMonitoring> providerSpecLearnerMonitoringMapper = null)
        {
            return new LearnerMapper(
                contactPreferenceMapper ?? Mock.Of<IModelMapper<Loose.MessageLearnerContactPreference, MessageLearnerContactPreference>>(),
                llddAndHealthProblemMapper ?? Mock.Of<IModelMapper<Loose.MessageLearnerLLDDandHealthProblem, MessageLearnerLLDDandHealthProblem>>(),
                learnerEmploymentStatusMapper ?? Mock.Of<IModelMapper<Loose.MessageLearnerLearnerEmploymentStatus, MessageLearnerLearnerEmploymentStatus>>(),
                learnerFamMapper ?? Mock.Of<IModelMapper<Loose.MessageLearnerLearnerFAM, MessageLearnerLearnerFAM>>(),
                learnerHeMapper ?? Mock.Of<IModelMapper<Loose.MessageLearnerLearnerHE, MessageLearnerLearnerHE>>(),
                learningDeliveryMapper ?? Mock.Of<IModelMapper<Loose.MessageLearnerLearningDelivery, MessageLearnerLearningDelivery>>(),
                providerSpecLearnerMonitoringMapper ?? Mock.Of<IModelMapper<Loose.MessageLearnerProviderSpecLearnerMonitoring, MessageLearnerProviderSpecLearnerMonitoring>>());
        }
    }
}
