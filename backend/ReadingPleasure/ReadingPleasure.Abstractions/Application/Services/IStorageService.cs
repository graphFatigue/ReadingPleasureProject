using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingPleasure.Abstractions.Application.Services
{
    public interface IStorageService
    {
        Task<string> UploadAsync(Stream file, string containerName, string fileName);
        Task<string> GetSasTokenAsync(string containerName, string fileName);
        Task DeleteAsync(string blobFilename);
    }
}
