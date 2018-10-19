using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseLearnerHE
    {
        string UCASPERID { get; }

        long? TTACCOMNullable { get; }

        IReadOnlyCollection<ILooseLearnerHEFinancialSupport> LearnerHEFinancialSupports { get; }
    }
}
