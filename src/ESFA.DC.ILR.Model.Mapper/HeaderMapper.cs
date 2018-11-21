using ESFA.DC.ILR.Model.Mapper.Abstract;
using ESFA.DC.ILR.Model.Mapper.Interface;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class HeaderMapper : AbstractModelMapper<Loose.MessageHeader, MessageHeader>
    {
        private readonly IModelMapper<Loose.MessageHeaderCollectionDetails, MessageHeaderCollectionDetails> _collectionDetailsMapper;
        private readonly IModelMapper<Loose.MessageHeaderSource, MessageHeaderSource> _sourceMapper;

        public HeaderMapper(
            IModelMapper<Loose.MessageHeaderCollectionDetails, MessageHeaderCollectionDetails> collectionDetailsMapper,
            IModelMapper<Loose.MessageHeaderSource, MessageHeaderSource> sourceMapper)
        {
            _collectionDetailsMapper = collectionDetailsMapper;
            _sourceMapper = sourceMapper;
        }

        protected override MessageHeader MapModel(Loose.MessageHeader model)
        {
            return new MessageHeader()
            {
                CollectionDetails = _collectionDetailsMapper.Map(model.CollectionDetails),
                Source = _sourceMapper.Map(model.Source),
            };
        }
    }
}
