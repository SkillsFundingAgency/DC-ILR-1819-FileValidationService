using System;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseAppFinRecord
    {
        string AFinType { get;  }
        
        long? AFinCodeNullable { get; }

        DateTime? AFinDateNullable { get; }

        long? AFinAmountNullable { get; }
    }
}
