using System;
using System.Collections.Generic;
using System.Text;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseHeader
    {
        ILooseCollectionDetails CollectionDetailsEntity { get; }

        ILooseSource SourceEntity { get; }
    }
}
