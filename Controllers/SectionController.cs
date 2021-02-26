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
    [Route("api/Section")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionRepository _repo;

        public SectionController(ISectionRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetSections")]
        public async Task<IActionResult> Get()
        {
            var sections = await _repo.Get();
            return Ok(sections);
        }

        [HttpGet]
        [Route("GetSection/{id}")]

        public async Task<IActionResult> Get(int id)
        {
            var sections = await _repo.Get(id);
            if (sections == null)
            {
                return Content("Can not find the sections");
            }
            return Ok(sections);
        }

        [HttpPost]
        [Route("InsertSection")]
        public async Task<IActionResult> Post(Section model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut, Route("UpdateSection/{id}")]
        public async Task<IActionResult> Put(int id, Section model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete, Route("DeleteSection/{id}")]
        public async Task<IActionResult> Delete(int id, Section model)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return Ok(model);
            }
            return Content("The Section you want to delete is not exist.");
        }
    }
}

