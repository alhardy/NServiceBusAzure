using System.IO;
using System.Threading.Tasks;

// ReSharper disable CheckNamespace
namespace Microsoft.AspNetCore.Http
    // ReSharper restore CheckNamespace
{
    public static class FormFileExtensions
    {
        public static async Task<byte[]> GetFileArray(this IFormFile file)
        {
            var filestream = new MemoryStream();
            await file.CopyToAsync(filestream);
            return filestream.ToArray();
        }
    }
}