using System;
using AutoMapper;
using ESFA.DC.ILR.FileValidationService.Service.Interface;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class LooseToTightSchemaMapper : ILooseToTightSchemaMapper
    {
        public Model.Message Map(Model.Loose.Message looseMessage)
        {
            Mapper.Initialize(c => c.CreateMap<Model.Loose.Message, Model.Message>());

            var output = Mapper.Map<Model.Loose.Message, Model.Message>(looseMessage);

            return output;
        }
    }
}
