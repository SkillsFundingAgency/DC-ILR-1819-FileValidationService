using System.Linq;
using ESFA.DC.ILR.Model.Loose.Interface;
using ESFA.DC.ILR.Model.Mapper.Abstract;
using ESFA.DC.ILR.Model.Mapper.Interface;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class MessageMapper : AbstractModelMapper<Loose.Message, Message>
    {
        private readonly IModelMapper<Loose.MessageHeader, MessageHeader> _headerMapper;
        private readonly IModelMapper<Loose.MessageLearningProvider, MessageLearningProvider> _learningProviderMapper;
        private readonly IModelMapper<Loose.MessageSourceFile, MessageSourceFile> _sourceFileMapper;
        private readonly IModelMapper<Loose.MessageLearner, MessageLearner> _learnerMapper;
        private readonly IModelMapper<Loose.MessageLearnerDestinationandProgression, MessageLearnerDestinationandProgression> _destinationAndProgressionMapper;


        public MessageMapper(
            IModelMapper<Loose.MessageHeader, MessageHeader> headerMapper,
            IModelMapper<Loose.MessageLearningProvider, MessageLearningProvider> learningProviderMapper,
            IModelMapper<Loose.MessageSourceFile, MessageSourceFile> sourceFileMapper,
            IModelMapper<Loose.MessageLearner, MessageLearner> learnerMapper,
            IModelMapper<Loose.MessageLearnerDestinationandProgression, MessageLearnerDestinationandProgression> destinationAndProgressionMapper)
        {
            _headerMapper = headerMapper;
            _learningProviderMapper = learningProviderMapper;
            _sourceFileMapper = sourceFileMapper;
            _learnerMapper = learnerMapper;
            _destinationAndProgressionMapper = destinationAndProgressionMapper;
        }

        protected override Message MapModel(Loose.Message model)
        {
            return new Message()
            {
                Header = _headerMapper.Map(model.Header),
                LearningProvider = _learningProviderMapper.Map(model.LearningProvider),
                SourceFiles = model.SourceFiles?.Select(sf => _sourceFileMapper.Map(sf)).ToArray(),
                Learner = model.Learner?.Select(l => _learnerMapper.Map(l)).ToArray(),
                LearnerDestinationandProgression = model.LearnerDestinationandProgression?.Select(ldp => _destinationAndProgressionMapper.Map(ldp)).ToArray(),
            };
        }
    }
}
