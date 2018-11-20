using ESFA.DC.ILR.Model.Mapper.Abstract;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class CollectionDetailsMapper : AbstractModelMapper<Loose.MessageHeaderCollectionDetails, MessageHeaderCollectionDetails>
    {
        protected override MessageHeaderCollectionDetails MapModel(Loose.MessageHeaderCollectionDetails model)
        {
            return new MessageHeaderCollectionDetails()
            {
                Collection = (MessageHeaderCollectionDetailsCollection)model.Collection,
                FilePreparationDate = model.FilePreparationDate,
                Year = (MessageHeaderCollectionDetailsYear)model.Year,
            };
        }
    }
}
