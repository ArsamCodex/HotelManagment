using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Shared
{
    public class UploadForm
    {
        public string FileDirectory { get; set; }
        public IFormFile FileAttachment { get; set; }
        //   public List<IFormFile>? FileAttachments { get; set; }
    }
}
