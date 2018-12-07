using ESFA.DC.ILR.Model.Mapper.Abstract;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class LearningDeliveryWorkPlacementMapper : AbstractModelMapper<Loose.MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement, MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement>
    {
        protected override MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement MapModel(Loose.MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement model)
        {
            return new MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement()
            {
                WorkPlaceEmpId = (int)model.WorkPlaceEmpId,
                WorkPlaceEmpIdSpecified = model.WorkPlaceEmpIdSpecified,
                WorkPlaceEndDate = model.WorkPlaceEndDate,
                WorkPlaceEndDateSpecified = model.WorkPlaceEndDateSpecified,
                WorkPlaceHours = (int)model.WorkPlaceHours,
                WorkPlaceMode = (int)model.WorkPlaceMode,
                WorkPlaceStartDate = model.WorkPlaceStartDate,
            };
        }
    }
}
