using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.Core.Services
{
    public class FileService : IFileService
    {
        
        public async Task SaveImage(IFormFile image, Guid imgName, string folder, string rootPath, string extention)
        {
            Directory.CreateDirectory($"{rootPath}/images/{folder}/");

            var physicalPath = $"{rootPath}/images/{folder}/{imgName}{extention}";

            await using Stream fileStrem = new FileStream(physicalPath, FileMode.Create);
            await image.CopyToAsync(fileStrem);
        }



     //  public string ValidateFile(IFormFile file, string expectedFileType)
     //  {
     //      string extention;
     //
     //      if (file == null)
     //      {
     //          return null;
     //      }
     //
     //      extention = Path.GetExtension(file.FileName).TrimStart('.');
     //
     //      if (expectedFileType == GlobalConstants.Gpx)
     //      {
     //          return this.gpxExtensions
     //              .FirstOrDefault(e => e == extention.ToLower());
     //      }
     //      else if (expectedFileType == GlobalConstants.Image)
     //      {
     //          if (file.Length > 10 * 1024 * 1024)
     //          {
     //              return null;
     //          }
     //
     //          return this.imageExtensions
     //              .FirstOrDefault(e => e == extention.ToLower());
     //      }
     //
     //      return null;
     //  }

    }
}
