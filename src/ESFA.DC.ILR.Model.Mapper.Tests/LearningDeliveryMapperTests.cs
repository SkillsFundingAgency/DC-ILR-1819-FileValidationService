using ESFA.DC.ILR.Model.Mapper.Interface;
using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class LearningDeliveryMapperTests : AbstractMapperTests<Loose.MessageLearnerLearningDelivery, MessageLearnerLearningDelivery>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_AchDate()
        {
            TestMapperProperty(NewMapper(), m => m.AchDate, TestDateTime, m => m.AchDate, TestDateTime);
        }

        [Fact]
        public void Map_AchDateSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.AchDateSpecified, TestBool, m => m.AchDateSpecified, TestBool);
        }

        [Fact]
        public void Map_AddHours()
        {
            TestMapperProperty(NewMapper(), m => m.AddHours, TestIntSizedLong, m => m.AddHours, TestInt);
        }

        [Fact]
        public void Map_AddHoursSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.AddHoursSpecified, TestBool, m => m.AddHoursSpecified, TestBool);
        }

        [Fact]
        public void Map_AimSeqNumber()
        {
            TestMapperProperty(NewMapper(), m => m.AimSeqNumber, TestIntSizedLong, m => m.AimSeqNumber, TestInt);
        }

        [Fact]
        public void Map_AimType()
        {
            TestMapperProperty(NewMapper(), m => m.AimType, TestIntSizedLong, m => m.AimType, TestInt);
        }

        [Fact]
        public void Map_AppFinRecord()
        {
            var inputCollection = NewArrayContaining<Loose.MessageLearnerLearningDeliveryAppFinRecord>();
            var outputCollection = NewArrayContaining<MessageLearnerLearningDeliveryAppFinRecord>();

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(propertyMapper);

            TestMapperCollectionProperty(mapper, m => m.AppFinRecord, inputCollection, m => m.AppFinRecord, outputCollection);
        }

        [Fact]
        public void Map_CompStatus()
        {
            TestMapperProperty(NewMapper(), m => m.CompStatus, TestIntSizedLong, m => m.CompStatus, TestInt);
        }

        [Fact]
        public void Map_ConRefNumber()
        {
            TestMapperProperty(NewMapper(), m => m.ConRefNumber, TestString, m => m.ConRefNumber, TestString);
            TestMapperProperty(NewMapper(), m => m.ConRefNumber, TestStringLeadingAndTrailingWhiteSpace, m => m.ConRefNumber, TestString);
        }

        [Fact]
        public void Map_DelLocPostCode()
        {
            TestMapperProperty(NewMapper(), m => m.DelLocPostCode, TestString, m => m.DelLocPostCode, TestString);
            TestMapperProperty(NewMapper(), m => m.DelLocPostCode, TestStringLeadingAndTrailingWhiteSpace, m => m.DelLocPostCode, TestString);
        }

        [Fact]
        public void Map_EPAOrgID()
        {
            TestMapperProperty(NewMapper(), m => m.EPAOrgID, TestString, m => m.EPAOrgID, TestString);
            TestMapperProperty(NewMapper(), m => m.EPAOrgID, TestStringLeadingAndTrailingWhiteSpace, m => m.EPAOrgID, TestString);
        }

        [Fact]
        public void Map_EmpOutcome()
        {
            TestMapperProperty(NewMapper(), m => m.EmpOutcome, TestIntSizedLong, m => m.EmpOutcome, TestInt);
        }

        [Fact]
        public void Map_EmpOutcomeSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.EmpOutcomeSpecified, TestBool, m => m.EmpOutcomeSpecified, TestBool);
        }

        [Fact]
        public void Map_FundModel()
        {
            TestMapperProperty(NewMapper(), m => m.EmpOutcome, TestIntSizedLong, m => m.EmpOutcome, TestInt);
        }

        [Fact]
        public void Map_FworkCode()
        {
            TestMapperProperty(NewMapper(), m => m.FworkCode, TestIntSizedLong, m => m.FworkCode, TestInt);
        }

        [Fact]
        public void Map_FworkCodeSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.FworkCodeSpecified, TestBool, m => m.FworkCodeSpecified, TestBool);
        }

        [Fact]
        public void Map_LearnActEndDate()
        {
            TestMapperProperty(NewMapper(), m => m.LearnActEndDate, TestDateTime, m => m.LearnActEndDate, TestDateTime);
        }

        [Fact]
        public void Map_LearnActEndDateSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.LearnActEndDateSpecified, TestBool, m => m.LearnActEndDateSpecified, TestBool);
        }

        [Fact]
        public void Map_LearnAimRef()
        {
            TestMapperProperty(NewMapper(), m => m.LearnAimRef, TestString, m => m.LearnAimRef, TestString);
            TestMapperProperty(NewMapper(), m => m.LearnAimRef, TestStringLeadingAndTrailingWhiteSpace, m => m.LearnAimRef, TestString);
        }

        [Fact]
        public void Map_LearnPlanEndDate()
        {
            TestMapperProperty(NewMapper(), m => m.LearnPlanEndDate, TestDateTime, m => m.LearnPlanEndDate, TestDateTime);
        }

        [Fact]
        public void Map_LearnStartDate()
        {
            TestMapperProperty(NewMapper(), m => m.LearnStartDate, TestDateTime, m => m.LearnStartDate, TestDateTime);
        }

        [Fact]
        public void Map_LearningDeliveryFAM()
        {
            var inputCollection = NewArrayContaining<Loose.MessageLearnerLearningDeliveryLearningDeliveryFAM>();
            var outputCollection = NewArrayContaining<MessageLearnerLearningDeliveryLearningDeliveryFAM>();

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(learningDeliveryFamMapper: propertyMapper);

            TestMapperCollectionProperty(mapper, m => m.LearningDeliveryFAM, inputCollection, m => m.LearningDeliveryFAM, outputCollection);
        }

        [Fact]
        public void Map_LearningDeliveryHE()
        {
            var outputItem = new MessageLearnerLearningDeliveryLearningDeliveryHE();

            var inputCollection = NewArrayContaining<Loose.MessageLearnerLearningDeliveryLearningDeliveryHE>(1);
            var outputCollection = new[] { outputItem };

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(learningDeliveryHeMapper: propertyMapper);

            TestMapperEntityProperty(mapper, m => m.LearningDeliveryHE, inputCollection, m => m.LearningDeliveryHE, outputItem);
        }

        [Fact]
        public void Map_LearningDeliveryWorkPlacement()
        {
            var inputCollection = NewArrayContaining<Loose.MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement>();
            var outputCollection = NewArrayContaining<MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement>();

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(learningDeliveryWorkPlacementMapper: propertyMapper);

            TestMapperCollectionProperty(mapper, m => m.LearningDeliveryWorkPlacement, inputCollection, m => m.LearningDeliveryWorkPlacement, outputCollection);
        }

        [Fact]
        public void Map_OrigLearnStartDate()
        {
            TestMapperProperty(NewMapper(), m => m.OrigLearnStartDate, TestDateTime, m => m.OrigLearnStartDate, TestDateTime);
        }

        [Fact]
        public void Map_OrigLearnStartDateSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.OrigLearnStartDateSpecified, TestBool, m => m.OrigLearnStartDateSpecified, TestBool);
        }

        [Fact]
        public void Map_OtherFundAdj()
        {
            TestMapperProperty(NewMapper(), m => m.OtherFundAdj, TestIntSizedLong, m => m.OtherFundAdj, TestInt);
        }

        [Fact]
        public void Map_OtherFundAdjSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.OtherFundAdjSpecified, TestBool, m => m.OtherFundAdjSpecified, TestBool);
        }

        [Fact]
        public void Map_OutGrade()
        {
            TestMapperProperty(NewMapper(), m => m.OutGrade, TestString, m => m.OutGrade, TestString);
            TestMapperProperty(NewMapper(), m => m.OutGrade, TestStringLeadingAndTrailingWhiteSpace, m => m.OutGrade, TestString);
        }

        [Fact]
        public void Map_Outcome()
        {
            TestMapperProperty(NewMapper(), m => m.Outcome, TestIntSizedLong, m => m.Outcome, TestInt);
        }
        
        [Fact]
        public void Map_OutcomeSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.OutcomeSpecified, TestBool, m => m.OutcomeSpecified, TestBool);
        }

        [Fact]
        public void Map_PartnerUKPRN()
        {
            TestMapperProperty(NewMapper(), m => m.PartnerUKPRN, TestIntSizedLong, m => m.PartnerUKPRN, TestInt);
        }

        [Fact]
        public void Map_PartnerUKPRNSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.PartnerUKPRNSpecified, TestBool, m => m.PartnerUKPRNSpecified, TestBool);
        }

        [Fact]
        public void Map_PriorLearnFundAdj()
        {
            TestMapperProperty(NewMapper(), m => m.PriorLearnFundAdj, TestIntSizedLong, m => m.PriorLearnFundAdj, TestInt);
        }

        [Fact]
        public void Map_PriorLearnFundAdjSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.PriorLearnFundAdjSpecified, TestBool, m => m.PriorLearnFundAdjSpecified, TestBool);
        }

        [Fact]
        public void Map_ProgType()
        {
            TestMapperProperty(NewMapper(), m => m.ProgType, TestIntSizedLong, m => m.ProgType, TestInt);
        }

        [Fact]
        public void Map_ProgTypeSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.ProgTypeSpecified, TestBool, m => m.ProgTypeSpecified, TestBool);
        }

        [Fact]
        public void Map_ProviderSpecDeliveryMonitoring()
        {
            var inputCollection = NewArrayContaining<Loose.MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring>();
            var outputCollection = NewArrayContaining<MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring>();

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(providerSpecDeliveryMonitoringMapper: propertyMapper);

            TestMapperCollectionProperty(mapper, m => m.ProviderSpecDeliveryMonitoring, inputCollection, m => m.ProviderSpecDeliveryMonitoring, outputCollection);
        }

        [Fact]
        public void Map_PwayCode()
        {
            TestMapperProperty(NewMapper(), m => m.PwayCode, TestIntSizedLong, m => m.PwayCode, TestInt);
        }

        [Fact]
        public void Map_PwayCodeSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.PwayCodeSpecified, TestBool, m => m.PwayCodeSpecified, TestBool);
        }

        [Fact]
        public void Map_SWSupAimId()
        {
            TestMapperProperty(NewMapper(), m => m.SWSupAimId, TestString, m => m.SWSupAimId, TestString);
            TestMapperProperty(NewMapper(), m => m.SWSupAimId, TestStringLeadingAndTrailingWhiteSpace, m => m.SWSupAimId, TestString);
        }

        [Fact]
        public void Map_StdCode()
        {
            TestMapperProperty(NewMapper(), m => m.StdCode, TestIntSizedLong, m => m.StdCode, TestInt);
        }

        [Fact]
        public void Map_StdCodeSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.StdCodeSpecified, TestBool, m => m.StdCodeSpecified, TestBool);
        }

        [Fact]
        public void Map_WithdrawReason()
        {
            TestMapperProperty(NewMapper(), m => m.WithdrawReason, TestIntSizedLong, m => m.WithdrawReason, TestInt);
        }

        [Fact]
        public void Map_WithdrawReasonSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.WithdrawReasonSpecified, TestBool, m => m.WithdrawReasonSpecified, TestBool);
        }

        private LearningDeliveryMapper NewMapper(
            IModelMapper<Loose.MessageLearnerLearningDeliveryAppFinRecord, MessageLearnerLearningDeliveryAppFinRecord> appFinRecordMapper = null,
            IModelMapper<Loose.MessageLearnerLearningDeliveryLearningDeliveryFAM, MessageLearnerLearningDeliveryLearningDeliveryFAM> learningDeliveryFamMapper = null,
            IModelMapper<Loose.MessageLearnerLearningDeliveryLearningDeliveryHE, MessageLearnerLearningDeliveryLearningDeliveryHE> learningDeliveryHeMapper = null,
            IModelMapper<Loose.MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement, MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement> learningDeliveryWorkPlacementMapper = null,
            IModelMapper<Loose.MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring, MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring> providerSpecDeliveryMonitoringMapper = null)
        {
            return new LearningDeliveryMapper(
                appFinRecordMapper ?? Mock.Of<IModelMapper<Loose.MessageLearnerLearningDeliveryAppFinRecord, MessageLearnerLearningDeliveryAppFinRecord>>(),
                learningDeliveryFamMapper ?? Mock.Of<IModelMapper<Loose.MessageLearnerLearningDeliveryLearningDeliveryFAM, MessageLearnerLearningDeliveryLearningDeliveryFAM>>(),
                learningDeliveryHeMapper ?? Mock.Of<IModelMapper<Loose.MessageLearnerLearningDeliveryLearningDeliveryHE, MessageLearnerLearningDeliveryLearningDeliveryHE>>(),
                learningDeliveryWorkPlacementMapper ?? Mock.Of<IModelMapper<Loose.MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement, MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement>>(),
                providerSpecDeliveryMonitoringMapper ?? Mock.Of<IModelMapper<Loose.MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring, MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring>>());
        }
    }
}
