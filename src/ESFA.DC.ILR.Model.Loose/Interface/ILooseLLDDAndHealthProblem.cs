using System;
using System.Collections.Generic;
using System.Text;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseLLDDAndHealthProblem
    {
        long? LLDDCatNullable { get; }

        long? PrimaryLLDDNullable { get; }
    }
}
