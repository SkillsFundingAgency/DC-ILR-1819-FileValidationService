using System;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement : ILooseLearningDeliveryWorkPlacement
    {
        public DateTime? WorkPlaceStartDateNullable => workPlaceStartDateFieldSpecified ? workPlaceStartDateField : default(DateTime?);

        public long? WorkPlaceHoursNullable => workPlaceHoursFieldSpecified ? workPlaceHoursField : default(long?);

        public long? WorkPlaceModeNullable => workPlaceModeFieldSpecified ? workPlaceModeField : default(long?);

        public long? WorkPlaceEmpIdNullable => workPlaceEmpIdFieldSpecified ? workPlaceEmpIdField : default(long?);

        public DateTime? WorkPlaceEndDateNullable => workPlaceEndDateFieldSpecified ? workPlaceEndDateField : default(DateTime?);
    }
}