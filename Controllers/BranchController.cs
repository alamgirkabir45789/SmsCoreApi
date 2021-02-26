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
    [Route("api/Branch")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepository _repo;

        public BranchController(IBranchRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetBranches")]
        public async Task<IActionResult> Get()
        {
            var branches = await _repo.Get();
            return Ok(branches);

        }

        [HttpGet, Route("GetBranch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var branches = await _repo.Get(id);
            if (branches == null)
            {
                return Content("Can not find the branch");
            }
            return Ok(branches);
        }

        [HttpPost]
        [Route("InsertBranch")]
        public async Task<IActionResult> Post(Branch model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut, Route("UpdateBranch/{id}")]
        public async Task<IActionResult> Put(int id, Branch model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete, Route("DeleteBranch/{id}")]
        public async Task<IActionResult> Delete(int id, Branch model)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return Ok(model);
            }
            return Content("The Branch you want to delete is not exit.");
        }
    }
}
