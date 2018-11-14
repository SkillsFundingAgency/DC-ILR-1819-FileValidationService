using System;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseLearningDeliveryWorkPlacement
    {
        DateTime? WorkPlaceStartDateNullable { get; }

        DateTime? WorkPlaceEndDateNullable { get; }

        long? WorkPlaceHoursNullable { get; }

        long? WorkPlaceModeNullable { get; }

        long? WorkPlaceEmpIdNullable { get; }
    }
}
