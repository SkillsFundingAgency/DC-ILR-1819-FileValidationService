using System;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageSourceFile : ILooseSourceFile
    {
        public DateTime? DateTimeNullable => dateTimeFieldSpecified ? dateTimeField : default(DateTime?);
    }
}
