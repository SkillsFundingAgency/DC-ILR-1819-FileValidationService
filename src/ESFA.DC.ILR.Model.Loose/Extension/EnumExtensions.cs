using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace ESFA.DC.ILR.Model.Loose.Extension
{
    public static class EnumExtensions
    {
        public static string XmlEnumToString<TEnum>(this TEnum value) where TEnum : struct, IConvertible
        {
            Type enumType = typeof(TEnum);

            if (!enumType.IsEnum)
            {
                return null;
            }

            MemberInfo member = enumType.GetMember(value.ToString()).FirstOrDefault();

            if (member == null)
            {
                return null;
            }

            XmlEnumAttribute attribute = member.GetCustomAttributes(false).OfType<XmlEnumAttribute>().FirstOrDefault();

            if (attribute == null)
            {
                return member.Name;
            }

            return attribute.Name;
        }
    }
}