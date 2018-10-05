using AutoMapper;
using ESFA.DC.Mapping.Interface;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class LooseToTightSchemaMapper : IMapper<Model.Loose.Message, Model.Message>
    {
        public Model.Message MapTo(Model.Loose.Message looseMessage)
        {
            Mapper.Initialize(c => c.CreateMap<Model.Loose.Message, Model.Message>());

            var output = Mapper.Map<Model.Loose.Message, Model.Message>(looseMessage);

            return output;
        }
        
        public Model.Loose.Message MapFrom(Model.Message value)
        {
            throw new System.NotImplementedException();
        }
    }
}
