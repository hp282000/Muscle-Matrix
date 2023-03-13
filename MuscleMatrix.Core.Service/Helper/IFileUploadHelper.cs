using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Service.Helper
{
    public interface IFileUploadHelper
    {
        Task<string> UploadImage(IFormFile formFile);
    }
}
