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
    [Route("api/Designation")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationRepository _repo;

        public DesignationController(IDesignationRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetDesignations")]
        public async Task<IActionResult> Get()
        {
            var designations = await _repo.Get();
            return Ok(designations);
        }

        [HttpGet, Route("GetDesignation/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var designation = await _repo.Get(id);
            if (designation == null)
            {
                return Content("Can not find the designation");
            }
            return Ok(designation);
        }

        [HttpPost]
        [Route("InsertDesignations")]

        public async Task<IActionResult> Post(Designation model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut, Route("UpdateDesignations/{id}")]
        public async Task<IActionResult> Put(int id, Designation model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete, Route("DeleteDesignations/{id}")]
        public async Task<IActionResult> Delete(int id, Designation model)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return Ok(model);
            }
            return Content("The Designation you want to delete is not exist.");
        }
    }
}
