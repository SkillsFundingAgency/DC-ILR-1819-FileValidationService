using AutoMapper;
using ESFA.DC.Mapping.Interface;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class LooseToTightSchemaMapper : IMapper<Model.Loose.Message, Model.Message>
    {
        public static void ConfigureMapper()
        {
            Mapper.Initialize(c => c.CreateMap<Model.Loose.Message, Model.Message>());
            Mapper.Configuration.CompileMappings();
        }

        public Model.Message MapTo(Model.Loose.Message looseMessage)
        {
            return Mapper.Map<Model.Loose.Message, Model.Message>(looseMessage);
        }
        
        public Model.Loose.Message MapFrom(Model.Message value)
        {
            throw new System.NotImplementedException();
        }
    }
}
