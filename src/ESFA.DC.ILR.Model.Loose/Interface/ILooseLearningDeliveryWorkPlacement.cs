using System;
using System.Collections.Generic;
using System.Text;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseLearningDeliveryWorkPlacement
    {
        DateTime? WorkPlaceStartDateNullable { get; }

        long? WorkPlaceHoursNullable { get; }

        long? WorkPlaceModeNullable { get; }
    }
}
