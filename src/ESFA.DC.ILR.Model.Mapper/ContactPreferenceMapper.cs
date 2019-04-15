using ESFA.DC.ILR.Model.Mapper.Abstract;
using ESFA.DC.ILR.Model.Mapper.Extension;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class ContactPreferenceMapper : AbstractModelMapper<Loose.MessageLearnerContactPreference, MessageLearnerContactPreference>
    {
        protected override MessageLearnerContactPreference MapModel(Loose.MessageLearnerContactPreference model)
        {
            return new MessageLearnerContactPreference()
            {
                ContPrefType = model.ContPrefType.Sanitize(),
                ContPrefCode = (int)model.ContPrefCode,
            };
        }
    }
}
