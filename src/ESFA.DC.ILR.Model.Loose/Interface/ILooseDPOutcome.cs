using System;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseDPOutcome
    {
        string OutType { get; }

        long? OutCodeNullable { get; }

        DateTime? OutStartDateNullable { get; }

        DateTime? OutCollDateNullable { get; }
    }
}
