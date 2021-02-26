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
    [Route("api/Event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _repo;

        public EventController(IEventRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetEvents")]
        public async Task<IActionResult> Get()
        {
            var events = await _repo.Get();
            return Ok(events);
        }

        [HttpGet, Route("GetEvent/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var events = await _repo.Get(id);
            if (events == null)
            {
                return Content("Can not find the event");
            }
            return Ok(events);
        }

        [HttpPost]
        [Route("InsertEvent")]
        public async Task<IActionResult> Post(Event model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut, Route("UpdateEvent/{id}")]
        public async Task<IActionResult> Put(int id, Event model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete, Route("DeleteEvent/{id}")]
        public async Task<IActionResult> Delete(int id, Event model)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return Ok(model);
            }
            return Content("The Event you want to delete is not exist.");
        }
    }
}
