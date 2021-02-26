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
    [Route("api/Attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _repo;

        public AttendanceController(IAttendanceRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetAttendances")]
        public async Task<IActionResult> Get()
        {
            var attendances = await _repo.Get();
            return Ok(attendances);
        }

        [HttpGet]
        [Route("GetAttendance/{id}")]

        public async Task<IActionResult> Get(int id)
        {
            var attendances = await _repo.Get(id);
            if (attendances == null)
            {
                return Content("Can not find the attendances");
            }
            return Ok(attendances);
        }

        [HttpPost]
        [Route("InsertAttendance")]
        public async Task<IActionResult> Post(Attendance model)
        {
            await _repo.Post(model);
            return Ok(model);
        }

        [HttpPut, Route("UpdateAttendance/{id}")]
        public async Task<IActionResult> Put(int id, Attendance model)
        {
            await _repo.Put(id, model);
            return Ok(model);
        }

        [HttpDelete, Route("DeleteAttendance/{id}")]
        public async Task<IActionResult> Delete(int id, Attendance model)
        {
            var data = await _repo.Delete(id);
            if (data != null)
            {
                return Ok(model);
            }
            return Content("The Attendance you want to delete is not exist.");
        }
    }
}