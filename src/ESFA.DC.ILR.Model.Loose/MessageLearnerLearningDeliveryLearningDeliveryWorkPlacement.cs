using System;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement : ILooseLearningDeliveryWorkPlacement
    {
        DateTime? ILooseLearningDeliveryWorkPlacement.WorkPlaceStartDateNullable => workPlaceStartDateFieldSpecified ? workPlaceStartDateField : default(DateTime?);

        long? ILooseLearningDeliveryWorkPlacement.WorkPlaceHoursNullable => workPlaceHoursFieldSpecified ? workPlaceHoursField : default(long?);

        long? ILooseLearningDeliveryWorkPlacement.WorkPlaceModeNullable => workPlaceModeFieldSpecified ? workPlaceModeField : default(long?);
    }
}
