// using HKCR.Infra.Services;
// using Microsoft.AspNetCore.Mvc;
//
// namespace HKCR.API.Controllers;
//
// [ApiController]
// [Route("api/v1/cars/uploadImage")]
// public class UploadController : ControllerBase
// {
//     private readonly CloudinaryService _cloudinaryService;
//
//     public UploadController(CloudinaryService cloudinaryService)
//     {
//         this._cloudinaryService = cloudinaryService;
//     }
//
//     [HttpPost]
//     public async Task<IActionResult> Post([FromForm] IFormFile? file)
//     {
//         if (file == null || file.Length == 0)
//         {
//             return BadRequest("No file selected");
//         }
//
//         var url = await _cloudinaryService.UploadAsync(file);
//
//         return Ok(url);
//     }
// }