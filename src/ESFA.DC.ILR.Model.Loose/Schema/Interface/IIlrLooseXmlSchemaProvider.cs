using System.Xml.Schema;

namespace ESFA.DC.ILR.Model.Loose.Schema.Interface
{
    public interface IIlrLooseXmlSchemaProvider
    {
        XmlSchema Provide();
    }
}
