using ESFA.DC.ILR.Model.Mapper.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class LearningDeliveryWorkPlacementMapperTests : AbstractMapperTests<Loose.MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement, MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement>
    {
        [Fact]
        public void Map_Null()
        {
            NewMapper().Map(null).Should().BeNull();
        }

        [Fact]
        public void Map_WorkPlaceEmpId()
        {
            TestMapperProperty(NewMapper(), m => m.WorkPlaceEmpId, TestIntSizedLong, m => m.WorkPlaceEmpId, TestInt);
        }

        [Fact]
        public void Map_WorkPlaceEmpIdSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.WorkPlaceEmpIdSpecified, TestBool, m => m.WorkPlaceEmpIdSpecified, TestBool);
        }

        [Fact]
        public void Map_WorkPlaceEndDate()
        {
            TestMapperProperty(NewMapper(), m => m.WorkPlaceEndDate, TestDateTime, m => m.WorkPlaceEndDate, TestDateTime);
        }

        [Fact]
        public void Map_WorkPlaceEndDateSpecified()
        {
            TestMapperProperty(NewMapper(), m => m.WorkPlaceEndDateSpecified, TestBool, m => m.WorkPlaceEndDateSpecified, TestBool);
        }

        [Fact]
        public void Map_WorkPlaceHours()
        {
            TestMapperProperty(NewMapper(), m => m.WorkPlaceHours, TestIntSizedLong, m => m.WorkPlaceHours, TestInt);
        }

        [Fact]
        public void Map_WorkPlaceMode()
        {
            TestMapperProperty(NewMapper(), m => m.WorkPlaceMode, TestIntSizedLong, m => m.WorkPlaceMode, TestInt);
        }

        [Fact]
        public void Map_WorkPlaceStartDate()
        {
            TestMapperProperty(NewMapper(), m => m.WorkPlaceStartDate, TestDateTime, m => m.WorkPlaceStartDate, TestDateTime);
        }
        
        private LearningDeliveryWorkPlacementMapper NewMapper()
        {
            return new LearningDeliveryWorkPlacementMapper();
        }
    }
}
