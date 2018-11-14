using System;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseSource
    {
        string ProtectiveMarkingString { get; }

        int UKPRN { get; }

        string SoftwareSupplier { get; }

        string SoftwarePackage { get; }

        string Release { get; }

        string SerialNo { get; }

        DateTime DateTime { get; }

        string ReferenceData { get; }

        string ComponentSetVersion { get; }
    }
}
