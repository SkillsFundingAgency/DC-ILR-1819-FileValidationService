using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.FileService.Interface
{
    public interface IFileService
    {
        Task<string> ReadStringAsync(string fileReference, string container, Encoding encoding = null);

        Task<Stream> OpenStreamAsync();

        Task WriteStringAsync(string content, string fileReference, string container, Encoding encoding = null);

        Task WriteToStreamAsync();
    }
}
