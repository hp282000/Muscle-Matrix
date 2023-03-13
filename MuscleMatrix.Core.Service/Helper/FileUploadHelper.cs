using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Service.Helper
{
    public class FileUploadHelper : IFileUploadHelper
    {

        public async Task<string> UploadImage(IFormFile photo)
        {

            var cloudinary = new Cloudinary("cloudinary://256532249671949:zYaObf6qQeiSh-WlCEJbWU4QTdo@dcky8arhy");

            cloudinary.Api.Secure = true;
            var filename = photo.FileName.Substring(0, photo.FileName.LastIndexOf("."));
            //var ext = Path.GetExtension(filename);
            var ext = photo.FileName.Substring(photo.FileName.LastIndexOf(".") , photo.FileName.Length - photo.FileName.LastIndexOf("."));

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(filename, photo.OpenReadStream()),
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = true,
                Folder ="/P-360"
                
            };
            var upload = cloudinary.Upload(uploadParams);
            var file = upload.SecureUrl.ToString();

            return file;


        }
    }
}
