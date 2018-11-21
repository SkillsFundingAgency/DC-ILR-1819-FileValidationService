using System;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseCollectionDetails
    {
        string CollectionString { get; }

        string YearString { get; }

        DateTime FilePreparationDate { get; }
    }
}
