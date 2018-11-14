using ESFA.DC.ILR.Model.Loose.Extension;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageHeaderCollectionDetails : ILooseCollectionDetails
    {
        public string CollectionString => collectionField.XmlEnumToString();

        public string YearString => yearField.XmlEnumToString();
    }
}
