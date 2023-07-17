using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IFileService
    {
         Task SaveImage(IFormFile image, Guid imgName, string folder,string rootPath, string extention);
    }
}
