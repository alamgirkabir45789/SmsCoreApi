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
    [Route("api/Group")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _repo;

        public GroupController(IGroupRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetGroups")]
        public async Task<IActionResult> Get()
        {
            var group = await _repo.Get();
            return Ok(group); 
        }

        [HttpGet,Route("GetGroup/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var group = await _repo.Get(id);
            if (group == null)
            {
                return Content("Can not find the Group");
            }
            return Ok(group);
        }

        [HttpPost,Route("InsertGroup")]

        public async Task<IActionResult> Post(Group model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut, Route("UpdateGroup/{id}")]
        public async Task<IActionResult> Put(int id, Group model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete, Route("DeleteGroup/{id}")]
        public async Task<IActionResult> Delete(int id,Group model)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return Ok(model);
            }
            return Content("The Group you want to delete is not exist.");
        }
    }
}
