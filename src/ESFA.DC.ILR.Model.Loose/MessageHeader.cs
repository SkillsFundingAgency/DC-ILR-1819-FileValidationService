using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageHeader : ILooseHeader
    {
        public ILooseCollectionDetails CollectionDetailsEntity => collectionDetailsField;

        public ILooseSource SourceEntity => sourceField;
    }
}
