using ESFA.DC.ILR.Model.Mapper.Interface;
using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class LearnerEmploymentStatusMapperTests : AbstractMapperTests<Loose.MessageLearnerLearnerEmploymentStatus, MessageLearnerLearnerEmploymentStatus>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_AgreeId()
        {
            TestMapperProperty(NewMapper(), m => m.AgreeId, TestString, m => m.AgreeId, TestString);
            TestMapperProperty(NewMapper(), m => m.AgreeId, TestStringLeadingAndTrailingWhiteSpace, m => m.AgreeId, TestString);
        }

        [Fact]
        public void Map_DateEmpStatApp()
        {
            TestMapperProperty(NewMapper(), m => m.DateEmpStatApp, TestDateTime, m => m.DateEmpStatApp, TestDateTime);
        }

        [Fact]
        public void Map_EmpId()
        {
            TestMapperProperty(NewMapper(), m => m.EmpId, TestIntSizedLong, m => m.EmpId, TestInt);
        }

        [Fact]
        public void Map_EmpIdSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.EmpIdSpecified, TestBool, m => m.EmpIdSpecified, TestBool);
        }
        
        [Fact]
        public void Map_EmploymentStatusMonitoring()
        {
            var inputCollection = NewArrayContaining<Loose.MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring>();
            var outputCollection = NewArrayContaining<MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring>();

            var propertyMapper = NewMockedModelCollectionMapper(inputCollection, outputCollection);

            var mapper = NewMapper(propertyMapper);

            TestMapperCollectionProperty(mapper, m => m.EmploymentStatusMonitoring, inputCollection, m => m.EmploymentStatusMonitoring, outputCollection);
        }

        [Fact]
        public void Map_EmpStat()
        {
            TestMapperProperty(NewMapper(), m => m.EmpStat, TestIntSizedLong, m => m.EmpStat, TestInt);
        }
        
        private LearnerEmploymentStatusMapper NewMapper(IModelMapper<Loose.MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring, MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring> employmentStatusMonitoringMapper = null)
        {
            return new LearnerEmploymentStatusMapper(employmentStatusMonitoringMapper ?? Mock.Of<IModelMapper<Loose.MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring, MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring>>());
        }
    }
}
