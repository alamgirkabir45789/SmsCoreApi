using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmsCoreApi.DAL.Interfaces;
using SmsCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsCoreApi.Controllers
{
    [Route("api/ImageGallery")]
    [ApiController]
    public class ImageGalleryController : ControllerBase
    {
        private readonly IImageGalleryRepository _repo;

        public ImageGalleryController(IImageGalleryRepository repository)
        {
            _repo = repository;
        }
        [HttpGet]
        [Route("GetImage")]
        public async Task<IActionResult> Get()
        {
            var imageGallery = await _repo.Get();
            return Ok(imageGallery);
        }

        [HttpGet, Route("GetImage/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var imageGallery = await _repo.Get(id);
            if (imageGallery == null)
            {
                return Content("Can not find the Image");
            }
            return Ok(imageGallery);
        }

        [HttpPost]
        [Route("InsertImage")]
        public async Task<IActionResult> Post(ImageGallery model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut, Route("UpdateImage/{id}")]
        public async Task<IActionResult> Put(int id, ImageGallery model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete, Route("DeleteImage/{id}")]
        public async Task<IActionResult> Delete(int id, ImageGallery model)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return Ok(model);
            }
            return Content("The Image you want to delete is not exist.");
        }
    }
}
