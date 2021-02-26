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
    [Route("api/Notice")]
    [ApiController]
    public class NoticeController : ControllerBase
    {
        private readonly INoticeRepository _repo;

        public NoticeController(INoticeRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetNotices")]
        public async Task<IActionResult> Get()
        {
            var notice = await _repo.Get();
            return Ok(notice);
        }

        [HttpGet, Route("GetNotice/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var notice = await _repo.Get(id);
            if (notice == null)
            {
                return Content("Can not find the notice");
            }
            return Ok(notice);
        }

        [HttpPost, Route("InsertNotice")]
        public async Task<IActionResult> Post(Notice model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut, Route("UpdateNotice/{id}")]
        public async Task<IActionResult> Put(int id, Notice model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete, Route("DeleteNotice/{id}")]
        public async Task<IActionResult> Delete(int id, Notice model)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return Ok(model);
            }
            return Content("The Notice you want to delete is not exist.");
        }
    }
}
