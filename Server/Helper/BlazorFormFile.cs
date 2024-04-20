using Microsoft.AspNetCore.Components.Forms;

namespace HotelManagment.Server.Helper
{
    public class BlazorFormFile : IFormFile
    {
        private readonly IBrowserFile _browserFile;

        public BlazorFormFile(IBrowserFile browserFile)
        {
            _browserFile = browserFile;
        }

        public string ContentType => _browserFile.ContentType;

        public string ContentDisposition => $"form-data; name=\"{Name}\"; filename=\"{FileName}\"";

        public IHeaderDictionary Headers => new HeaderDictionary();

        public long Length => _browserFile.Size;

        public string Name => _browserFile.Name;

        public string FileName => _browserFile.Name;

        public Stream OpenReadStream() => _browserFile.OpenReadStream();

        public void CopyTo(Stream target)
        {
            _browserFile.OpenReadStream().CopyTo(target);
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            return _browserFile.OpenReadStream().CopyToAsync(target, cancellationToken);
        }

        public Task<byte[]> GetAllBytesAsync(CancellationToken cancellationToken = default)
        {
            using (var memoryStream = new MemoryStream())
            {
                _browserFile.OpenReadStream().CopyTo(memoryStream);
                return Task.FromResult(memoryStream.ToArray());
            }
        }
    }
}
