// using CloudinaryDotNet;
// using CloudinaryDotNet.Actions;
// using HKCR.Application.Common.Interface;
// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.Configuration;
//
// namespace HKCR.Infra.Services;
//
// public abstract class CloudinaryService
// {
//     private readonly Cloudinary _cloudinary;
//
//     protected CloudinaryService(Cloudinary cloudinary)
//     {
//         _cloudinary = cloudinary;
//     }
//
//     // protected CloudinaryService(IConfiguration configuration)
//     // {
//     //     var account = new Account(
//     //         configuration["Cloudinary:CloudName"],
//     //         configuration["Cloudinary:ApiKey"],
//     //         configuration["Cloudinary:ApiSecret"]);
//     //
//     //     _cloudinary = new Cloudinary(account);
//     // }
//
//     public async Task<string> UploadAsync(IFormFile file)
//     {
//         var uploadParams = new ImageUploadParams
//         {
//             File = new FileDescription(file.FileName, file.OpenReadStream()),
//             Folder = "HKCR/Cars",
//             // Transformation = new Transformation().Crop("limit").Width(100).Height(100).AspectRatio(1.33)
//         };
//
//         var result = await _cloudinary.UploadAsync(uploadParams);
//
//         return result.SecureUrl.AbsoluteUri;
//     }
//     
// }