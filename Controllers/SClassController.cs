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
    [Route("api/SClass")]
    [ApiController]
    public class SClassController : ControllerBase
    {
        private readonly ISClassRepository _repo;


        public SClassController(ISClassRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetSClasses")]
        public async Task<IActionResult> Get()
        {
            var sclass = await _repo.Get();
            return Ok(sclass);
        }

        [HttpGet, Route("GetSClass/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var sclass = await _repo.Get(id);
            if (sclass == null)
            {
                return Content("Can not find the SClass");
            }
            return Ok(sclass);
        }

        [HttpPost, Route("InsertSClass")]
        public async Task<IActionResult> Post(SClass model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut, Route("UpdateSClass/{id}")]
        public async Task<IActionResult> Put(int id, SClass model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete, Route("DeleteSClass/{id}")]
        public async Task<IActionResult> Delete(int id, SClass model)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return Ok(model);
            }
            return Content("The SClass you want to delete is not exist.");
        }
    }
}
