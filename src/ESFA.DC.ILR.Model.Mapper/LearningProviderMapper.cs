using ESFA.DC.ILR.Model.Mapper.Abstract;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class LearningProviderMapper : AbstractModelMapper<Loose.MessageLearningProvider, MessageLearningProvider>
    {
        protected override MessageLearningProvider MapModel(Loose.MessageLearningProvider model)
        {
            return new MessageLearningProvider()
            {
                UKPRN = model.UKPRN
            };
        }
    }
}
