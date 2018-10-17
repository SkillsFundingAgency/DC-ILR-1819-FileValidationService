using System;
using System.Collections.Generic;
using System.Text;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseLearnerHE
    {
        string UCASPERID { get; }

        long? TTACCOMNullable { get; }

        IReadOnlyCollection<ILooseLearnerHEFinancialSupport> LearnerHEFinancialSupports { get; }
    }
}
