using ESFA.DC.ILR.Model.Loose.Extension;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageHeaderSource : ILooseSource
    {
        public string ProtectiveMarkingString => protectiveMarkingField.XmlEnumToString();
    }
}
