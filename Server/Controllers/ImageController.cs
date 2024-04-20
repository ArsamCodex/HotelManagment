﻿using HotelManagment.Server.Data;
using HotelManagment.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HotelManagment.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ImageController : Controller
    {

        public readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostEnvironment;
        private string _SystemFiles;
        public ImageController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            hostEnvironment = environment;
            _SystemFiles =
            System.IO.Path.Combine(
                    hostEnvironment.ContentRootPath,
                    "Images");
            // Create SystemFiles directory if needed
            if (!Directory.Exists(_SystemFiles))
            {
                DirectoryInfo di =
                    Directory.CreateDirectory(_SystemFiles);
            }
        }
        [HttpPost]
        public void UploadAPI([FromForm] UploadForm form)
        {
            // Get File Directory
            string FileDirectory = form.FileDirectory;
            // Set _SystemFiles
            _SystemFiles = System.IO.Path.Combine(_SystemFiles, FileDirectory);
            // Create SystemFiles directory if needed
            if (!Directory.Exists(_SystemFiles))
            {
                DirectoryInfo di =
                    Directory.CreateDirectory(_SystemFiles);
            }
            // Process File Attachment
            if (form.FileAttachment != null)
            {
                using (var readStream = form.FileAttachment.OpenReadStream())
                {
                    var filename = form.FileAttachment.FileName.Replace("\"", "").ToString();
                    filename = _SystemFiles + $@"\{filename}";
                    //Save file to harddrive
                    using (FileStream fs = System.IO.File.Create(filename))
                    {
                        form.FileAttachment.CopyTo(fs);
                        fs.Flush();
                    }
                }
            }
            // Process all File Attachments
          /*  if (form.FileAttachments != null)
            {
                foreach (var file in form.FileAttachments)
                {
                    // Process file
                    using (var readStream = file.OpenReadStream())
                    {
                        var filename = file.FileName.Replace("\"", "").ToString();
                        filename = _SystemFiles + $@"\{filename}";
                        //Save file to harddrive
                        using (FileStream fs = System.IO.File.Create(filename))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }
            }*/
        }

        [HttpPost("UpImage")]
        public void Post(UploadedFile uploadedFile)
        {
            var path = $"{hostEnvironment.WebRootPath}\\{uploadedFile.FileName}";
            var fs = System.IO.File.Create(path);
            fs.Write(uploadedFile.FileContent, 0,
              uploadedFile.FileContent.Length);
            fs.Close();
        }

        public class UploadForm
        {
            public string FileDirectory { get; set; }
            public IFormFile FileAttachment { get; set; }
         //   public List<IFormFile>? FileAttachments { get; set; }
        }
    }
}
