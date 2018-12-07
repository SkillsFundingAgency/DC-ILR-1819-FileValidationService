using ESFA.DC.ILR.Model.Mapper.Interface;
using ESFA.DC.Mapping.Interface;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class LooseToTightSchemaMapper : IMapper<Model.Loose.Message, Model.Message>
    {
        private readonly IModelMapper<Model.Loose.Message, Model.Message> _messageMapper;

        public LooseToTightSchemaMapper(IModelMapper<Model.Loose.Message, Model.Message> messageMapper)
        {
            _messageMapper = messageMapper;
        }

        public Model.Message MapTo(Model.Loose.Message looseMessage)
        {
            return _messageMapper.Map(looseMessage);
        }
        
        public Model.Loose.Message MapFrom(Model.Message value)
        {
            throw new System.NotImplementedException();
        }
    }
}
