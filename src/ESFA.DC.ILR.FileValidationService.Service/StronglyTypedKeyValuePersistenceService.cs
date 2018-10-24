using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class StronglyTypedKeyValuePersistenceService : IStronglyTypedKeyValuePersistenceService
    {
        private readonly ISerializationService _serializationService;
        private readonly IKeyValuePersistenceService _keyValuePersistenceService;

        public StronglyTypedKeyValuePersistenceService(ISerializationService serializationService, IKeyValuePersistenceService keyValuePersistenceService)
        {
            _serializationService = serializationService;
            _keyValuePersistenceService = keyValuePersistenceService;
        }

        public Task SaveAsync<T>(string key, T value, CancellationToken cancellationToken)
        {
            return _keyValuePersistenceService.SaveAsync(key, _serializationService.Serialize(value), cancellationToken);
        }

        public async Task<T> GetAsync<T>(string key, CancellationToken cancellationToken)
        {
            return _serializationService.Deserialize<T>(await _keyValuePersistenceService.GetAsync(key, cancellationToken));
        }
    }
}
