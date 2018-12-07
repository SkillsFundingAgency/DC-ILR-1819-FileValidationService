using ESFA.DC.ILR.Model.Mapper.Abstract;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class ContactPreferenceMapper : AbstractModelMapper<Loose.MessageLearnerContactPreference, MessageLearnerContactPreference>
    {
        protected override MessageLearnerContactPreference MapModel(Loose.MessageLearnerContactPreference model)
        {
            return new MessageLearnerContactPreference()
            {
                ContPrefType = model.ContPrefType,
                ContPrefCode = (int)model.ContPrefCode,
            };
        }
    }
}
