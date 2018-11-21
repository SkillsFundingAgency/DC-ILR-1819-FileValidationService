using System;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseSourceFile
    {
        string SourceFileName { get; }

        DateTime FilePreparationDate { get; }

        string SoftwareSupplier { get; }

        string SoftwarePackage { get; }

        string Release { get; }

        string SerialNo { get; }

        DateTime? DateTimeNullable { get; }
    }
}
