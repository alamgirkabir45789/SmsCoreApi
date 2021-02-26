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
    [Route("api/Session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionRepository _repo;

        public SessionController(ISessionRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetSessions")]
        public async Task<IActionResult> Get()
        {
            var session = await _repo.Get();
            return Ok(session);
        }

        [HttpGet, Route("GetSession/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var session = await _repo.Get(id);
            if (session == null)
            {
                return Content("Can not find the country");
            }
            return Ok(session);
        }

        [HttpPost]
        [Route("InsertSession")]
        public async Task<IActionResult> Post(Session model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut, Route("UpdateSession/{id}")]
        public async Task<IActionResult> Put(int id, Session model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete, Route("DeleteSession/{id}")]
        public async Task<IActionResult> Delete(int id, Session model)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return Ok(model);
            }
            return Content("The Session you want to delete is not exist.");
        }
    }
}
